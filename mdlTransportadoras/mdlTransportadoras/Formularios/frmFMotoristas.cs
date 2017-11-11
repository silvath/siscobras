using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTransportadoras.Formularios
{
	/// <summary>
	/// Summary description for frmFMotoristas.
	/// </summary>
	public class frmFMotoristas : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallMotoristasRefresh(int nIdTransportadora,ref System.Windows.Forms.ListView lvMotoristas);
			public delegate void delCallMotoristasCarregaSelecionado(out int nIdMotorista);
			public delegate void delCallMotoristasSalvaSelecionado(int nIdMotorista);
			public delegate bool delCallMotoristasNovo(int nIdTransportadora);
			public delegate bool delCallMotoristasEditar(int nIdTransportadora,int nIdMotorista);
			public delegate bool delCallMotoristasExcluir(int nIdTransportadora,ref System.Collections.ArrayList arlMotoristas,bool bSilent);
		#endregion
		#region Events
			public event delCallMotoristasRefresh eCallMotoristasRefresh;	
			public event delCallMotoristasCarregaSelecionado eCallMotoristasCarregaSelecionado;	
			public event delCallMotoristasSalvaSelecionado eCallMotoristasSalvaSelecionado;	
			public event delCallMotoristasNovo eCallMotoristasNovo;	
			public event delCallMotoristasEditar eCallMotoristasEditar;	
			public event delCallMotoristasExcluir eCallMotoristasExcluir;	
		#endregion
		#region Events Methods
			protected virtual void OnCallMotoristasRefresh()
			{
				if (eCallMotoristasRefresh != null)
					eCallMotoristasRefresh(m_nIdTransportadora,ref m_lvMotoristas);
			}

			protected virtual void OnCallMotoristasCarregaSelecionado()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_lvMotoristas.SelectedItems.Clear();
				if (eCallMotoristasCarregaSelecionado != null)
				{
					int nIdMotorista;
					eCallMotoristasCarregaSelecionado(out nIdMotorista);
					foreach(System.Windows.Forms.ListViewItem lviMotorista in m_lvMotoristas.Items)
					{
						if (Int32.Parse(lviMotorista.Tag.ToString()) == nIdMotorista)
						{
							lviMotorista.Selected = true;
							break;
						}
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallMotoristasSalvaSelecionado()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallMotoristasSalvaSelecionado != null)
				{
					int nIdMotorista = -1;
					if (m_lvMotoristas.SelectedItems.Count > 0)
						nIdMotorista = Int32.Parse(m_lvMotoristas.SelectedItems[0].Tag.ToString());
					eCallMotoristasSalvaSelecionado(nIdMotorista);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}


			protected virtual bool OnCallMotoristasNovo()
			{
				bool bRetorno = false;
				if (eCallMotoristasNovo != null)
					bRetorno = eCallMotoristasNovo(m_nIdTransportadora);
				return(bRetorno);
			}

			protected virtual bool OnCallMotoristasEditar()
			{
				bool bRetorno = false;
				if ((eCallMotoristasEditar != null) && (m_lvMotoristas.SelectedItems.Count > 0))
					bRetorno = eCallMotoristasEditar(m_nIdTransportadora,Int32.Parse(m_lvMotoristas.SelectedItems[0].Tag.ToString()));
				return(bRetorno);
			}

			protected virtual bool OnCallMotoristasExcluir()
			{
				if ((eCallMotoristasExcluir != null) && (m_lvMotoristas.SelectedItems.Count > 0))
				{
					System.Collections.ArrayList arlMotoristas = new ArrayList();
					foreach(System.Windows.Forms.ListViewItem lviMotorista in m_lvMotoristas.SelectedItems)
						arlMotoristas.Add(Int32.Parse(lviMotorista.Tag.ToString()));
					return(eCallMotoristasExcluir(m_nIdTransportadora,ref arlMotoristas,false));
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
			private System.Windows.Forms.GroupBox m_gbMotoristas;
			private System.Windows.Forms.Button m_btExcluir;
			private System.Windows.Forms.Button m_btEditar;
			private System.Windows.Forms.Button m_btNovo;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.ListView m_lvMotoristas;
			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmFMotoristas(string strEnderecoExecutavel,int nIdTransportadora)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFMotoristas));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbMotoristas = new System.Windows.Forms.GroupBox();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_lvMotoristas = new System.Windows.Forms.ListView();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbMotoristas.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbMotoristas);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(243, 255);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbMotoristas
			// 
			this.m_gbMotoristas.Controls.Add(this.m_btExcluir);
			this.m_gbMotoristas.Controls.Add(this.m_btEditar);
			this.m_gbMotoristas.Controls.Add(this.m_btNovo);
			this.m_gbMotoristas.Controls.Add(this.m_lvMotoristas);
			this.m_gbMotoristas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMotoristas.Location = new System.Drawing.Point(5, 8);
			this.m_gbMotoristas.Name = "m_gbMotoristas";
			this.m_gbMotoristas.Size = new System.Drawing.Size(234, 216);
			this.m_gbMotoristas.TabIndex = 7;
			this.m_gbMotoristas.TabStop = false;
			this.m_gbMotoristas.Text = "Motoristas";
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
			// m_lvMotoristas
			// 
			this.m_lvMotoristas.HideSelection = false;
			this.m_lvMotoristas.Location = new System.Drawing.Point(8, 40);
			this.m_lvMotoristas.Name = "m_lvMotoristas";
			this.m_lvMotoristas.Size = new System.Drawing.Size(216, 168);
			this.m_lvMotoristas.TabIndex = 0;
			this.m_lvMotoristas.View = System.Windows.Forms.View.List;
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
			// frmFMotoristas
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 256);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFMotoristas";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Motoristas";
			this.Load += new System.EventHandler(this.frmFMotoristas_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbMotoristas.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFMotoristas_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallMotoristasRefresh();
					OnCallMotoristasCarregaSelecionado();
				}
			#endregion
			#region Botoes
				private void m_btNovo_Click(object sender, System.EventArgs e)
				{
					if (OnCallMotoristasNovo())
						OnCallMotoristasRefresh();
				}

				private void m_btEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallMotoristasEditar())
						OnCallMotoristasRefresh();
				}

				private void m_btExcluir_Click(object sender, System.EventArgs e)
				{
					if (OnCallMotoristasExcluir())
						OnCallMotoristasRefresh();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					OnCallMotoristasSalvaSelecionado();
					m_bModificado = true;
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
