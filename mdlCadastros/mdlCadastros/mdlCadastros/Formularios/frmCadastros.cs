using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlCadastros.Formularios
{
	/// <summary>
	/// Summary description for frmCadastros.
	/// </summary>
	public class frmCadastros : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaInterface(out string strMainText);
			public delegate void delCallCarregaBotoes(ref System.Windows.Forms.ToolTip ttDicas,out System.Collections.ArrayList arlBotoes);
		#endregion
		#region Events
			public event delCallCarregaInterface eCallCarregaInterface;	
			public event delCallCarregaBotoes eCallCarregaBotoes;	
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaInterface()
			{
				if (eCallCarregaInterface != null)
				{
					string strMainText = "";
					eCallCarregaInterface(out strMainText);
					m_gbGeral.Text = strMainText;
				}
			}

			protected virtual void OnCallCarregaBotoes()
			{
				if (eCallCarregaBotoes != null)
				{
					m_gbGeral.Controls.Clear();
					System.Collections.ArrayList arlBotoes;
					eCallCarregaBotoes(ref m_ttDicas,out arlBotoes);
					for(int i = 0; i < arlBotoes.Count;i++)
					{
						System.Windows.Forms.Button btCurrent = (System.Windows.Forms.Button)arlBotoes[i];
						btCurrent.ImageList = m_ilCadastros;
						m_gbGeral.Controls.Add(btCurrent);
					}
				}
			}
		#endregion

		#region Atributes
			private string m_strEnderecoExecutavel = "";
			internal System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.ImageList m_ilCadastros;
		private System.Windows.Forms.ToolTip m_ttDicas;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmCadastros(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCadastros));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_ilCadastros = new System.Windows.Forms.ImageList(this.components);
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Location = new System.Drawing.Point(73, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(719, 593);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			this.m_gbGeral.Text = "Cadastros";
			// 
			// m_ilCadastros
			// 
			this.m_ilCadastros.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.m_ilCadastros.ImageSize = new System.Drawing.Size(200, 100);
			this.m_ilCadastros.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilCadastros.ImageStream")));
			this.m_ilCadastros.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmCadastros
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
			this.ClientSize = new System.Drawing.Size(792, 592);
			this.ControlBox = false;
			this.Controls.Add(this.m_gbGeral);
			this.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmCadastros";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmCadastros_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmCadastros_Load(object sender, System.EventArgs e)
				{
					this.SetBounds(this.MdiParent.Bounds.X,this.MdiParent.Bounds.Y,this.MdiParent.Bounds.Width - 13,this.MdiParent.Bounds.Height - 40);
					vMostraCor();
					OnCallCarregaInterface();
					OnCallCarregaBotoes();
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
