using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRE.Formularios
{
	/// <summary>
	/// Summary description for frmFREInformacoes.
	/// </summary>
	public class frmFREInformacoes : System.Windows.Forms.Form
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
					eCallRefreshPEs(m_nIdRe,ref m_lvREsPEs);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region Atributos
			private int m_nIdRe = -1;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbREsPEs;
			private mdlComponentesGraficos.ListView m_lvREsPEs;
			private System.Windows.Forms.ColumnHeader m_chNumero;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor
			public frmFREInformacoes(string strEnderecoExecutavel,int nIdRe)
			{
				m_nIdRe = nIdRe;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFREInformacoes));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbREsPEs = new System.Windows.Forms.GroupBox();
			this.m_lvREsPEs = new mdlComponentesGraficos.ListView();
			this.m_chNumero = new System.Windows.Forms.ColumnHeader();
			this.m_gbGeral.SuspendLayout();
			this.m_gbREsPEs.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbREsPEs);
			this.m_gbGeral.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbGeral.Location = new System.Drawing.Point(4, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(195, 265);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbREsPEs
			// 
			this.m_gbREsPEs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbREsPEs.Controls.Add(this.m_lvREsPEs);
			this.m_gbREsPEs.Location = new System.Drawing.Point(8, 9);
			this.m_gbREsPEs.Name = "m_gbREsPEs";
			this.m_gbREsPEs.Size = new System.Drawing.Size(182, 246);
			this.m_gbREsPEs.TabIndex = 0;
			this.m_gbREsPEs.TabStop = false;
			this.m_gbREsPEs.Text = "PEs vinculados ao RE";
			// 
			// m_lvREsPEs
			// 
			this.m_lvREsPEs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvREsPEs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.m_chNumero});
			this.m_lvREsPEs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvREsPEs.HideSelection = false;
			this.m_lvREsPEs.Location = new System.Drawing.Point(7, 18);
			this.m_lvREsPEs.Name = "m_lvREsPEs";
			this.m_lvREsPEs.Size = new System.Drawing.Size(167, 222);
			this.m_lvREsPEs.TabIndex = 0;
			this.m_lvREsPEs.View = System.Windows.Forms.View.Details;
			// 
			// m_chNumero
			// 
			this.m_chNumero.Text = "m_chNumero";
			// 
			// frmFREInformacoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(202, 271);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFREInformacoes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Informações";
			this.Load += new System.EventHandler(this.frmFREInformacoes_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbREsPEs.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFREInformacoes_Load(object sender, System.EventArgs e)
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
