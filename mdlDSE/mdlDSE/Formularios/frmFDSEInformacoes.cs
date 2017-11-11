using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlDSE.Formularios
{
	/// <summary>
	/// Summary description for frmFDSEInformacoes.
	/// </summary>
	public class frmFDSEInformacoes : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallRefreshPEs(int nIdRe,ref mdlComponentesGraficos.ListView lvPEs);
		#endregion
		#region Events
			public event delCallRefreshPEs eCallRefreshPEs;
		#endregion
		#region Events Methods
			public virtual void OnCallRefreshPEs()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshPEs != null)
					eCallRefreshPEs(m_nIdDSE,ref m_lvDSEsPEs);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region Atributos
			private int m_nIdDSE = -1;

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbDSEsPEs;
			private mdlComponentesGraficos.ListView m_lvDSEsPEs;
			private System.Windows.Forms.ColumnHeader m_chNumero;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Construtores
			public frmFDSEInformacoes(string strEnderecoExecutavel,int nIdDSE)
			{
				m_nIdDSE = nIdDSE;
				InitializeComponent();
				vMostraCor(strEnderecoExecutavel);
			}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFDSEInformacoes));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbDSEsPEs = new System.Windows.Forms.GroupBox();
			this.m_lvDSEsPEs = new mdlComponentesGraficos.ListView();
			this.m_chNumero = new System.Windows.Forms.ColumnHeader();
			this.m_gbGeral.SuspendLayout();
			this.m_gbDSEsPEs.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbDSEsPEs);
			this.m_gbGeral.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbGeral.Location = new System.Drawing.Point(3, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(195, 265);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbDSEsPEs
			// 
			this.m_gbDSEsPEs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbDSEsPEs.Controls.Add(this.m_lvDSEsPEs);
			this.m_gbDSEsPEs.Location = new System.Drawing.Point(8, 9);
			this.m_gbDSEsPEs.Name = "m_gbDSEsPEs";
			this.m_gbDSEsPEs.Size = new System.Drawing.Size(182, 246);
			this.m_gbDSEsPEs.TabIndex = 0;
			this.m_gbDSEsPEs.TabStop = false;
			this.m_gbDSEsPEs.Text = "PEs vinculados ao DSE";
			// 
			// m_lvDSEsPEs
			// 
			this.m_lvDSEsPEs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvDSEsPEs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.m_chNumero});
			this.m_lvDSEsPEs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvDSEsPEs.HideSelection = false;
			this.m_lvDSEsPEs.Location = new System.Drawing.Point(7, 18);
			this.m_lvDSEsPEs.Name = "m_lvDSEsPEs";
			this.m_lvDSEsPEs.Size = new System.Drawing.Size(167, 222);
			this.m_lvDSEsPEs.TabIndex = 0;
			this.m_lvDSEsPEs.View = System.Windows.Forms.View.Details;
			// 
			// m_chNumero
			// 
			this.m_chNumero.Text = "m_chNumero";
			// 
			// frmFDSEInformacoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(200, 269);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFDSEInformacoes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Informações";
			this.Load += new System.EventHandler(this.frmFDSEInformacoes_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbDSEsPEs.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFDSEInformacoes_Load(object sender, System.EventArgs e)
				{
					OnCallRefreshPEs();
				}
			#endregion
		#endregion

		#region Cores
			private void vMostraCor(string strEnderecoExecutavel)
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
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
					case "System.Windows.Forms.ListView":
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
