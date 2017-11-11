using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlControladoraMensagens.Forms
{
	/// <summary>
	/// Summary description for frmConfig.
	/// </summary>
	public class frmConfig : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallSessoesRefresh(ref System.Windows.Forms.TreeView tvSessoes);
			public delegate bool delCallSessaoCarrega(ref System.Windows.Forms.GroupBox gbOpcoes,int nIdSessao);
			public delegate bool delCallCarregaDados();
			public delegate bool delCallSalvaDados();
		#endregion
		#region Events
			public event delCallSessoesRefresh eCallSessoesRefresh;
			public event delCallSessaoCarrega eCallSessaoCarrega;
			public event delCallCarregaDados eCallCarregaDados;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected virtual void OnCallSessoesRefresh()
			{
				if (eCallSessoesRefresh != null)
					eCallSessoesRefresh(ref m_tvSessao);
			}

			protected virtual void OnCallSessaoCarrega()
			{
				if ((eCallSessaoCarrega != null) && (m_tvSessao.SelectedNode != null))
					eCallSessaoCarrega(ref m_gbOpcoes,Int32.Parse(m_tvSessao.SelectedNode.Tag.ToString()));
			}

			protected virtual void OnCallSessaoCarrega(int nIdSessao)
			{
				if (eCallSessaoCarrega != null)
					if (eCallSessaoCarrega(ref m_gbOpcoes,nIdSessao))
						vShowColor();
			}

			protected virtual void OnCallCarregaDados()
			{
				if (eCallCarregaDados != null)
					eCallCarregaDados();
			}

			protected virtual bool OnCallSalvaDados()
			{
				bool bReturn = false;
				if (eCallSalvaDados != null)
					bReturn = eCallSalvaDados();
				return(bReturn); 
			}
		#endregion

		#region Atributes
			private bool m_bModificado = false;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbSessao;
			private System.Windows.Forms.GroupBox m_gbOpcoes;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.TreeView m_tvSessao;
		#endregion
		#region Constructors and Destructors
			public frmConfig()
			{
				InitializeComponent();

			}

			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmConfig));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbOpcoes = new System.Windows.Forms.GroupBox();
			this.m_gbSessao = new System.Windows.Forms.GroupBox();
			this.m_tvSessao = new System.Windows.Forms.TreeView();
			this.m_gbGeral.SuspendLayout();
			this.m_gbSessao.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbOpcoes);
			this.m_gbGeral.Controls.Add(this.m_gbSessao);
			this.m_gbGeral.Location = new System.Drawing.Point(6, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(481, 492);
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
			this.m_btOk.Location = new System.Drawing.Point(179, 462);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 10;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(243, 462);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 11;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbOpcoes
			// 
			this.m_gbOpcoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbOpcoes.Location = new System.Drawing.Point(194, 8);
			this.m_gbOpcoes.Name = "m_gbOpcoes";
			this.m_gbOpcoes.Size = new System.Drawing.Size(280, 448);
			this.m_gbOpcoes.TabIndex = 1;
			this.m_gbOpcoes.TabStop = false;
			// 
			// m_gbSessao
			// 
			this.m_gbSessao.Controls.Add(this.m_tvSessao);
			this.m_gbSessao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbSessao.Location = new System.Drawing.Point(8, 8);
			this.m_gbSessao.Name = "m_gbSessao";
			this.m_gbSessao.Size = new System.Drawing.Size(184, 448);
			this.m_gbSessao.TabIndex = 0;
			this.m_gbSessao.TabStop = false;
			this.m_gbSessao.Text = "Sessão";
			// 
			// m_tvSessao
			// 
			this.m_tvSessao.ImageIndex = -1;
			this.m_tvSessao.Location = new System.Drawing.Point(6, 16);
			this.m_tvSessao.Name = "m_tvSessao";
			this.m_tvSessao.SelectedImageIndex = -1;
			this.m_tvSessao.Size = new System.Drawing.Size(168, 424);
			this.m_tvSessao.TabIndex = 0;
			this.m_tvSessao.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvSessao_AfterSelect);
			// 
			// frmConfig
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(492, 496);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConfig";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SiscoMensagem: Configuração";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbSessao.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmMain_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaDados();
					vShowColor();
					OnCallSessoesRefresh();
					OnCallSessaoCarrega(clsControladoraMensagens.SESSION_MAIN);
					vExpandTreeView();
				}
			#endregion
			#region TreeView
				private void vExpandTreeView()
				{
					foreach(System.Windows.Forms.TreeNode tvnNode in m_tvSessao.Nodes)
						tvnNode.Expand();
				}

				private void m_tvSessao_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
				{
					OnCallSessaoCarrega();
					vShowColor();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_bModificado = OnCallSalvaDados())
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
		private void vShowColor()
		{
			System.Windows.Forms.Control ctrControleChild;
			for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
			{
				ctrControleChild = this.Controls[nCont];
				vPaintControl(ref ctrControleChild,clsControladoraMensagens.BackColor);
			}
		}

		private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
		{
			switch(ctrControle.GetType().ToString())
			{
				case "mdlComponentesGraficos.ListView":
				case "System.Windows.Forms.ListView":
				case "System.Windows.Forms.TreeView":
				case "System.Windows.Forms.TextBox":
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
