using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for frmFPaisIdiomas.
	/// </summary>
	internal class frmFPaisIdioma : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		private string m_strEnderecoExecutavel;

		public bool m_bModificado = false;
		private int loader = -1;

		private int m_nIdIdioma = 0;
		
		// Bandeiras
		private System.Windows.Forms.ImageList m_ilBandeiras;
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.Label m_lPais;
		private System.Windows.Forms.Label m_lIdioma;
		private System.Windows.Forms.GroupBox m_gbPaisIdiomaEditar;
		private mdlComponentesGraficos.ComboBox m_cbPais;
		private mdlComponentesGraficos.TextBox m_ctbIdioma;
		private mdlComponentesGraficos.TextBox m_ctbEditar;
		internal System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Label m_lEditar;
		private System.Windows.Forms.ToolTip m_ttDicaFrmFPaisIdioma;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		private System.ComponentModel.IContainer components;
		#endregion
		
		#region Construtor e Destrutor
		public frmFPaisIdioma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel,ref System.Windows.Forms.ImageList ilBandeiras)
		{
			try 
			{
				m_ilBandeiras = ilBandeiras;
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = EnderecoExecutavel;

				InitializeComponent();
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion		
		#region Delegate

		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ComboBox cbPaises, ref mdlComponentesGraficos.TextBox tbIdioma, ref mdlComponentesGraficos.TextBox tbPaisIdioma);
		public delegate void delCallCarregaDadosInterfaceEditar(ref mdlComponentesGraficos.TextBox tbPaisIdioma, ref mdlComponentesGraficos.ComboBox cbPaises);
		public delegate void delCallChecaIntegridadeDados();
		public delegate bool delCallSalvaDadosInterface(ref mdlComponentesGraficos.ComboBox cbPais, ref mdlComponentesGraficos.TextBox tbPaisIdioma, bool bModified);
		public delegate void delCallSalvaDadosBD();

		public delegate void delCallAlteraIdConsignatario(int nIdConsignatario);

		#endregion
		#region Events

		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCarregaDadosInterfaceEditar eCallCarregaDadosInterfaceEditar;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		public event delCallAlteraIdConsignatario eCallAlteraIdConsignatario;

		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterfaceEditar()
		{
			if (eCallCarregaDadosInterfaceEditar != null)
				eCallCarregaDadosInterfaceEditar(ref this.m_ctbEditar, ref this.m_cbPais);
		}
		protected virtual void OnCallAlteraIdConsignatario()
		{
			if (eCallAlteraIdConsignatario != null)
				eCallAlteraIdConsignatario(Int32.Parse(m_cbPais.ReturnObjectSelectedItem().ToString()));
		}
		
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		} 

		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref this.m_cbPais, ref this.m_ctbIdioma, ref this.m_ctbEditar);
		} 

		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}

		protected virtual bool OnCallSalvaDadosInterface()
		{
			bool bRetorno = false;
			if (eCallSalvaDadosInterface != null)
				bRetorno = eCallSalvaDadosInterface(ref this.m_cbPais, ref this.m_ctbEditar,this.m_bModificado);
			return(bRetorno);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD();
		} 
		#endregion

		#region Procedimentos Para Troca de Cor
		#region Trocar Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		public void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Mostrar Cor
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		public void mostraCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if (((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox")) ||
								(this.Controls[cont].Controls[cont2].Controls[cont3].Name == 
								"m_ctbIdioma"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
						}
					}
				}
			} 
			catch (Exception erro) 
			{ 
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#endregion

		#region Métodos para manipulação da ImageList
		public void mostraBandeiraAtual()
		{
			try
			{
				if (m_ilBandeiras != null)
				{
					int nIdIdioma;
					nIdIdioma = Int32.Parse(this.m_ctbIdioma.Tag.ToString());
					if ((nIdIdioma > 0) & (nIdIdioma <= m_ilBandeiras.Images.Count))
					{
						System.Drawing.Bitmap bmpBandeira;						
						bmpBandeira = (System.Drawing.Bitmap)m_ilBandeiras.Images[nIdIdioma - 1];
						this.Icon = System.Drawing.Icon.FromHandle(bmpBandeira.GetHicon());
					} 
					else 
					{
						m_nIdIdioma = nIdIdioma;
					}
				}
			} 
			catch (Exception erro) 
			{
				Object err = erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFPaisIdioma));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbPaisIdiomaEditar = new System.Windows.Forms.GroupBox();
			this.m_ctbEditar = new mdlComponentesGraficos.TextBox();
			this.m_ctbIdioma = new mdlComponentesGraficos.TextBox();
			this.m_cbPais = new mdlComponentesGraficos.ComboBox();
			this.m_lEditar = new System.Windows.Forms.Label();
			this.m_lIdioma = new System.Windows.Forms.Label();
			this.m_lPais = new System.Windows.Forms.Label();
			this.m_ttDicaFrmFPaisIdioma = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbPaisIdiomaEditar.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_gbPaisIdiomaEditar);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(246, 161);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(63, 128);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 1;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(127, 128);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 2;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(3, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 3;
			this.m_ttDicaFrmFPaisIdioma.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbPaisIdiomaEditar
			// 
			this.m_gbPaisIdiomaEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPaisIdiomaEditar.Controls.Add(this.m_ctbEditar);
			this.m_gbPaisIdiomaEditar.Controls.Add(this.m_ctbIdioma);
			this.m_gbPaisIdiomaEditar.Controls.Add(this.m_cbPais);
			this.m_gbPaisIdiomaEditar.Controls.Add(this.m_lEditar);
			this.m_gbPaisIdiomaEditar.Controls.Add(this.m_lIdioma);
			this.m_gbPaisIdiomaEditar.Controls.Add(this.m_lPais);
			this.m_gbPaisIdiomaEditar.Location = new System.Drawing.Point(8, 8);
			this.m_gbPaisIdiomaEditar.Name = "m_gbPaisIdiomaEditar";
			this.m_gbPaisIdiomaEditar.Size = new System.Drawing.Size(230, 116);
			this.m_gbPaisIdiomaEditar.TabIndex = 0;
			this.m_gbPaisIdiomaEditar.TabStop = false;
			// 
			// m_ctbEditar
			// 
			this.m_ctbEditar.Location = new System.Drawing.Point(76, 85);
			this.m_ctbEditar.Name = "m_ctbEditar";
			this.m_ctbEditar.Size = new System.Drawing.Size(141, 20);
			this.m_ctbEditar.TabIndex = 2;
			this.m_ctbEditar.Text = "";
			this.m_ttDicaFrmFPaisIdioma.SetToolTip(this.m_ctbEditar, "Edite aqui o nome do país no idioma selecionado");
			this.m_ctbEditar.TextChanged += new System.EventHandler(this.m_ctbEditar_TextChanged);
			// 
			// m_ctbIdioma
			// 
			this.m_ctbIdioma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ctbIdioma.BackColor = System.Drawing.SystemColors.Window;
			this.m_ctbIdioma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_ctbIdioma.Enabled = false;
			this.m_ctbIdioma.ForeColor = System.Drawing.SystemColors.WindowText;
			this.m_ctbIdioma.Location = new System.Drawing.Point(76, 49);
			this.m_ctbIdioma.Name = "m_ctbIdioma";
			this.m_ctbIdioma.Size = new System.Drawing.Size(141, 20);
			this.m_ctbIdioma.TabIndex = 0;
			this.m_ctbIdioma.Text = "";
			this.m_ttDicaFrmFPaisIdioma.SetToolTip(this.m_ctbIdioma, "Idioma atual");
			// 
			// m_cbPais
			// 
			this.m_cbPais.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_cbPais.Location = new System.Drawing.Point(76, 15);
			this.m_cbPais.Name = "m_cbPais";
			this.m_cbPais.Size = new System.Drawing.Size(141, 21);
			this.m_cbPais.TabIndex = 1;
			this.m_ttDicaFrmFPaisIdioma.SetToolTip(this.m_cbPais, "Selecione o país desejado");
			this.m_cbPais.SelectedIndexChanged += new System.EventHandler(this.m_cbPais_SelectedIndexChanged);
			// 
			// m_lEditar
			// 
			this.m_lEditar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEditar.Location = new System.Drawing.Point(14, 85);
			this.m_lEditar.Name = "m_lEditar";
			this.m_lEditar.Size = new System.Drawing.Size(50, 15);
			this.m_lEditar.TabIndex = 0;
			this.m_lEditar.Text = "Editar:";
			// 
			// m_lIdioma
			// 
			this.m_lIdioma.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lIdioma.Location = new System.Drawing.Point(14, 51);
			this.m_lIdioma.Name = "m_lIdioma";
			this.m_lIdioma.Size = new System.Drawing.Size(50, 15);
			this.m_lIdioma.TabIndex = 0;
			this.m_lIdioma.Text = "Idioma:";
			// 
			// m_lPais
			// 
			this.m_lPais.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPais.Location = new System.Drawing.Point(14, 17);
			this.m_lPais.Name = "m_lPais";
			this.m_lPais.Size = new System.Drawing.Size(50, 15);
			this.m_lPais.TabIndex = 0;
			this.m_lPais.Text = "País:";
			// 
			// m_ttDicaFrmFPaisIdioma
			// 
			this.m_ttDicaFrmFPaisIdioma.AutomaticDelay = 100;
			this.m_ttDicaFrmFPaisIdioma.AutoPopDelay = 5000;
			this.m_ttDicaFrmFPaisIdioma.InitialDelay = 100;
			this.m_ttDicaFrmFPaisIdioma.ReshowDelay = 20;
			// 
			// frmFPaisIdioma
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 163);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFPaisIdioma";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "País";
			this.Load += new System.EventHandler(this.frmFPaisIdiomas_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbPaisIdiomaEditar.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
		private void frmFPaisIdiomas_Load(object sender, System.EventArgs e)
		{
			try 
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
				this.mostraBandeiraAtual();
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.trocaCor();
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_ctbEditar_TextChanged(object sender, System.EventArgs e)
		{
			if (loader >= 0)
                this.m_bModificado = true;
			else
				loader = 0;
		}

		private void m_cbPais_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.m_bModificado = true;
			this.OnCallAlteraIdConsignatario();
			this.OnCallCarregaDadosInterfaceEditar();
		}
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try 
			{
				m_bModificado = true;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (OnCallSalvaDadosInterface())
				{
					OnCallSalvaDadosBD();
					this.Close();
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.m_bModificado = false;
				this.Close();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
	}
}
