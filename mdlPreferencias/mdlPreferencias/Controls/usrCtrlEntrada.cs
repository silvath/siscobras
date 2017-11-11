using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace mdlPreferencias.Entrada
{
	/// <summary>
	/// Summary description for usrCtrlEntrada.
	/// </summary>
	internal class usrCtrlEntrada : System.Windows.Forms.UserControl
	{
		#region Delegate
			public delegate void delCallCarregaDados(out bool bEntrarUltimaConta,out bool bEntrarUltimoPe,out bool bEntrarUltimoDocumento,out int nIdDocumento);
			public delegate bool delCallPrestadorServico();
			public delegate bool delCallSalvaDados(bool bEntrarUltimaConta,bool bEntrarUltimoPe,bool bEntrarUltimoDocumento,int nIdDocumento);
		#endregion
		#region Events
			public event delCallCarregaDados eCallCarregaDados;
			public event delCallPrestadorServico eCallPrestadorServico;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDados()
			{
				if (eCallCarregaDados != null)
				{
					bool bEntrarUltimaConta;
					bool bEntrarUltimoPe;
					bool bEntrarUltimoDocumento;
					int nIdDocumento;
					eCallCarregaDados(out bEntrarUltimaConta,out bEntrarUltimoPe,out bEntrarUltimoDocumento,out nIdDocumento);
					m_ckConta.Checked = bEntrarUltimaConta;
					m_ckPE.Checked = bEntrarUltimoPe;
					m_ckDocumento.Checked = bEntrarUltimoDocumento;
					switch(nIdDocumento)
					{
						case -1:
							m_rbDocumentoUltimo.Checked = true;
							break;
						case 0:
							m_rbDocumentoStatusPe.Checked = true;
							break;
						case 3:
							m_rbDocumentoFaturaComercial.Checked = true;
							break;
 					}
				}
			}

			protected virtual bool OnCallPrestadorServico()
			{
				bool bRetorno = false;
				if (eCallPrestadorServico != null)
					bRetorno = eCallPrestadorServico();
				return(bRetorno);
			}


			protected virtual bool OnCallSalvaDados()
			{
				bool bRetorno = false;
				if (eCallSalvaDados != null)
				{
					int nIdDocumento = -1;
					if (m_rbDocumentoUltimo.Checked)
						nIdDocumento = -1;
					if (m_rbDocumentoStatusPe.Checked)
						nIdDocumento = 0;
					if (m_rbDocumentoFaturaComercial.Checked)
						nIdDocumento = 3;
					bRetorno = eCallSalvaDados(m_ckConta.Checked,m_ckPE.Checked,m_ckDocumento.Checked,nIdDocumento);
				}
				return(bRetorno);
			}
		#endregion
		#region Atributos
		private System.Windows.Forms.CheckBox m_ckConta;
		private System.Windows.Forms.GroupBox m_gbDocumento;
		private System.Windows.Forms.RadioButton m_rbDocumentoUltimo;
		private System.Windows.Forms.CheckBox m_ckPE;
		private System.Windows.Forms.CheckBox m_ckDocumento;
		private System.Windows.Forms.RadioButton m_rbDocumentoFaturaComercial;
		private System.Windows.Forms.RadioButton m_rbDocumentoStatusPe;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		#region Construtors and Destructors
		public usrCtrlEntrada()
		{
			InitializeComponent();
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
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_ckConta = new System.Windows.Forms.CheckBox();
			this.m_ckPE = new System.Windows.Forms.CheckBox();
			this.m_gbDocumento = new System.Windows.Forms.GroupBox();
			this.m_rbDocumentoFaturaComercial = new System.Windows.Forms.RadioButton();
			this.m_rbDocumentoStatusPe = new System.Windows.Forms.RadioButton();
			this.m_rbDocumentoUltimo = new System.Windows.Forms.RadioButton();
			this.m_ckDocumento = new System.Windows.Forms.CheckBox();
			this.m_gbDocumento.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_ckConta
			// 
			this.m_ckConta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckConta.Location = new System.Drawing.Point(10, 22);
			this.m_ckConta.Name = "m_ckConta";
			this.m_ckConta.Size = new System.Drawing.Size(200, 16);
			this.m_ckConta.TabIndex = 0;
			this.m_ckConta.Text = "Entrar ultima Conta utilizada.";
			this.m_ckConta.CheckedChanged += new System.EventHandler(this.m_ckConta_CheckedChanged);
			// 
			// m_ckPE
			// 
			this.m_ckPE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckPE.Location = new System.Drawing.Point(10, 40);
			this.m_ckPE.Name = "m_ckPE";
			this.m_ckPE.Size = new System.Drawing.Size(214, 16);
			this.m_ckPE.TabIndex = 1;
			this.m_ckPE.Text = "Entrar ultimo PE utilizado da conta.";
			this.m_ckPE.CheckedChanged += new System.EventHandler(this.m_ckPE_CheckedChanged);
			// 
			// m_gbDocumento
			// 
			this.m_gbDocumento.Controls.Add(this.m_rbDocumentoFaturaComercial);
			this.m_gbDocumento.Controls.Add(this.m_rbDocumentoStatusPe);
			this.m_gbDocumento.Controls.Add(this.m_rbDocumentoUltimo);
			this.m_gbDocumento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbDocumento.Location = new System.Drawing.Point(10, 73);
			this.m_gbDocumento.Name = "m_gbDocumento";
			this.m_gbDocumento.Size = new System.Drawing.Size(256, 71);
			this.m_gbDocumento.TabIndex = 2;
			this.m_gbDocumento.TabStop = false;
			// 
			// m_rbDocumentoFaturaComercial
			// 
			this.m_rbDocumentoFaturaComercial.Location = new System.Drawing.Point(7, 46);
			this.m_rbDocumentoFaturaComercial.Name = "m_rbDocumentoFaturaComercial";
			this.m_rbDocumentoFaturaComercial.Size = new System.Drawing.Size(232, 16);
			this.m_rbDocumentoFaturaComercial.TabIndex = 3;
			this.m_rbDocumentoFaturaComercial.Text = "Fatura Comercial";
			this.m_rbDocumentoFaturaComercial.CheckedChanged += new System.EventHandler(this.m_rbDocumentoFaturaComercial_CheckedChanged);
			// 
			// m_rbDocumentoStatusPe
			// 
			this.m_rbDocumentoStatusPe.Location = new System.Drawing.Point(7, 29);
			this.m_rbDocumentoStatusPe.Name = "m_rbDocumentoStatusPe";
			this.m_rbDocumentoStatusPe.Size = new System.Drawing.Size(232, 16);
			this.m_rbDocumentoStatusPe.TabIndex = 1;
			this.m_rbDocumentoStatusPe.Text = "Informaçoes do PE";
			this.m_rbDocumentoStatusPe.CheckedChanged += new System.EventHandler(this.m_rbDocumentoStatusPe_CheckedChanged);
			// 
			// m_rbDocumentoUltimo
			// 
			this.m_rbDocumentoUltimo.Location = new System.Drawing.Point(7, 13);
			this.m_rbDocumentoUltimo.Name = "m_rbDocumentoUltimo";
			this.m_rbDocumentoUltimo.Size = new System.Drawing.Size(232, 16);
			this.m_rbDocumentoUltimo.TabIndex = 0;
			this.m_rbDocumentoUltimo.Text = "Ultimo documento utilizado no PE";
			this.m_rbDocumentoUltimo.CheckedChanged += new System.EventHandler(this.m_rbDocumentoUltimo_CheckedChanged);
			// 
			// m_ckDocumento
			// 
			this.m_ckDocumento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckDocumento.Location = new System.Drawing.Point(10, 58);
			this.m_ckDocumento.Name = "m_ckDocumento";
			this.m_ckDocumento.Size = new System.Drawing.Size(261, 16);
			this.m_ckDocumento.TabIndex = 3;
			this.m_ckDocumento.Text = "Entrar automaticamente no documento.";
			this.m_ckDocumento.CheckedChanged += new System.EventHandler(this.m_ckDocumento_CheckedChanged);
			// 
			// usrCtrlEntrada
			// 
			this.Controls.Add(this.m_ckDocumento);
			this.Controls.Add(this.m_gbDocumento);
			this.Controls.Add(this.m_ckPE);
			this.Controls.Add(this.m_ckConta);
			this.Name = "usrCtrlEntrada";
			this.Size = new System.Drawing.Size(394, 368);
			this.Load += new System.EventHandler(this.usrCtrlEntrada_Load);
			this.m_gbDocumento.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void usrCtrlEntrada_Load(object sender, System.EventArgs e)
				{
					m_ckConta.Visible = OnCallPrestadorServico();
					OnCallCarregaDados();
				}
			#endregion
			#region CheckBoxes
				private void m_ckConta_CheckedChanged(object sender, System.EventArgs e)
				{
					OnCallSalvaDados();
				}

				private void m_ckPE_CheckedChanged(object sender, System.EventArgs e)
				{
					OnCallSalvaDados();
				}

				private void m_ckDocumento_CheckedChanged(object sender, System.EventArgs e)
				{
					OnCallSalvaDados();
				}
			#endregion
			#region RadioButtons
				private void m_rbDocumentoUltimo_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbDocumentoUltimo.Checked)
						OnCallSalvaDados();
				}

				private void m_rbDocumentoStatusPe_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbDocumentoStatusPe.Checked)
						OnCallSalvaDados();
				}

				private void m_rbDocumentoFaturaComercial_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbDocumentoFaturaComercial.Checked)
						OnCallSalvaDados();
				}
			#endregion
		#endregion
	}
}
