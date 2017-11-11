using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for frmFIdiomasIndisponiveis.
	/// </summary>
	public class frmFIdiomasIndisponiveis : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallIdiomaInstaladoChinesTradicional();
			public delegate void delCallIdiomaShowChinesTradicional();
		#endregion
		#region Events
			public event delCallIdiomaInstaladoChinesTradicional eCallIdiomaInstaladoChinesTradicional;
			public event delCallIdiomaShowChinesTradicional eCallIdiomaShowChinesTradicional;
		#endregion
		#region Events Methods
			protected virtual bool OnCallIdiomaInstaladoChinesTradicional()
			{
				bool bRetorno = false;
				if (eCallIdiomaInstaladoChinesTradicional != null)
					bRetorno = eCallIdiomaInstaladoChinesTradicional();
				return(bRetorno);
			} 

			protected virtual void OnCallIdiomaShowChinesTradicional()
			{
				if (eCallIdiomaShowChinesTradicional != null)
					eCallIdiomaShowChinesTradicional();
			} 
		#endregion

		#region Atributes
			private string m_strEnderecoExecutavel;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Label m_lbInfo;
			private System.Windows.Forms.Button m_btChinesTradicional;
			private System.Windows.Forms.Button m_btArabe;
			private System.Windows.Forms.Label m_lbArabe;
			private System.Windows.Forms.LinkLabel m_llbChinesTradicional;
			public System.Windows.Forms.ImageList m_ilBandeiras;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public System.Windows.Forms.ImageList Bandeiras
			{
				get
				{
					return(m_ilBandeiras);
				}
			}
		#endregion
		#region Constructors and Destructors
			public frmFIdiomasIndisponiveis(string strEnderecoExecutavel)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFIdiomasIndisponiveis));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_llbChinesTradicional = new System.Windows.Forms.LinkLabel();
			this.m_lbArabe = new System.Windows.Forms.Label();
			this.m_btArabe = new System.Windows.Forms.Button();
			this.m_btChinesTradicional = new System.Windows.Forms.Button();
			this.m_lbInfo = new System.Windows.Forms.Label();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ilBandeiras = new System.Windows.Forms.ImageList(this.components);
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_llbChinesTradicional);
			this.m_gbGeral.Controls.Add(this.m_lbArabe);
			this.m_gbGeral.Controls.Add(this.m_btArabe);
			this.m_gbGeral.Controls.Add(this.m_btChinesTradicional);
			this.m_gbGeral.Controls.Add(this.m_lbInfo);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(211, 152);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_llbChinesTradicional
			// 
			this.m_llbChinesTradicional.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llbChinesTradicional.Location = new System.Drawing.Point(40, 74);
			this.m_llbChinesTradicional.Name = "m_llbChinesTradicional";
			this.m_llbChinesTradicional.Size = new System.Drawing.Size(136, 16);
			this.m_llbChinesTradicional.TabIndex = 29;
			this.m_llbChinesTradicional.TabStop = true;
			this.m_llbChinesTradicional.Text = "Chinês Simplificado";
			this.m_llbChinesTradicional.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llbChinesTradicional_LinkClicked);
			// 
			// m_lbArabe
			// 
			this.m_lbArabe.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbArabe.Location = new System.Drawing.Point(40, 95);
			this.m_lbArabe.Name = "m_lbArabe";
			this.m_lbArabe.Size = new System.Drawing.Size(112, 15);
			this.m_lbArabe.TabIndex = 28;
			this.m_lbArabe.Text = "Árabe";
			this.m_lbArabe.Visible = false;
			// 
			// m_btArabe
			// 
			this.m_btArabe.Image = ((System.Drawing.Image)(resources.GetObject("m_btArabe.Image")));
			this.m_btArabe.Location = new System.Drawing.Point(9, 91);
			this.m_btArabe.Name = "m_btArabe";
			this.m_btArabe.Size = new System.Drawing.Size(20, 20);
			this.m_btArabe.TabIndex = 26;
			this.m_btArabe.Visible = false;
			// 
			// m_btChinesTradicional
			// 
			this.m_btChinesTradicional.Image = ((System.Drawing.Image)(resources.GetObject("m_btChinesTradicional.Image")));
			this.m_btChinesTradicional.Location = new System.Drawing.Point(9, 69);
			this.m_btChinesTradicional.Name = "m_btChinesTradicional";
			this.m_btChinesTradicional.Size = new System.Drawing.Size(20, 20);
			this.m_btChinesTradicional.TabIndex = 25;
			this.m_btChinesTradicional.Click += new System.EventHandler(this.m_btChinesTradicional_Click);
			// 
			// m_lbInfo
			// 
			this.m_lbInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInfo.Location = new System.Drawing.Point(8, 12);
			this.m_lbInfo.Name = "m_lbInfo";
			this.m_lbInfo.Size = new System.Drawing.Size(200, 52);
			this.m_lbInfo.TabIndex = 10;
			this.m_lbInfo.Text = "Os seguintes idiomas se encontram indisponíveis no seu sistema operacional. Cliqu" +
				"e no respectivo idioma para maiores informações.";
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(75, 117);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 9;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilBandeiras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBandeiras.ImageStream")));
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// frmFIdiomasIndisponiveis
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(218, 152);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFIdiomasIndisponiveis";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Idiomas Indisponíveis";
			this.Load += new System.EventHandler(this.frmFIdiomasIndisponiveis_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFIdiomasIndisponiveis_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					// Chines Tradicional
					m_btChinesTradicional.Visible = !OnCallIdiomaInstaladoChinesTradicional();
					m_llbChinesTradicional.Visible = m_btChinesTradicional.Visible;
				}
			#endregion
			#region Link Labels
				private void m_llbChinesTradicional_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
				{
					OnCallIdiomaShowChinesTradicional();
				}
			#endregion
			#region Botoes
				private void m_btChinesTradicional_Click(object sender, System.EventArgs e)
				{
					OnCallIdiomaShowChinesTradicional();
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
					case "System.Windows.Forms.ListView":
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
