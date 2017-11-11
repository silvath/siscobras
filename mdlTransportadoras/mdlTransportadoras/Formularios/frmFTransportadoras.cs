using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTransportadoras.Formularios
{
	/// <summary>
	/// Summary description for frmFTransportadoras.
	/// </summary>
	internal class frmFTransportadoras : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallTransportadorasRefresh(ref System.Windows.Forms.ListView lvTransportadoras);
			public delegate void delCallTransportadoraCarregaSelecionada(out int nIdTransportadora);
			public delegate void delCallTransportadoraSalvaSelecionada(int nIdTransportadora);
			public delegate bool delCallTransportadorasNova();
			public delegate bool delCallTransportadorasEditar(int nIdTransportadora);
			public delegate bool delCallTransportadorasExcluir(ref System.Collections.ArrayList arlTransportadoras,bool bSilent);
			public delegate bool delCallShowDialogContatos(int nIdTransportadoras);
			public delegate bool delCallShowDialogMotoristas(int nIdTransportadoras);
			public delegate bool delCallShowDialogVeiculos(int nIdTransportadoras);
			public delegate bool delCallSalvaDados();
		#endregion
		#region Events
			public event delCallTransportadorasRefresh eCallTransportadorasRefresh;	
			public event delCallTransportadoraCarregaSelecionada eCallTransportadoraCarregaSelecionada;	
			public event delCallTransportadoraSalvaSelecionada eCallTransportadoraSalvaSelecionada;	
			public event delCallTransportadorasNova eCallTransportadorasNova;	
			public event delCallTransportadorasEditar eCallTransportadorasEditar;	
			public event delCallTransportadorasExcluir eCallTransportadorasExcluir;	
			public event delCallShowDialogContatos eCallShowDialogContatos;	
			public event delCallShowDialogMotoristas eCallShowDialogMotoristas;	
			public event delCallShowDialogVeiculos eCallShowDialogVeiculos;	
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected virtual void OnCallTransportadorasRefresh()
			{
				if (eCallTransportadorasRefresh != null)
				{
					eCallTransportadorasRefresh(ref m_lvTransportadoras);
				}
			}

			protected virtual void OnCallTransportadoraCarregaSelecionada()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_lvTransportadoras.SelectedItems.Clear();
				if (eCallTransportadoraCarregaSelecionada != null)
				{
					int nIdTransportadora;
					eCallTransportadoraCarregaSelecionada(out nIdTransportadora);
					foreach(System.Windows.Forms.ListViewItem lviTransportadora in m_lvTransportadoras.Items)
					{
						if (Int32.Parse(lviTransportadora.Tag.ToString()) == nIdTransportadora)
						{
							lviTransportadora.Selected = true;
							break;
						}
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallTransportadoraSalvaSelecionada()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallTransportadoraSalvaSelecionada != null)
				{
					int nIdTransportadora = -1;
					if (m_lvTransportadoras.SelectedItems.Count > 0)
						nIdTransportadora = Int32.Parse(m_lvTransportadoras.SelectedItems[0].Tag.ToString());
					eCallTransportadoraSalvaSelecionada(nIdTransportadora);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallTransportadorasNova()
			{
				if (eCallTransportadorasNova != null)
					return(eCallTransportadorasNova());
				else
					return(false);
			}

			protected virtual bool OnCallTransportadorasEditar()
			{
				if ((eCallTransportadorasEditar != null) && (m_lvTransportadoras.SelectedItems.Count > 0))
					return(eCallTransportadorasEditar(Int32.Parse(m_lvTransportadoras.SelectedItems[0].Tag.ToString())));
				else
					return(false);
			}

			protected virtual bool OnCallTransportadorasExcluir()
			{
				if ((eCallTransportadorasExcluir != null) && (m_lvTransportadoras.SelectedItems.Count > 0))
				{
					System.Collections.ArrayList arlTransportadoras = new ArrayList();
					foreach(System.Windows.Forms.ListViewItem lviTransportadora in m_lvTransportadoras.SelectedItems)
						arlTransportadoras.Add(Int32.Parse(lviTransportadora.Tag.ToString()));
					return(eCallTransportadorasExcluir(ref arlTransportadoras,false));
				}
				else
					return(false);
			}

			protected virtual void OnCallShowDialogContatos()
			{
				if ((eCallShowDialogContatos != null) && (m_lvTransportadoras.SelectedItems.Count > 0))
					eCallShowDialogContatos(Int32.Parse(m_lvTransportadoras.SelectedItems[0].Tag.ToString()));
			}

			protected virtual void OnCallShowDialogMotoristas()
			{
				if ((eCallShowDialogMotoristas != null) && (m_lvTransportadoras.SelectedItems.Count > 0))
					eCallShowDialogMotoristas(Int32.Parse(m_lvTransportadoras.SelectedItems[0].Tag.ToString()));
			}

			protected virtual void OnCallShowDialogVeiculos()
			{
				if ((eCallShowDialogVeiculos != null) && (m_lvTransportadoras.SelectedItems.Count > 0))
					eCallShowDialogVeiculos(Int32.Parse(m_lvTransportadoras.SelectedItems[0].Tag.ToString()));
			}

			protected virtual bool OnCallSalvaDados()
			{	
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallSalvaDados != null)
					bRetorno = eCallSalvaDados();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributes
			public bool m_bModificado = false;

			private string m_strEnderecoExecutavel = "";

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbAgentesCarga;
			private System.Windows.Forms.Button m_btContatos;
			private System.Windows.Forms.Button m_btExcluir;
			private System.Windows.Forms.Button m_btEditar;
			private System.Windows.Forms.Button m_btNovo;
			private System.Windows.Forms.ListView m_lvTransportadoras;
			private System.Windows.Forms.Button m_btMotoristas;
			private System.Windows.Forms.Button m_btVeiculos;
			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
		public frmFTransportadoras(string strEnderecoExecutavel)
		{
			m_strEnderecoExecutavel = strEnderecoExecutavel;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFTransportadoras));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbAgentesCarga = new System.Windows.Forms.GroupBox();
			this.m_btVeiculos = new System.Windows.Forms.Button();
			this.m_btMotoristas = new System.Windows.Forms.Button();
			this.m_btContatos = new System.Windows.Forms.Button();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_lvTransportadoras = new System.Windows.Forms.ListView();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbAgentesCarga.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbAgentesCarga);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(355, 312);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(119, 282);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 3;
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
			this.m_btCancelar.Location = new System.Drawing.Point(183, 282);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 4;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbAgentesCarga
			// 
			this.m_gbAgentesCarga.Controls.Add(this.m_btVeiculos);
			this.m_gbAgentesCarga.Controls.Add(this.m_btMotoristas);
			this.m_gbAgentesCarga.Controls.Add(this.m_btContatos);
			this.m_gbAgentesCarga.Controls.Add(this.m_btExcluir);
			this.m_gbAgentesCarga.Controls.Add(this.m_btEditar);
			this.m_gbAgentesCarga.Controls.Add(this.m_btNovo);
			this.m_gbAgentesCarga.Controls.Add(this.m_lvTransportadoras);
			this.m_gbAgentesCarga.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbAgentesCarga.Location = new System.Drawing.Point(7, 9);
			this.m_gbAgentesCarga.Name = "m_gbAgentesCarga";
			this.m_gbAgentesCarga.Size = new System.Drawing.Size(345, 271);
			this.m_gbAgentesCarga.TabIndex = 0;
			this.m_gbAgentesCarga.TabStop = false;
			this.m_gbAgentesCarga.Text = "Transportadoras";
			// 
			// m_btVeiculos
			// 
			this.m_btVeiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btVeiculos.BackColor = System.Drawing.SystemColors.Control;
			this.m_btVeiculos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVeiculos.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVeiculos.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btVeiculos.Image = ((System.Drawing.Image)(resources.GetObject("m_btVeiculos.Image")));
			this.m_btVeiculos.Location = new System.Drawing.Point(312, 17);
			this.m_btVeiculos.Name = "m_btVeiculos";
			this.m_btVeiculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btVeiculos.Size = new System.Drawing.Size(25, 25);
			this.m_btVeiculos.TabIndex = 10;
			this.m_btVeiculos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btVeiculos, "Veículos");
			this.m_btVeiculos.Click += new System.EventHandler(this.m_btVeiculos_Click);
			// 
			// m_btMotoristas
			// 
			this.m_btMotoristas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btMotoristas.BackColor = System.Drawing.SystemColors.Control;
			this.m_btMotoristas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btMotoristas.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btMotoristas.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btMotoristas.Image = ((System.Drawing.Image)(resources.GetObject("m_btMotoristas.Image")));
			this.m_btMotoristas.Location = new System.Drawing.Point(284, 17);
			this.m_btMotoristas.Name = "m_btMotoristas";
			this.m_btMotoristas.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btMotoristas.Size = new System.Drawing.Size(25, 25);
			this.m_btMotoristas.TabIndex = 9;
			this.m_btMotoristas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btMotoristas, "Motoristas");
			this.m_btMotoristas.Click += new System.EventHandler(this.m_btMotoristas_Click);
			// 
			// m_btContatos
			// 
			this.m_btContatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btContatos.BackColor = System.Drawing.SystemColors.Control;
			this.m_btContatos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContatos.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContatos.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContatos.Image = ((System.Drawing.Image)(resources.GetObject("m_btContatos.Image")));
			this.m_btContatos.Location = new System.Drawing.Point(257, 17);
			this.m_btContatos.Name = "m_btContatos";
			this.m_btContatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContatos.Size = new System.Drawing.Size(25, 25);
			this.m_btContatos.TabIndex = 8;
			this.m_btContatos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btContatos, "Contatos");
			this.m_btContatos.Click += new System.EventHandler(this.m_btContatos_Click);
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(200, 16);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 7;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btExcluir, "Excluir");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btEditar
			// 
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(168, 16);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 6;
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
			this.m_btNovo.Location = new System.Drawing.Point(136, 16);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 5;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btNovo, "Nova");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_lvTransportadoras
			// 
			this.m_lvTransportadoras.HideSelection = false;
			this.m_lvTransportadoras.Location = new System.Drawing.Point(8, 45);
			this.m_lvTransportadoras.Name = "m_lvTransportadoras";
			this.m_lvTransportadoras.Size = new System.Drawing.Size(328, 216);
			this.m_lvTransportadoras.TabIndex = 0;
			this.m_lvTransportadoras.View = System.Windows.Forms.View.List;
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFTransportadoras
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(362, 314);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFTransportadoras";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Transportadoras";
			this.Load += new System.EventHandler(this.frmFTransportadoras_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbAgentesCarga.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFTransportadoras_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallTransportadorasRefresh();
					OnCallTransportadoraCarregaSelecionada();
				}
			#endregion
			#region Botoes
				private void m_btNovo_Click(object sender, System.EventArgs e)
				{
					if (OnCallTransportadorasNova())
						OnCallTransportadorasRefresh();
				}

				private void m_btEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallTransportadorasEditar())
						OnCallTransportadorasRefresh();
				}

				private void m_btExcluir_Click(object sender, System.EventArgs e)
				{
					if (OnCallTransportadorasExcluir())
						OnCallTransportadorasRefresh();
				}

				private void m_btContatos_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogContatos();
				}

				private void m_btMotoristas_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogMotoristas();
				}

				private void m_btVeiculos_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogVeiculos();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					OnCallTransportadoraSalvaSelecionada();
					if (OnCallSalvaDados())
						this.Close();
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
