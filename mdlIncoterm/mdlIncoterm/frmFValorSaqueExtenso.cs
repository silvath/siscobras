using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlIncoterm
{
	/// <summary>
	/// Summary description for frmFValorSaqueExtenso.
	/// </summary>
	public class frmFValorSaqueExtenso : System.Windows.Forms.Form
	{
		#region Atributes
			private bool m_bModificado = false;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbAtual;
			private System.Windows.Forms.TextBox m_txtValor;
			private System.Windows.Forms.GroupBox m_gbDefault;
			private System.Windows.Forms.TextBox m_txtDefault;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
		#endregion
		private System.Windows.Forms.ToolTip m_ttDicas;
		private System.ComponentModel.IContainer components;
		#region Properties
			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}

			public string ValorExtenso
			{
				set
				{
					m_txtValor.Text = value;
				}
				get
				{
					return(m_txtValor.Text);
				}
			}

			public string ValorExtensoDefault
			{
				set
				{
					m_txtDefault.Text = value;
				}
				get
				{
					return(m_txtDefault.Text);
				}
			}
		#endregion
		#region Constructors and Destructors
		public frmFValorSaqueExtenso(System.Drawing.Color clrFundo)
		{
			InitializeComponent();
			vMostraCor(clrFundo);
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFValorSaqueExtenso));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbAtual = new System.Windows.Forms.GroupBox();
			this.m_txtValor = new System.Windows.Forms.TextBox();
			this.m_gbDefault = new System.Windows.Forms.GroupBox();
			this.m_txtDefault = new System.Windows.Forms.TextBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbAtual.SuspendLayout();
			this.m_gbDefault.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbAtual);
			this.m_gbGeral.Controls.Add(this.m_gbDefault);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(2, -3);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(284, 230);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbAtual
			// 
			this.m_gbAtual.Controls.Add(this.m_txtValor);
			this.m_gbAtual.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbAtual.Location = new System.Drawing.Point(8, 103);
			this.m_gbAtual.Name = "m_gbAtual";
			this.m_gbAtual.Size = new System.Drawing.Size(272, 96);
			this.m_gbAtual.TabIndex = 89;
			this.m_gbAtual.TabStop = false;
			this.m_gbAtual.Text = "Personalizável";
			// 
			// m_txtValor
			// 
			this.m_txtValor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtValor.Location = new System.Drawing.Point(6, 15);
			this.m_txtValor.Multiline = true;
			this.m_txtValor.Name = "m_txtValor";
			this.m_txtValor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtValor.Size = new System.Drawing.Size(259, 72);
			this.m_txtValor.TabIndex = 87;
			this.m_txtValor.Text = "";
			// 
			// m_gbDefault
			// 
			this.m_gbDefault.Controls.Add(this.m_txtDefault);
			this.m_gbDefault.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbDefault.Location = new System.Drawing.Point(7, 7);
			this.m_gbDefault.Name = "m_gbDefault";
			this.m_gbDefault.Size = new System.Drawing.Size(272, 96);
			this.m_gbDefault.TabIndex = 88;
			this.m_gbDefault.TabStop = false;
			this.m_gbDefault.Text = "Padrão";
			// 
			// m_txtDefault
			// 
			this.m_txtDefault.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtDefault.Location = new System.Drawing.Point(7, 14);
			this.m_txtDefault.Multiline = true;
			this.m_txtDefault.Name = "m_txtDefault";
			this.m_txtDefault.ReadOnly = true;
			this.m_txtDefault.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtDefault.Size = new System.Drawing.Size(259, 72);
			this.m_txtDefault.TabIndex = 88;
			this.m_txtDefault.Text = "";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(86, 200);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 85;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(150, 200);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 86;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFValorSaqueExtenso
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 229);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFValorSaqueExtenso";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Valor ";
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbAtual.ResumeLayout(false);
			this.m_gbDefault.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Cores
			private void vMostraCor(System.Drawing.Color clrFundo)
			{
				this.BackColor = clrFundo;
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

		#region Eventos
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bModificado = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
		#endregion
	}
}
