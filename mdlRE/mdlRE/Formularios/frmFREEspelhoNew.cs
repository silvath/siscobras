using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRE.Formularios
{
	/// <summary>
	/// Summary description for frmFREEspelhoNew.
	/// </summary>
	public class frmFREEspelhoNew : System.Windows.Forms.Form
	{
		#region Atributes
			private mdlRE.clsREEspelho.TypeREEspelhoNew m_enumtypeREEspelho = mdlRE.clsREEspelho.TypeREEspelhoNew.Cancelar;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.Label label1;
			internal mdlComponentesGraficos.Button m_btCancelar;
			internal mdlComponentesGraficos.Button m_btOk;
			private System.Windows.Forms.RadioButton m_rbBaseadoRESiscomex;
			private System.Windows.Forms.RadioButton m_rbBaseadoRELocal;
			private System.Windows.Forms.RadioButton m_rbBranco;
			private System.Windows.Forms.RadioButton m_rbBaseadoPE;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			internal mdlRE.clsREEspelho.TypeREEspelhoNew TypeREEspelho
			{
				get
				{
					return(m_enumtypeREEspelho);
				}
			}

			public bool TypeBaseadoPE
			{
				set
				{
					m_rbBaseadoPE.Visible = value;
					if ((!value) && (m_rbBaseadoPE.Checked))
						m_rbBranco.Checked = true;
				}
				get
				{
					return(m_rbBaseadoPE.Visible);
				}
			}
		#endregion
		#region Constructors
			public frmFREEspelhoNew()
			{
				InitializeComponent();
				vMostraCor();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFREEspelhoNew));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_rbBaseadoRESiscomex = new System.Windows.Forms.RadioButton();
			this.m_rbBaseadoRELocal = new System.Windows.Forms.RadioButton();
			this.m_rbBranco = new System.Windows.Forms.RadioButton();
			this.m_rbBaseadoPE = new System.Windows.Forms.RadioButton();
			this.m_btCancelar = new mdlComponentesGraficos.Button();
			this.m_btOk = new mdlComponentesGraficos.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.m_gbMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_rbBaseadoRESiscomex);
			this.m_gbMain.Controls.Add(this.m_rbBaseadoRELocal);
			this.m_gbMain.Controls.Add(this.m_rbBranco);
			this.m_gbMain.Controls.Add(this.m_rbBaseadoPE);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.label1);
			this.m_gbMain.Location = new System.Drawing.Point(4, -1);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(284, 141);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_rbBaseadoRESiscomex
			// 
			this.m_rbBaseadoRESiscomex.Enabled = false;
			this.m_rbBaseadoRESiscomex.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbBaseadoRESiscomex.Location = new System.Drawing.Point(64, 86);
			this.m_rbBaseadoRESiscomex.Name = "m_rbBaseadoRESiscomex";
			this.m_rbBaseadoRESiscomex.Size = new System.Drawing.Size(208, 16);
			this.m_rbBaseadoRESiscomex.TabIndex = 19;
			this.m_rbBaseadoRESiscomex.Text = "Baseado em um RE do Siscomex";
			// 
			// m_rbBaseadoRELocal
			// 
			this.m_rbBaseadoRELocal.Enabled = false;
			this.m_rbBaseadoRELocal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbBaseadoRELocal.Location = new System.Drawing.Point(64, 70);
			this.m_rbBaseadoRELocal.Name = "m_rbBaseadoRELocal";
			this.m_rbBaseadoRELocal.Size = new System.Drawing.Size(176, 16);
			this.m_rbBaseadoRELocal.TabIndex = 18;
			this.m_rbBaseadoRELocal.Text = "Baseado em um RE local";
			// 
			// m_rbBranco
			// 
			this.m_rbBranco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbBranco.Location = new System.Drawing.Point(64, 54);
			this.m_rbBranco.Name = "m_rbBranco";
			this.m_rbBranco.Size = new System.Drawing.Size(176, 16);
			this.m_rbBranco.TabIndex = 17;
			this.m_rbBranco.Text = "Em Branco";
			// 
			// m_rbBaseadoPE
			// 
			this.m_rbBaseadoPE.Checked = true;
			this.m_rbBaseadoPE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbBaseadoPE.Location = new System.Drawing.Point(64, 38);
			this.m_rbBaseadoPE.Name = "m_rbBaseadoPE";
			this.m_rbBaseadoPE.Size = new System.Drawing.Size(176, 16);
			this.m_rbBaseadoPE.TabIndex = 16;
			this.m_rbBaseadoPE.TabStop = true;
			this.m_rbBaseadoPE.Text = "Baseado em um PE";
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.GradiendColorEnd = System.Drawing.Color.Black;
			this.m_btCancelar.GradiendColorStart = System.Drawing.Color.White;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(144, 111);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 15;
			this.m_btCancelar.Type = mdlComponentesGraficos.Button.ButtonType.Cancel;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.GradiendColorEnd = System.Drawing.Color.Black;
			this.m_btOk.GradiendColorStart = System.Drawing.Color.White;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(80, 111);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 14;
			this.m_btOk.Type = mdlComponentesGraficos.Button.ButtonType.Ok;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(40, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Como você deseja criar o novo RE ?";
			// 
			// frmFREEspelhoNew
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 141);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFREEspelhoNew";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Novo Espelho do RE";
			this.m_gbMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Cores
			private void vMostraCor()
			{
				this.BackColor = mdlConstantes.clsConfig.FirstColor;
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

		#region Events
			#region Buttons
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_rbBaseadoPE.Checked)
						m_enumtypeREEspelho = mdlRE.clsREEspelho.TypeREEspelhoNew.BaseadoPE;
					else if (m_rbBaseadoRELocal.Checked)
						m_enumtypeREEspelho = mdlRE.clsREEspelho.TypeREEspelhoNew.BaseadoRELocal;
					else if (m_rbBaseadoRESiscomex.Checked)
						m_enumtypeREEspelho = mdlRE.clsREEspelho.TypeREEspelhoNew.BaseadoRESiscomex;
					else if (m_rbBranco.Checked)
						m_enumtypeREEspelho = mdlRE.clsREEspelho.TypeREEspelhoNew.Branco;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_enumtypeREEspelho = mdlRE.clsREEspelho.TypeREEspelhoNew.Cancelar;
					this.Close();
				}
			#endregion
		#endregion

	}
}
