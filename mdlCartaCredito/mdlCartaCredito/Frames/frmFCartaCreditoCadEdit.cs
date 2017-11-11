using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlCartaCredito.Frames
{
	/// <summary>
	/// Summary description for frmFCartaCreditoCadEdit.
	/// </summary>
	internal class frmFCartaCreditoCadEdit : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegate
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.DateTimePicker dtpkEmissao, ref mdlComponentesGraficos.TextBox tbSaldo, ref System.Windows.Forms.CheckBox ckbxEmendas, ref System.Windows.Forms.CheckBox ckbxDiscrepancias, ref string strSimbolo);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.DateTimePicker dtpkEmissao, ref mdlComponentesGraficos.TextBox tbSaldo, ref System.Windows.Forms.CheckBox ckbxEmendas, ref System.Windows.Forms.CheckBox ckbxDiscrepancias);
		// Moeda
		public delegate void delCallAlterarMoeda(ref string strSimbolo);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		// Moeda
		public event delCallAlterarMoeda eCallAlterarMoeda;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
			{
				string strSimbolo = "";
				eCallCarregaDadosInterface(ref m_tbNumero, ref m_dtpkEmissao, ref m_tbSaldo, ref m_ckbxEmendas, ref m_ckbxDiscrepancias, ref strSimbolo);
				m_btMoeda.Text = strSimbolo;
			}
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_tbNumero, ref m_dtpkEmissao, ref m_tbSaldo, ref m_ckbxEmendas, ref m_ckbxDiscrepancias);
		}
		// Moeda
		protected virtual void OnCallAlterarMoeda()
		{
			if (eCallAlterarMoeda != null)
			{
				string strSimbolo = "";
				eCallAlterarMoeda(ref strSimbolo);
				m_btMoeda.Text = strSimbolo;
			}
		}
		#endregion

		#region Atributos
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected string m_strEnderecoExecutavel;

			private bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbFrame;
			private System.Windows.Forms.GroupBox m_gbFields;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Label m_lNumero;
			private mdlComponentesGraficos.TextBox m_tbNumero;
			private System.Windows.Forms.Label m_lEmissao;
			private System.Windows.Forms.DateTimePicker m_dtpkEmissao;
			private System.Windows.Forms.CheckBox m_ckbxEmendas;
			private mdlComponentesGraficos.TextBox m_tbSaldo;
			private System.Windows.Forms.Label m_lValor;
			private System.Windows.Forms.CheckBox m_ckbxDiscrepancias;
			private System.Windows.Forms.ToolTip m_ttCartaCredito;
			private System.Windows.Forms.Button m_btMoeda;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Construtores & Destrutores
			public frmFCartaCreditoCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
			{
				InitializeComponent();

				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = EnderecoExecutavel;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFCartaCreditoCadEdit));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_btMoeda = new System.Windows.Forms.Button();
			this.m_ckbxDiscrepancias = new System.Windows.Forms.CheckBox();
			this.m_tbSaldo = new mdlComponentesGraficos.TextBox();
			this.m_lValor = new System.Windows.Forms.Label();
			this.m_ckbxEmendas = new System.Windows.Forms.CheckBox();
			this.m_dtpkEmissao = new System.Windows.Forms.DateTimePicker();
			this.m_lEmissao = new System.Windows.Forms.Label();
			this.m_tbNumero = new mdlComponentesGraficos.TextBox();
			this.m_lNumero = new System.Windows.Forms.Label();
			this.m_ttCartaCredito = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Size = new System.Drawing.Size(182, 190);
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
			this.m_btOk.Location = new System.Drawing.Point(31, 158);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_ttCartaCredito.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(95, 158);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttCartaCredito.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_btMoeda);
			this.m_gbFields.Controls.Add(this.m_ckbxDiscrepancias);
			this.m_gbFields.Controls.Add(this.m_tbSaldo);
			this.m_gbFields.Controls.Add(this.m_lValor);
			this.m_gbFields.Controls.Add(this.m_ckbxEmendas);
			this.m_gbFields.Controls.Add(this.m_dtpkEmissao);
			this.m_gbFields.Controls.Add(this.m_lEmissao);
			this.m_gbFields.Controls.Add(this.m_tbNumero);
			this.m_gbFields.Controls.Add(this.m_lNumero);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 7);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(166, 146);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edição";
			// 
			// m_btMoeda
			// 
			this.m_btMoeda.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btMoeda.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btMoeda.Location = new System.Drawing.Point(45, 70);
			this.m_btMoeda.Name = "m_btMoeda";
			this.m_btMoeda.Size = new System.Drawing.Size(44, 25);
			this.m_btMoeda.TabIndex = 7;
			this.m_ttCartaCredito.SetToolTip(this.m_btMoeda, "Moeda");
			this.m_btMoeda.Click += new System.EventHandler(this.m_btMoeda_Click);
			// 
			// m_ckbxDiscrepancias
			// 
			this.m_ckbxDiscrepancias.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckbxDiscrepancias.Location = new System.Drawing.Point(8, 122);
			this.m_ckbxDiscrepancias.Name = "m_ckbxDiscrepancias";
			this.m_ckbxDiscrepancias.Size = new System.Drawing.Size(140, 16);
			this.m_ckbxDiscrepancias.TabIndex = 6;
			this.m_ckbxDiscrepancias.Text = "Possui discrepâncias";
			// 
			// m_tbSaldo
			// 
			this.m_tbSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbSaldo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbSaldo.Location = new System.Drawing.Point(92, 72);
			this.m_tbSaldo.Name = "m_tbSaldo";
			this.m_tbSaldo.OnlyNumbers = true;
			this.m_tbSaldo.Size = new System.Drawing.Size(66, 21);
			this.m_tbSaldo.TabIndex = 3;
			this.m_tbSaldo.Text = "";
			this.m_tbSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lValor
			// 
			this.m_lValor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lValor.Location = new System.Drawing.Point(8, 74);
			this.m_lValor.Name = "m_lValor";
			this.m_lValor.Size = new System.Drawing.Size(40, 16);
			this.m_lValor.TabIndex = 0;
			this.m_lValor.Text = "Valor:";
			this.m_lValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ckbxEmendas
			// 
			this.m_ckbxEmendas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckbxEmendas.Location = new System.Drawing.Point(8, 98);
			this.m_ckbxEmendas.Name = "m_ckbxEmendas";
			this.m_ckbxEmendas.Size = new System.Drawing.Size(120, 16);
			this.m_ckbxEmendas.TabIndex = 4;
			this.m_ckbxEmendas.Text = "Possui emendas";
			// 
			// m_dtpkEmissao
			// 
			this.m_dtpkEmissao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_dtpkEmissao.CustomFormat = "dd/MM/yyyy";
			this.m_dtpkEmissao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtpkEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpkEmissao.Location = new System.Drawing.Point(72, 44);
			this.m_dtpkEmissao.Name = "m_dtpkEmissao";
			this.m_dtpkEmissao.Size = new System.Drawing.Size(86, 21);
			this.m_dtpkEmissao.TabIndex = 2;
			// 
			// m_lEmissao
			// 
			this.m_lEmissao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEmissao.Location = new System.Drawing.Point(8, 50);
			this.m_lEmissao.Name = "m_lEmissao";
			this.m_lEmissao.Size = new System.Drawing.Size(56, 16);
			this.m_lEmissao.TabIndex = 0;
			this.m_lEmissao.Text = "Emissão:";
			this.m_lEmissao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbNumero
			// 
			this.m_tbNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbNumero.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbNumero.Location = new System.Drawing.Point(72, 20);
			this.m_tbNumero.Name = "m_tbNumero";
			this.m_tbNumero.Size = new System.Drawing.Size(86, 21);
			this.m_tbNumero.TabIndex = 1;
			this.m_tbNumero.Text = "";
			// 
			// m_lNumero
			// 
			this.m_lNumero.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNumero.Location = new System.Drawing.Point(8, 26);
			this.m_lNumero.Name = "m_lNumero";
			this.m_lNumero.Size = new System.Drawing.Size(52, 16);
			this.m_lNumero.TabIndex = 0;
			this.m_lNumero.Text = "Número:";
			this.m_lNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttCartaCredito
			// 
			this.m_ttCartaCredito.AutomaticDelay = 100;
			this.m_ttCartaCredito.AutoPopDelay = 5000;
			this.m_ttCartaCredito.InitialDelay = 100;
			this.m_ttCartaCredito.ReshowDelay = 20;
			// 
			// frmFCartaCreditoCadEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(186, 192);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFCartaCreditoCadEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Carta de Crédito";
			this.Load += new System.EventHandler(this.frmFCartaCreditoCadEdit_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		private void trocaCor()
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") && 
								(this.Controls[cont].Controls[cont2].Controls[cont3].Name != "m_lSimboloMoeda") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.Checkbox") && (this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.DateTimePicker") ||
								((this.Controls[cont].Controls[cont2].Controls[cont3].Name == "m_lvDadosImportadores") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() == 
								"mdlComponentesGraficos.ListView")))
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

		#region Get & Set
		public void setTextoGroupBox(string strTexto)
		{
			m_gbFields.Text = strTexto;
		}
		#endregion

		#region Eventos
			#region Formulario
			private void frmFCartaCreditoCadEdit_Load(object sender, System.EventArgs e)
			{
				OnCallCarregaDadosInterface();
				this.mostraCor();
			}
		#endregion
			#region Botoes
			private void m_btMoeda_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OnCallAlterarMoeda();
				this.mostraCor();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btOk_Click(object sender, System.EventArgs e)
			{
				OnCallSalvaDadosInterface();
				this.Close();
			}

			private void m_btCancelar_Click(object sender, System.EventArgs e)
			{
				this.Close();
			}
		#endregion
		#endregion
	}
}
