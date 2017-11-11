using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosBordero
{
	/// <summary>
	/// Summary description for frmFBancoAtual.
	/// </summary>
	public class frmFBancoAtual : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallRefreshBancos(ref mdlComponentesGraficos.ListView lvBancos);
			public delegate void delCallCarregaDados(out int nIdBanco);
			public delegate bool delCallSalvaDados(int nIdBanco);
		#endregion
		#region Events
			public event delCallRefreshBancos eCallRefreshBancos;
			public event delCallCarregaDados eCallCarregaDados;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			public virtual void OnCallRefreshBancos()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshBancos != null)
					eCallRefreshBancos(ref m_lvBancos);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual void OnCallCarregaDados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDados != null)
				{
					int nIdBanco;
					eCallCarregaDados(out nIdBanco);
					m_lvBancos.SelectedItems.Clear();
					for(int i = 0;i < m_lvBancos.Items.Count;i++)
					{
						if (Int32.Parse(m_lvBancos.Items[0].Tag.ToString()) == nIdBanco)
						{
							m_lvBancos.Items[0].Selected = true;
							break;
						}
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual bool OnCallSalvaDados()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallSalvaDados != null)
				{
					if (m_lvBancos.SelectedItems.Count > 0)
					{
						bRetorno = eCallSalvaDados(Int32.Parse(m_lvBancos.SelectedItems[0].Tag.ToString()));
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributes

			private string m_strEnderecoExecutavel = "";

			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Button m_btOk;
			private mdlComponentesGraficos.ListView m_lvBancos;
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public frmFBancoAtual(string strEnderecoExecutavel)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();

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
		#endregion
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFBancoAtual));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_lvBancos = new mdlComponentesGraficos.ListView();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_lvBancos);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Location = new System.Drawing.Point(7, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(348, 192);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_lvBancos
			// 
			this.m_lvBancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvBancos.FullRowSelect = true;
			this.m_lvBancos.HideSelection = false;
			this.m_lvBancos.Location = new System.Drawing.Point(8, 16);
			this.m_lvBancos.Name = "m_lvBancos";
			this.m_lvBancos.Size = new System.Drawing.Size(328, 136);
			this.m_lvBancos.TabIndex = 8;
			this.m_lvBancos.View = System.Windows.Forms.View.List;
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(168, 160);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 7;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(104, 160);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 6;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// frmFBancoAtual
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(362, 200);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFBancoAtual";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bancos disponíveis";
			this.Load += new System.EventHandler(this.frmFBancoAtual_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFBancoAtual_Load(object sender, System.EventArgs e)
				{
					OnCallRefreshBancos();
					OnCallCarregaDados();
					vMostraCor();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_bModificado = OnCallSalvaDados())
						this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}
			#endregion
		#endregion

		#region Cores
			private void vMostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				this.BackColor = clsPaletaCores.retornaCorAtual();
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
			}

			private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
			{
				switch(ctrControle.GetType().ToString())
				{
					case "mdlComponentesGraficos.ListView":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
						break;

					default:
						ctrControle.BackColor = clrBackColor;
						break;
				}
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
				{
					ctrControleChild = ctrControle.Controls[nCont];
					vPaintControl(ref ctrControleChild,clrBackColor);
				}
			}
		#endregion
	}
}
