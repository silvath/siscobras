using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlNotaFiscal.Frames
{
	/// <summary>
	/// Summary description for frmFNotasFiscaisCadEdit.
	/// </summary>
	internal class frmFNotasFiscaisCadEdit : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		internal bool m_bModificado = false;
		private bool m_bAtivado = true;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Label m_lEmissao;
		private System.Windows.Forms.Label m_lNumero;
		private System.Windows.Forms.Label m_lValor;
		private mdlComponentesGraficos.TextBox m_tbNumero;
		private System.Windows.Forms.DateTimePicker m_dtpkEmissao;
		private mdlComponentesGraficos.TextBox m_tbTotal;
		private System.Windows.Forms.ToolTip m_ttNotas;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFNotasFiscaisCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = enderecoExecutavel;
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

		#region Delegate
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.DateTimePicker dtpkEmissao, ref mdlComponentesGraficos.TextBox tbValor, ref System.Windows.Forms.GroupBox gbFields);
		public delegate bool delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.DateTimePicker dtpkEmissao, ref mdlComponentesGraficos.TextBox tbValor);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_tbNumero, ref m_dtpkEmissao, ref m_tbTotal, ref m_gbFields);
		}
		protected virtual bool OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				return (eCallSalvaDadosInterface(ref m_tbNumero, ref m_dtpkEmissao, ref m_tbTotal));

			return true;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFNotasFiscaisCadEdit));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_tbTotal = new mdlComponentesGraficos.TextBox();
			this.m_dtpkEmissao = new System.Windows.Forms.DateTimePicker();
			this.m_tbNumero = new mdlComponentesGraficos.TextBox();
			this.m_lValor = new System.Windows.Forms.Label();
			this.m_lEmissao = new System.Windows.Forms.Label();
			this.m_lNumero = new System.Windows.Forms.Label();
			this.m_ttNotas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(180, 141);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(30, 109);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 1;
			this.m_ttNotas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(94, 109);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttNotas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_tbTotal);
			this.m_gbFields.Controls.Add(this.m_dtpkEmissao);
			this.m_gbFields.Controls.Add(this.m_tbNumero);
			this.m_gbFields.Controls.Add(this.m_lValor);
			this.m_gbFields.Controls.Add(this.m_lEmissao);
			this.m_gbFields.Controls.Add(this.m_lNumero);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 7);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(164, 97);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edição";
			// 
			// m_tbTotal
			// 
			this.m_tbTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbTotal.HideSelection = false;
			this.m_tbTotal.Location = new System.Drawing.Point(70, 69);
			this.m_tbTotal.Name = "m_tbTotal";
			this.m_tbTotal.OnlyNumbers = true;
			this.m_tbTotal.Size = new System.Drawing.Size(86, 21);
			this.m_tbTotal.TabIndex = 4;
			this.m_tbTotal.Text = "";
			this.m_tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_dtpkEmissao
			// 
			this.m_dtpkEmissao.CustomFormat = "dd/MM/yyyy";
			this.m_dtpkEmissao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtpkEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpkEmissao.Location = new System.Drawing.Point(70, 45);
			this.m_dtpkEmissao.Name = "m_dtpkEmissao";
			this.m_dtpkEmissao.Size = new System.Drawing.Size(86, 21);
			this.m_dtpkEmissao.TabIndex = 2;
			// 
			// m_tbNumero
			// 
			this.m_tbNumero.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbNumero.HideSelection = false;
			this.m_tbNumero.Location = new System.Drawing.Point(70, 21);
			this.m_tbNumero.Name = "m_tbNumero";
			this.m_tbNumero.OnlyNumbers = true;
			this.m_tbNumero.Size = new System.Drawing.Size(86, 21);
			this.m_tbNumero.TabIndex = 1;
			this.m_tbNumero.Text = "";
			this.m_tbNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lValor
			// 
			this.m_lValor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lValor.Location = new System.Drawing.Point(8, 72);
			this.m_lValor.Name = "m_lValor";
			this.m_lValor.Size = new System.Drawing.Size(35, 16);
			this.m_lValor.TabIndex = 0;
			this.m_lValor.Text = "Total:";
			this.m_lValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lEmissao
			// 
			this.m_lEmissao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEmissao.Location = new System.Drawing.Point(8, 48);
			this.m_lEmissao.Name = "m_lEmissao";
			this.m_lEmissao.Size = new System.Drawing.Size(55, 16);
			this.m_lEmissao.TabIndex = 0;
			this.m_lEmissao.Text = "Emissão:";
			this.m_lEmissao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lNumero
			// 
			this.m_lNumero.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNumero.Location = new System.Drawing.Point(8, 24);
			this.m_lNumero.Name = "m_lNumero";
			this.m_lNumero.Size = new System.Drawing.Size(52, 16);
			this.m_lNumero.TabIndex = 0;
			this.m_lNumero.Text = "Número:";
			this.m_lNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttNotas
			// 
			this.m_ttNotas.AutomaticDelay = 100;
			this.m_ttNotas.AutoPopDelay = 5000;
			this.m_ttNotas.InitialDelay = 100;
			this.m_ttNotas.ReshowDelay = 20;
			// 
			// frmFNotasFiscaisCadEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(184, 143);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFNotasFiscaisCadEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Nota Fiscal";
			this.Load += new System.EventHandler(this.frmFNotasFiscaisCadEdit_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		#region Trocar Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		public void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Mostrar Cor
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		public void mostraCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
						}
					}
				}
			} 
			catch (Exception erro) 
			{ 
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#endregion

		#region Get & Set
		public void setTextoGroupBox(string strTexto)
		{
			m_gbFields.Text = strTexto;
		}
		public void setCorCadastro()
		{
			m_lNumero.ForeColor = System.Drawing.Color.Red;
			m_lEmissao.ForeColor = System.Drawing.Color.Red;
			m_lValor.ForeColor = System.Drawing.Color.Red;
		}
		#endregion

		#region Eventos
		#region Load
		private void frmFNotasFiscaisCadEdit_Load(object sender, System.EventArgs e)
		{
			this.mostraCor();
			OnCallCarregaDadosInterface();
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			if (m_tbNumero.Text.Trim() != "")
			{
				if (m_tbTotal.Text.Trim() != "")
				{
					double dTeste = 0;
					bool bErro = false;
					try
					{
						dTeste = Double.Parse(m_tbTotal.Text);
					}
					catch
					{
						bErro = true;
						dTeste = 0;
						mdlMensagens.clsMensagens.ShowError("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlNotaFiscal_frmFNotaFiscalCadEdit_ValorInvalido.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
						m_tbTotal.Focus();
					}
					if ((dTeste > 0) && (!bErro))
					{
						if (OnCallSalvaDadosInterface())
						{
							m_bModificado = true;
							this.Close();
						}
						else
						{
							m_tbNumero.Focus();
						}
					}
					else if (!bErro)
					{
						mdlMensagens.clsMensagens.ShowError("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlNotaFiscal_frmFNotaFiscalCadEdit_ValorIgualAZero.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
						m_tbTotal.Focus();
					}
				}
				else
				{
					mdlMensagens.clsMensagens.ShowError("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlNotaFiscal_frmFNotaFiscalCadEdit_ValorInvalido.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
					m_tbTotal.Focus();
				}
			}
			else
			{
				mdlMensagens.clsMensagens.ShowError("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlNotaFiscal_frmFNotaFiscalCadEdit_SemNumero.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
				m_tbNumero.Focus();
			}
		}
		#endregion
		#endregion
	}
}
