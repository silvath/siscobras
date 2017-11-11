using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosRomaneio.Formularios
{
	/// <summary>
	/// Summary description for frmFVolumeConfiguracoes.
	/// </summary>
	public class frmFVolumeConfiguracoes : System.Windows.Forms.Form
	{
		#region Constants
			private const string TEXTO_EMBALAGENS_SEM = "Escolha esta opção quando não houver embalagens intermediárias.";
			private const string TEXTO_EMBALAGENS_COM = "Escolha esta opção quando houver embalagens intermediárias.";
		#endregion
		#region Atributes
			private string m_strEnderecoExecutavel = "";
			private bool m_bModificado = false;
			private bool m_bEmbalagens = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbTipos;
			private System.Windows.Forms.GroupBox m_gbInformacoes;
			private System.Windows.Forms.TextBox m_txtInformacoes;
			private System.Windows.Forms.RadioButton m_rbEmbalagemIntermediariaCom;
			private System.Windows.Forms.RadioButton m_rbEmbalagemIntermediariaSem;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}

			public bool Embalagens
			{
				set
				{

					m_bEmbalagens = value;
					if (m_bEmbalagens)
					{
						m_txtInformacoes.Text = TEXTO_EMBALAGENS_COM;
						m_rbEmbalagemIntermediariaCom.Checked = true;
					}
					else
					{
						m_txtInformacoes.Text = TEXTO_EMBALAGENS_SEM;
						m_rbEmbalagemIntermediariaSem.Checked = true;
					}
				}
				get
				{
					return(m_bEmbalagens);
				}
			}
		#endregion
		#region Contructors and Destructors
			public frmFVolumeConfiguracoes(string strEnderecoExecutavel)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFVolumeConfiguracoes));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_txtInformacoes = new System.Windows.Forms.TextBox();
			this.m_gbTipos = new System.Windows.Forms.GroupBox();
			this.m_rbEmbalagemIntermediariaCom = new System.Windows.Forms.RadioButton();
			this.m_rbEmbalagemIntermediariaSem = new System.Windows.Forms.RadioButton();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbTipos.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbInformacoes);
			this.m_gbMain.Controls.Add(this.m_gbTipos);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(3, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(451, 391);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbInformacoes.Controls.Add(this.m_txtInformacoes);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(8, 240);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(440, 120);
			this.m_gbInformacoes.TabIndex = 10;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Informações";
			// 
			// m_txtInformacoes
			// 
			this.m_txtInformacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtInformacoes.Location = new System.Drawing.Point(8, 17);
			this.m_txtInformacoes.Multiline = true;
			this.m_txtInformacoes.Name = "m_txtInformacoes";
			this.m_txtInformacoes.ReadOnly = true;
			this.m_txtInformacoes.Size = new System.Drawing.Size(424, 96);
			this.m_txtInformacoes.TabIndex = 0;
			this.m_txtInformacoes.Text = "";
			// 
			// m_gbTipos
			// 
			this.m_gbTipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbTipos.Controls.Add(this.m_rbEmbalagemIntermediariaCom);
			this.m_gbTipos.Controls.Add(this.m_rbEmbalagemIntermediariaSem);
			this.m_gbTipos.Location = new System.Drawing.Point(8, 7);
			this.m_gbTipos.Name = "m_gbTipos";
			this.m_gbTipos.Size = new System.Drawing.Size(440, 233);
			this.m_gbTipos.TabIndex = 9;
			this.m_gbTipos.TabStop = false;
			// 
			// m_rbEmbalagemIntermediariaCom
			// 
			this.m_rbEmbalagemIntermediariaCom.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_rbEmbalagemIntermediariaCom.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbEmbalagemIntermediariaCom.Image = ((System.Drawing.Image)(resources.GetObject("m_rbEmbalagemIntermediariaCom.Image")));
			this.m_rbEmbalagemIntermediariaCom.Location = new System.Drawing.Point(221, 12);
			this.m_rbEmbalagemIntermediariaCom.Name = "m_rbEmbalagemIntermediariaCom";
			this.m_rbEmbalagemIntermediariaCom.Size = new System.Drawing.Size(212, 212);
			this.m_rbEmbalagemIntermediariaCom.TabIndex = 2;
			this.m_rbEmbalagemIntermediariaCom.CheckedChanged += new System.EventHandler(this.m_rbEmbalagemIntermediariaCom_CheckedChanged);
			// 
			// m_rbEmbalagemIntermediariaSem
			// 
			this.m_rbEmbalagemIntermediariaSem.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_rbEmbalagemIntermediariaSem.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbEmbalagemIntermediariaSem.Image = ((System.Drawing.Image)(resources.GetObject("m_rbEmbalagemIntermediariaSem.Image")));
			this.m_rbEmbalagemIntermediariaSem.Location = new System.Drawing.Point(8, 12);
			this.m_rbEmbalagemIntermediariaSem.Name = "m_rbEmbalagemIntermediariaSem";
			this.m_rbEmbalagemIntermediariaSem.Size = new System.Drawing.Size(212, 212);
			this.m_rbEmbalagemIntermediariaSem.TabIndex = 1;
			this.m_rbEmbalagemIntermediariaSem.CheckedChanged += new System.EventHandler(this.m_rbEmbalagemIntermediariaSem_CheckedChanged);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(166, 363);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 7;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(230, 363);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 8;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFVolumeConfiguracoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 391);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFVolumeConfiguracoes";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configuração dos Volumes ";
			this.m_gbMain.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbTipos.ResumeLayout(false);
			this.ResumeLayout(false);

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
			#region RadioButtons
				private void m_rbEmbalagemIntermediariaSem_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbEmbalagemIntermediariaSem.Checked)
					{
						this.Embalagens = false;
						m_rbEmbalagemIntermediariaSem.BackColor = System.Drawing.Color.Green;
					}else{
						m_rbEmbalagemIntermediariaSem.BackColor = this.BackColor;
					}
				}

				private void m_rbEmbalagemIntermediariaCom_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbEmbalagemIntermediariaCom.Checked)
					{
						this.Embalagens = true;
						m_rbEmbalagemIntermediariaCom.BackColor = System.Drawing.Color.Green;
					}else{
						m_rbEmbalagemIntermediariaCom.BackColor = this.BackColor;
					}
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
