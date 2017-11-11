using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlSD.Formularios
{
	/// <summary>
	/// Summary description for frmFSDs.
	/// </summary>
	public class frmFSDs : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallRefreshSDs(ref mdlComponentesGraficos.ListView lvSDs);
			public delegate void delCallShowConfiguracoes();
			public delegate bool delCallShowSDNovo();
			public delegate bool delCallShowSDEditar(int nIdSD);
			public delegate bool delCallShowSDRemover(int nIdSD);
			public delegate bool delCallShowSDVincular(int nIdSD);
			public delegate bool delCallSalvaDados();
		#endregion
		#region Events
			public event delCallRefreshSDs eCallRefreshSDs;
			public event delCallShowConfiguracoes eCallShowConfiguracoes;
			public event delCallShowSDNovo eCallShowSDNovo;
			public event delCallShowSDEditar eCallShowSDEditar;
			public event delCallShowSDRemover eCallShowSDRemover;
			public event delCallShowSDVincular eCallShowSDVincular;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			public virtual void OnCallRefreshSDs()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshSDs != null)
					eCallRefreshSDs(ref m_lvSDs);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallShowConfiguracoes()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowConfiguracoes != null)
					eCallShowConfiguracoes();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallShowSDNovo()
			{				
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowSDNovo != null)
					bRetorno = eCallShowSDNovo();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallShowSDEditar()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowSDEditar != null)
				{
					if (m_lvSDs.SelectedItems.Count > 0)
					{
						int nIdSD = Int32.Parse(m_lvSDs.SelectedItems[0].Tag.ToString());
						bRetorno = eCallShowSDEditar(nIdSD);
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallShowSDRemover()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowSDRemover != null)
				{
					if (m_lvSDs.SelectedItems.Count > 0)
					{
						int nIdSD = Int32.Parse(m_lvSDs.SelectedItems[0].Tag.ToString());
						bRetorno = eCallShowSDRemover(nIdSD);
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual void OnCallShowSDVincular()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowSDVincular != null)
				{
					if (m_lvSDs.SelectedItems.Count > 0)
					{
						int nIdSD = Int32.Parse(m_lvSDs.SelectedItems[0].Tag.ToString());
						if (eCallShowSDVincular(nIdSD))
							OnCallRefreshSDs();
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
			bool m_bModificado = false;

			private System.Windows.Forms.ToolTip m_ttDicas;
			public System.Windows.Forms.Button button1;
			private System.ComponentModel.IContainer components;
			private System.Windows.Forms.GroupBox m_gbMain;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbSDs;
			public System.Windows.Forms.Button m_btConfiguracoes;
			public System.Windows.Forms.Button m_btSDExclui;
			public System.Windows.Forms.Button m_btSDNovo;
			private mdlComponentesGraficos.ListView m_lvSDs;
			private System.Windows.Forms.ColumnHeader m_chNumero;
			public System.Windows.Forms.Button m_btSDEditar;
		#endregion
		#region Propriedades
			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}
		#endregion
		#region Constructores
			public frmFSDs(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFSDs));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbSDs = new System.Windows.Forms.GroupBox();
			this.m_btSDEditar = new System.Windows.Forms.Button();
			this.m_btConfiguracoes = new System.Windows.Forms.Button();
			this.m_btSDExclui = new System.Windows.Forms.Button();
			this.m_btSDNovo = new System.Windows.Forms.Button();
			this.m_lvSDs = new mdlComponentesGraficos.ListView();
			this.m_chNumero = new System.Windows.Forms.ColumnHeader();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gbSDs.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_gbSDs);
			this.m_gbMain.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMain.Location = new System.Drawing.Point(3, -3);
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
			// m_gbSDs
			// 
			this.m_gbSDs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbSDs.Controls.Add(this.button1);
			this.m_gbSDs.Controls.Add(this.m_btSDEditar);
			this.m_gbSDs.Controls.Add(this.m_btConfiguracoes);
			this.m_gbSDs.Controls.Add(this.m_btSDExclui);
			this.m_gbSDs.Controls.Add(this.m_btSDNovo);
			this.m_gbSDs.Controls.Add(this.m_lvSDs);
			this.m_gbSDs.Location = new System.Drawing.Point(7, 7);
			this.m_gbSDs.Name = "m_gbSDs";
			this.m_gbSDs.Size = new System.Drawing.Size(367, 329);
			this.m_gbSDs.TabIndex = 0;
			this.m_gbSDs.TabStop = false;
			this.m_gbSDs.Text = "DDEs";
			// 
			// m_btSDEditar
			// 
			this.m_btSDEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btSDEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSDEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btSDEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btSDEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btSDEditar.Image")));
			this.m_btSDEditar.Location = new System.Drawing.Point(171, 14);
			this.m_btSDEditar.Name = "m_btSDEditar";
			this.m_btSDEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btSDEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btSDEditar.TabIndex = 22;
			this.m_btSDEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btSDEditar.Click += new System.EventHandler(this.m_btSDEditar_Click);
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
			// m_btSDExclui
			// 
			this.m_btSDExclui.BackColor = System.Drawing.SystemColors.Control;
			this.m_btSDExclui.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSDExclui.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btSDExclui.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btSDExclui.Image = ((System.Drawing.Image)(resources.GetObject("m_btSDExclui.Image")));
			this.m_btSDExclui.Location = new System.Drawing.Point(199, 14);
			this.m_btSDExclui.Name = "m_btSDExclui";
			this.m_btSDExclui.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btSDExclui.Size = new System.Drawing.Size(25, 25);
			this.m_btSDExclui.TabIndex = 20;
			this.m_btSDExclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btSDExclui.Click += new System.EventHandler(this.m_btSDExclui_Click);
			// 
			// m_btSDNovo
			// 
			this.m_btSDNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btSDNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSDNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btSDNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btSDNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btSDNovo.Image")));
			this.m_btSDNovo.Location = new System.Drawing.Point(143, 14);
			this.m_btSDNovo.Name = "m_btSDNovo";
			this.m_btSDNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btSDNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btSDNovo.TabIndex = 19;
			this.m_btSDNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btSDNovo.Click += new System.EventHandler(this.m_btSDNovo_Click);
			// 
			// m_lvSDs
			// 
			this.m_lvSDs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvSDs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.m_chNumero});
			this.m_lvSDs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvSDs.HideSelection = false;
			this.m_lvSDs.Location = new System.Drawing.Point(7, 42);
			this.m_lvSDs.Name = "m_lvSDs";
			this.m_lvSDs.Size = new System.Drawing.Size(352, 280);
			this.m_lvSDs.TabIndex = 0;
			this.m_lvSDs.View = System.Windows.Forms.View.Details;
			this.m_lvSDs.DoubleClick += new System.EventHandler(this.m_lvSDs_DoubleClick);
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
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(115, 14);
			this.button1.Name = "button1";
			this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.button1.Size = new System.Drawing.Size(25, 25);
			this.button1.TabIndex = 23;
			this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.button1, "Clique aqui para vincular um RE a esta  DDE");
			// 
			// frmFSDs
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 373);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFSDs";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DDEs";
			this.Load += new System.EventHandler(this.frmFSDs_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbSDs.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFSDs_Load(object sender, System.EventArgs e)
				{
					OnCallRefreshSDs();
				}
			#endregion
			#region ListView
				private void m_lvSDs_DoubleClick(object sender, System.EventArgs e)
				{
					OnCallShowSDVincular();
				}
			#endregion
			#region Botoes
				private void m_btSDNovo_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowSDNovo())
						OnCallRefreshSDs();
				}

				private void m_btSDEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowSDEditar())
						OnCallRefreshSDs();
				}

				private void m_btSDExclui_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowSDRemover())
						OnCallRefreshSDs();
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
