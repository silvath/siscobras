using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRegistro
{
	/// <summary>
	/// Summary description for frmFRegistroCategoria.
	/// </summary>
	internal class frmFRegistroCategoria : mdlComponentesGraficos.FormFlutuante
	{
		#region Constantes
			private const string INFORMACAO_PJ_EXPORTADOR = "Trabalho em uma empresa exportadora.";
			private const string INFORMACAO_PJ_PRESTADORSERVICO = "Trabalho em uma empresa prestadora de serviços de comércio exterior: assessoria, consultoria, despacho aduaneiro, etc.";
			private const string INFORMACAO_PF_EXPORTADOR = "Não tenho empresa, mas realizo pequenas expotações, principalmente pelo correio.";
			private const string INFORMACAO_PF_PRESTADORSERVICO = "Presto serviços de comércio exterior. Porém não possuo empresa.";
			private const string INFORMACAO_AC_ESTUDANTE = "Sou estudante (Estudantes poderão utilizar o Siscobras gratuitamente, no entanto não será permitido usá-lo comercialmente, pois o sistema impõe restrições.)";
			private const string INFORMACAO_AC_PROFESSOR = "Sou professor (Professores poderão utilizar o Siscobras gratuitamente, no entanto não será permitido usá-lo comercialmente, pois o sistema impõe restrições.)";
		#endregion
		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = null;
			private string m_strEnderecoExecutavel = "";

			private mdlRegistro.RegistroClasse m_enumRegistroClasse = mdlRegistro.RegistroClasse.None;

			public bool m_bModificado = false;
        
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.RadioButton m_rbPJPrestadorServico;
			private System.Windows.Forms.RadioButton m_rbPJExportador;
			private System.Windows.Forms.RadioButton m_rbPFPrestadorServico;
			private System.Windows.Forms.RadioButton m_rbPFExportador;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.GroupBox m_gbPessoaFisica;
			private System.Windows.Forms.GroupBox m_gbComercial;
			private System.Windows.Forms.GroupBox m_gbImagem;
			private System.Windows.Forms.GroupBox m_gbInformacoes;
			private System.Windows.Forms.GroupBox m_gbAcademico;
			private System.Windows.Forms.TextBox m_txtInformacoes;
			private System.Windows.Forms.RadioButton m_rbACEstudante;
			private System.Windows.Forms.RadioButton m_rbACProfessor;
		private System.Windows.Forms.PictureBox m_picImagem;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors 
			public frmFRegistroCategoria(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,string strEnderecoExecutavel,mdlRegistro.RegistroClasse enumRegistroClasse)
			{
				m_cls_ter_TratadorErro = cls_ter_TratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_enumRegistroClasse = enumRegistroClasse;
				InitializeComponent();
			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRegistroCategoria));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbAcademico = new System.Windows.Forms.GroupBox();
			this.m_rbACEstudante = new System.Windows.Forms.RadioButton();
			this.m_rbACProfessor = new System.Windows.Forms.RadioButton();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_txtInformacoes = new System.Windows.Forms.TextBox();
			this.m_gbImagem = new System.Windows.Forms.GroupBox();
			this.m_picImagem = new System.Windows.Forms.PictureBox();
			this.m_gbComercial = new System.Windows.Forms.GroupBox();
			this.m_gbPessoaFisica = new System.Windows.Forms.GroupBox();
			this.m_rbPFExportador = new System.Windows.Forms.RadioButton();
			this.m_rbPFPrestadorServico = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_rbPJPrestadorServico = new System.Windows.Forms.RadioButton();
			this.m_rbPJExportador = new System.Windows.Forms.RadioButton();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbAcademico.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbImagem.SuspendLayout();
			this.m_gbComercial.SuspendLayout();
			this.m_gbPessoaFisica.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbAcademico);
			this.m_gbGeral.Controls.Add(this.m_gbInformacoes);
			this.m_gbGeral.Controls.Add(this.m_gbImagem);
			this.m_gbGeral.Controls.Add(this.m_gbComercial);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(4, 1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(436, 407);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbAcademico
			// 
			this.m_gbAcademico.Controls.Add(this.m_rbACEstudante);
			this.m_gbAcademico.Controls.Add(this.m_rbACProfessor);
			this.m_gbAcademico.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbAcademico.ForeColor = System.Drawing.Color.Maroon;
			this.m_gbAcademico.Location = new System.Drawing.Point(7, 306);
			this.m_gbAcademico.Name = "m_gbAcademico";
			this.m_gbAcademico.Size = new System.Drawing.Size(184, 64);
			this.m_gbAcademico.TabIndex = 19;
			this.m_gbAcademico.TabStop = false;
			this.m_gbAcademico.Text = "Versão Acadêmica";
			// 
			// m_rbACEstudante
			// 
			this.m_rbACEstudante.ForeColor = System.Drawing.Color.Black;
			this.m_rbACEstudante.Location = new System.Drawing.Point(12, 20);
			this.m_rbACEstudante.Name = "m_rbACEstudante";
			this.m_rbACEstudante.Size = new System.Drawing.Size(144, 16);
			this.m_rbACEstudante.TabIndex = 5;
			this.m_rbACEstudante.Text = "Estudante";
			this.m_rbACEstudante.CheckedChanged += new System.EventHandler(this.m_rbACEstudante_CheckedChanged);
			// 
			// m_rbACProfessor
			// 
			this.m_rbACProfessor.ForeColor = System.Drawing.Color.Black;
			this.m_rbACProfessor.Location = new System.Drawing.Point(12, 36);
			this.m_rbACProfessor.Name = "m_rbACProfessor";
			this.m_rbACProfessor.Size = new System.Drawing.Size(144, 16);
			this.m_rbACProfessor.TabIndex = 4;
			this.m_rbACProfessor.Text = "Professor";
			this.m_rbACProfessor.CheckedChanged += new System.EventHandler(this.m_rbACProfessor_CheckedChanged);
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Controls.Add(this.m_txtInformacoes);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(194, 162);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(230, 208);
			this.m_gbInformacoes.TabIndex = 18;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Informações";
			// 
			// m_txtInformacoes
			// 
			this.m_txtInformacoes.Location = new System.Drawing.Point(7, 15);
			this.m_txtInformacoes.Multiline = true;
			this.m_txtInformacoes.Name = "m_txtInformacoes";
			this.m_txtInformacoes.ReadOnly = true;
			this.m_txtInformacoes.Size = new System.Drawing.Size(209, 185);
			this.m_txtInformacoes.TabIndex = 0;
			this.m_txtInformacoes.Text = "";
			// 
			// m_gbImagem
			// 
			this.m_gbImagem.Controls.Add(this.m_picImagem);
			this.m_gbImagem.Location = new System.Drawing.Point(8, 9);
			this.m_gbImagem.Name = "m_gbImagem";
			this.m_gbImagem.Size = new System.Drawing.Size(416, 151);
			this.m_gbImagem.TabIndex = 17;
			this.m_gbImagem.TabStop = false;
			// 
			// m_picImagem
			// 
			this.m_picImagem.Image = ((System.Drawing.Image)(resources.GetObject("m_picImagem.Image")));
			this.m_picImagem.Location = new System.Drawing.Point(6, 12);
			this.m_picImagem.Name = "m_picImagem";
			this.m_picImagem.Size = new System.Drawing.Size(402, 132);
			this.m_picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_picImagem.TabIndex = 16;
			this.m_picImagem.TabStop = false;
			// 
			// m_gbComercial
			// 
			this.m_gbComercial.Controls.Add(this.m_gbPessoaFisica);
			this.m_gbComercial.Controls.Add(this.groupBox1);
			this.m_gbComercial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbComercial.ForeColor = System.Drawing.Color.Maroon;
			this.m_gbComercial.Location = new System.Drawing.Point(8, 162);
			this.m_gbComercial.Name = "m_gbComercial";
			this.m_gbComercial.Size = new System.Drawing.Size(184, 144);
			this.m_gbComercial.TabIndex = 15;
			this.m_gbComercial.TabStop = false;
			this.m_gbComercial.Text = "Versão Comercial";
			// 
			// m_gbPessoaFisica
			// 
			this.m_gbPessoaFisica.Controls.Add(this.m_rbPFExportador);
			this.m_gbPessoaFisica.Controls.Add(this.m_rbPFPrestadorServico);
			this.m_gbPessoaFisica.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPessoaFisica.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_gbPessoaFisica.Location = new System.Drawing.Point(8, 82);
			this.m_gbPessoaFisica.Name = "m_gbPessoaFisica";
			this.m_gbPessoaFisica.Size = new System.Drawing.Size(168, 54);
			this.m_gbPessoaFisica.TabIndex = 14;
			this.m_gbPessoaFisica.TabStop = false;
			this.m_gbPessoaFisica.Text = "Pessoa Física";
			// 
			// m_rbPFExportador
			// 
			this.m_rbPFExportador.ForeColor = System.Drawing.Color.Black;
			this.m_rbPFExportador.Location = new System.Drawing.Point(8, 18);
			this.m_rbPFExportador.Name = "m_rbPFExportador";
			this.m_rbPFExportador.Size = new System.Drawing.Size(144, 16);
			this.m_rbPFExportador.TabIndex = 7;
			this.m_rbPFExportador.Text = "Exportador";
			this.m_rbPFExportador.CheckedChanged += new System.EventHandler(this.m_rbPFExportador_CheckedChanged);
			// 
			// m_rbPFPrestadorServico
			// 
			this.m_rbPFPrestadorServico.ForeColor = System.Drawing.Color.Black;
			this.m_rbPFPrestadorServico.Location = new System.Drawing.Point(8, 34);
			this.m_rbPFPrestadorServico.Name = "m_rbPFPrestadorServico";
			this.m_rbPFPrestadorServico.Size = new System.Drawing.Size(144, 16);
			this.m_rbPFPrestadorServico.TabIndex = 6;
			this.m_rbPFPrestadorServico.Text = "Prestador de Serviço";
			this.m_rbPFPrestadorServico.CheckedChanged += new System.EventHandler(this.m_rbPFPrestadorServico_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_rbPJPrestadorServico);
			this.groupBox1.Controls.Add(this.m_rbPJExportador);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(8, 19);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 56);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pessoa Jurídica";
			// 
			// m_rbPJPrestadorServico
			// 
			this.m_rbPJPrestadorServico.ForeColor = System.Drawing.Color.Black;
			this.m_rbPJPrestadorServico.Location = new System.Drawing.Point(9, 36);
			this.m_rbPJPrestadorServico.Name = "m_rbPJPrestadorServico";
			this.m_rbPJPrestadorServico.Size = new System.Drawing.Size(144, 16);
			this.m_rbPJPrestadorServico.TabIndex = 3;
			this.m_rbPJPrestadorServico.Text = "Prestador de Serviço";
			this.m_rbPJPrestadorServico.CheckedChanged += new System.EventHandler(this.m_rbPJPrestadorServico_CheckedChanged);
			// 
			// m_rbPJExportador
			// 
			this.m_rbPJExportador.Checked = true;
			this.m_rbPJExportador.ForeColor = System.Drawing.Color.Black;
			this.m_rbPJExportador.Location = new System.Drawing.Point(9, 20);
			this.m_rbPJExportador.Name = "m_rbPJExportador";
			this.m_rbPJExportador.Size = new System.Drawing.Size(144, 16);
			this.m_rbPJExportador.TabIndex = 2;
			this.m_rbPJExportador.TabStop = true;
			this.m_rbPJExportador.Text = "Exportador";
			this.m_rbPJExportador.CheckedChanged += new System.EventHandler(this.m_rbPJExportador_CheckedChanged);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(222, 376);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_ttDica.SetToolTip(this.m_btOk, "Continuar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(158, 376);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFRegistroCategoria
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(444, 418);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRegistroCategoria";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Identifique-se";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmFRegistroCategoria_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbAcademico.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbImagem.ResumeLayout(false);
			this.m_gbComercial.ResumeLayout(false);
			this.m_gbPessoaFisica.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Carregamento dos Dados Interface
			private void vCarregaDadosInterface()
			{
				// Selecting the Class
				switch(m_enumRegistroClasse)
				{
					case mdlRegistro.RegistroClasse.PessoaJuridicaExportador:
						m_rbPJExportador.Checked = true;
						break;
					case mdlRegistro.RegistroClasse.PessoaJuridicaPrestadorServico:
						m_rbPJPrestadorServico.Checked = true;
						break;
					case mdlRegistro.RegistroClasse.PessoaFisicaExportador:
						m_rbPFExportador.Checked = true;
						break;
					case mdlRegistro.RegistroClasse.PessoaFisicaPrestadorServico:
						m_rbPFPrestadorServico.Checked = true;
						break;
					case mdlRegistro.RegistroClasse.PessoaFisicaEstudante:
						m_rbACEstudante.Checked = true;
						break;
					case mdlRegistro.RegistroClasse.PessoaFisicaProfessor:
						m_rbACProfessor.Checked = true;
						break;
				}
			}
		#endregion

		#region Eventos 
			#region Formulario
				private void frmFRegistroCategoria_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					vCarregaDadosInterface();
					m_txtInformacoes.Text = INFORMACAO_PJ_EXPORTADOR;
					RefreshCategoria();
				}
			#endregion
			#region RadioButton
				private void m_rbPJExportador_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbPJExportador.Checked)
					{
						m_txtInformacoes.Text = INFORMACAO_PJ_EXPORTADOR;
						DesselecionaTodosItensPF();
						DesselecionaTodosItensAC();
					}
				}

				private void m_rbPJPrestadorServico_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbPJPrestadorServico.Checked)
					{
						m_txtInformacoes.Text = INFORMACAO_PJ_PRESTADORSERVICO;
						DesselecionaTodosItensPF();
						DesselecionaTodosItensAC();
					}
				}

				private void m_rbACEstudante_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbACEstudante.Checked)
					{
						m_txtInformacoes.Text = INFORMACAO_AC_ESTUDANTE;
						DesselecionaTodosItensPF();
						DesselecionaTodosItensPJ();
					}
				}

				private void m_rbACProfessor_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbACProfessor.Checked)
					{
						m_txtInformacoes.Text = INFORMACAO_AC_PROFESSOR;
						DesselecionaTodosItensPF();
						DesselecionaTodosItensPJ();			
					}
				}

				private void m_rbPFExportador_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbPFExportador.Checked)
					{
						m_txtInformacoes.Text = INFORMACAO_PF_EXPORTADOR;
						DesselecionaTodosItensPJ();				
						DesselecionaTodosItensAC();
					}
				}

				private void m_rbPFPrestadorServico_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_rbPFPrestadorServico.Checked)
					{
						m_txtInformacoes.Text = INFORMACAO_PF_PRESTADORSERVICO;
						DesselecionaTodosItensPJ();
						DesselecionaTodosItensAC();
					}
				}
			#endregion
			#region Botoes
				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					// PJ Exportador 
					if (m_rbPJExportador.Checked)
					{
						m_enumRegistroClasse = mdlRegistro.RegistroClasse.PessoaJuridicaExportador;
					}

					// PJ Prestador Servico
					if (m_rbPJPrestadorServico.Checked)
					{
						m_enumRegistroClasse = mdlRegistro.RegistroClasse.PessoaJuridicaPrestadorServico;
					}

					// AC Estudante 
					if (m_rbACEstudante.Checked)
					{
						m_enumRegistroClasse = mdlRegistro.RegistroClasse.PessoaFisicaEstudante;
					}
					
					// AC Professor 
					if (m_rbACProfessor.Checked)
					{
						m_enumRegistroClasse = mdlRegistro.RegistroClasse.PessoaFisicaProfessor;
					}

					// PF Exportador 
					if (m_rbPFExportador.Checked)
					{
						m_enumRegistroClasse = mdlRegistro.RegistroClasse.PessoaFisicaExportador;
					}

					// PJ PrestadorServico
					if (m_rbPFPrestadorServico.Checked)
					{
						m_enumRegistroClasse = mdlRegistro.RegistroClasse.PessoaFisicaPrestadorServico;
					}

					m_bModificado = true;
					this.Close();
				}
			#endregion
		#endregion
		#region Cores
			private void MostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","CoresSecundarias");
				this.BackColor = clsPaletaCores.retornaCorAtual();
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					this.Controls[nCont].BackColor = this.BackColor;
					for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
					{
						if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.Panel"))
							this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

						for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
						{
							if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.Panel"))
								this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
						}
					}
				}
			}
		#endregion

		#region Refresh
			private void RefreshCategoria()
			{
				switch(m_enumRegistroClasse)
				{
					case mdlRegistro.RegistroClasse.PessoaJuridicaExportador:
						m_rbPJExportador.Checked = true;
						m_txtInformacoes.Text = INFORMACAO_PJ_EXPORTADOR;
						break;
					case mdlRegistro.RegistroClasse.PessoaJuridicaPrestadorServico:
						m_rbPJPrestadorServico.Checked = true;
						m_txtInformacoes.Text = INFORMACAO_PJ_PRESTADORSERVICO;
						break;
					case mdlRegistro.RegistroClasse.PessoaFisicaExportador:
						m_rbPFExportador.Checked = true;
						m_txtInformacoes.Text = INFORMACAO_PF_EXPORTADOR;
						break;
					case mdlRegistro.RegistroClasse.PessoaFisicaPrestadorServico:
						m_rbPFPrestadorServico.Checked = true;
						m_txtInformacoes.Text = INFORMACAO_PF_PRESTADORSERVICO;
						break;
					case mdlRegistro.RegistroClasse.PessoaFisicaEstudante:
						m_rbACEstudante.Checked = true;
						m_txtInformacoes.Text = INFORMACAO_AC_ESTUDANTE;
						break;
					case mdlRegistro.RegistroClasse.PessoaFisicaProfessor:
						m_rbACProfessor.Checked = true;
						m_txtInformacoes.Text = INFORMACAO_AC_PROFESSOR;
						break;
				}
			}
		#endregion
		#region Métodos
			private void DesselecionaTodosItensPJ()
			{
                m_rbPJExportador.Checked = false;
				m_rbPJPrestadorServico.Checked = false;
			}

			private void DesselecionaTodosItensPF()
			{
				m_rbPFExportador.Checked = false;
				m_rbPFPrestadorServico.Checked = false;
			}
			
			private void DesselecionaTodosItensAC()
			{
				m_rbACEstudante.Checked = false;
				m_rbACProfessor.Checked = false;
			}
		#endregion

		#region Retorno 
			public void RetornaValores(out mdlRegistro.RegistroClasse enumRegistroClasse)
			{
				enumRegistroClasse = m_enumRegistroClasse;
			} 
		#endregion
	}
}
