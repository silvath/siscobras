using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlControladoraMensagens.Forms
{
	/// <summary>
	/// Summary description for frmMain.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallMenuItemPopup(out bool bMessages,out bool bConfigurate,out bool bPersonalized,out bool bStart,out bool bPause,out bool bContinue,out bool bStop,out bool bClose);
			public delegate void delCallMenuItemMessages();
			public delegate void delCallMenuItemConfigurate();
			public delegate void delCallMenuItemPersonalized();
			public delegate void delCallMenuItemStart();
			public delegate void delCallMenuItemPause();
			public delegate void delCallMenuItemContinue();
			public delegate void delCallMenuItemStop();
			public delegate void delCallMenuItemClose();
		#endregion
		#region Events
			public event delCallMenuItemPopup eCallMenuItemPopup;
			public event delCallMenuItemMessages eCallMenuItemMessages;
			public event delCallMenuItemConfigurate eCallMenuItemConfigurate;
			public event delCallMenuItemPersonalized eCallMenuItemPersonalized;
			public event delCallMenuItemStart eCallMenuItemStart;
			public event delCallMenuItemPause eCallMenuItemPause;
			public event delCallMenuItemContinue eCallMenuItemContinue;
			public event delCallMenuItemStop eCallMenuItemStop;
			public event delCallMenuItemClose eCallMenuItemClose;
		#endregion
		#region Events Methods
			protected virtual void OnCallMenuItemPopup()
			{
				if (eCallMenuItemPopup != null)
				{
					bool bMessages,bConfigurate,bPersonalized,bStart,bPause,bContinue,bStop,bClose;
					eCallMenuItemPopup(out bMessages,out bConfigurate,out bPersonalized,out bStart,out bPause,out bContinue,out bStop,out bClose);
					m_miMensagens.Enabled = bMessages;
					m_miConfigurar.Enabled = bConfigurate;
					m_miPersonalized.Enabled = bPersonalized;
					m_miIniciar.Enabled = bStart;
					m_miPausar.Enabled = bPause;
					m_miContinuar.Enabled = bContinue;
					m_miParar.Enabled = bStop;
					m_miFechar.Enabled = bClose;
				}
			}

			protected virtual void OnCallMenuItemMessages()
			{
				if (eCallMenuItemMessages != null)
					eCallMenuItemMessages();
			}

			protected virtual void OnCallMenuItemConfigurate()
			{
				if (eCallMenuItemConfigurate != null)
					eCallMenuItemConfigurate();
			}

			protected virtual void OnCallMenuItemPersonalized()
			{
				if (eCallMenuItemPersonalized != null)
					eCallMenuItemPersonalized();
			}

			protected virtual void OnCallMenuItemStart()
			{
				if (eCallMenuItemStart != null)
					eCallMenuItemStart();
			}

			protected virtual void OnCallMenuItemPause()
			{
				if (eCallMenuItemPause != null)
					eCallMenuItemPause();
			}

			protected virtual void OnCallMenuItemContinue()
			{
				if (eCallMenuItemContinue != null)
					eCallMenuItemContinue();
			}

			protected virtual void OnCallMenuItemStop()
			{
				if (eCallMenuItemStop != null)
					eCallMenuItemStop();
			}

			protected virtual void OnCallMenuItemClose()
			{
				if (eCallMenuItemClose != null)
					eCallMenuItemClose();
			}
		#endregion

		#region Atributes
			private System.Windows.Forms.NotifyIcon m_niControladoraMensagens;
			private System.Windows.Forms.ContextMenu m_cmControladoraMensagens;
			private System.Windows.Forms.MenuItem m_miIniciar;
			private System.Windows.Forms.MenuItem m_miFechar;
			private System.Windows.Forms.MenuItem menuItem4;
			private System.Windows.Forms.MenuItem menuItem5;
			private System.Windows.Forms.MenuItem m_miMensagens;
			private System.Windows.Forms.MenuItem m_miConfigurar;
		private System.Windows.Forms.MenuItem m_miPersonalized;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem m_miPausar;
		private System.Windows.Forms.MenuItem m_miContinuar;
		private System.Windows.Forms.MenuItem m_miParar;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public bool ShowInSystemTray
			{
				set
				{
					m_niControladoraMensagens.Visible = value;
				}
				get
				{
					return(m_niControladoraMensagens.Visible);
				}
			}
		#endregion
		#region Constructors and Destructors
			public frmMain()
			{
				InitializeComponent();
				m_niControladoraMensagens.Icon = this.Icon;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.m_niControladoraMensagens = new System.Windows.Forms.NotifyIcon(this.components);
			this.m_cmControladoraMensagens = new System.Windows.Forms.ContextMenu();
			this.m_miMensagens = new System.Windows.Forms.MenuItem();
			this.m_miConfigurar = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.m_miPersonalized = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.m_miIniciar = new System.Windows.Forms.MenuItem();
			this.m_miPausar = new System.Windows.Forms.MenuItem();
			this.m_miContinuar = new System.Windows.Forms.MenuItem();
			this.m_miParar = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.m_miFechar = new System.Windows.Forms.MenuItem();
			// 
			// m_niControladoraMensagens
			// 
			this.m_niControladoraMensagens.ContextMenu = this.m_cmControladoraMensagens;
			this.m_niControladoraMensagens.Icon = ((System.Drawing.Icon)(resources.GetObject("m_niControladoraMensagens.Icon")));
			this.m_niControladoraMensagens.Text = "Siscobras - SiscoMensagem";
			this.m_niControladoraMensagens.DoubleClick += new System.EventHandler(this.m_niControladoraMensagens_DoubleClick);
			// 
			// m_cmControladoraMensagens
			// 
			this.m_cmControladoraMensagens.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									  this.m_miMensagens,
																									  this.m_miConfigurar,
																									  this.menuItem2,
																									  this.m_miPersonalized,
																									  this.menuItem4,
																									  this.m_miIniciar,
																									  this.m_miPausar,
																									  this.m_miContinuar,
																									  this.m_miParar,
																									  this.menuItem5,
																									  this.m_miFechar});
			this.m_cmControladoraMensagens.Popup += new System.EventHandler(this.m_cmControladoraMensagens_Popup);
			// 
			// m_miMensagens
			// 
			this.m_miMensagens.Index = 0;
			this.m_miMensagens.Text = "Mensagens";
			this.m_miMensagens.Click += new System.EventHandler(this.m_miMensagens_Click);
			// 
			// m_miConfigurar
			// 
			this.m_miConfigurar.Index = 1;
			this.m_miConfigurar.Text = "Configurar";
			this.m_miConfigurar.Click += new System.EventHandler(this.m_miConfigurar_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.Text = "-";
			// 
			// m_miPersonalized
			// 
			this.m_miPersonalized.Index = 3;
			this.m_miPersonalized.Text = "Personalizada";
			this.m_miPersonalized.Click += new System.EventHandler(this.m_miPersonalized_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 4;
			this.menuItem4.Text = "-";
			// 
			// m_miIniciar
			// 
			this.m_miIniciar.Index = 5;
			this.m_miIniciar.Text = "Iniciar";
			this.m_miIniciar.Click += new System.EventHandler(this.m_miIniciar_Click);
			// 
			// m_miPausar
			// 
			this.m_miPausar.Index = 6;
			this.m_miPausar.Text = "Pausar";
			this.m_miPausar.Click += new System.EventHandler(this.m_miPausar_Click);
			// 
			// m_miContinuar
			// 
			this.m_miContinuar.Index = 7;
			this.m_miContinuar.Text = "Continuar";
			this.m_miContinuar.Click += new System.EventHandler(this.m_miContinuar_Click);
			// 
			// m_miParar
			// 
			this.m_miParar.Index = 8;
			this.m_miParar.Text = "Parar";
			this.m_miParar.Click += new System.EventHandler(this.m_miParar_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 9;
			this.menuItem5.Text = "-";
			// 
			// m_miFechar
			// 
			this.m_miFechar.Index = 10;
			this.m_miFechar.Text = "Fechar";
			this.m_miFechar.Click += new System.EventHandler(this.m_miFechar_Click);
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(218, 56);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SiscoMensagem";

		}
		#endregion

		#region Eventos
			#region MenuItens
				private void m_cmControladoraMensagens_Popup(object sender, System.EventArgs e)
				{
					OnCallMenuItemPopup();
				}

				private void m_miMensagens_Click(object sender, System.EventArgs e)
				{
					OnCallMenuItemMessages();
				}

				private void m_miConfigurar_Click(object sender, System.EventArgs e)
				{
					OnCallMenuItemConfigurate();
				}

				private void m_miPersonalized_Click(object sender, System.EventArgs e)
				{
					OnCallMenuItemPersonalized();
				}

				private void m_miIniciar_Click(object sender, System.EventArgs e)
				{
					OnCallMenuItemStart();
				}

				private void m_miPausar_Click(object sender, System.EventArgs e)
				{
					OnCallMenuItemPause();
				}

				private void m_miContinuar_Click(object sender, System.EventArgs e)
				{
					OnCallMenuItemContinue();
				}

				private void m_miParar_Click(object sender, System.EventArgs e)
				{
					OnCallMenuItemStop();
				}

				private void m_miFechar_Click(object sender, System.EventArgs e)
				{
					OnCallMenuItemClose();
				}
			#endregion
			#region NotifyIcon
				private void m_niControladoraMensagens_DoubleClick(object sender, System.EventArgs e)
				{
					OnCallMenuItemMessages();
				}
			#endregion
		#endregion
	}
}
