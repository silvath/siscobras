using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosGeral
{
	/// <summary>
	/// Summary description for frmFPropriedades.
	/// </summary>
	public class frmFPropriedades : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallConfigure(ref mdlComponentesGraficos.DataGrid dgPropriedades);
			public delegate bool delCallRefreshPropriedades(ref mdlComponentesGraficos.DataGrid dgPropriedades);	

			public delegate bool delCallSalvaDados();
		#endregion
		#region Events
			public event delCallConfigure eCallConfigure;
			public event delCallRefreshPropriedades eCallRefreshPropriedades;

			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected bool OnCallConfigure()
			{
				if (eCallConfigure == null)
					return(false);
				return(eCallConfigure(ref m_dgPropriedades));
			}

			internal bool OnCallRefreshPropriedades()
			{
				if (eCallRefreshPropriedades == null)
					return(false);
				return(eCallRefreshPropriedades(ref m_dgPropriedades));
			}

			protected bool OnCallSalvaDados()
			{
				if (eCallSalvaDados == null)
					return(false);
				return(eCallSalvaDados());
			}
		#endregion

		#region Atributes
			private bool m_bConfirmed = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbPropriedades;
			private mdlComponentesGraficos.DataGrid m_dgPropriedades;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			public bool Confirmed
			{
				get
				{
					return(m_bConfirmed);
				}
			}
		#endregion
		#region Constructors
		public frmFPropriedades(string strEnderecoExecutavel)
		{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFPropriedades));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbPropriedades = new System.Windows.Forms.GroupBox();
			this.m_dgPropriedades = new mdlComponentesGraficos.DataGrid();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gbPropriedades.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dgPropriedades)).BeginInit();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbPropriedades);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMain.Location = new System.Drawing.Point(4, -1);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(687, 367);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbPropriedades
			// 
			this.m_gbPropriedades.Controls.Add(this.m_dgPropriedades);
			this.m_gbPropriedades.Location = new System.Drawing.Point(8, 8);
			this.m_gbPropriedades.Name = "m_gbPropriedades";
			this.m_gbPropriedades.Size = new System.Drawing.Size(673, 320);
			this.m_gbPropriedades.TabIndex = 8;
			this.m_gbPropriedades.TabStop = false;
			this.m_gbPropriedades.Text = "Propriedades";
			// 
			// m_dgPropriedades
			// 
			this.m_dgPropriedades.AcceptsEnter = false;
			this.m_dgPropriedades.AcceptsTab = false;
			this.m_dgPropriedades.DataMember = "";
			this.m_dgPropriedades.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.m_dgPropriedades.Location = new System.Drawing.Point(8, 16);
			this.m_dgPropriedades.Name = "m_dgPropriedades";
			this.m_dgPropriedades.Size = new System.Drawing.Size(656, 296);
			this.m_dgPropriedades.TabIndex = 0;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(282, 334);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 6;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(346, 334);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 7;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFPropriedades
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(694, 368);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFPropriedades";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Propriedades Dinâmicas";
			this.Load += new System.EventHandler(this.frmFPropriedades_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbPropriedades.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dgPropriedades)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
			#region Formulario
				private void frmFPropriedades_Load(object sender, System.EventArgs e)
				{
					OnCallConfigure();
					OnCallRefreshPropriedades();
				}
			#endregion
			#region Buttons
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (OnCallSalvaDados())
					{
						m_bConfirmed = true;
						this.Close();
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bConfirmed = false;
					this.Close();
				}
			#endregion
		#endregion

		#region Cores
			private void vMostraCor(string strEnderecoExecutavel)
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME,"SiscobrasCorSecundaria");
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
					case "System.Windows.Forms.TextBox":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
					case "mdlComponentesGraficos.TreeView":
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
