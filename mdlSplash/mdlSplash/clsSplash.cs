using System;

namespace mdlSplash
{
	/// <summary>
	/// Summary description for clsSplash.
	/// </summary>
	public class clsSplash
	{
		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro;
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			private string m_strEnderecoExecutavel;

			private System.Threading.Thread m_thr_Registro = null;
			private mdlRegistro.clsRegistro m_cls_reg_Registro = null;

			private string m_strVersaoCliente = "";
			private string m_strVersaoServidor = "";

			private bool m_bHalibitado = false;
		#endregion
		#region Properties
			public bool Habilitado
			{
				get
				{
					return (m_bHalibitado);
				}
			}
		#endregion
		#region Constructors and Destructors 
			public clsSplash(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel)
			{
				m_cls_ter_TratadorErro = cls_ter_TratadorErro;
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
			}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				vCarregaVersao();
                vIniciaThreadRegistro();
				frmFSplash formFSplash = new frmFSplash(m_strEnderecoExecutavel);
				InitializeFrmFSplash(ref formFSplash);
				formFSplash.ShowDialog();
				formFSplash = null;
			}
			
			private void InitializeFrmFSplash(ref frmFSplash formFSplash)
			{
				formFSplash.eCallConfiguraPictureBox += new frmFSplash.delCallConfiguraPictureBox(ConfiguraImagemSplash);
				formFSplash.eCallShowRegistro += new frmFSplash.delCallShowRegistro(ShowDialogRegistro);
				formFSplash.eCallDesenvolvimento += new frmFSplash.delCallDesenvolvimento(bDesenvolvimento);

			}
		#endregion
		#region Thread 
			private void vIniciaThreadRegistro()
			{
				m_thr_Registro = new System.Threading.Thread(new System.Threading.ThreadStart(vInstanciadorRegistro));
				m_thr_Registro.Start();
			}

			private void vInstanciadorRegistro()
			{
				m_cls_reg_Registro = new mdlRegistro.clsRegistro(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
			}
		#endregion

		#region Imagem Splash
			private void ConfiguraImagemSplash(ref mdlComponentesGraficos.PictureBox picSiscobras)
			{
				System.Drawing.Image imgSplash = mdlControladoraImagens.clsControladoraImagens.retornaImagem(mdlControladoraImagens.LOCALIMAGEM.SPLASH);
				if (imgSplash != null)
				{
					vInsereVersaoImagem(ref imgSplash);
					picSiscobras.OriginalImage = imgSplash;
				}
				// Configurando os Efeitos 
				picSiscobras.Percentage = 0;
				picSiscobras.Effect = mdlComponentesGraficos.PictureBox.Effects.BlackAndWhite;
				picSiscobras.EffectDirection = mdlComponentesGraficos.PictureBox.Directions.Vertical;
				picSiscobras.WithEffects = true;
			}
		#endregion
		#region Versao
			private void vCarregaVersao()
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_ini_File = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "Sisco.ini");
				string strVersaoCliente = "";
				string strVersaoServidor = "";
				try
				{
					strVersaoCliente = cls_ini_File.retornaValor("Siscobras","VersaoCliente","");
					
				}
				catch
				{
				}
				bool bShowErrors = m_cls_dba_ConnectionDB.ShowDialogsErrors;
				m_cls_dba_ConnectionDB.ShowDialogsErrors = false;
				try
				{
					strVersaoServidor = m_cls_dba_ConnectionDB.GetConfiguracao("STRVERSION","");
				}
				catch
				{
				}
				m_cls_dba_ConnectionDB.ShowDialogsErrors = bShowErrors;
				m_strVersaoCliente = strVersaoCliente;
				m_strVersaoServidor = strVersaoServidor;
			}

			private void vInsereVersaoImagem(ref System.Drawing.Image imgSplash)
			{
				System.Drawing.Graphics gra = System.Drawing.Graphics.FromImage(imgSplash);
				if (m_strVersaoCliente != "")
				{
					gra.DrawString("VC: " + m_strVersaoCliente,new System.Drawing.Font("Arial",10,System.Drawing.FontStyle.Bold),new System.Drawing.SolidBrush(System.Drawing.Color.Gray),10,40);
					gra.DrawString("VC: " + m_strVersaoCliente,new System.Drawing.Font("Arial",10,System.Drawing.FontStyle.Bold),new System.Drawing.SolidBrush(System.Drawing.Color.Black),10 + 1,40 + 1);
				}
				if (m_strVersaoServidor != "") 
				{
					gra.DrawString("VS: " + m_strVersaoServidor,new System.Drawing.Font("Arial",10,System.Drawing.FontStyle.Bold),new System.Drawing.SolidBrush(System.Drawing.Color.Gray),10,55);
					gra.DrawString("VS: " + m_strVersaoServidor,new System.Drawing.Font("Arial",10,System.Drawing.FontStyle.Bold),new System.Drawing.SolidBrush(System.Drawing.Color.Black),10 + 1,55 + 1);
				}
			}
		#endregion
		#region Registro
			private void ShowDialogRegistro()
			{
				while (m_cls_reg_Registro == null)
				{
					System.Threading.Thread.Sleep(100);
				}
				m_bHalibitado = m_cls_reg_Registro.bRegistroOK();
			}
		#endregion

		#region Desenvolvimento
			private bool bDesenvolvimento()
			{
				bool bRetorno = false;
				System.Windows.Forms.Keys key = System.Windows.Forms.Keys.Control;
				if (bMaquinaDesenvolvimento())
					if (System.Windows.Forms.Form.ModifierKeys == key)
					{
						bRetorno = true;
						m_bHalibitado = true;
					}
				return(bRetorno);
			}

			private bool bMaquinaDesenvolvimento()
			{
				bool bRetorno = false;
				string strMaquina = System.Environment.MachineName.ToUpper();
				if ((strMaquina == "CRON") || (strMaquina == "ODIN") || (strMaquina == "THOR"))
				{
					bRetorno = true;
				}
				return(bRetorno);
			}
		#endregion

	}
}
