using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlDSE.Formularios
{
	/// <summary>
	/// Summary description for frmFDSEVincular.
	/// </summary>
	public class frmFDSEVincular : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallRefreshDSEs(ref mdlComponentesGraficos.ListView lvDSEs);
			public delegate void delCallRefreshDSEsVinculados(ref mdlComponentesGraficos.ListView lvDSEsPEs);
			public delegate bool delCallShowDialogDSEs();
			public delegate bool delCallDSEVincular(frmFDSEVincular sender,int nIdDSE);
			public delegate bool delCallDSEDesvincular(frmFDSEVincular sender,int nIdDSE);
			public delegate bool delCallShowDSENovo();
			public delegate bool delCallShowDSEEditar(int nIdDSE);
			public delegate bool delCallShowDSERemover(int nIdDSE);
		#endregion
		#region Events
			public event delCallRefreshDSEs eCallRefreshDSEs;
			public event delCallRefreshDSEsVinculados eCallRefreshDSEsVinculados;
			public event delCallShowDialogDSEs eCallShowDialogDSEs;
			public event delCallDSEVincular eCallDSEVincular;
			public event delCallDSEDesvincular eCallDSEDesvincular;
			public event delCallShowDSENovo eCallShowDSENovo;
			public event delCallShowDSEEditar eCallShowDSEEditar;
			public event delCallShowDSERemover eCallShowDSERemover;
		#endregion
		#region Events Methods
			public virtual void OnCallRefreshDSEs()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshDSEs != null)
					eCallRefreshDSEs(ref m_lvDSEs);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual void OnCallRefreshDSEsVinculados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshDSEsVinculados != null)
					eCallRefreshDSEsVinculados(ref m_lvDSEsVinculados);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual bool OnCallShowDialogDSEs()
			{
				bool bReturno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowDialogDSEs != null)
					bReturno = eCallShowDialogDSEs();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturno);
			}

			public virtual bool OnCallDSEVincular()
			{
				bool bReturno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if ((eCallDSEVincular != null) && (m_lvDSEs.SelectedItems.Count > 0))
					bReturno = eCallDSEVincular(this,Int32.Parse(m_lvDSEs.SelectedItems[0].Tag.ToString()));
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturno);
			}

			public virtual bool OnCallDSEDesvincular()
			{
				bool bReturno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if ((eCallDSEDesvincular != null) && (m_lvDSEsVinculados.SelectedItems.Count > 0))
					bReturno = eCallDSEDesvincular(this,Int32.Parse(m_lvDSEsVinculados.SelectedItems[0].Tag.ToString()));
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturno);
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
		#endregion

		#region Atributos
			private bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			public System.Windows.Forms.Button m_btREs;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.ColumnHeader m_chREPE;
			private System.Windows.Forms.ColumnHeader m_chRENumero;
			private System.Windows.Forms.Button m_btDSERemove;
			private System.Windows.Forms.Button m_btDSEInsere;
			private System.Windows.Forms.GroupBox m_gbDSEsVinculados;
			private mdlComponentesGraficos.ListView m_lvDSEsVinculados;
			private System.Windows.Forms.GroupBox m_gbDSEs;
			private mdlComponentesGraficos.ListView m_lvDSEs;
			private mdlComponentesGraficos.TextBox m_txtPersonalizavel;
		private System.Windows.Forms.GroupBox m_gbPersonalizavel;
		public System.Windows.Forms.Button m_btDSEEditar;
		public System.Windows.Forms.Button m_btDSEExclui;
		public System.Windows.Forms.Button m_btDSENovo;
		#endregion
		private System.Windows.Forms.ToolTip m_ttDicas;
		private System.ComponentModel.IContainer components;
		#region Properties
			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}
			
			public string Personalizavel
			{
				set
				{
					m_txtPersonalizavel.Text= value;
				}
				get
				{
					return(m_txtPersonalizavel.Text);
				}
			}
			
			public bool Editavel
			{
				set
				{
					m_txtPersonalizavel.Enabled = value;
				}
			}
		#endregion
		#region Construtores
			public frmFDSEVincular(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFDSEVincular));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbPersonalizavel = new System.Windows.Forms.GroupBox();
			this.m_txtPersonalizavel = new mdlComponentesGraficos.TextBox();
			this.m_btREs = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btDSERemove = new System.Windows.Forms.Button();
			this.m_btDSEInsere = new System.Windows.Forms.Button();
			this.m_gbDSEsVinculados = new System.Windows.Forms.GroupBox();
			this.m_lvDSEsVinculados = new mdlComponentesGraficos.ListView();
			this.m_chREPE = new System.Windows.Forms.ColumnHeader();
			this.m_gbDSEs = new System.Windows.Forms.GroupBox();
			this.m_btDSEEditar = new System.Windows.Forms.Button();
			this.m_btDSEExclui = new System.Windows.Forms.Button();
			this.m_btDSENovo = new System.Windows.Forms.Button();
			this.m_lvDSEs = new mdlComponentesGraficos.ListView();
			this.m_chRENumero = new System.Windows.Forms.ColumnHeader();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbMain.SuspendLayout();
			this.m_gbPersonalizavel.SuspendLayout();
			this.m_gbDSEsVinculados.SuspendLayout();
			this.m_gbDSEs.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbPersonalizavel);
			this.m_gbMain.Controls.Add(this.m_btREs);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btDSERemove);
			this.m_gbMain.Controls.Add(this.m_btDSEInsere);
			this.m_gbMain.Controls.Add(this.m_gbDSEsVinculados);
			this.m_gbMain.Controls.Add(this.m_gbDSEs);
			this.m_gbMain.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMain.Location = new System.Drawing.Point(3, -1);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(341, 395);
			this.m_gbMain.TabIndex = 1;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbPersonalizavel
			// 
			this.m_gbPersonalizavel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPersonalizavel.Controls.Add(this.m_txtPersonalizavel);
			this.m_gbPersonalizavel.Location = new System.Drawing.Point(5, 291);
			this.m_gbPersonalizavel.Name = "m_gbPersonalizavel";
			this.m_gbPersonalizavel.Size = new System.Drawing.Size(331, 72);
			this.m_gbPersonalizavel.TabIndex = 22;
			this.m_gbPersonalizavel.TabStop = false;
			this.m_gbPersonalizavel.Text = "Personalizável";
			// 
			// m_txtPersonalizavel
			// 
			this.m_txtPersonalizavel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtPersonalizavel.Location = new System.Drawing.Point(8, 16);
			this.m_txtPersonalizavel.Multiline = true;
			this.m_txtPersonalizavel.Name = "m_txtPersonalizavel";
			this.m_txtPersonalizavel.Size = new System.Drawing.Size(314, 48);
			this.m_txtPersonalizavel.TabIndex = 0;
			this.m_txtPersonalizavel.Text = "";
			// 
			// m_btREs
			// 
			this.m_btREs.BackColor = System.Drawing.SystemColors.Control;
			this.m_btREs.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btREs.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btREs.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btREs.Image = ((System.Drawing.Image)(resources.GetObject("m_btREs.Image")));
			this.m_btREs.Location = new System.Drawing.Point(8, 155);
			this.m_btREs.Name = "m_btREs";
			this.m_btREs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btREs.Size = new System.Drawing.Size(25, 25);
			this.m_btREs.TabIndex = 21;
			this.m_btREs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btREs, "DSE\'s");
			this.m_btREs.Click += new System.EventHandler(this.m_btREs_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(174, 365);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 11;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(110, 365);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 10;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btDSERemove
			// 
			this.m_btDSERemove.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDSERemove.Image = ((System.Drawing.Image)(resources.GetObject("m_btDSERemove.Image")));
			this.m_btDSERemove.Location = new System.Drawing.Point(176, 145);
			this.m_btDSERemove.Name = "m_btDSERemove";
			this.m_btDSERemove.Size = new System.Drawing.Size(60, 40);
			this.m_btDSERemove.TabIndex = 8;
			this.m_ttDicas.SetToolTip(this.m_btDSERemove, "Desvincular");
			this.m_btDSERemove.Click += new System.EventHandler(this.m_btRERemove_Click);
			// 
			// m_btDSEInsere
			// 
			this.m_btDSEInsere.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDSEInsere.Image = ((System.Drawing.Image)(resources.GetObject("m_btDSEInsere.Image")));
			this.m_btDSEInsere.Location = new System.Drawing.Point(112, 145);
			this.m_btDSEInsere.Name = "m_btDSEInsere";
			this.m_btDSEInsere.Size = new System.Drawing.Size(60, 40);
			this.m_btDSEInsere.TabIndex = 7;
			this.m_ttDicas.SetToolTip(this.m_btDSEInsere, "Vincular");
			this.m_btDSEInsere.Click += new System.EventHandler(this.m_btREInsere_Click);
			// 
			// m_gbDSEsVinculados
			// 
			this.m_gbDSEsVinculados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbDSEsVinculados.Controls.Add(this.m_lvDSEsVinculados);
			this.m_gbDSEsVinculados.Location = new System.Drawing.Point(5, 187);
			this.m_gbDSEsVinculados.Name = "m_gbDSEsVinculados";
			this.m_gbDSEsVinculados.Size = new System.Drawing.Size(331, 104);
			this.m_gbDSEsVinculados.TabIndex = 1;
			this.m_gbDSEsVinculados.TabStop = false;
			this.m_gbDSEsVinculados.Text = "DSEs vinculados a este PE";
			// 
			// m_lvDSEsVinculados
			// 
			this.m_lvDSEsVinculados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvDSEsVinculados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.m_chREPE});
			this.m_lvDSEsVinculados.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvDSEsVinculados.HideSelection = false;
			this.m_lvDSEsVinculados.Location = new System.Drawing.Point(4, 15);
			this.m_lvDSEsVinculados.Name = "m_lvDSEsVinculados";
			this.m_lvDSEsVinculados.Size = new System.Drawing.Size(318, 80);
			this.m_lvDSEsVinculados.TabIndex = 1;
			this.m_lvDSEsVinculados.View = System.Windows.Forms.View.Details;
			// 
			// m_chREPE
			// 
			this.m_chREPE.Text = "m_chREPE";
			this.m_chREPE.Width = 200;
			// 
			// m_gbDSEs
			// 
			this.m_gbDSEs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbDSEs.Controls.Add(this.m_btDSEEditar);
			this.m_gbDSEs.Controls.Add(this.m_btDSEExclui);
			this.m_gbDSEs.Controls.Add(this.m_btDSENovo);
			this.m_gbDSEs.Controls.Add(this.m_lvDSEs);
			this.m_gbDSEs.Location = new System.Drawing.Point(6, 7);
			this.m_gbDSEs.Name = "m_gbDSEs";
			this.m_gbDSEs.Size = new System.Drawing.Size(331, 136);
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
			this.m_btDSEEditar.Location = new System.Drawing.Point(154, 8);
			this.m_btDSEEditar.Name = "m_btDSEEditar";
			this.m_btDSEEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDSEEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btDSEEditar.TabIndex = 25;
			this.m_btDSEEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btDSEEditar, "Editar");
			this.m_btDSEEditar.Click += new System.EventHandler(this.m_btDSEEditar_Click);
			// 
			// m_btDSEExclui
			// 
			this.m_btDSEExclui.BackColor = System.Drawing.SystemColors.Control;
			this.m_btDSEExclui.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDSEExclui.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDSEExclui.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btDSEExclui.Image = ((System.Drawing.Image)(resources.GetObject("m_btDSEExclui.Image")));
			this.m_btDSEExclui.Location = new System.Drawing.Point(186, 8);
			this.m_btDSEExclui.Name = "m_btDSEExclui";
			this.m_btDSEExclui.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDSEExclui.Size = new System.Drawing.Size(25, 25);
			this.m_btDSEExclui.TabIndex = 24;
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
			this.m_btDSENovo.Location = new System.Drawing.Point(122, 8);
			this.m_btDSENovo.Name = "m_btDSENovo";
			this.m_btDSENovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDSENovo.Size = new System.Drawing.Size(25, 25);
			this.m_btDSENovo.TabIndex = 23;
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
																					   this.m_chRENumero});
			this.m_lvDSEs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvDSEs.HideSelection = false;
			this.m_lvDSEs.Location = new System.Drawing.Point(7, 36);
			this.m_lvDSEs.Name = "m_lvDSEs";
			this.m_lvDSEs.Size = new System.Drawing.Size(315, 92);
			this.m_lvDSEs.TabIndex = 0;
			this.m_lvDSEs.View = System.Windows.Forms.View.Details;
			// 
			// m_chRENumero
			// 
			this.m_chRENumero.Text = "m_chRENumero";
			this.m_chRENumero.Width = 200;
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFDSEVincular
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(346, 397);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFDSEVincular";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Vincular";
			this.Load += new System.EventHandler(this.frmFDSEVincular_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbPersonalizavel.ResumeLayout(false);
			this.m_gbDSEsVinculados.ResumeLayout(false);
			this.m_gbDSEs.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFDSEVincular_Load(object sender, System.EventArgs e)
				{
					OnCallRefreshDSEs();
					OnCallRefreshDSEsVinculados();
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

				private void m_btREs_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowDialogDSEs())
						OnCallRefreshDSEs();
				}

				private void m_btREInsere_Click(object sender, System.EventArgs e)
				{
					if (OnCallDSEVincular())
					{
						OnCallRefreshDSEs();
						OnCallRefreshDSEsVinculados();
					}
				}

				private void m_btRERemove_Click(object sender, System.EventArgs e)
				{
					if (OnCallDSEDesvincular())
					{
						OnCallRefreshDSEs();
						OnCallRefreshDSEsVinculados();
					}
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
