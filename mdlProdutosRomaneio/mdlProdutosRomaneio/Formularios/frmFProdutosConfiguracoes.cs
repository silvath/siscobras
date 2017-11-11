using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio.Formularios
{
	/// <summary>
	/// Summary description for frmFProdutosConfiguracoes.
	/// </summary>
	public class frmFProdutosConfiguracoes : System.Windows.Forms.Form
	{
		#region Atributes
			private string m_strEnderecoExecutavel = ""; 
			private bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbApresentar;
			private System.Windows.Forms.CheckBox m_ckMostrarVolumes;
			private System.Windows.Forms.CheckBox m_ckMostrarEmbalagens;
			private System.Windows.Forms.GroupBox m_gb;
			private System.Windows.Forms.RadioButton m_rbQuantidadeVolumesCom;
			private System.Windows.Forms.RadioButton m_rbQuantidadeVolumesSem;
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

			public bool MostrarQuantidadesVolumes
			{
				set
				{
					if (value)
					{
						if (!m_rbQuantidadeVolumesCom.Checked)
							m_rbQuantidadeVolumesCom.Checked = true;
					}
					else
					{
						if (!m_rbQuantidadeVolumesSem.Checked)
							m_rbQuantidadeVolumesSem.Checked = true;
					}
				}
				get
				{
					return(m_rbQuantidadeVolumesCom.Checked);
				}
			}

			public bool MostrarVolumesConsecutivos
			{
				set
				{
					m_ckMostrarVolumes.Checked = value;
				}
				get
				{
					return(m_ckMostrarVolumes.Checked);
				}
			}

			public bool MostrarEmbalagensConsecutivas
			{
				set
				{
					m_ckMostrarEmbalagens.Checked = value;
				}
				get
				{
					return(m_ckMostrarEmbalagens.Checked);
				}
			}
		#endregion
		#region Constructors and Destructors
			public frmFProdutosConfiguracoes(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosConfiguracoes));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gb = new System.Windows.Forms.GroupBox();
			this.m_rbQuantidadeVolumesCom = new System.Windows.Forms.RadioButton();
			this.m_rbQuantidadeVolumesSem = new System.Windows.Forms.RadioButton();
			this.m_gbApresentar = new System.Windows.Forms.GroupBox();
			this.m_ckMostrarVolumes = new System.Windows.Forms.CheckBox();
			this.m_ckMostrarEmbalagens = new System.Windows.Forms.CheckBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gb.SuspendLayout();
			this.m_gbApresentar.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gb);
			this.m_gbMain.Controls.Add(this.m_gbApresentar);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(4, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(219, 207);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gb
			// 
			this.m_gb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gb.Controls.Add(this.m_rbQuantidadeVolumesCom);
			this.m_gb.Controls.Add(this.m_rbQuantidadeVolumesSem);
			this.m_gb.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gb.Location = new System.Drawing.Point(7, 7);
			this.m_gb.Name = "m_gb";
			this.m_gb.Size = new System.Drawing.Size(209, 113);
			this.m_gb.TabIndex = 20;
			this.m_gb.TabStop = false;
			this.m_gb.Text = "Apresentação dos volumes";
			// 
			// m_rbQuantidadeVolumesCom
			// 
			this.m_rbQuantidadeVolumesCom.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_rbQuantidadeVolumesCom.Image = ((System.Drawing.Image)(resources.GetObject("m_rbQuantidadeVolumesCom.Image")));
			this.m_rbQuantidadeVolumesCom.Location = new System.Drawing.Point(11, 59);
			this.m_rbQuantidadeVolumesCom.Name = "m_rbQuantidadeVolumesCom";
			this.m_rbQuantidadeVolumesCom.Size = new System.Drawing.Size(186, 40);
			this.m_rbQuantidadeVolumesCom.TabIndex = 1;
			this.m_rbQuantidadeVolumesCom.CheckedChanged += new System.EventHandler(this.m_rbQuantidadeVolumesCom_CheckedChanged);
			// 
			// m_rbQuantidadeVolumesSem
			// 
			this.m_rbQuantidadeVolumesSem.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_rbQuantidadeVolumesSem.BackColor = System.Drawing.SystemColors.Control;
			this.m_rbQuantidadeVolumesSem.Image = ((System.Drawing.Image)(resources.GetObject("m_rbQuantidadeVolumesSem.Image")));
			this.m_rbQuantidadeVolumesSem.Location = new System.Drawing.Point(11, 17);
			this.m_rbQuantidadeVolumesSem.Name = "m_rbQuantidadeVolumesSem";
			this.m_rbQuantidadeVolumesSem.Size = new System.Drawing.Size(186, 40);
			this.m_rbQuantidadeVolumesSem.TabIndex = 0;
			this.m_rbQuantidadeVolumesSem.CheckedChanged += new System.EventHandler(this.m_rbQuantidadeVolumesSem_CheckedChanged);
			// 
			// m_gbApresentar
			// 
			this.m_gbApresentar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbApresentar.Controls.Add(this.m_ckMostrarVolumes);
			this.m_gbApresentar.Controls.Add(this.m_ckMostrarEmbalagens);
			this.m_gbApresentar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbApresentar.Location = new System.Drawing.Point(6, 120);
			this.m_gbApresentar.Name = "m_gbApresentar";
			this.m_gbApresentar.Size = new System.Drawing.Size(209, 55);
			this.m_gbApresentar.TabIndex = 19;
			this.m_gbApresentar.TabStop = false;
			this.m_gbApresentar.Text = "Apresentar";
			// 
			// m_ckMostrarVolumes
			// 
			this.m_ckMostrarVolumes.Location = new System.Drawing.Point(7, 15);
			this.m_ckMostrarVolumes.Name = "m_ckMostrarVolumes";
			this.m_ckMostrarVolumes.Size = new System.Drawing.Size(191, 16);
			this.m_ckMostrarVolumes.TabIndex = 0;
			this.m_ckMostrarVolumes.Text = "Volumes em todos os itens.";
			// 
			// m_ckMostrarEmbalagens
			// 
			this.m_ckMostrarEmbalagens.Location = new System.Drawing.Point(6, 32);
			this.m_ckMostrarEmbalagens.Name = "m_ckMostrarEmbalagens";
			this.m_ckMostrarEmbalagens.Size = new System.Drawing.Size(194, 16);
			this.m_ckMostrarEmbalagens.TabIndex = 1;
			this.m_ckMostrarEmbalagens.Text = "Embalagens em todos os itens.";
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(47, 179);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 8;
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
			this.m_btCancelar.Location = new System.Drawing.Point(111, 179);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 9;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFProdutosConfiguracoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(226, 207);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutosConfiguracoes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configurações";
			this.m_gbMain.ResumeLayout(false);
			this.m_gb.ResumeLayout(false);
			this.m_gbApresentar.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region RadioButtons
				private void m_rbQuantidadeVolumesSem_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbQuantidadeVolumesSem.Checked)
					{
						m_rbQuantidadeVolumesSem.BackColor = System.Drawing.Color.Green;
					}
					else
					{
						m_rbQuantidadeVolumesSem.BackColor = this.BackColor;
					}
				}

				private void m_rbQuantidadeVolumesCom_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbQuantidadeVolumesCom.Checked)
					{
						m_rbQuantidadeVolumesCom.BackColor = System.Drawing.Color.Green;
					}
					else
					{
						m_rbQuantidadeVolumesCom.BackColor = this.BackColor;
					}
				}
			#endregion
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

		#region Cores
			private void vMostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME,"SiscobrasCorSecundaria");
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
