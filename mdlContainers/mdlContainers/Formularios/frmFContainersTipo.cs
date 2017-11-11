using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlContainers.Formularios
{
	/// <summary>
	/// Summary description for frmFContainersTipo.
	/// </summary>
	internal class frmFContainersTipo : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallContainersTipoRefresh(ref System.Windows.Forms.ListView lvContainersTipo);
			public delegate bool delCallContainersInformacao(int nIdContainerTipo,out string strInformacao);
		#endregion
		#region Events
			public event delCallContainersTipoRefresh eCallContainersTipoRefresh;
			public event delCallContainersInformacao eCallContainersInformacao;
		#endregion
		#region Events Methods
			public virtual void OnCallContainersTipoRefresh() 
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallContainersTipoRefresh != null)
					eCallContainersTipoRefresh(ref m_lvContainersTipo);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual void OnCallContainersInformacao() 
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				string strInformacao = "";
				if ((eCallContainersInformacao != null) && (m_lvContainersTipo.SelectedItems.Count > 0))
					eCallContainersInformacao(Int32.Parse(m_lvContainersTipo.SelectedItems[0].Tag.ToString()),out strInformacao);
				m_txtContainer.Text = strInformacao;
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region Atributes
			public bool m_bModificado = false;
			private int m_nIdContainerTipo = -1;

			private string m_strEnderecoExecutavel = "";

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbContainersTipo;
			public System.Windows.Forms.Button m_btOk;
			public System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbContainersLista;
			private System.Windows.Forms.ListView m_lvContainersTipo;
			private System.Windows.Forms.GroupBox m_gbContainerInformacoes;
			private System.Windows.Forms.GroupBox m_gbContainerImagem;
			private System.Windows.Forms.PictureBox m_picContainer;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.TextBox m_txtContainer;
			private System.Windows.Forms.ColumnHeader m_colhNome;
			private System.Windows.Forms.ImageList m_ilContainers;
		private System.Windows.Forms.Label m_lbInformacao;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmFContainersTipo(string strEnderecoExecutavel,int nIdContainerTipo)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdContainerTipo = nIdContainerTipo;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFContainersTipo));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbContainersTipo = new System.Windows.Forms.GroupBox();
			this.m_lbInformacao = new System.Windows.Forms.Label();
			this.m_gbContainerInformacoes = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_txtContainer = new System.Windows.Forms.TextBox();
			this.m_gbContainerImagem = new System.Windows.Forms.GroupBox();
			this.m_picContainer = new System.Windows.Forms.PictureBox();
			this.m_gbContainersLista = new System.Windows.Forms.GroupBox();
			this.m_lvContainersTipo = new System.Windows.Forms.ListView();
			this.m_colhNome = new System.Windows.Forms.ColumnHeader();
			this.m_ilContainers = new System.Windows.Forms.ImageList(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbContainersTipo.SuspendLayout();
			this.m_gbContainerInformacoes.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.m_gbContainerImagem.SuspendLayout();
			this.m_gbContainersLista.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbContainersTipo);
			this.m_gbGeral.Location = new System.Drawing.Point(5, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(496, 503);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(185, 474);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 29;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(249, 474);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 30;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbContainersTipo
			// 
			this.m_gbContainersTipo.Controls.Add(this.m_lbInformacao);
			this.m_gbContainersTipo.Controls.Add(this.m_gbContainerInformacoes);
			this.m_gbContainersTipo.Controls.Add(this.m_gbContainersLista);
			this.m_gbContainersTipo.Location = new System.Drawing.Point(7, 8);
			this.m_gbContainersTipo.Name = "m_gbContainersTipo";
			this.m_gbContainersTipo.Size = new System.Drawing.Size(481, 460);
			this.m_gbContainersTipo.TabIndex = 0;
			this.m_gbContainersTipo.TabStop = false;
			// 
			// m_lbInformacao
			// 
			this.m_lbInformacao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInformacao.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbInformacao.Location = new System.Drawing.Point(96, 424);
			this.m_lbInformacao.Name = "m_lbInformacao";
			this.m_lbInformacao.Size = new System.Drawing.Size(328, 32);
			this.m_lbInformacao.TabIndex = 5;
			this.m_lbInformacao.Text = "As informações referentes as medidas dos containers podem variar de acordo com o " +
				"fabricante do container.";
			// 
			// m_gbContainerInformacoes
			// 
			this.m_gbContainerInformacoes.Controls.Add(this.groupBox1);
			this.m_gbContainerInformacoes.Controls.Add(this.m_gbContainerImagem);
			this.m_gbContainerInformacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbContainerInformacoes.Location = new System.Drawing.Point(186, 8);
			this.m_gbContainerInformacoes.Name = "m_gbContainerInformacoes";
			this.m_gbContainerInformacoes.Size = new System.Drawing.Size(286, 416);
			this.m_gbContainerInformacoes.TabIndex = 1;
			this.m_gbContainerInformacoes.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_txtContainer);
			this.groupBox1.Location = new System.Drawing.Point(7, 287);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 121);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Informação";
			// 
			// m_txtContainer
			// 
			this.m_txtContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtContainer.Location = new System.Drawing.Point(7, 16);
			this.m_txtContainer.Multiline = true;
			this.m_txtContainer.Name = "m_txtContainer";
			this.m_txtContainer.ReadOnly = true;
			this.m_txtContainer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtContainer.Size = new System.Drawing.Size(255, 95);
			this.m_txtContainer.TabIndex = 2;
			this.m_txtContainer.Text = "";
			// 
			// m_gbContainerImagem
			// 
			this.m_gbContainerImagem.Controls.Add(this.m_picContainer);
			this.m_gbContainerImagem.Location = new System.Drawing.Point(7, 7);
			this.m_gbContainerImagem.Name = "m_gbContainerImagem";
			this.m_gbContainerImagem.Size = new System.Drawing.Size(273, 281);
			this.m_gbContainerImagem.TabIndex = 2;
			this.m_gbContainerImagem.TabStop = false;
			this.m_gbContainerImagem.Text = "Imagem";
			// 
			// m_picContainer
			// 
			this.m_picContainer.BackColor = System.Drawing.Color.White;
			this.m_picContainer.Image = ((System.Drawing.Image)(resources.GetObject("m_picContainer.Image")));
			this.m_picContainer.Location = new System.Drawing.Point(9, 16);
			this.m_picContainer.Name = "m_picContainer";
			this.m_picContainer.Size = new System.Drawing.Size(256, 256);
			this.m_picContainer.TabIndex = 1;
			this.m_picContainer.TabStop = false;
			// 
			// m_gbContainersLista
			// 
			this.m_gbContainersLista.Controls.Add(this.m_lvContainersTipo);
			this.m_gbContainersLista.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbContainersLista.Location = new System.Drawing.Point(8, 8);
			this.m_gbContainersLista.Name = "m_gbContainersLista";
			this.m_gbContainersLista.Size = new System.Drawing.Size(176, 416);
			this.m_gbContainersLista.TabIndex = 0;
			this.m_gbContainersLista.TabStop = false;
			this.m_gbContainersLista.Text = "Lista";
			// 
			// m_lvContainersTipo
			// 
			this.m_lvContainersTipo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.m_colhNome});
			this.m_lvContainersTipo.Location = new System.Drawing.Point(8, 16);
			this.m_lvContainersTipo.Name = "m_lvContainersTipo";
			this.m_lvContainersTipo.Size = new System.Drawing.Size(160, 392);
			this.m_lvContainersTipo.TabIndex = 0;
			this.m_lvContainersTipo.View = System.Windows.Forms.View.Details;
			this.m_lvContainersTipo.SelectedIndexChanged += new System.EventHandler(this.m_lvContainersTipo_SelectedIndexChanged);
			// 
			// m_colhNome
			// 
			this.m_colhNome.Text = "Nome";
			this.m_colhNome.Width = 150;
			// 
			// m_ilContainers
			// 
			this.m_ilContainers.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.m_ilContainers.ImageSize = new System.Drawing.Size(256, 256);
			this.m_ilContainers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilContainers.ImageStream")));
			this.m_ilContainers.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// frmFContainersTipo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(506, 503);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFContainersTipo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tipos de Containers";
			this.Load += new System.EventHandler(this.frmFContainersTipo_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbContainersTipo.ResumeLayout(false);
			this.m_gbContainerInformacoes.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.m_gbContainerImagem.ResumeLayout(false);
			this.m_gbContainersLista.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFContainersTipo_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallContainersTipoRefresh();
					foreach(System.Windows.Forms.ListViewItem lviContainerTipo in m_lvContainersTipo.Items)
					{
						if (Int32.Parse(lviContainerTipo.Tag.ToString()) == m_nIdContainerTipo)
						{
							lviContainerTipo.Selected = true;
							break;
						}
					}
				}
			#endregion
			#region ListView
				private void m_lvContainersTipo_SelectedIndexChanged(object sender, System.EventArgs e)
				{
					if (m_lvContainersTipo.SelectedItems.Count > 0)
					{
						m_picContainer.Image = m_ilContainers.Images[Int32.Parse(m_lvContainersTipo.SelectedItems[0].Tag.ToString())];
					}
					OnCallContainersInformacao();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_bModificado = m_lvContainersTipo.SelectedItems.Count > 0)
					{
						m_nIdContainerTipo = Int32.Parse(m_lvContainersTipo.SelectedItems[0].Tag.ToString());
						this.Close();
					}
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
					case "System.Windows.Forms.ListView":
					case "mdlComponentesGraficos.ComboBox":
					case "System.Windows.Forms.TextBox":
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

		#region Retorna Valores
			public void vRetornaValores(out int nIdContainerTipo)
			{
				nIdContainerTipo = m_nIdContainerTipo;
			}
		#endregion
	}
}
