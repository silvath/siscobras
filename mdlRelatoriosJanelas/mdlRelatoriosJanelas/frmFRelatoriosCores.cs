using System;

namespace mdlRelatoriosJanelas
{
	/// <summary>
	/// Summary description for frmFRelatoriosCores.
	/// </summary>
	public class frmFRelatoriosCores : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
		private string m_strEnderecoExecutavel; 
		private System.Drawing.Color m_corCaneta; 
		private System.Drawing.Color m_corCampoBD;  
		private System.Drawing.Color m_corObjetosFocados; 
		private System.Drawing.Color m_corObjetosNaoImpressos; 
		private System.Drawing.Color m_corAreaProdutos; 
		private System.Drawing.Color m_corMargem;
		private System.Drawing.Color m_corFundo; 
		public bool m_bModificado; 

		internal System.Windows.Forms.GroupBox m_gbGeral;
		internal System.Windows.Forms.PictureBox m_picFundo;
		internal System.Windows.Forms.PictureBox m_picMargens;
		internal System.Windows.Forms.PictureBox m_picAreaProdutos;
		internal System.Windows.Forms.PictureBox m_picObjetosNImpressos;
		internal System.Windows.Forms.PictureBox m_picObjetosFocados;
		internal System.Windows.Forms.PictureBox m_picTextoDinamico;
		internal System.Windows.Forms.PictureBox m_picCaneta;
		internal System.Windows.Forms.Label m_lbFundo;
		internal System.Windows.Forms.Label m_lbMargem;
		internal System.Windows.Forms.Label m_lbAreaProdutos;
		internal System.Windows.Forms.Label m_lbObjetosNaoImpressos;
		internal System.Windows.Forms.Label m_lbObjetosFocados;
		internal System.Windows.Forms.Label m_lbTextoDinamico;
		internal System.Windows.Forms.Button m_btCorMargem;
		internal System.Windows.Forms.Button m_btCorFundo;
		internal System.Windows.Forms.Button m_btCorAreaProdutos;
		internal System.Windows.Forms.Button m_btObjetoNaoImpresso;
		internal System.Windows.Forms.Button m_btCorObjetoFocado;
		internal System.Windows.Forms.Button m_btCorCampoBD;
		internal System.Windows.Forms.Label m_lbCaneta;
		internal System.Windows.Forms.Button m_btCorCaneta;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		#endregion
		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRelatoriosCores));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_picFundo = new System.Windows.Forms.PictureBox();
			this.m_picMargens = new System.Windows.Forms.PictureBox();
			this.m_picAreaProdutos = new System.Windows.Forms.PictureBox();
			this.m_picObjetosNImpressos = new System.Windows.Forms.PictureBox();
			this.m_picObjetosFocados = new System.Windows.Forms.PictureBox();
			this.m_picTextoDinamico = new System.Windows.Forms.PictureBox();
			this.m_picCaneta = new System.Windows.Forms.PictureBox();
			this.m_lbFundo = new System.Windows.Forms.Label();
			this.m_lbMargem = new System.Windows.Forms.Label();
			this.m_lbAreaProdutos = new System.Windows.Forms.Label();
			this.m_lbObjetosNaoImpressos = new System.Windows.Forms.Label();
			this.m_lbObjetosFocados = new System.Windows.Forms.Label();
			this.m_lbTextoDinamico = new System.Windows.Forms.Label();
			this.m_btCorMargem = new System.Windows.Forms.Button();
			this.m_btCorFundo = new System.Windows.Forms.Button();
			this.m_btCorAreaProdutos = new System.Windows.Forms.Button();
			this.m_btObjetoNaoImpresso = new System.Windows.Forms.Button();
			this.m_btCorObjetoFocado = new System.Windows.Forms.Button();
			this.m_btCorCampoBD = new System.Windows.Forms.Button();
			this.m_lbCaneta = new System.Windows.Forms.Label();
			this.m_btCorCaneta = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_picFundo);
			this.m_gbGeral.Controls.Add(this.m_picMargens);
			this.m_gbGeral.Controls.Add(this.m_picAreaProdutos);
			this.m_gbGeral.Controls.Add(this.m_picObjetosNImpressos);
			this.m_gbGeral.Controls.Add(this.m_picObjetosFocados);
			this.m_gbGeral.Controls.Add(this.m_picTextoDinamico);
			this.m_gbGeral.Controls.Add(this.m_picCaneta);
			this.m_gbGeral.Controls.Add(this.m_lbFundo);
			this.m_gbGeral.Controls.Add(this.m_lbMargem);
			this.m_gbGeral.Controls.Add(this.m_lbAreaProdutos);
			this.m_gbGeral.Controls.Add(this.m_lbObjetosNaoImpressos);
			this.m_gbGeral.Controls.Add(this.m_lbObjetosFocados);
			this.m_gbGeral.Controls.Add(this.m_lbTextoDinamico);
			this.m_gbGeral.Controls.Add(this.m_btCorMargem);
			this.m_gbGeral.Controls.Add(this.m_btCorFundo);
			this.m_gbGeral.Controls.Add(this.m_btCorAreaProdutos);
			this.m_gbGeral.Controls.Add(this.m_btObjetoNaoImpresso);
			this.m_gbGeral.Controls.Add(this.m_btCorObjetoFocado);
			this.m_gbGeral.Controls.Add(this.m_btCorCampoBD);
			this.m_gbGeral.Controls.Add(this.m_lbCaneta);
			this.m_gbGeral.Controls.Add(this.m_btCorCaneta);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(8, 8);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(200, 240);
			this.m_gbGeral.TabIndex = 3;
			this.m_gbGeral.TabStop = false;
			// 
			// m_picFundo
			// 
			this.m_picFundo.Image = ((System.Drawing.Image)(resources.GetObject("m_picFundo.Image")));
			this.m_picFundo.Location = new System.Drawing.Point(40, 181);
			this.m_picFundo.Name = "m_picFundo";
			this.m_picFundo.Size = new System.Drawing.Size(16, 16);
			this.m_picFundo.TabIndex = 88;
			this.m_picFundo.TabStop = false;
			// 
			// m_picMargens
			// 
			this.m_picMargens.Image = ((System.Drawing.Image)(resources.GetObject("m_picMargens.Image")));
			this.m_picMargens.Location = new System.Drawing.Point(40, 154);
			this.m_picMargens.Name = "m_picMargens";
			this.m_picMargens.Size = new System.Drawing.Size(16, 16);
			this.m_picMargens.TabIndex = 87;
			this.m_picMargens.TabStop = false;
			// 
			// m_picAreaProdutos
			// 
			this.m_picAreaProdutos.Image = ((System.Drawing.Image)(resources.GetObject("m_picAreaProdutos.Image")));
			this.m_picAreaProdutos.Location = new System.Drawing.Point(40, 127);
			this.m_picAreaProdutos.Name = "m_picAreaProdutos";
			this.m_picAreaProdutos.Size = new System.Drawing.Size(16, 16);
			this.m_picAreaProdutos.TabIndex = 86;
			this.m_picAreaProdutos.TabStop = false;
			// 
			// m_picObjetosNImpressos
			// 
			this.m_picObjetosNImpressos.Image = ((System.Drawing.Image)(resources.GetObject("m_picObjetosNImpressos.Image")));
			this.m_picObjetosNImpressos.Location = new System.Drawing.Point(40, 100);
			this.m_picObjetosNImpressos.Name = "m_picObjetosNImpressos";
			this.m_picObjetosNImpressos.Size = new System.Drawing.Size(16, 16);
			this.m_picObjetosNImpressos.TabIndex = 85;
			this.m_picObjetosNImpressos.TabStop = false;
			// 
			// m_picObjetosFocados
			// 
			this.m_picObjetosFocados.Image = ((System.Drawing.Image)(resources.GetObject("m_picObjetosFocados.Image")));
			this.m_picObjetosFocados.Location = new System.Drawing.Point(40, 73);
			this.m_picObjetosFocados.Name = "m_picObjetosFocados";
			this.m_picObjetosFocados.Size = new System.Drawing.Size(16, 16);
			this.m_picObjetosFocados.TabIndex = 84;
			this.m_picObjetosFocados.TabStop = false;
			// 
			// m_picTextoDinamico
			// 
			this.m_picTextoDinamico.Image = ((System.Drawing.Image)(resources.GetObject("m_picTextoDinamico.Image")));
			this.m_picTextoDinamico.Location = new System.Drawing.Point(40, 46);
			this.m_picTextoDinamico.Name = "m_picTextoDinamico";
			this.m_picTextoDinamico.Size = new System.Drawing.Size(16, 16);
			this.m_picTextoDinamico.TabIndex = 83;
			this.m_picTextoDinamico.TabStop = false;
			// 
			// m_picCaneta
			// 
			this.m_picCaneta.Image = ((System.Drawing.Image)(resources.GetObject("m_picCaneta.Image")));
			this.m_picCaneta.Location = new System.Drawing.Point(39, 19);
			this.m_picCaneta.Name = "m_picCaneta";
			this.m_picCaneta.Size = new System.Drawing.Size(16, 16);
			this.m_picCaneta.TabIndex = 82;
			this.m_picCaneta.TabStop = false;
			// 
			// m_lbFundo
			// 
			this.m_lbFundo.Location = new System.Drawing.Point(62, 182);
			this.m_lbFundo.Name = "m_lbFundo";
			this.m_lbFundo.Size = new System.Drawing.Size(120, 16);
			this.m_lbFundo.TabIndex = 81;
			this.m_lbFundo.Text = "Fundo";
			// 
			// m_lbMargem
			// 
			this.m_lbMargem.Location = new System.Drawing.Point(62, 155);
			this.m_lbMargem.Name = "m_lbMargem";
			this.m_lbMargem.Size = new System.Drawing.Size(120, 16);
			this.m_lbMargem.TabIndex = 80;
			this.m_lbMargem.Text = "Margens";
			// 
			// m_lbAreaProdutos
			// 
			this.m_lbAreaProdutos.Location = new System.Drawing.Point(62, 128);
			this.m_lbAreaProdutos.Name = "m_lbAreaProdutos";
			this.m_lbAreaProdutos.Size = new System.Drawing.Size(120, 16);
			this.m_lbAreaProdutos.TabIndex = 79;
			this.m_lbAreaProdutos.Text = "Área Composta";
			// 
			// m_lbObjetosNaoImpressos
			// 
			this.m_lbObjetosNaoImpressos.Location = new System.Drawing.Point(62, 101);
			this.m_lbObjetosNaoImpressos.Name = "m_lbObjetosNaoImpressos";
			this.m_lbObjetosNaoImpressos.Size = new System.Drawing.Size(122, 16);
			this.m_lbObjetosNaoImpressos.TabIndex = 78;
			this.m_lbObjetosNaoImpressos.Text = "Objetos não impressos";
			// 
			// m_lbObjetosFocados
			// 
			this.m_lbObjetosFocados.Location = new System.Drawing.Point(62, 74);
			this.m_lbObjetosFocados.Name = "m_lbObjetosFocados";
			this.m_lbObjetosFocados.Size = new System.Drawing.Size(120, 16);
			this.m_lbObjetosFocados.TabIndex = 77;
			this.m_lbObjetosFocados.Text = "Objetos focados";
			// 
			// m_lbTextoDinamico
			// 
			this.m_lbTextoDinamico.Location = new System.Drawing.Point(62, 47);
			this.m_lbTextoDinamico.Name = "m_lbTextoDinamico";
			this.m_lbTextoDinamico.Size = new System.Drawing.Size(133, 16);
			this.m_lbTextoDinamico.TabIndex = 76;
			this.m_lbTextoDinamico.Text = "Textos Dinâmicos";
			// 
			// m_btCorMargem
			// 
			this.m_btCorMargem.Location = new System.Drawing.Point(12, 150);
			this.m_btCorMargem.Name = "m_btCorMargem";
			this.m_btCorMargem.Size = new System.Drawing.Size(24, 24);
			this.m_btCorMargem.TabIndex = 75;
			this.m_btCorMargem.Click += new System.EventHandler(this.m_btCorMargem_Click);
			// 
			// m_btCorFundo
			// 
			this.m_btCorFundo.Location = new System.Drawing.Point(12, 177);
			this.m_btCorFundo.Name = "m_btCorFundo";
			this.m_btCorFundo.Size = new System.Drawing.Size(24, 24);
			this.m_btCorFundo.TabIndex = 74;
			this.m_btCorFundo.Click += new System.EventHandler(this.m_btCorFundo_Click);
			// 
			// m_btCorAreaProdutos
			// 
			this.m_btCorAreaProdutos.Location = new System.Drawing.Point(12, 123);
			this.m_btCorAreaProdutos.Name = "m_btCorAreaProdutos";
			this.m_btCorAreaProdutos.Size = new System.Drawing.Size(24, 24);
			this.m_btCorAreaProdutos.TabIndex = 73;
			this.m_btCorAreaProdutos.Click += new System.EventHandler(this.m_btCorAreaProdutos_Click);
			// 
			// m_btObjetoNaoImpresso
			// 
			this.m_btObjetoNaoImpresso.Location = new System.Drawing.Point(12, 96);
			this.m_btObjetoNaoImpresso.Name = "m_btObjetoNaoImpresso";
			this.m_btObjetoNaoImpresso.Size = new System.Drawing.Size(24, 24);
			this.m_btObjetoNaoImpresso.TabIndex = 72;
			this.m_btObjetoNaoImpresso.Click += new System.EventHandler(this.m_btObjetoNaoImpresso_Click);
			// 
			// m_btCorObjetoFocado
			// 
			this.m_btCorObjetoFocado.Location = new System.Drawing.Point(12, 69);
			this.m_btCorObjetoFocado.Name = "m_btCorObjetoFocado";
			this.m_btCorObjetoFocado.Size = new System.Drawing.Size(24, 24);
			this.m_btCorObjetoFocado.TabIndex = 71;
			this.m_btCorObjetoFocado.Click += new System.EventHandler(this.m_btCorObjetoFocado_Click);
			// 
			// m_btCorCampoBD
			// 
			this.m_btCorCampoBD.Location = new System.Drawing.Point(12, 42);
			this.m_btCorCampoBD.Name = "m_btCorCampoBD";
			this.m_btCorCampoBD.Size = new System.Drawing.Size(24, 24);
			this.m_btCorCampoBD.TabIndex = 70;
			this.m_btCorCampoBD.Click += new System.EventHandler(this.m_btCorCampoBD_Click);
			// 
			// m_lbCaneta
			// 
			this.m_lbCaneta.Location = new System.Drawing.Point(62, 20);
			this.m_lbCaneta.Name = "m_lbCaneta";
			this.m_lbCaneta.Size = new System.Drawing.Size(120, 16);
			this.m_lbCaneta.TabIndex = 69;
			this.m_lbCaneta.Text = "Traçado";
			// 
			// m_btCorCaneta
			// 
			this.m_btCorCaneta.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.m_btCorCaneta.Location = new System.Drawing.Point(12, 15);
			this.m_btCorCaneta.Name = "m_btCorCaneta";
			this.m_btCorCaneta.Size = new System.Drawing.Size(24, 24);
			this.m_btCorCaneta.TabIndex = 68;
			this.m_btCorCaneta.Click += new System.EventHandler(this.m_btCorCaneta_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(41, 208);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 66;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(105, 209);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 67;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFRelatoriosCores
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(216, 254);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosCores";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cores";
			this.Load += new System.EventHandler(this.frmFRelatoriosCores_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#region Constructors and Destructors
		public frmFRelatoriosCores(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string enderecoExecutavel ,System.Drawing.Color corCaneta, System.Drawing.Color corCampoBD, System.Drawing.Color corObjetosFocados, System.Drawing.Color corObjetosNaoImpressos, System.Drawing.Color corAreaProdutos, System.Drawing.Color corMargem,System.Drawing.Color corFundo)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = enderecoExecutavel;

			m_corCaneta = corCaneta;
			m_corCampoBD = corCampoBD;
			m_corObjetosFocados = corObjetosFocados;
			m_corObjetosNaoImpressos = corObjetosNaoImpressos;
			m_corAreaProdutos = corAreaProdutos;
			m_corMargem = corMargem;
			m_corFundo = corFundo;

			InitializeComponent();
		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFRelatoriosCores_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					RefreshInterface();
				}
			#endregion
			#region Botoes
				private void m_btCorCaneta_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.ColorDialog dlgColor = new System.Windows.Forms.ColorDialog();
		            dlgColor.FullOpen = true;
				    dlgColor.Color = m_corCaneta;
					if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK){
						m_corCaneta = dlgColor.Color;
						RefreshInterface();
					}
				}

				private void m_btCorCampoBD_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.ColorDialog dlgColor = new System.Windows.Forms.ColorDialog();
					dlgColor.FullOpen = true;
					dlgColor.Color = m_corCampoBD;
					if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						m_corCampoBD = dlgColor.Color;
						RefreshInterface();
					}
				}

				private void m_btCorObjetoFocado_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.ColorDialog dlgColor = new System.Windows.Forms.ColorDialog();
					dlgColor.FullOpen = true;
					dlgColor.Color = m_corObjetosFocados;
					if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						m_corObjetosFocados = dlgColor.Color;
						RefreshInterface();
					}
				}

				private void m_btObjetoNaoImpresso_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.ColorDialog dlgColor = new System.Windows.Forms.ColorDialog();
					dlgColor.FullOpen = true;
					dlgColor.Color = m_corObjetosNaoImpressos;
					if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						m_corObjetosNaoImpressos = dlgColor.Color;
						RefreshInterface();
					}
				}

				private void m_btCorAreaProdutos_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.ColorDialog dlgColor = new System.Windows.Forms.ColorDialog();
					dlgColor.FullOpen = true;
					dlgColor.Color = m_corAreaProdutos;
					if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						m_corAreaProdutos = dlgColor.Color;
						RefreshInterface();
					}
				}

				private void m_btCorMargem_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.ColorDialog dlgColor = new System.Windows.Forms.ColorDialog();
					dlgColor.FullOpen = true;
					dlgColor.Color = m_corMargem;
					if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						m_corMargem = dlgColor.Color;
						RefreshInterface();
					}
				}

				private void m_btCorFundo_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.ColorDialog dlgColor = new System.Windows.Forms.ColorDialog();
					dlgColor.FullOpen = true;
					dlgColor.Color = m_corFundo;
					if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						m_corFundo = dlgColor.Color;
						RefreshInterface();
					}
				}

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
		private void MostraCor()
		{
			mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
			this.BackColor = clsPaletaCores.retornaCorAtual();
			for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
			{
				this.Controls[nCont].BackColor = this.BackColor;
				for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
				{
					if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.ComboBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.TextBox"))
						this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

					for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
					{
						if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentes.compListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.TreeView"))
							this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
					}
				}
			}
		}
		#endregion

		#region Refreshs
		private void RefreshInterface()
		{
			m_btCorCaneta.BackColor = m_corCaneta;
			m_btCorCampoBD.BackColor = m_corCampoBD;
			m_btCorObjetoFocado.BackColor = m_corObjetosFocados;
			m_btObjetoNaoImpresso.BackColor = m_corObjetosNaoImpressos;
			m_btCorAreaProdutos.BackColor = m_corAreaProdutos;
			m_btCorMargem.BackColor = m_corMargem;
			m_btCorFundo.BackColor = m_corFundo;
		}
		#endregion

		#region Retorno
		public void RetornaValores(out System.Drawing.Color corCaneta,out System.Drawing.Color corCampoBD, out System.Drawing.Color corObjetosFocados, out System.Drawing.Color corObjetosNaoImpressos, out System.Drawing.Color corAreaProdutos, out System.Drawing.Color corMargem, out System.Drawing.Color corFundo)
		{
			corCaneta = m_corCaneta;
			corCampoBD = m_corCampoBD;
			corObjetosFocados = m_corObjetosFocados;
			corObjetosNaoImpressos = m_corObjetosNaoImpressos;
			corAreaProdutos = m_corAreaProdutos;
			corMargem = m_corMargem;
			corFundo = m_corFundo;
		}
		#endregion
	 }
}
