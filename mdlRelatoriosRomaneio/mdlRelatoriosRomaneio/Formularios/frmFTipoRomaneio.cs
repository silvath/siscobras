using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosRomaneio.Formularios
{
	/// <summary>
	/// Summary description for frmFTipoRomaneio.
	/// </summary>
	public class frmFTipoRomaneio : System.Windows.Forms.Form
	{
		#region Constants
			private const string TEXT_ROMANEIO_VOLUMES = " Recomenda-se o uso deste tipo de romaneio quando se quer ordenar por volumes.";
			private const string TEXT_ROMANEIO_PRODUTOS = " Recomenda-se o uso deste tipo de romaneio quando se quer ordenar por produtos.";
			private const string TEXT_ROMANEIO_SIMPLIFICADO = " Recomenda-se o uso deste tipo de romaneio quando não houver identificação de volumes.";
		#endregion
		#region Atributes
			private string m_strEnderecoExecutavel = "";
			private bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.RadioButton m_rbTipoRomaneioSimplificado;
			private System.Windows.Forms.RadioButton m_rbTipoRomaneioVolumes;
			private System.Windows.Forms.RadioButton m_rbTipoRomaneioProdutos;
			private System.Windows.Forms.GroupBox m_gbInformacoes;
			private System.Windows.Forms.TextBox m_txtInformacoes;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbTipo;
			private System.ComponentModel.Container components = null;

			private int m_nIdTipoRomaneio = -1;
		#endregion
		#region Properties
			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}

			public int TipoRomaneio
			{
				set
				{
					if (value != m_nIdTipoRomaneio)
					{
						switch(value)
						{
							case (int)mdlConstantes.Relatorio.Romaneio:
								m_txtInformacoes.Text = TEXT_ROMANEIO_PRODUTOS;
								if (!m_rbTipoRomaneioProdutos.Checked)
									m_rbTipoRomaneioProdutos.Checked = true;
								break;
							case (int)mdlConstantes.Relatorio.RomaneioVolumes:
								m_txtInformacoes.Text = TEXT_ROMANEIO_VOLUMES;
								if (!m_rbTipoRomaneioVolumes.Checked)
									m_rbTipoRomaneioVolumes.Checked = true;
								break;
							case (int)mdlConstantes.Relatorio.RomaneioSimplificado:
								m_txtInformacoes.Text = TEXT_ROMANEIO_SIMPLIFICADO;
								if (!m_rbTipoRomaneioSimplificado.Checked)
									m_rbTipoRomaneioSimplificado.Checked = true;
								break;
							default:
								m_txtInformacoes.Text = "";
								break;
						}
						m_nIdTipoRomaneio = value;
					}
				}
				get
				{
					return(m_nIdTipoRomaneio);
				}
			}
		#endregion
		#region Constructors and Destructors
		public frmFTipoRomaneio(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFTipoRomaneio));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_txtInformacoes = new System.Windows.Forms.TextBox();
			this.m_gbTipo = new System.Windows.Forms.GroupBox();
			this.m_rbTipoRomaneioProdutos = new System.Windows.Forms.RadioButton();
			this.m_rbTipoRomaneioVolumes = new System.Windows.Forms.RadioButton();
			this.m_rbTipoRomaneioSimplificado = new System.Windows.Forms.RadioButton();
			this.m_gbMain.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbTipo.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_gbInformacoes);
			this.m_gbMain.Controls.Add(this.m_gbTipo);
			this.m_gbMain.Location = new System.Drawing.Point(3, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(340, 542);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(109, 511);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(173, 511);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbInformacoes.Controls.Add(this.m_txtInformacoes);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(8, 389);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(328, 120);
			this.m_gbInformacoes.TabIndex = 1;
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
			this.m_txtInformacoes.Size = new System.Drawing.Size(312, 96);
			this.m_txtInformacoes.TabIndex = 0;
			this.m_txtInformacoes.Text = "";
			// 
			// m_gbTipo
			// 
			this.m_gbTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbTipo.Controls.Add(this.m_rbTipoRomaneioProdutos);
			this.m_gbTipo.Controls.Add(this.m_rbTipoRomaneioVolumes);
			this.m_gbTipo.Controls.Add(this.m_rbTipoRomaneioSimplificado);
			this.m_gbTipo.Location = new System.Drawing.Point(8, 6);
			this.m_gbTipo.Name = "m_gbTipo";
			this.m_gbTipo.Size = new System.Drawing.Size(328, 382);
			this.m_gbTipo.TabIndex = 0;
			this.m_gbTipo.TabStop = false;
			// 
			// m_rbTipoRomaneioProdutos
			// 
			this.m_rbTipoRomaneioProdutos.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_rbTipoRomaneioProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbTipoRomaneioProdutos.Image = ((System.Drawing.Image)(resources.GetObject("m_rbTipoRomaneioProdutos.Image")));
			this.m_rbTipoRomaneioProdutos.Location = new System.Drawing.Point(6, 132);
			this.m_rbTipoRomaneioProdutos.Name = "m_rbTipoRomaneioProdutos";
			this.m_rbTipoRomaneioProdutos.Size = new System.Drawing.Size(320, 120);
			this.m_rbTipoRomaneioProdutos.TabIndex = 2;
			this.m_rbTipoRomaneioProdutos.CheckedChanged += new System.EventHandler(this.m_rbTipoRomaneioProdutos_CheckedChanged);
			// 
			// m_rbTipoRomaneioVolumes
			// 
			this.m_rbTipoRomaneioVolumes.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_rbTipoRomaneioVolumes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbTipoRomaneioVolumes.Image = ((System.Drawing.Image)(resources.GetObject("m_rbTipoRomaneioVolumes.Image")));
			this.m_rbTipoRomaneioVolumes.Location = new System.Drawing.Point(6, 256);
			this.m_rbTipoRomaneioVolumes.Name = "m_rbTipoRomaneioVolumes";
			this.m_rbTipoRomaneioVolumes.Size = new System.Drawing.Size(320, 120);
			this.m_rbTipoRomaneioVolumes.TabIndex = 1;
			this.m_rbTipoRomaneioVolumes.CheckedChanged += new System.EventHandler(this.m_rbTipoRomaneioVolumes_CheckedChanged);
			// 
			// m_rbTipoRomaneioSimplificado
			// 
			this.m_rbTipoRomaneioSimplificado.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_rbTipoRomaneioSimplificado.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbTipoRomaneioSimplificado.Image = ((System.Drawing.Image)(resources.GetObject("m_rbTipoRomaneioSimplificado.Image")));
			this.m_rbTipoRomaneioSimplificado.Location = new System.Drawing.Point(6, 11);
			this.m_rbTipoRomaneioSimplificado.Name = "m_rbTipoRomaneioSimplificado";
			this.m_rbTipoRomaneioSimplificado.Size = new System.Drawing.Size(320, 120);
			this.m_rbTipoRomaneioSimplificado.TabIndex = 0;
			this.m_rbTipoRomaneioSimplificado.CheckedChanged += new System.EventHandler(this.m_rbTipoRomaneioSimplificado_CheckedChanged);
			// 
			// frmFTipoRomaneio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(346, 545);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFTipoRomaneio";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Tipo Romaneio";
			this.m_gbMain.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbTipo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (this.TipoRomaneio != -1)
					{
						m_bModificado = true;
						this.Close();
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
			#region RadioButtons
				private void m_rbTipoRomaneioSimplificado_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbTipoRomaneioSimplificado.Checked)
					{
						this.TipoRomaneio = (int)mdlConstantes.Relatorio.RomaneioSimplificado;
						m_rbTipoRomaneioSimplificado.BackColor = System.Drawing.Color.Green;
					}else{
						m_rbTipoRomaneioSimplificado.BackColor = this.BackColor;
					}
				}
				private void m_rbTipoRomaneioProdutos_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbTipoRomaneioProdutos.Checked)
					{
						this.TipoRomaneio = (int)mdlConstantes.Relatorio.Romaneio;
						m_rbTipoRomaneioProdutos.BackColor = System.Drawing.Color.Green;
					}else{
						m_rbTipoRomaneioProdutos.BackColor = this.BackColor;
					}
				}

				private void m_rbTipoRomaneioVolumes_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbTipoRomaneioVolumes.Checked)
					{
						this.TipoRomaneio = (int)mdlConstantes.Relatorio.RomaneioVolumes;
						m_rbTipoRomaneioVolumes.BackColor = System.Drawing.Color.Green;
					}else{
						m_rbTipoRomaneioVolumes.BackColor = this.BackColor;
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
