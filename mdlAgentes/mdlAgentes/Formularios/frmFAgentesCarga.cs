using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlAgentes.Formularios
{
	/// <summary>
	/// Summary description for frmFAgentesCarga.
	/// </summary>
	public class frmFAgentesCarga : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallAgentesCargaRefresh(ref System.Windows.Forms.ListView lvAgentesCarga);
			public delegate void delCallAgentesCargaCarregaSelecionado(out int nIdAgenteCarga);
			public delegate void delCallAgentesCargaSalvaSelecionado(int nIdAgenteCarga);
			public delegate bool delCallAgentesCargaNovo();
			public delegate bool delCallAgentesCargaEditar(int nIdAgenteCarga);
			public delegate bool delCallAgentesCargaExcluir(ref System.Collections.ArrayList arlAgentesCarga,bool bSilent);
			public delegate bool delCallShowDialogContatos(int nIdAgenteCarga);
			public delegate bool delCallSalvaDados();
		#endregion
		#region Events
			public event delCallAgentesCargaRefresh eCallAgentesCargaRefresh;	
			public event delCallAgentesCargaCarregaSelecionado eCallAgentesCargaCarregaSelecionado;	
			public event delCallAgentesCargaSalvaSelecionado eCallAgentesCargaSalvaSelecionado;	
			public event delCallAgentesCargaNovo eCallAgentesCargaNovo;	
			public event delCallAgentesCargaEditar eCallAgentesCargaEditar;	
			public event delCallAgentesCargaExcluir eCallAgentesCargaExcluir;	
			public event delCallShowDialogContatos eCallShowDialogContatos;	
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected virtual void OnCallAgentesCargaRefresh()
			{
				if (eCallAgentesCargaRefresh != null)
				{
					eCallAgentesCargaRefresh(ref m_lvAgentesCarga);
				}
			}

			protected virtual void OnCallAgentesCargaCarregaSelecionado()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_lvAgentesCarga.SelectedItems.Clear();
				if (eCallAgentesCargaCarregaSelecionado != null)
				{
					int nIdAgenteCarga;
					eCallAgentesCargaCarregaSelecionado(out nIdAgenteCarga);
					foreach(System.Windows.Forms.ListViewItem lviAgenteCarga in m_lvAgentesCarga.Items)
					{
						if (Int32.Parse(lviAgenteCarga.Tag.ToString()) == nIdAgenteCarga)
						{
							lviAgenteCarga.Selected = true;
							break;
						}
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallAgentesCargaSalvaSelecionado()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallAgentesCargaSalvaSelecionado != null)
				{
					int nIdAgenteCarga = -1;
					if (m_lvAgentesCarga.SelectedItems.Count > 0)
						nIdAgenteCarga = Int32.Parse(m_lvAgentesCarga.SelectedItems[0].Tag.ToString());
					eCallAgentesCargaSalvaSelecionado(nIdAgenteCarga);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallAgentesCargaNovo()
			{
				if (eCallAgentesCargaNovo != null)
					return(eCallAgentesCargaNovo());
				else
					return(false);
			}

			protected virtual bool OnCallAgentesCargaEditar()
			{
				if ((eCallAgentesCargaEditar != null) && (m_lvAgentesCarga.SelectedItems.Count > 0))
					return(eCallAgentesCargaEditar(Int32.Parse(m_lvAgentesCarga.SelectedItems[0].Tag.ToString())));
				else
					return(false);
			}

			protected virtual bool OnCallAgentesCargaExcluir()
			{
				if ((eCallAgentesCargaExcluir != null) && (m_lvAgentesCarga.SelectedItems.Count > 0))
				{
					System.Collections.ArrayList arlAgentesCarga = new ArrayList();
					foreach(System.Windows.Forms.ListViewItem lviAgenteCarga in m_lvAgentesCarga.SelectedItems)
						arlAgentesCarga.Add(Int32.Parse(lviAgenteCarga.Tag.ToString()));
					return(eCallAgentesCargaExcluir(ref arlAgentesCarga,false));
				}else
					return(false);
			}

			protected virtual void OnCallShowDialogContatos()
			{
				if ((eCallShowDialogContatos != null) && (m_lvAgentesCarga.SelectedItems.Count > 0))
					eCallShowDialogContatos(Int32.Parse(m_lvAgentesCarga.SelectedItems[0].Tag.ToString()));
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
			private string m_strEnderecoExecutavel = "";

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbAgentesCarga;
			private System.Windows.Forms.ListView m_lvAgentesCarga;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Button m_btContatos;
			private System.Windows.Forms.Button m_btExcluir;
			private System.Windows.Forms.Button m_btEditar;
			private System.Windows.Forms.Button m_btNovo;
			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmFAgentesCarga(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFAgentesCarga));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbAgentesCarga = new System.Windows.Forms.GroupBox();
			this.m_btContatos = new System.Windows.Forms.Button();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_lvAgentesCarga = new System.Windows.Forms.ListView();
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
			this.m_gbGeral.Location = new System.Drawing.Point(4, -3);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(308, 312);
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
			this.m_btOk.Location = new System.Drawing.Point(100, 282);
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
			this.m_btCancelar.Location = new System.Drawing.Point(164, 282);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 4;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbAgentesCarga
			// 
			this.m_gbAgentesCarga.Controls.Add(this.m_btContatos);
			this.m_gbAgentesCarga.Controls.Add(this.m_btExcluir);
			this.m_gbAgentesCarga.Controls.Add(this.m_btEditar);
			this.m_gbAgentesCarga.Controls.Add(this.m_btNovo);
			this.m_gbAgentesCarga.Controls.Add(this.m_lvAgentesCarga);
			this.m_gbAgentesCarga.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbAgentesCarga.Location = new System.Drawing.Point(7, 9);
			this.m_gbAgentesCarga.Name = "m_gbAgentesCarga";
			this.m_gbAgentesCarga.Size = new System.Drawing.Size(297, 271);
			this.m_gbAgentesCarga.TabIndex = 0;
			this.m_gbAgentesCarga.TabStop = false;
			this.m_gbAgentesCarga.Text = "Agentes de Carga";
			// 
			// m_btContatos
			// 
			this.m_btContatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btContatos.BackColor = System.Drawing.SystemColors.Control;
			this.m_btContatos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContatos.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContatos.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContatos.Image = ((System.Drawing.Image)(resources.GetObject("m_btContatos.Image")));
			this.m_btContatos.Location = new System.Drawing.Point(264, 17);
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
			this.m_btExcluir.Location = new System.Drawing.Point(168, 16);
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
			this.m_btEditar.Location = new System.Drawing.Point(136, 16);
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
			this.m_btNovo.Location = new System.Drawing.Point(104, 16);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 5;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btNovo, "Novo");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_lvAgentesCarga
			// 
			this.m_lvAgentesCarga.HideSelection = false;
			this.m_lvAgentesCarga.Location = new System.Drawing.Point(8, 45);
			this.m_lvAgentesCarga.Name = "m_lvAgentesCarga";
			this.m_lvAgentesCarga.Size = new System.Drawing.Size(280, 216);
			this.m_lvAgentesCarga.TabIndex = 0;
			this.m_lvAgentesCarga.View = System.Windows.Forms.View.List;
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFAgentesCarga
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(314, 312);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFAgentesCarga";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Agentes de Carga";
			this.Load += new System.EventHandler(this.frmFAgentesCarga_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbAgentesCarga.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFAgentesCarga_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallAgentesCargaRefresh();
					OnCallAgentesCargaCarregaSelecionado();
				}
			#endregion
			#region Botoes
				private void m_btNovo_Click(object sender, System.EventArgs e)
				{
					if (OnCallAgentesCargaNovo())
						OnCallAgentesCargaRefresh();
				}

				private void m_btEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallAgentesCargaEditar())
						OnCallAgentesCargaRefresh();
				}

				private void m_btExcluir_Click(object sender, System.EventArgs e)
				{
					if (OnCallAgentesCargaExcluir())
						OnCallAgentesCargaRefresh();
				}

				private void m_btContatos_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogContatos();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					OnCallAgentesCargaSalvaSelecionado();
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
