using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlSplash
{
	/// <summary>
	/// Summary description for frmFSplash.
	/// </summary>
	internal class frmFSplash : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegates
			public delegate void delCallConfiguraPictureBox(ref mdlComponentesGraficos.PictureBox picSlash);
			public delegate void delCallShowRegistro();
			public delegate bool delCallDesenvolvimento();
		#endregion
		#region Events
			public event delCallConfiguraPictureBox eCallConfiguraPictureBox;
			public event delCallShowRegistro eCallShowRegistro;
			public event delCallDesenvolvimento eCallDesenvolvimento;
		#endregion
		#region Events Methods
			protected virtual void OnCallConfiguraPictureBox()
			{
				if (eCallConfiguraPictureBox != null)
					eCallConfiguraPictureBox(ref m_picSplash);
			}

			protected virtual void OnCallShowRegistro()
			{
				if (eCallShowRegistro != null)
					eCallShowRegistro();
			}

			protected virtual bool OnCallDesenvolvimento()
			{
				bool bRetorno = false;
				if (eCallDesenvolvimento != null)
					bRetorno = eCallDesenvolvimento();
				return(bRetorno);
			}
		#endregion
		#region Atributes
			private string m_strEnderecoExecutavel = "";

			private System.Windows.Forms.ToolTip m_ttDica;
			private mdlComponentesGraficos.PictureBox m_picSplash;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructor and Destructors

		public frmFSplash(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFSplash));
			this.m_picSplash = new mdlComponentesGraficos.PictureBox();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// m_picSplash
			// 
			this.m_picSplash.Effect = mdlComponentesGraficos.PictureBox.Effects.Negative;
			this.m_picSplash.EffectDirection = mdlComponentesGraficos.PictureBox.Directions.Horizontal;
			this.m_picSplash.Image = ((System.Drawing.Image)(resources.GetObject("m_picSplash.Image")));
			this.m_picSplash.Location = new System.Drawing.Point(0, 0);
			this.m_picSplash.Name = "m_picSplash";
			this.m_picSplash.OriginalImage = ((System.Drawing.Image)(resources.GetObject("m_picSplash.OriginalImage")));
			this.m_picSplash.Percentage = 0;
			this.m_picSplash.Size = new System.Drawing.Size(500, 303);
			this.m_picSplash.TabIndex = 0;
			this.m_picSplash.TabStop = false;
			this.m_picSplash.WithEffects = true;
			// 
			// frmFSplash
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(498, 298);
			this.ControlBox = false;
			this.Controls.Add(this.m_picSplash);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFSplash";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.frmFSplash_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFSplash_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					OnCallConfiguraPictureBox();
					System.Threading.Thread thrStart = new System.Threading.Thread(new System.Threading.ThreadStart(StartSplash));
					thrStart.Start();
				}
			#endregion
			#region Botoes
			#endregion
		#endregion
		#region Cores
			private void MostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","CoresSecundarias");
				this.BackColor = clsPaletaCores.retornaCorAtual();
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					this.Controls[nCont].BackColor = this.BackColor;
					for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
					{
						if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.PictureBox"))
							this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

						for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
						{
							if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.PictureBox"))
								this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
						}
					}
				}
			}
		#endregion

		#region StartSplash
			private void StartSplash()
			{
				ImagemSplashEfeitoColoca();
				if (!OnCallDesenvolvimento())
					OnCallShowRegistro();
				//ImagemSplashEfeitoRetira();
				this.Close();
			}
		#endregion

		#region Efeito ImagemSplash
			private void ImagemSplashEfeitoColoca()
			{
				while (this.m_picSplash.Percentage < 100)
				{
					this.m_picSplash.Percentage = this.m_picSplash.Percentage + 5;
				}
			}

			private void ImagemSplashEfeitoRetira()
			{
				this.m_picSplash.EffectDirection = mdlComponentesGraficos.PictureBox.Directions.Horizontal;
				while (this.m_picSplash.Percentage > 0)
				{
					this.m_picSplash.Percentage = this.m_picSplash.Percentage - 5;
				}
			}
		#endregion
	}
}
