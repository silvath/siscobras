using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlDSE.Formularios
{
	/// <summary>
	/// Summary description for frmFDSEs.
	/// </summary>
	public class frmFDSEs : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallRefreshDSEs(ref mdlComponentesGraficos.ListView lvDSEs);
			public delegate void delCallShowConfiguracoes();
			public delegate bool delCallShowDSENovo();
			public delegate bool delCallShowDSEEditar(int nIdDSE);
			public delegate bool delCallShowDSERemover(int nIdDSE);
			public delegate bool delCallShowDSEInformacoes(int nIdDSE);
			public delegate bool delCallSalvaDados();
		#endregion
		#region Events
			public event delCallRefreshDSEs eCallRefreshDSEs;
			public event delCallShowConfiguracoes eCallShowConfiguracoes;
			public event delCallShowDSENovo eCallShowDSENovo;
			public event delCallShowDSEEditar eCallShowDSEEditar;
			public event delCallShowDSERemover eCallShowDSERemover;
			public event delCallShowDSEInformacoes eCallShowDSEInformacoes;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			public virtual void OnCallRefreshDSEs()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshDSEs != null)
					eCallRefreshDSEs(ref m_lvDSEs);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallShowConfiguracoes()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowConfiguracoes != null)
					eCallShowConfiguracoes();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallShowDSENovo()
			{				
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowDSENovo != null)
					bRetorno = eCallShowDSENovo();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallShowDSEEditar()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowDSERemover != null)
				{
					if (m_lvDSEs.SelectedItems.Count > 0)
					{
						int nIdDSE = Int32.Parse(m_lvDSEs.SelectedItems[0].Tag.ToString());
						bRetorno = eCallShowDSEEditar(nIdDSE);
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallShowDSERemover()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowDSERemover != null)
				{
					if (m_lvDSEs.SelectedItems.Count > 0)
					{
						int nIdDSE = Int32.Parse(m_lvDSEs.SelectedItems[0].Tag.ToString());
						bRetorno = eCallShowDSERemover(nIdDSE);
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual void OnCallShowDSEInformacoes()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowDSEInformacoes != null)
				{
					if (m_lvDSEs.SelectedItems.Count > 0)
					{
						int nIdDSE = Int32.Parse(m_lvDSEs.SelectedItems[0].Tag.ToString());
						if (eCallShowDSEInformacoes(nIdDSE))
							OnCallRefreshDSEs();
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallSalvaDados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallSalvaDados != null)
					bRetorno = eCallSalvaDados();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributos
			private bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbDSEs;
			public System.Windows.Forms.Button m_btConfiguracoes;
			public System.Windows.Forms.Button m_btDSEExclui;
			public System.Windows.Forms.Button m_btDSENovo;
			private System.Windows.Forms.ColumnHeader m_chNumero;
		private mdlComponentesGraficos.ListView m_lvDSEs;
		public System.Windows.Forms.Button m_btDSEEditar;
		#endregion
		private System.Windows.Forms.ToolTip m_ttDicas;
		private System.ComponentModel.IContainer components;
		#region Propriedades
			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}
		#endregion
		#region Construtores
			public frmFDSEs(string strEnderecoExecutavel)
			{
				InitializeComponent();
				vMostraCor(strEnderecoExecutavel);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFDSEs));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbDSEs = new System.Windows.Forms.GroupBox();
			this.m_btDSEEditar = new System.Windows.Forms.Button();
			this.m_btConfiguracoes = new System.Windows.Forms.Button();
			this.m_btDSEExclui = new System.Windows.Forms.Button();
			this.m_btDSENovo = new System.Windows.Forms.Button();
			this.m_lvDSEs = new mdlComponentesGraficos.ListView();
			this.m_chNumero = new System.Windows.Forms.ColumnHeader();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbMain.SuspendLayout();
			this.m_gbDSEs.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_gbDSEs);
			this.m_gbMain.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMain.Location = new System.Drawing.Point(3, -1);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(378, 375);
			this.m_gbMain.TabIndex = 1;
			this.m_gbMain.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(133, 343);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 12;
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
			this.m_btCancelar.Location = new System.Drawing.Point(197, 343);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 13;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbDSEs
			// 
			this.m_gbDSEs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbDSEs.Controls.Add(this.m_btDSEEditar);
			this.m_gbDSEs.Controls.Add(this.m_btConfiguracoes);
			this.m_gbDSEs.Controls.Add(this.m_btDSEExclui);
			this.m_gbDSEs.Controls.Add(this.m_btDSENovo);
			this.m_gbDSEs.Controls.Add(this.m_lvDSEs);
			this.m_gbDSEs.Location = new System.Drawing.Point(7, 7);
			this.m_gbDSEs.Name = "m_gbDSEs";
			this.m_gbDSEs.Size = new System.Drawing.Size(367, 329);
			this.m_gbDSEs.TabIndex = 0;
			this.m_gbDSEs.TabStop = false;
			this.m_gbDSEs.Text = "DSEs";
			// 
			// m_btDSEEditar
			// 
			this.m_btDSEEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btDSEEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDSEEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDSEEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btDSEEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btDSEEditar.Image")));
			this.m_btDSEEditar.Location = new System.Drawing.Point(172, 15);
			this.m_btDSEEditar.Name = "m_btDSEEditar";
			this.m_btDSEEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDSEEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btDSEEditar.TabIndex = 22;
			this.m_btDSEEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btDSEEditar, "Editar");
			this.m_btDSEEditar.Click += new System.EventHandler(this.m_btDSEEditar_Click);
			// 
			// m_btConfiguracoes
			// 
			this.m_btConfiguracoes.BackColor = System.Drawing.SystemColors.Control;
			this.m_btConfiguracoes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btConfiguracoes.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btConfiguracoes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btConfiguracoes.Image = ((System.Drawing.Image)(resources.GetObject("m_btConfiguracoes.Image")));
			this.m_btConfiguracoes.Location = new System.Drawing.Point(8, 15);
			this.m_btConfiguracoes.Name = "m_btConfiguracoes";
			this.m_btConfiguracoes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btConfiguracoes.Size = new System.Drawing.Size(25, 25);
			this.m_btConfiguracoes.TabIndex = 21;
			this.m_btConfiguracoes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btConfiguracoes.Visible = false;
			// 
			// m_btDSEExclui
			// 
			this.m_btDSEExclui.BackColor = System.Drawing.SystemColors.Control;
			this.m_btDSEExclui.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDSEExclui.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDSEExclui.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btDSEExclui.Image = ((System.Drawing.Image)(resources.GetObject("m_btDSEExclui.Image")));
			this.m_btDSEExclui.Location = new System.Drawing.Point(200, 15);
			this.m_btDSEExclui.Name = "m_btDSEExclui";
			this.m_btDSEExclui.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDSEExclui.Size = new System.Drawing.Size(25, 25);
			this.m_btDSEExclui.TabIndex = 20;
			this.m_btDSEExclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btDSEExclui, "Excluir");
			this.m_btDSEExclui.Click += new System.EventHandler(this.m_btDSEExclui_Click);
			// 
			// m_btDSENovo
			// 
			this.m_btDSENovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btDSENovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDSENovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDSENovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btDSENovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btDSENovo.Image")));
			this.m_btDSENovo.Location = new System.Drawing.Point(143, 15);
			this.m_btDSENovo.Name = "m_btDSENovo";
			this.m_btDSENovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDSENovo.Size = new System.Drawing.Size(25, 25);
			this.m_btDSENovo.TabIndex = 19;
			this.m_btDSENovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btDSENovo, "Nova");
			this.m_btDSENovo.Click += new System.EventHandler(this.m_btDSENovo_Click);
			// 
			// m_lvDSEs
			// 
			this.m_lvDSEs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvDSEs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.m_chNumero});
			this.m_lvDSEs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvDSEs.HideSelection = false;
			this.m_lvDSEs.Location = new System.Drawing.Point(7, 42);
			this.m_lvDSEs.Name = "m_lvDSEs";
			this.m_lvDSEs.Size = new System.Drawing.Size(352, 280);
			this.m_lvDSEs.TabIndex = 0;
			this.m_lvDSEs.View = System.Windows.Forms.View.Details;
			this.m_lvDSEs.DoubleClick += new System.EventHandler(this.m_lvDSEs_DoubleClick);
			// 
			// m_chNumero
			// 
			this.m_chNumero.Text = "m_chNumero";
			this.m_chNumero.Width = 300;
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFDSEs
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 373);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFDSEs";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DSEs";
			this.Load += new System.EventHandler(this.frmFDSEs_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbDSEs.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFDSEs_Load(object sender, System.EventArgs e)
				{
					OnCallRefreshDSEs();
				}
			#endregion
			#region ListView
			private void m_lvDSEs_DoubleClick(object sender, System.EventArgs e)
			{
				OnCallShowDSEInformacoes();
			}
			#endregion
			#region Botoes
				private void m_btDSENovo_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowDSENovo())
						OnCallRefreshDSEs();
				}

				private void m_btDSEEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowDSEEditar())
						OnCallRefreshDSEs();
				}

				private void m_btDSEExclui_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowDSERemover())
						OnCallRefreshDSEs();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					this.m_bModificado = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.m_bModificado = false;
					this.Close();
				}
			#endregion
		#endregion

		#region Cores
			private void vMostraCor(string strEnderecoExecutavel)
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
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
