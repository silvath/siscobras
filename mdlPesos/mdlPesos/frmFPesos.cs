using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlPesos
{
	/// <summary>
	/// Summary description for frmFPesos.
	/// </summary>
	internal class frmFPesos : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		
		public bool m_bModificado = false;
		protected bool m_bChanged = true;
		
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		private string m_strenderecoExecutavel;
		private System.Windows.Forms.ToolTip m_ttDica;
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Label m_lPesoBruto;
		private System.Windows.Forms.Label m_lPesoLiquido;
		internal mdlComponentesGraficos.TextBox m_txtPesoBruto;
		internal mdlComponentesGraficos.TextBox m_txtPesoLiquido;
		private System.Windows.Forms.Button m_btCancel;
		private System.Windows.Forms.Button m_btOk;
		private mdlComponentesGraficos.ComboBox m_cbUnidadeLiquido;
		private mdlComponentesGraficos.ComboBox m_cbUnidadeBruto;
		private System.Windows.Forms.Button btTrocarCor;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtor & Destrutor
		public frmFPesos(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			try
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strenderecoExecutavel = EnderecoExecutavel;
			
				InitializeComponent();
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			try 
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
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Delegate
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox txtPesoBruto, ref mdlComponentesGraficos.TextBox txtPesoLiquido,ref mdlComponentesGraficos.ComboBox cbUnidadeMassaLiquida,ref mdlComponentesGraficos.ComboBox cbUnidadeMassaBruta, ref System.Windows.Forms.GroupBox gbFields);
		public delegate void delCallChecaIntegridadeDados(ref mdlComponentesGraficos.TextBox txtPesoBruto, ref mdlComponentesGraficos.TextBox txtPesoLiquido);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox txtPesoBruto, ref mdlComponentesGraficos.TextBox txtPesoLiquido, ref mdlComponentesGraficos.ComboBox cbUnidadeMassaLiquida, ref mdlComponentesGraficos.ComboBox cbUnidadeMassaBruta, bool m_bModificado);
		public delegate void delCallSalvaDadosBD();
		#endregion
		#region Events
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		} 

		protected virtual void OnCallCarregaDadosInterface()
		{
				if (eCallCarregaDadosInterface != null)
					eCallCarregaDadosInterface(ref this.m_txtPesoBruto,ref this.m_txtPesoLiquido,ref this.m_cbUnidadeLiquido,ref this.m_cbUnidadeBruto, ref m_gbFields);
		} 

		protected virtual void OnCallChecaIntegridadeDados()
		{
				if (eCallChecaIntegridadeDados != null)
					eCallChecaIntegridadeDados(ref this.m_txtPesoBruto,ref this.m_txtPesoLiquido);
		}

		protected virtual void OnCallSalvaDadosInterface()
		{
				if (eCallSalvaDadosInterface != null)
					eCallSalvaDadosInterface(ref this.m_txtPesoBruto,ref this.m_txtPesoLiquido, ref this.m_cbUnidadeLiquido,ref this.m_cbUnidadeBruto,this.m_bModificado);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFPesos));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.btTrocarCor = new System.Windows.Forms.Button();
			this.m_btCancel = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_cbUnidadeBruto = new mdlComponentesGraficos.ComboBox();
			this.m_cbUnidadeLiquido = new mdlComponentesGraficos.ComboBox();
			this.m_lPesoBruto = new System.Windows.Forms.Label();
			this.m_lPesoLiquido = new System.Windows.Forms.Label();
			this.m_txtPesoBruto = new mdlComponentesGraficos.TextBox();
			this.m_txtPesoLiquido = new mdlComponentesGraficos.TextBox();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btCancel);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, -3);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(382, 104);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// btTrocarCor
			// 
			this.btTrocarCor.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btTrocarCor.Location = new System.Drawing.Point(3, 1);
			this.btTrocarCor.Name = "btTrocarCor";
			this.btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.btTrocarCor.TabIndex = 8;
			this.m_ttDica.SetToolTip(this.btTrocarCor, "Cor");
			this.btTrocarCor.Click += new System.EventHandler(this.btTrocarCor_Click);
			// 
			// m_btCancel
			// 
			this.m_btCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btCancel.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancel.Image")));
			this.m_btCancel.Location = new System.Drawing.Point(195, 74);
			this.m_btCancel.Name = "m_btCancel";
			this.m_btCancel.Size = new System.Drawing.Size(57, 25);
			this.m_btCancel.TabIndex = 6;
			this.m_ttDica.SetToolTip(this.m_btCancel, "Cancelar");
			this.m_btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(131, 74);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
			this.m_ttDica.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.btOk_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_cbUnidadeBruto);
			this.m_gbFields.Controls.Add(this.m_cbUnidadeLiquido);
			this.m_gbFields.Controls.Add(this.m_lPesoBruto);
			this.m_gbFields.Controls.Add(this.m_lPesoLiquido);
			this.m_gbFields.Controls.Add(this.m_txtPesoBruto);
			this.m_gbFields.Controls.Add(this.m_txtPesoLiquido);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 9);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(368, 64);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_cbUnidadeBruto
			// 
			this.m_cbUnidadeBruto.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_cbUnidadeBruto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbUnidadeBruto.GoToNextControlWithEnter = true;
			this.m_cbUnidadeBruto.Location = new System.Drawing.Point(303, 36);
			this.m_cbUnidadeBruto.Name = "m_cbUnidadeBruto";
			this.m_cbUnidadeBruto.Size = new System.Drawing.Size(51, 22);
			this.m_cbUnidadeBruto.TabIndex = 4;
			this.m_ttDica.SetToolTip(this.m_cbUnidadeBruto, "Unidade");
			this.m_cbUnidadeBruto.TextChanged += new System.EventHandler(this.m_cbUnidadeBruto_TextChanged);
			// 
			// m_cbUnidadeLiquido
			// 
			this.m_cbUnidadeLiquido.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_cbUnidadeLiquido.AutoCompleteCaseSensitive = false;
			this.m_cbUnidadeLiquido.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbUnidadeLiquido.GoToNextControlWithEnter = true;
			this.m_cbUnidadeLiquido.Location = new System.Drawing.Point(303, 13);
			this.m_cbUnidadeLiquido.Name = "m_cbUnidadeLiquido";
			this.m_cbUnidadeLiquido.Size = new System.Drawing.Size(51, 22);
			this.m_cbUnidadeLiquido.TabIndex = 2;
			this.m_ttDica.SetToolTip(this.m_cbUnidadeLiquido, "Unidade");
			this.m_cbUnidadeLiquido.TextChanged += new System.EventHandler(this.m_cbUnidadeLiquido_TextChanged);
			// 
			// m_lPesoBruto
			// 
			this.m_lPesoBruto.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_lPesoBruto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPesoBruto.Location = new System.Drawing.Point(10, 40);
			this.m_lPesoBruto.Name = "m_lPesoBruto";
			this.m_lPesoBruto.Size = new System.Drawing.Size(104, 16);
			this.m_lPesoBruto.TabIndex = 0;
			this.m_lPesoBruto.Text = "Peso Bruto Total:";
			// 
			// m_lPesoLiquido
			// 
			this.m_lPesoLiquido.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_lPesoLiquido.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPesoLiquido.Location = new System.Drawing.Point(10, 17);
			this.m_lPesoLiquido.Name = "m_lPesoLiquido";
			this.m_lPesoLiquido.Size = new System.Drawing.Size(110, 16);
			this.m_lPesoLiquido.TabIndex = 0;
			this.m_lPesoLiquido.Text = "Peso Líquido Total:";
			// 
			// m_txtPesoBruto
			// 
			this.m_txtPesoBruto.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_txtPesoBruto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtPesoBruto.Location = new System.Drawing.Point(120, 37);
			this.m_txtPesoBruto.Name = "m_txtPesoBruto";
			this.m_txtPesoBruto.OnlyNumbers = true;
			this.m_txtPesoBruto.Size = new System.Drawing.Size(168, 20);
			this.m_txtPesoBruto.TabIndex = 3;
			this.m_txtPesoBruto.Text = "";
			this.m_txtPesoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_txtPesoLiquido
			// 
			this.m_txtPesoLiquido.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_txtPesoLiquido.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtPesoLiquido.Location = new System.Drawing.Point(121, 14);
			this.m_txtPesoLiquido.Name = "m_txtPesoLiquido";
			this.m_txtPesoLiquido.OnlyNumbers = true;
			this.m_txtPesoLiquido.Size = new System.Drawing.Size(167, 20);
			this.m_txtPesoLiquido.TabIndex = 1;
			this.m_txtPesoLiquido.Text = "";
			this.m_txtPesoLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFPesos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(386, 105);
			this.Controls.Add(this.m_gbFrame);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFPesos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pesos";
			this.Load += new System.EventHandler(this.frmFPesos_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		public void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strenderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
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
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strenderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentesGraficos.TextBox"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentes.compTextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox"))
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

		#region Eventos
			#region Ok
			private void btOk_Click(object sender, System.EventArgs e)
			{
				try 
				{
					this.m_bModificado = true;
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					if (m_cbUnidadeBruto.ReturnObjectSelectedItem() != null)
					{
						OnCallSalvaDadosInterface();
						OnCallSalvaDadosBD();
						this.Close();
					} 
					else 
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlPeso_frmFPeso_PesoNaoSelecionado));
						//MessageBox.Show("Selecione uma unidade existente.",this.Text);
						m_cbUnidadeLiquido.SelectedIndex = 0;
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				} 
				catch (Exception err) 
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region Cancelar
			private void btCancel_Click(object sender, System.EventArgs e)
			{
				try 
				{
					m_bModificado = false;
					this.Close();
				} 
				catch (Exception err) 
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion	
			#region Cor
			private void btTrocarCor_Click(object sender, System.EventArgs e)
			{
				try 
				{
					this.trocaCor();
					this.mostraCor();
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region Load
			private void frmFPesos_Load(object sender, System.EventArgs e)
			{
				try 
				{
					this.mostraCor();
					OnCallCarregaDadosInterface();
				} 
				catch (Exception err) 
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region Unidade Liquido
			private void m_cbUnidadeLiquido_TextChanged(object sender, System.EventArgs e)
			{
				m_cbUnidadeBruto.Text = m_cbUnidadeLiquido.Text;
			}
			#endregion
			#region Unidade Bruto
			private void m_cbUnidadeBruto_TextChanged(object sender, System.EventArgs e)
			{
				m_cbUnidadeLiquido.Text = m_cbUnidadeBruto.Text;
			}
			#endregion
		#endregion
	}
}