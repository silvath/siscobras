using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlPEInfo
{
	/// <summary>
	/// Summary description for frmFExportacaoDocumento.
	/// </summary>
	public class frmFExportacaoDocumento : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCancelar();
		#endregion
		#region Events
			public event delCallCancelar eCallCancelar;
		#endregion
		#region Events Methods
			protected virtual void OnCallCancelar()
			{
				if (eCallCancelar != null)
					eCallCancelar();
			}
		#endregion

		#region Atributos
			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.Windows.Forms.Label m_lbInformacao;
			private System.ComponentModel.IContainer components;
			private System.Windows.Forms.GroupBox m_gbPrincipal;
			private mdlComponentesGraficos.PictureBox m_picBarraProgresso;
			private System.Windows.Forms.Label m_lbDocumento;
			private System.Windows.Forms.Button m_btCancelar;
		#endregion
		#region Properties
			public int Porcentagem
			{
				set
				{
					if ((value >=0) && (value <= 100))
						m_picBarraProgresso.Percentage = value;
				}
			}
			
			public string Documento
			{
				set
				{
					m_lbDocumento.Text = value;
				}
			}

		#endregion
		#region Constructors and Destructors
		public frmFExportacaoDocumento(System.Drawing.Color clrCor)
		{
			InitializeComponent();
			vMostraCor(clrCor);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFExportacaoDocumento));
			this.m_gbPrincipal = new System.Windows.Forms.GroupBox();
			this.m_lbDocumento = new System.Windows.Forms.Label();
			this.m_picBarraProgresso = new mdlComponentesGraficos.PictureBox();
			this.m_lbInformacao = new System.Windows.Forms.Label();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbPrincipal.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbPrincipal
			// 
			this.m_gbPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPrincipal.Controls.Add(this.m_lbDocumento);
			this.m_gbPrincipal.Controls.Add(this.m_picBarraProgresso);
			this.m_gbPrincipal.Controls.Add(this.m_lbInformacao);
			this.m_gbPrincipal.Controls.Add(this.m_btCancelar);
			this.m_gbPrincipal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPrincipal.Location = new System.Drawing.Point(5, 0);
			this.m_gbPrincipal.Name = "m_gbPrincipal";
			this.m_gbPrincipal.Size = new System.Drawing.Size(306, 97);
			this.m_gbPrincipal.TabIndex = 0;
			this.m_gbPrincipal.TabStop = false;
			// 
			// m_lbDocumento
			// 
			this.m_lbDocumento.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_lbDocumento.Location = new System.Drawing.Point(11, 28);
			this.m_lbDocumento.Name = "m_lbDocumento";
			this.m_lbDocumento.Size = new System.Drawing.Size(285, 16);
			this.m_lbDocumento.TabIndex = 15;
			this.m_lbDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_picBarraProgresso
			// 
			this.m_picBarraProgresso.Effect = mdlComponentesGraficos.PictureBox.Effects.BlackAndWhite;
			this.m_picBarraProgresso.EffectDirection = mdlComponentesGraficos.PictureBox.Directions.Horizontal;
			this.m_picBarraProgresso.Image = ((System.Drawing.Image)(resources.GetObject("m_picBarraProgresso.Image")));
			this.m_picBarraProgresso.Location = new System.Drawing.Point(9, 45);
			this.m_picBarraProgresso.Name = "m_picBarraProgresso";
			this.m_picBarraProgresso.OriginalImage = ((System.Drawing.Image)(resources.GetObject("m_picBarraProgresso.OriginalImage")));
			this.m_picBarraProgresso.Percentage = 0;
			this.m_picBarraProgresso.Size = new System.Drawing.Size(287, 16);
			this.m_picBarraProgresso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_picBarraProgresso.TabIndex = 14;
			this.m_picBarraProgresso.TabStop = false;
			this.m_picBarraProgresso.WithEffects = true;
			// 
			// m_lbInformacao
			// 
			this.m_lbInformacao.Location = new System.Drawing.Point(11, 13);
			this.m_lbInformacao.Name = "m_lbInformacao";
			this.m_lbInformacao.Size = new System.Drawing.Size(288, 16);
			this.m_lbInformacao.TabIndex = 13;
			this.m_lbInformacao.Text = "Aguarde enquanto o documento está sendo criado.";
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(121, 66);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 12;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFExportacaoDocumento
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(314, 103);
			this.Controls.Add(this.m_gbPrincipal);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFExportacaoDocumento";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Criando documento";
			this.m_gbPrincipal.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			private void m_btCancelar_Click(object sender, System.EventArgs e)
			{
				OnCallCancelar();
				this.Close();
			}
		#endregion

		#region Cores
			private void vMostraCor(System.Drawing.Color clrCor)
			{
				this.BackColor = clrCor;
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
					case "System.Windows.Forms.TreeView":
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
