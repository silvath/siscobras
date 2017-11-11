using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRE.Formularios
{
	/// <summary>
	/// Summary description for frmFREEspelho.
	/// </summary>
	public class frmFREEspelho : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallREsEspelhosRefresh(System.Windows.Forms.ListView lvResEspelhos,int nIdREEspelho);
			public delegate int delCallREsEspelhosNew();
			public delegate bool delCallREsEspelhosEdit(int nIdREEspelho);
			public delegate bool delCallREsEspelhosDelete(int nIdREEspelho);
		#endregion
		#region Events
			public event delCallREsEspelhosRefresh eCallREsEspelhosRefresh;
			public event delCallREsEspelhosNew eCallREsEspelhosNew;
			public event delCallREsEspelhosEdit eCallREsEspelhosEdit;
			public event delCallREsEspelhosDelete eCallREsEspelhosDelete;
		#endregion
		#region Events Methods
			public virtual void OnCallREsEspelhosRefresh()
			{
				OnCallREsEspelhosRefresh(-1);
			}

			public virtual void OnCallREsEspelhosRefresh(int index)
			{
				if (eCallREsEspelhosRefresh != null)
					eCallREsEspelhosRefresh(m_lvREsEspelhos,index);
			}

			public virtual int OnCallREsEspelhosNew()
			{
				if (eCallREsEspelhosNew == null)
					return(0);
				return(eCallREsEspelhosNew());
			}

			public virtual bool OnCallREsEspelhosEdit()
			{
				if (eCallREsEspelhosEdit == null)
					return(false);
				if (m_lvREsEspelhos.SelectedItems.Count == 0)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve escolher o RE que deseja editar.");
					return(false);
				}
				return(eCallREsEspelhosEdit(Int32.Parse(m_lvREsEspelhos.SelectedItems[0].Tag.ToString())));
			}

			public virtual bool OnCallREsEspelhosDelete()
			{
				if (eCallREsEspelhosDelete == null)
					return(false);
				if (m_lvREsEspelhos.SelectedItems.Count == 0)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve escolher o RE que deseja apagar.");
					return(false);
				}
				if (mdlMensagens.clsMensagens.ShowQuestion("SiscoRE","Deseja mesmo apagar este RE ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
					return(false);
				return(eCallREsEspelhosDelete(Int32.Parse(m_lvREsEspelhos.SelectedItems[0].Tag.ToString())));
			}
		#endregion

		#region Atributes
			private bool m_bConfirmed = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			internal mdlComponentesGraficos.Button m_btCancelar;
			internal mdlComponentesGraficos.Button m_btOk;
			private System.Windows.Forms.ListView m_lvREsEspelhos;
			public System.Windows.Forms.Button m_btRENovo;

			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.Windows.Forms.ColumnHeader m_chNumero;
			private System.Windows.Forms.ColumnHeader m_chPE;
			private System.Windows.Forms.ColumnHeader m_chEstado;
			public System.Windows.Forms.Button button3;
		private System.Windows.Forms.ColumnHeader m_chId;
		private System.Windows.Forms.ColumnHeader m_chDataCriacao;
		public System.Windows.Forms.Button m_btREExcluir;
		public System.Windows.Forms.Button m_btREEditar;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public bool Confirmed
			{
				get
				{
					return(m_bConfirmed);
				}
			}
		#endregion
		#region Constructors
			public frmFREEspelho()
			{
				InitializeComponent();
				vMostraCor();
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
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFREEspelho));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.m_btREExcluir = new System.Windows.Forms.Button();
			this.m_btREEditar = new System.Windows.Forms.Button();
			this.m_btRENovo = new System.Windows.Forms.Button();
			this.m_lvREsEspelhos = new System.Windows.Forms.ListView();
			this.m_chId = new System.Windows.Forms.ColumnHeader();
			this.m_chEstado = new System.Windows.Forms.ColumnHeader();
			this.m_chNumero = new System.Windows.Forms.ColumnHeader();
			this.m_chPE = new System.Windows.Forms.ColumnHeader();
			this.m_chDataCriacao = new System.Windows.Forms.ColumnHeader();
			this.m_btCancelar = new mdlComponentesGraficos.Button();
			this.m_btOk = new mdlComponentesGraficos.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.button3);
			this.m_gbMain.Controls.Add(this.m_btREExcluir);
			this.m_gbMain.Controls.Add(this.m_btREEditar);
			this.m_gbMain.Controls.Add(this.m_btRENovo);
			this.m_gbMain.Controls.Add(this.m_lvREsEspelhos);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Location = new System.Drawing.Point(2, 0);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(445, 434);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.Control;
			this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.Location = new System.Drawing.Point(5, 19);
			this.button3.Name = "button3";
			this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.button3.Size = new System.Drawing.Size(25, 25);
			this.button3.TabIndex = 23;
			this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.button3, "Novo");
			// 
			// m_btREExcluir
			// 
			this.m_btREExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btREExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btREExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btREExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btREExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btREExcluir.Image")));
			this.m_btREExcluir.Location = new System.Drawing.Point(240, 18);
			this.m_btREExcluir.Name = "m_btREExcluir";
			this.m_btREExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btREExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btREExcluir.TabIndex = 22;
			this.m_btREExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btREExcluir, "Cancelar");
			this.m_btREExcluir.Click += new System.EventHandler(this.m_btREExcluir_Click);
			// 
			// m_btREEditar
			// 
			this.m_btREEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btREEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btREEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btREEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btREEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btREEditar.Image")));
			this.m_btREEditar.Location = new System.Drawing.Point(208, 18);
			this.m_btREEditar.Name = "m_btREEditar";
			this.m_btREEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btREEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btREEditar.TabIndex = 21;
			this.m_btREEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btREEditar, "Editar");
			this.m_btREEditar.Click += new System.EventHandler(this.m_btREEditar_Click);
			// 
			// m_btRENovo
			// 
			this.m_btRENovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btRENovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRENovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btRENovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btRENovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btRENovo.Image")));
			this.m_btRENovo.Location = new System.Drawing.Point(176, 18);
			this.m_btRENovo.Name = "m_btRENovo";
			this.m_btRENovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btRENovo.Size = new System.Drawing.Size(25, 25);
			this.m_btRENovo.TabIndex = 20;
			this.m_btRENovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btRENovo, "Novo");
			this.m_btRENovo.Click += new System.EventHandler(this.m_btRENovo_Click);
			// 
			// m_lvREsEspelhos
			// 
			this.m_lvREsEspelhos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvREsEspelhos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.m_chId,
																							  this.m_chEstado,
																							  this.m_chNumero,
																							  this.m_chPE,
																							  this.m_chDataCriacao});
			this.m_lvREsEspelhos.FullRowSelect = true;
			this.m_lvREsEspelhos.HideSelection = false;
			this.m_lvREsEspelhos.Location = new System.Drawing.Point(6, 48);
			this.m_lvREsEspelhos.Name = "m_lvREsEspelhos";
			this.m_lvREsEspelhos.Size = new System.Drawing.Size(434, 352);
			this.m_lvREsEspelhos.TabIndex = 14;
			this.m_lvREsEspelhos.View = System.Windows.Forms.View.Details;
			// 
			// m_chId
			// 
			this.m_chId.Text = "ID";
			this.m_chId.Width = 41;
			// 
			// m_chEstado
			// 
			this.m_chEstado.Text = "Estado";
			this.m_chEstado.Width = 79;
			// 
			// m_chNumero
			// 
			this.m_chNumero.Text = "Número";
			this.m_chNumero.Width = 114;
			// 
			// m_chPE
			// 
			this.m_chPE.Text = "PE";
			this.m_chPE.Width = 77;
			// 
			// m_chDataCriacao
			// 
			this.m_chDataCriacao.Text = "Data Criação";
			this.m_chDataCriacao.Width = 115;
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.GradiendColorEnd = System.Drawing.Color.Black;
			this.m_btCancelar.GradiendColorStart = System.Drawing.Color.White;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(225, 404);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 13;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Type = mdlComponentesGraficos.Button.ButtonType.Cancel;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.GradiendColorEnd = System.Drawing.Color.Black;
			this.m_btOk.GradiendColorStart = System.Drawing.Color.White;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(161, 404);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 12;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Type = mdlComponentesGraficos.Button.ButtonType.Ok;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFREEspelho
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 437);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFREEspelho";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SiscoRE - Gerenciador de REs";
			this.Load += new System.EventHandler(this.frmFREEspelho_Load);
			this.m_gbMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Cores
			private void vMostraCor()
			{
				this.BackColor = mdlConstantes.clsConfig.FirstColor;
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
					case "System.Windows.Forms.TextBox":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
					case "mdlComponentesGraficos.TreeView":
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

		#region Events
			#region Form
				private void frmFREEspelho_Load(object sender, System.EventArgs e)
				{
					OnCallREsEspelhosRefresh();
				}
			#endregion
			#region Buttons
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bConfirmed = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bConfirmed = false;
					this.Close();
				}

				private void m_btRENovo_Click(object sender, System.EventArgs e)
				{
					int nIndex = -1;
					if ((nIndex = OnCallREsEspelhosNew()) > 0)
						OnCallREsEspelhosRefresh(nIndex);
				}

				private void m_btREEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallREsEspelhosEdit())
						OnCallREsEspelhosRefresh();
				}

				private void m_btREExcluir_Click(object sender, System.EventArgs e)
				{
					if (OnCallREsEspelhosDelete())
						OnCallREsEspelhosRefresh();
				}
			#endregion
		#endregion

	}
}
