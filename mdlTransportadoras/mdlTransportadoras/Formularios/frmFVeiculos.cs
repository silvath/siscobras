using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTransportadoras.Formularios
{
	/// <summary>
	/// Summary description for frmFVeiculos.
	/// </summary>
	public class frmFVeiculos : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallVeiculosRefresh(int nIdTransportadora,ref System.Windows.Forms.ListView lvVeiculos);
			public delegate void delCallVeiculosCarregaSelecionado(out int nIdVeiculo);
			public delegate void delCallVeiculosSalvaSelecionado(int nIdVeiculo);
			public delegate bool delCallVeiculosNovo(int nIdTransportadora);
			public delegate bool delCallVeiculosEditar(int nIdTransportadora,int nIdVeiculos);
			public delegate bool delCallVeiculosExcluir(int nIdTransportadora,ref System.Collections.ArrayList arlVeiculos,bool bSilent);
		#endregion
		#region Events
			public event delCallVeiculosRefresh eCallVeiculosRefresh;	
			public event delCallVeiculosCarregaSelecionado eCallVeiculosCarregaSelecionado;	
			public event delCallVeiculosSalvaSelecionado eCallVeiculosSalvaSelecionado;	
			public event delCallVeiculosNovo eCallVeiculosNovo;	
			public event delCallVeiculosEditar eCallVeiculosEditar;	
			public event delCallVeiculosExcluir eCallVeiculosExcluir;	
		#endregion
		#region Events Methods
			protected virtual void OnCallVeiculosRefresh()
			{
				if (eCallVeiculosRefresh != null)
					eCallVeiculosRefresh(m_nIdTransportadora,ref m_lvVeiculos);
			}

			protected virtual void OnCallVeiculosCarregaSelecionado()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_lvVeiculos.SelectedItems.Clear();
				if (eCallVeiculosCarregaSelecionado != null)
				{
					int nIdVeiculo;
					eCallVeiculosCarregaSelecionado(out nIdVeiculo);
					foreach(System.Windows.Forms.ListViewItem lviVeiculo in m_lvVeiculos.Items)
					{
						if (Int32.Parse(lviVeiculo.Tag.ToString()) == nIdVeiculo)
						{
							lviVeiculo.Selected = true;
							break;
						}
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallVeiculosSalvaSelecionado()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallVeiculosSalvaSelecionado != null)
				{
					int nIdVeiculo = -1;
					if (m_lvVeiculos.SelectedItems.Count > 0)
						nIdVeiculo = Int32.Parse(m_lvVeiculos.SelectedItems[0].Tag.ToString());
					eCallVeiculosSalvaSelecionado(nIdVeiculo);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallVeiculosNovo()
			{
				bool bRetorno = false;
				if (eCallVeiculosNovo != null)
					bRetorno = eCallVeiculosNovo(m_nIdTransportadora);
				return(bRetorno);
			}

			protected virtual bool OnCallVeiculosEditar()
			{
				bool bRetorno = false;
				if ((eCallVeiculosEditar != null) && (m_lvVeiculos.SelectedItems.Count > 0))
					bRetorno = eCallVeiculosEditar(m_nIdTransportadora,Int32.Parse(m_lvVeiculos.SelectedItems[0].Tag.ToString()));
				return(bRetorno);
			}

			protected virtual bool OnCallVeiculosExcluir()
			{
				if ((eCallVeiculosExcluir != null) && (m_lvVeiculos.SelectedItems.Count > 0))
				{
					System.Collections.ArrayList arlVeiculos = new ArrayList();
					foreach(System.Windows.Forms.ListViewItem lviVeiculos in m_lvVeiculos.SelectedItems)
						arlVeiculos.Add(Int32.Parse(lviVeiculos.Tag.ToString()));
					return(eCallVeiculosExcluir(m_nIdTransportadora,ref arlVeiculos,false));
				}
				else
					return(false);
			}
		#endregion

		#region Atributes
			private string m_strEnderecoExecutavel = "";
			private int m_nIdTransportadora = -1;

			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Button m_btExcluir;
			private System.Windows.Forms.Button m_btEditar;
			private System.Windows.Forms.Button m_btNovo;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbVeiculos;
			private System.Windows.Forms.ListView m_lvVeiculos;
			private System.Windows.Forms.ColumnHeader m_colhIdentificacao;
			private System.Windows.Forms.ColumnHeader m_colhDescricao;
			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmFVeiculos(string strEnderecoExecutavel,int nIdTransportadora)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdTransportadora = nIdTransportadora;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFVeiculos));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbVeiculos = new System.Windows.Forms.GroupBox();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_lvVeiculos = new System.Windows.Forms.ListView();
			this.m_colhIdentificacao = new System.Windows.Forms.ColumnHeader();
			this.m_colhDescricao = new System.Windows.Forms.ColumnHeader();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbVeiculos.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbVeiculos);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, -3);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(243, 255);
			this.m_gbGeral.TabIndex = 3;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbVeiculos
			// 
			this.m_gbVeiculos.Controls.Add(this.m_btExcluir);
			this.m_gbVeiculos.Controls.Add(this.m_btEditar);
			this.m_gbVeiculos.Controls.Add(this.m_btNovo);
			this.m_gbVeiculos.Controls.Add(this.m_lvVeiculos);
			this.m_gbVeiculos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbVeiculos.Location = new System.Drawing.Point(5, 8);
			this.m_gbVeiculos.Name = "m_gbVeiculos";
			this.m_gbVeiculos.Size = new System.Drawing.Size(234, 216);
			this.m_gbVeiculos.TabIndex = 7;
			this.m_gbVeiculos.TabStop = false;
			this.m_gbVeiculos.Text = "Veiculos";
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(139, 11);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 10;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btExcluir, "Cancelar");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btEditar
			// 
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(107, 11);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 9;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btEditar, "Editar");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_btNovo
			// 
			this.m_btNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovo.Image")));
			this.m_btNovo.Location = new System.Drawing.Point(75, 11);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 8;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btNovo, "Novo");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_lvVeiculos
			// 
			this.m_lvVeiculos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.m_colhIdentificacao,
																						   this.m_colhDescricao});
			this.m_lvVeiculos.FullRowSelect = true;
			this.m_lvVeiculos.HideSelection = false;
			this.m_lvVeiculos.Location = new System.Drawing.Point(8, 40);
			this.m_lvVeiculos.Name = "m_lvVeiculos";
			this.m_lvVeiculos.Size = new System.Drawing.Size(216, 168);
			this.m_lvVeiculos.TabIndex = 0;
			this.m_lvVeiculos.View = System.Windows.Forms.View.Details;
			// 
			// m_colhIdentificacao
			// 
			this.m_colhIdentificacao.Text = "Placa";
			this.m_colhIdentificacao.Width = 92;
			// 
			// m_colhDescricao
			// 
			this.m_colhDescricao.Text = "Descricao";
			this.m_colhDescricao.Width = 117;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(63, 225);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(127, 225);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFVeiculos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 254);
			this.Controls.Add(this.m_gbGeral);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFVeiculos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Veículos";
			this.Load += new System.EventHandler(this.frmFVeiculos_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbVeiculos.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFVeiculos_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallVeiculosRefresh();
					OnCallVeiculosCarregaSelecionado();
				}
			#endregion
			#region Botoes
				private void m_btNovo_Click(object sender, System.EventArgs e)
				{
					if (OnCallVeiculosNovo())
						OnCallVeiculosRefresh();
				}

				private void m_btEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallVeiculosEditar())
						OnCallVeiculosRefresh();
				}

				private void m_btExcluir_Click(object sender, System.EventArgs e)
				{
					if (OnCallVeiculosExcluir())
						OnCallVeiculosRefresh();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					OnCallVeiculosSalvaSelecionado();
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
				case "System.Windows.Forms.ListView":
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
