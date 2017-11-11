using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace executavel
{
	/// <summary>
	/// Summary description for frmRelatoriosTeste.
	/// </summary>
	public class frmRelatoriosTeste : mdlRelatoriosBase.frmRelatoriosBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		private System.ComponentModel.Container components = null;

		public frmRelatoriosTeste(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_Connection, ref System.Windows.Forms.Form mdiParent,string strEnderecoExecutavel,int nTipoRelatorio,int nIdExportador,string strIdCodigo) : base(ref tratadorErro,ref cls_dba_Connection,ref mdiParent,strEnderecoExecutavel,nTipoRelatorio,nIdExportador,strIdCodigo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			bResizeForm();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_gbBarraSuperior.SuspendLayout();
			this.m_gbBarraInferior.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_btEnviarImagemEmail
			// 
			this.m_btEnviarImagemEmail.Visible = true;
			// 
			// m_btIdioma
			// 
			this.m_btIdioma.Visible = true;
			// 
			// m_btSalvarImagem
			// 
			this.m_btSalvarImagem.Visible = true;
			// 
			// m_btModoEdicao
			// 
			this.m_btModoEdicao.Visible = true;
			// 
			// m_btTrocarRelatorio
			// 
			this.m_btTrocarRelatorio.Visible = true;
			// 
			// m_btImprimirRelatorioImprimir
			// 
			this.m_btImprimir.Visible = true;
			// 
			// m_btUltimaPagina
			// 
			this.m_btUltimaPagina.Visible = true;
			// 
			// m_btPrimeiraPagima
			// 
			this.m_btPrimeiraPagima.Visible = true;
			// 
			// m_lbPaginaAtual
			// 
			this.m_lbPaginaAtual.Visible = true;
			// 
			// m_btPaginaAnterior
			// 
			this.m_btPaginaAnterior.Visible = true;
			// 
			// m_btProximaPagina
			// 
			this.m_btProximaPagina.Visible = true;
			// 
			// m_btZoomMenos
			// 
			// 
			// m_btZoomMais
			// 
			// 
			// m_gbBarraSuperior
			// 
			this.m_gbBarraSuperior.Visible = true;
			// 
			// m_gbBarraInferior
			// 
			this.m_gbBarraInferior.Visible = true;
			// 
			// frmRelatoriosTeste
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1022, 622);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_gbBarraInferior,
																		  this.m_gbBarraSuperior});
			this.Name = "frmRelatoriosTeste";
			this.Load += new System.EventHandler(this.frmRelatoriosTeste_Load);
			this.m_gbBarraSuperior.ResumeLayout(false);
			this.m_gbBarraInferior.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		private void frmRelatoriosTeste_Load(object sender, System.EventArgs e)
		{
			this.bMostrarRelatorio();
		}

		public override bool bCarregaIdRelatorio()
		{
			m_nIdRelatorio =  -4;
			return true;
		}

		public override bool bCarregaIdIdioma()
		{
			m_nIdIdioma =  1;
			return true;
		}
	}
}
