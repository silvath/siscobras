using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTec.Formularios
{
	/// <summary>
	/// Summary description for frmFTecNesh.
	/// </summary>
	public class frmFTecNesh : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallCarregaDados(string strCodigo,out string strNesh);
		#endregion
		#region Events
			public event delCallCarregaDados eCallCarregaDados;
		#endregion
		#region Events Methods
			protected virtual bool OnCallCarregaDados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallCarregaDados != null)
				{
					string strNesh;
					bRetorno = eCallCarregaDados(m_strCodigo,out strNesh);
					m_txtNesh.Text = strNesh;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributes
			private string m_strCodigo = "";
			private string m_strTextoLocalizar = "";

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.TextBox m_txtClassificacao;
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.Label label2;
			private System.Windows.Forms.RichTextBox m_txtNesh;
			private System.Windows.Forms.Button m_btLocalizar;
			private System.Windows.Forms.ImageList m_ilImagens;
		private System.Windows.Forms.ToolTip m_ttDicas;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public System.Drawing.Color Cor
			{
				set
				{
					vMostraCor(value);
				}
			}
		#endregion
		#region Constructors
		public frmFTecNesh(string strEnderecoExecutavel,string strCodigo,string strDescricao)
		{
			m_strCodigo = strCodigo;
			InitializeComponent();
			m_txtClassificacao.Text = strDescricao;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFTecNesh));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_btLocalizar = new System.Windows.Forms.Button();
			this.m_ilImagens = new System.Windows.Forms.ImageList(this.components);
			this.m_txtNesh = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtClassificacao = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_btLocalizar);
			this.m_gbMain.Controls.Add(this.m_txtNesh);
			this.m_gbMain.Controls.Add(this.label2);
			this.m_gbMain.Controls.Add(this.m_txtClassificacao);
			this.m_gbMain.Controls.Add(this.label1);
			this.m_gbMain.Location = new System.Drawing.Point(5, 3);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(584, 328);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_btLocalizar
			// 
			this.m_btLocalizar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btLocalizar.ImageIndex = 0;
			this.m_btLocalizar.ImageList = this.m_ilImagens;
			this.m_btLocalizar.Location = new System.Drawing.Point(552, 10);
			this.m_btLocalizar.Name = "m_btLocalizar";
			this.m_btLocalizar.Size = new System.Drawing.Size(28, 28);
			this.m_btLocalizar.TabIndex = 79;
			this.m_ttDicas.SetToolTip(this.m_btLocalizar, "Localizar");
			this.m_btLocalizar.Click += new System.EventHandler(this.m_btLocalizar_Click);
			// 
			// m_ilImagens
			// 
			this.m_ilImagens.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilImagens.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilImagens.ImageStream")));
			this.m_ilImagens.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_txtNesh
			// 
			this.m_txtNesh.HideSelection = false;
			this.m_txtNesh.Location = new System.Drawing.Point(8, 57);
			this.m_txtNesh.Name = "m_txtNesh";
			this.m_txtNesh.ReadOnly = true;
			this.m_txtNesh.Size = new System.Drawing.Size(568, 263);
			this.m_txtNesh.TabIndex = 5;
			this.m_txtNesh.Text = "";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(11, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Nesh:";
			// 
			// m_txtClassificacao
			// 
			this.m_txtClassificacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtClassificacao.Location = new System.Drawing.Point(91, 15);
			this.m_txtClassificacao.Name = "m_txtClassificacao";
			this.m_txtClassificacao.ReadOnly = true;
			this.m_txtClassificacao.Size = new System.Drawing.Size(453, 20);
			this.m_txtClassificacao.TabIndex = 3;
			this.m_txtClassificacao.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(11, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Classificação:";
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFTecNesh
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(594, 336);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFTecNesh";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Nesh";
			this.Load += new System.EventHandler(this.frmFTecNesh_Load);
			this.m_gbMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
			#region Form
				private void frmFTecNesh_Load(object sender, System.EventArgs e)
				{
					CarregaDados();
				}
			#endregion
			#region Buttons
				private void m_btLocalizar_Click(object sender, System.EventArgs e)
				{
					ShowDialogProcurar();
				}
			#endregion
		#endregion

		#region Cores
			private void vMostraCor(System.Drawing.Color color)
			{
				this.BackColor = color;
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
			}

			private void vMostraCor(string strEnderecoExecutavel)
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME,"SiscobrasCorSecundaria");
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
					case "System.Windows.Forms.TextBox":
					case "System.Windows.Forms.TreeView":
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
		#region CarregaDados
			private void CarregaDados()
			{
				System.Threading.Thread threadCarregaDados = new System.Threading.Thread(new System.Threading.ThreadStart(CarregaDadosStart));
				threadCarregaDados.Start();
			}

			private void CarregaDadosStart()
			{
				OnCallCarregaDados();
			}
		#endregion

		#region ShowDialogProcurar
			private void ShowDialogProcurar()
			{
				Formularios.frmFProcurar formFProcurar = new frmFProcurar();
				formFProcurar.Localizar = m_strTextoLocalizar;
				formFProcurar.Cor = this.BackColor;
				formFProcurar.ShowDialog();
				if (formFProcurar.Confirmed)
				{
					m_strTextoLocalizar = formFProcurar.Localizar;
					int index = m_txtNesh.Text.ToUpper().IndexOf(m_strTextoLocalizar.ToUpper(),m_txtNesh.SelectionStart + 1);
					if (index != -1)
					{
						m_txtNesh.SelectionStart = index;
						m_txtNesh.SelectionLength = m_strTextoLocalizar.Length;
					}else{
						mdlMensagens.clsMensagens.ShowInformation("Não foi possível locarlizar o texto.");
					}
				}
			}
		#endregion
	}
}
