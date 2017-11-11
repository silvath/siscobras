using System;
using System.Drawing;
using System.Collections;
//using System.Windows.Forms;

namespace mdlPreferencias
{
	/// <summary>
	/// Summary description for frmFPreferencias.
	/// </summary>
	internal class frmFPreferencias : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegate
			public delegate void delCallCarregaVersoes(out string strVersaoServidor,out string strVersaoCliente);
			public delegate bool delCallNeedShowPreferences();
			public delegate void delCallInitialiazeEventsControlEntrada(ref Entrada.usrCtrlEntrada frmEntrada);
			public delegate void delCallInitialiazeEventsControlBackup(ref Backup.usrCtrlBackup frmBackup);
			public delegate void delCallInitialiazeEventsControlCores(ref Cores.usrCtrlCores frmCores);
			public delegate void delCallInitialiazeEventsControlRelatorios(ref usrCtrlRelatorios frmRelatorios);
			public delegate void delCallInitialiazeEventsControlGlobal(ref Global.usrCtrlGlobal frmGlobal);
			public delegate void delCallInitialiazeEventsControlMensagens(ref usrCtrlMensagens frmMensagens);
			public delegate void delCallInitialiazeEventsControlAtualizacoes(ref usrCtrlAtualizacoes frmAtualizacoes);
			public delegate void delCallConfiguraBancoDados();
			public delegate void delCallShowDialogEnviaErros();
			public delegate void delCallSalvaDadosBD(bool bModificado, ref mdlComponentesGraficos.TreeView tvPreferencias);
		#endregion
		#region Events
			public event delCallCarregaVersoes eCallCarregaVersoes;
			public event delCallNeedShowPreferences eCallNeedShowPreferences;
			public event delCallInitialiazeEventsControlEntrada eCallInitialiazeEventsControlEntrada;
			public event delCallInitialiazeEventsControlBackup eCallInitialiazeEventsControlBackup;
			public event delCallInitialiazeEventsControlCores eCallInitialiazeEventsControlCores;
			public event delCallInitialiazeEventsControlRelatorios eCallInitialiazeEventsControlRelatorios;
			public event delCallInitialiazeEventsControlGlobal eCallInitialiazeEventsControlGlobal;
			public event delCallInitialiazeEventsControlMensagens eCallInitialiazeEventsControlMensagens;
			public event delCallInitialiazeEventsControlAtualizacoes eCallInitialiazeEventsControlAtualizacoes;
			public event delCallConfiguraBancoDados eCallConfiguraBancoDados;
			public event delCallShowDialogEnviaErros eCallShowDialogEnviaErros;
			public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaVersoes()
			{
				if (eCallCarregaVersoes != null)
				{
					string strVersaoCliente = "";
					string strVersaoServidor = "";
					eCallCarregaVersoes(out strVersaoServidor,out strVersaoCliente);
					if (strVersaoServidor == "")
						m_lbVersaoServidor.Visible = false;
					else
						m_lbVersaoServidor.Text = "Versão Servidor: " + strVersaoServidor;
					if (strVersaoCliente == "")
						m_lbVersaoCliente.Visible = false;
					else
						m_lbVersaoCliente.Text = "Versão Cliente:   " + strVersaoCliente;
				}
			}

			protected virtual void OnCallNeedShowPreferences()
			{
				if ((eCallNeedShowPreferences != null))
				{
					if (eCallNeedShowPreferences())
					{
						foreach(System.Windows.Forms.TreeNode tvnPref in m_tvItensPreferencias.Nodes)
						{
							if (tvnPref.Text == "Atualizações")
							{
								m_tvItensPreferencias.SelectedNode = tvnPref;
								break;
							}
						}
					}
				}
			}

			protected virtual void OnCallInitialiazeEventsControlEntrada()
			{
				if ((eCallInitialiazeEventsControlEntrada != null) && UserCtrlEntrada != null)
					eCallInitialiazeEventsControlEntrada(ref UserCtrlEntrada);
			}
			protected virtual void OnCallInitialiazeEventsControlBackup()
			{
				if (eCallInitialiazeEventsControlBackup != null)
					eCallInitialiazeEventsControlBackup(ref UserCtrlBackup);
			}
			protected virtual void OnCallInitialiazeEventsControlCores()
			{
				if (eCallInitialiazeEventsControlCores != null)
					eCallInitialiazeEventsControlCores(ref UserCtrlCores);
			}

			protected virtual void OnCallInitialiazeEventsControlRelatorios()
			{
				if (eCallInitialiazeEventsControlRelatorios != null)
					eCallInitialiazeEventsControlRelatorios(ref UserCtrlRelatorios);
			}

			protected virtual void OnCallInitialiazeEventsControlGlobal()
			{
				if (eCallInitialiazeEventsControlGlobal!= null)
					eCallInitialiazeEventsControlGlobal(ref UserCtrlGlobal);
			}

			protected virtual void OnCallInitialiazeEventsControlMensagens()
			{
				if (eCallInitialiazeEventsControlMensagens != null)
					eCallInitialiazeEventsControlMensagens(ref UserCtrlMensagens);
			}

			protected virtual void OnCallInitialiazeEventsControlAtualizacoes()
			{
				if (eCallInitialiazeEventsControlAtualizacoes != null)
					eCallInitialiazeEventsControlAtualizacoes(ref UserCtrlAtualizacoes);
			}

			protected virtual void OnCallConfiguraBancoDados()
			{
				if (eCallConfiguraBancoDados != null)
					eCallConfiguraBancoDados();
			}

			protected virtual void OnCallShowDialogEnviaErros()
			{
				if (eCallShowDialogEnviaErros != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogEnviaErros();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallSalvaDadosBD()
			{
				if (eCallSalvaDadosBD != null)
					eCallSalvaDadosBD(m_bModificado, ref m_tvItensPreferencias);
			}
		#endregion

		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			private string m_strEnderecoExecutavel = "";

			public bool m_bModificado = false;
			private bool m_bAtivado = true;
			private string m_strUltimaOpcaoSelecionada = "";

			internal Global.usrCtrlGlobal UserCtrlGlobal;
			internal Entrada.usrCtrlEntrada UserCtrlEntrada;
			internal Backup.usrCtrlBackup UserCtrlBackup;
			internal Cores.usrCtrlCores UserCtrlCores;
			internal usrCtrlRelatorios UserCtrlRelatorios;
			internal usrCtrlMensagens UserCtrlMensagens;
			internal usrCtrlAtualizacoes UserCtrlAtualizacoes;
			private System.Windows.Forms.GroupBox m_gbFrame;
			private System.Windows.Forms.GroupBox m_gbTreeView;
			private System.Windows.Forms.GroupBox m_gbPreferencias;
			private mdlComponentesGraficos.TreeView m_tvItensPreferencias;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Button m_btTrocarCor;
			private System.Windows.Forms.ToolTip m_ttPreferencias;
			private System.Windows.Forms.Label m_lbVersaoServidor;
			private System.Windows.Forms.Label m_lbVersaoCliente;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public string PREFERENCIASELECIONADA
			{
				get
				{
					string strTemp = "Global";
					if (m_tvItensPreferencias.SelectedNode != null)
						strTemp = m_tvItensPreferencias.SelectedNode.Text;
					return strTemp;
				}
			}
		#endregion
		#region Construtors and Destrutors
			public frmFPreferencias(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel, string strUltimaOpcaoSelecionada)
			{
				InitializeComponent();
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = EnderecoExecutavel;
				m_strUltimaOpcaoSelecionada = strUltimaOpcaoSelecionada;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFPreferencias));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_lbVersaoCliente = new System.Windows.Forms.Label();
			this.m_lbVersaoServidor = new System.Windows.Forms.Label();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbPreferencias = new System.Windows.Forms.GroupBox();
			this.m_gbTreeView = new System.Windows.Forms.GroupBox();
			this.m_tvItensPreferencias = new mdlComponentesGraficos.TreeView();
			this.m_ttPreferencias = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbTreeView.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_lbVersaoCliente);
			this.m_gbFrame.Controls.Add(this.m_lbVersaoServidor);
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbPreferencias);
			this.m_gbFrame.Controls.Add(this.m_gbTreeView);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(606, 438);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_lbVersaoCliente
			// 
			this.m_lbVersaoCliente.Location = new System.Drawing.Point(9, 414);
			this.m_lbVersaoCliente.Name = "m_lbVersaoCliente";
			this.m_lbVersaoCliente.Size = new System.Drawing.Size(233, 16);
			this.m_lbVersaoCliente.TabIndex = 9;
			this.m_lbVersaoCliente.Text = "Versão Servidor:";
			// 
			// m_lbVersaoServidor
			// 
			this.m_lbVersaoServidor.Location = new System.Drawing.Point(9, 395);
			this.m_lbVersaoServidor.Name = "m_lbVersaoServidor";
			this.m_lbVersaoServidor.Size = new System.Drawing.Size(233, 20);
			this.m_lbVersaoServidor.TabIndex = 8;
			this.m_lbVersaoServidor.Text = "Versão Servidor: 2004-02-01-10-10";
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(3, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 7;
			this.m_btTrocarCor.Visible = false;
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(243, 406);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 1;
			this.m_ttPreferencias.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(307, 406);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttPreferencias.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbPreferencias
			// 
			this.m_gbPreferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPreferencias.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPreferencias.Location = new System.Drawing.Point(192, 8);
			this.m_gbPreferencias.Name = "m_gbPreferencias";
			this.m_gbPreferencias.Size = new System.Drawing.Size(406, 384);
			this.m_gbPreferencias.TabIndex = 1;
			this.m_gbPreferencias.TabStop = false;
			// 
			// m_gbTreeView
			// 
			this.m_gbTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_gbTreeView.Controls.Add(this.m_tvItensPreferencias);
			this.m_gbTreeView.Location = new System.Drawing.Point(8, 8);
			this.m_gbTreeView.Name = "m_gbTreeView";
			this.m_gbTreeView.Size = new System.Drawing.Size(176, 384);
			this.m_gbTreeView.TabIndex = 0;
			this.m_gbTreeView.TabStop = false;
			// 
			// m_tvItensPreferencias
			// 
			this.m_tvItensPreferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tvItensPreferencias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_tvItensPreferencias.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_tvItensPreferencias.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tvItensPreferencias.HideSelection = false;
			this.m_tvItensPreferencias.ImageIndex = -1;
			this.m_tvItensPreferencias.Location = new System.Drawing.Point(6, 11);
			this.m_tvItensPreferencias.Name = "m_tvItensPreferencias";
			this.m_tvItensPreferencias.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																							  new System.Windows.Forms.TreeNode("Atualizações"),
																							  new System.Windows.Forms.TreeNode("Becape"),
																							  new System.Windows.Forms.TreeNode("Cores"),
																							  new System.Windows.Forms.TreeNode("Entrada"),
																							  new System.Windows.Forms.TreeNode("Global"),
																							  new System.Windows.Forms.TreeNode("Relatórios"),
																							  new System.Windows.Forms.TreeNode("SiscoMensagem")});
			this.m_tvItensPreferencias.SelectedImageIndex = -1;
			this.m_tvItensPreferencias.Size = new System.Drawing.Size(163, 363);
			this.m_tvItensPreferencias.TabIndex = 0;
			this.m_tvItensPreferencias.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvItensPreferencias_AfterSelect);
			this.m_tvItensPreferencias.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_tvItensPreferencias_MouseMove);
			this.m_tvItensPreferencias.MouseLeave += new System.EventHandler(this.m_tvItensPreferencias_MouseLeave);
			// 
			// m_ttPreferencias
			// 
			this.m_ttPreferencias.AutomaticDelay = 100;
			this.m_ttPreferencias.AutoPopDelay = 5000;
			this.m_ttPreferencias.InitialDelay = 100;
			this.m_ttPreferencias.ReshowDelay = 20;
			// 
			// frmFPreferencias
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(610, 440);
			this.Controls.Add(this.m_gbFrame);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFPreferencias";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Preferências";
			this.Load += new System.EventHandler(this.frmFPreferencias_Load);
			this.Activated += new System.EventHandler(this.frmFPreferencias_Activated);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmFPreferencias_KeyUp);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbTreeView.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region SelecionaNodo
		private void selecionaNodoOpcao()
		{
			try
			{
				foreach(System.Windows.Forms.TreeNode tnNodo in m_tvItensPreferencias.Nodes)
				{
					if (tnNodo.Text == m_strUltimaOpcaoSelecionada)
					{
						m_tvItensPreferencias.SelectedNode = tnNodo;
						break;
					}
				}
				m_tvItensPreferencias.SelectedNode = m_tvItensPreferencias.Nodes[0];
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFPreferencias_Activated(object sender, System.EventArgs e)
				{
					m_gbPreferencias.BringToFront();
					m_tvItensPreferencias.SelectedNode = null;
				}

				private void frmFPreferencias_Load(object sender, System.EventArgs e)
				{
					try
					{
						OnCallCarregaVersoes();
						this.mostraCor();
						selecionaNodoOpcao();
						OnCallNeedShowPreferences();
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void frmFPreferencias_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					switch(e.KeyCode)
					{
						case System.Windows.Forms.Keys.E:
							if ((e.Control) && (e.Alt))
								OnCallShowDialogEnviaErros();
							break;
					}
				}
			#endregion
			#region TreeView
				private void m_tvItensPreferencias_MouseLeave(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_tvItensPreferencias_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
				{
					if (m_tvItensPreferencias.GetNodeAt(e.X,e.Y) != null)
					{
						this.Cursor = System.Windows.Forms.Cursors.Hand;
					}
					else
					{
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}
				}

				private void m_tvItensPreferencias_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
				{
					if (m_bAtivado)
					{
						m_bAtivado = false;
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						System.Windows.Forms.TreeNode teste = m_tvItensPreferencias.SelectedNode;
						if (teste != null)
						{
							#region Entrada
							if (teste.Text == "Entrada")
							{
								m_gbPreferencias.Text = "";
								if (UserCtrlBackup != null)
								{
									UserCtrlBackup.OnCallSalvaDadosInterface();
									this.m_gbPreferencias.Controls.Remove(UserCtrlBackup);
									UserCtrlBackup.Visible = false;
								}
								if (UserCtrlGlobal != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlGlobal);
									UserCtrlGlobal.Visible = false;
								}
								if (UserCtrlCores != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlCores);
									UserCtrlCores.Visible = false;
								}
								if (UserCtrlRelatorios != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlRelatorios);
									UserCtrlRelatorios.Visible = false;
								}
								if (UserCtrlMensagens != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlMensagens);
									UserCtrlMensagens.Visible = false;
								}
								if (UserCtrlAtualizacoes != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlAtualizacoes);
									UserCtrlAtualizacoes.Visible = false;
								}
								if (UserCtrlEntrada == null)
								{
									UserCtrlEntrada = new Entrada.usrCtrlEntrada();
									OnCallInitialiazeEventsControlEntrada();
								}
								UserCtrlEntrada.Visible = false;
								this.m_gbPreferencias.Controls.Add(UserCtrlEntrada);
								UserCtrlEntrada.SetBounds(4, 9, (this.m_gbPreferencias.Width - 9), (this.m_gbPreferencias.Height - 14));
								UserCtrlEntrada.Visible = true;
								UserCtrlEntrada.BringToFront();
							}
								#endregion
							#region Becape
							else if (teste.Text == "Becape")
							{
								if (UserCtrlEntrada != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlEntrada);
									UserCtrlEntrada.Visible = false;
								}
								if (UserCtrlGlobal != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlGlobal);
									UserCtrlGlobal.Visible = false;
								}
								if (UserCtrlCores != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlCores);
									UserCtrlCores.Visible = false;
								}
								if (UserCtrlRelatorios != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlRelatorios);
									UserCtrlRelatorios.Visible = false;
								}
								if (UserCtrlMensagens != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlMensagens);
									UserCtrlMensagens.Visible = false;
								}
								if (UserCtrlAtualizacoes != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlAtualizacoes);
									UserCtrlAtualizacoes.Visible = false;
								}
								if (UserCtrlBackup == null)
								{
									UserCtrlBackup = new Backup.usrCtrlBackup();
									OnCallInitialiazeEventsControlBackup();
								}
								UserCtrlBackup.Visible = false;
								this.m_gbPreferencias.Controls.Add(UserCtrlBackup);
								UserCtrlBackup.SetBounds(4, 9, (this.m_gbPreferencias.Width - 9), (this.m_gbPreferencias.Height - 14));
								UserCtrlBackup.Visible = true;
								UserCtrlBackup.BringToFront();
							}
								#endregion
							#region Global
							else if (teste.Text == "Global")
							{
								if (UserCtrlEntrada != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlEntrada);
									UserCtrlEntrada.Visible = false;
								}
								if (UserCtrlBackup != null)
								{
									UserCtrlBackup.OnCallSalvaDadosInterface();
									this.m_gbPreferencias.Controls.Remove(UserCtrlBackup);
									UserCtrlBackup.Visible = false;
								}
								if (UserCtrlCores != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlCores);
									UserCtrlCores.Visible = false;
								}
								if (UserCtrlRelatorios != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlRelatorios);
									UserCtrlRelatorios.Visible = false;
								}
								if (UserCtrlMensagens != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlMensagens);
									UserCtrlMensagens.Visible = false;
								}
								if (UserCtrlAtualizacoes != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlAtualizacoes);
									UserCtrlAtualizacoes.Visible = false;
								}
								if (UserCtrlGlobal == null)
								{
									UserCtrlGlobal = new Global.usrCtrlGlobal();
									OnCallInitialiazeEventsControlGlobal();
								}
								UserCtrlGlobal.Visible = false;
								this.m_gbPreferencias.Controls.Add(UserCtrlGlobal);
								UserCtrlGlobal.SetBounds(4, 9, (this.m_gbPreferencias.Width - 9), (this.m_gbPreferencias.Height - 14));
								UserCtrlGlobal.Visible = true;
								UserCtrlGlobal.BringToFront();
							}
								#endregion
							#region Cores
							else if (teste.Text == "Cores")
							{
								if (UserCtrlEntrada != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlEntrada);
									UserCtrlEntrada.Visible = false;
								}
								if (UserCtrlGlobal != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlGlobal);
									UserCtrlGlobal.Visible = false;
								}
								if (UserCtrlBackup != null)
								{
									UserCtrlBackup.OnCallSalvaDadosInterface();
									this.m_gbPreferencias.Controls.Remove(UserCtrlBackup);
									UserCtrlBackup.Visible = false;
								}
								if (UserCtrlRelatorios != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlRelatorios);
									UserCtrlRelatorios.Visible = false;
								}
								if (UserCtrlMensagens != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlMensagens);
									UserCtrlMensagens.Visible = false;
								}
								if (UserCtrlAtualizacoes != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlAtualizacoes);
									UserCtrlAtualizacoes.Visible = false;
								}
								if (UserCtrlCores == null)
								{
									UserCtrlCores = new Cores.usrCtrlCores();
									OnCallInitialiazeEventsControlCores();
								}
								UserCtrlCores.Visible = false;
								this.m_gbPreferencias.Controls.Add(UserCtrlCores);
								UserCtrlCores.SetBounds(4, 9, (this.m_gbPreferencias.Width - 7), (this.m_gbPreferencias.Height - 13));
								UserCtrlCores.Visible = true;
								UserCtrlCores.BringToFront();
							}
								#endregion
							#region Relatorios
							else if (teste.Text == "Relatórios")
							{
								if (UserCtrlEntrada != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlEntrada);
									UserCtrlEntrada.Visible = false;
								}
								if (UserCtrlGlobal != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlGlobal);
									UserCtrlGlobal.Visible = false;
								}
								if (UserCtrlBackup != null)
								{
									UserCtrlBackup.OnCallSalvaDadosInterface();
									this.m_gbPreferencias.Controls.Remove(UserCtrlBackup);
									UserCtrlBackup.Visible = false;
								}
								if (UserCtrlCores != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlCores);
									UserCtrlCores.Visible = false;
								}
								if (UserCtrlMensagens != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlMensagens);
									UserCtrlMensagens.Visible = false;
								}
								if (UserCtrlAtualizacoes != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlAtualizacoes);
									UserCtrlAtualizacoes.Visible = false;
								}
								if (UserCtrlRelatorios == null)
								{
									UserCtrlRelatorios = new usrCtrlRelatorios();
									OnCallInitialiazeEventsControlRelatorios();
								}
								UserCtrlRelatorios.Visible = false;
								this.m_gbPreferencias.Controls.Add(UserCtrlRelatorios);
								UserCtrlRelatorios.SetBounds(4, 9, (this.m_gbPreferencias.Width - 7), (this.m_gbPreferencias.Height - 13));
								UserCtrlRelatorios.Visible = true;
								UserCtrlRelatorios.BringToFront();
							}
								#endregion
							#region SiscoMensagem
							else if (teste.Text == "SiscoMensagem")
							{
								if (UserCtrlEntrada != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlEntrada);
									UserCtrlEntrada.Visible = false;
								}
								if (UserCtrlGlobal != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlGlobal);
									UserCtrlGlobal.Visible = false;
								}
								if (UserCtrlBackup != null)
								{
									UserCtrlBackup.OnCallSalvaDadosInterface();
									this.m_gbPreferencias.Controls.Remove(UserCtrlBackup);
									UserCtrlBackup.Visible = false;
								}
								if (UserCtrlCores != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlCores);
									UserCtrlCores.Visible = false;
								}
								if (UserCtrlRelatorios != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlRelatorios);
									UserCtrlRelatorios.Visible = false;
								}
								if (UserCtrlAtualizacoes != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlAtualizacoes);
									UserCtrlAtualizacoes.Visible = false;
								}
								if (UserCtrlMensagens == null)
								{
									UserCtrlMensagens = new usrCtrlMensagens();
									OnCallInitialiazeEventsControlMensagens();
								}
								this.m_gbPreferencias.Controls.Add(UserCtrlMensagens);
								UserCtrlMensagens.SetBounds(4, 9, (this.m_gbPreferencias.Width - 7), (this.m_gbPreferencias.Height - 13));
								UserCtrlMensagens.Visible = true;
								UserCtrlMensagens.BringToFront();
							}
							#endregion
							#region Atualizações
							else if (teste.Text == "Atualizações")
							{
								if (UserCtrlEntrada != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlEntrada);
									UserCtrlEntrada.Visible = false;
								}
								if (UserCtrlGlobal != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlGlobal);
									UserCtrlGlobal.Visible = false;
								}
								if (UserCtrlBackup != null)
								{
									UserCtrlBackup.OnCallSalvaDadosInterface();
									this.m_gbPreferencias.Controls.Remove(UserCtrlBackup);
									UserCtrlBackup.Visible = false;
								}
								if (UserCtrlCores != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlCores);
									UserCtrlCores.Visible = false;
								}
								if (UserCtrlRelatorios != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlRelatorios);
									UserCtrlRelatorios.Visible = false;
								}
								if (UserCtrlMensagens != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlMensagens);
									UserCtrlMensagens.Visible = false;
								}
								if (UserCtrlAtualizacoes == null)
								{
									UserCtrlAtualizacoes = new usrCtrlAtualizacoes();
									OnCallInitialiazeEventsControlAtualizacoes();
								}
								this.m_gbPreferencias.Controls.Add(UserCtrlAtualizacoes);
								UserCtrlAtualizacoes.SetBounds(4, 9, (this.m_gbPreferencias.Width - 7), (this.m_gbPreferencias.Height - 13));
								UserCtrlAtualizacoes.Visible = true;
								UserCtrlAtualizacoes.BringToFront();
							}
							#endregion
							#region Atualizacoes

							#endregion
							#region Impressão
							else if (teste.Text == "Impressão")
							{
								if (UserCtrlEntrada != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlEntrada);
									UserCtrlEntrada.Visible = false;
								}
								if (UserCtrlGlobal != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlGlobal);
									UserCtrlGlobal.Visible = false;
								}
								if (UserCtrlBackup != null)
								{
									UserCtrlBackup.OnCallSalvaDadosInterface();
									this.m_gbPreferencias.Controls.Remove(UserCtrlBackup);
									UserCtrlBackup.Visible = false;
								}
								if (UserCtrlCores != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlCores);
									UserCtrlCores.Visible = false;
								}
								if (UserCtrlRelatorios != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlRelatorios);
									UserCtrlRelatorios.Visible = false;
								}
								if (UserCtrlMensagens != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlMensagens);
									UserCtrlMensagens.Visible = false;
								}
								if (UserCtrlAtualizacoes != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlAtualizacoes);
									UserCtrlAtualizacoes.Visible = false;
								}
							}
								#endregion
							#region Banco de Dados
							else if (teste.Text == "Banco de Dados")
							{
								if (UserCtrlEntrada != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlEntrada);
									UserCtrlEntrada.Visible = false;
								}
								if (UserCtrlGlobal != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlGlobal);
									UserCtrlGlobal.Visible = false;
								}
								if (UserCtrlBackup != null)
								{
									UserCtrlBackup.OnCallSalvaDadosInterface();
									this.m_gbPreferencias.Controls.Remove(UserCtrlBackup);
									UserCtrlBackup.Visible = false;
								}
								if (UserCtrlCores != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlCores);
									UserCtrlCores.Visible = false;
								}
								if (UserCtrlMensagens != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlMensagens);
									UserCtrlMensagens.Visible = false;
								}
								if (UserCtrlAtualizacoes != null)
								{
									this.m_gbPreferencias.Controls.Remove(UserCtrlAtualizacoes);
									UserCtrlAtualizacoes.Visible = false;
								}
								OnCallConfiguraBancoDados();
							}
							#endregion
						}
						this.mostraCor();
						m_tvItensPreferencias.Focus();
						this.Cursor = System.Windows.Forms.Cursors.Default;
						m_bAtivado = true;
					}
				}
			#endregion
			#region Botoes
				private void m_btTrocarCor_Click(object sender, System.EventArgs e)
				{
					try
					{
						this.trocaCor();
						if (UserCtrlCores != null)
							UserCtrlCores.refreshCores();
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					if (UserCtrlBackup != null)
						UserCtrlBackup.OnCallSalvaDadosInterface();
					if (UserCtrlRelatorios != null)
						UserCtrlRelatorios.OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					this.Close();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}


			#endregion
		#endregion

		#region Cores
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		public void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "Preferencias");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		public void mostraCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "Preferencias");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TreeView") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlPreferencias.JanelaPrincipal.usrCtrlJanelaPrincipal") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].Name != 
								"m_btCoresPrimarias")&&
								(this.Controls[cont].Controls[cont2].Controls[cont3].Name != 
								"m_btCoresSecundarias"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
							for (int cont4 = 0; cont4 < this.Controls[cont].Controls[cont2].Controls[cont3].Controls.Count; cont4++)
							{
								if ((this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].GetType().ToString() != 
									"mdlComponentesGraficos.TextBox") &&
									(this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].GetType().ToString() != 
									"mdlComponentesGraficos.TreeView") &&
									(this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].GetType().ToString() != 
									"mdlComponentesGraficos.ListView") &&
									(this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].Name != 
									"m_btCoresPrimarias")&&
									(this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].Name != 
									"m_btCoresSecundarias"))
								{
									this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].BackColor = this.BackColor;
								}
								for (int cont5 = 0; cont5 < this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].Controls.Count; cont5++)
								{
									if ((this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].Controls[cont5].GetType().ToString() != 
										"mdlComponentesGraficos.TextBox") &&
										(this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].Controls[cont5].GetType().ToString() != 
										"mdlComponentesGraficos.TreeView") &&
										(this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].Controls[cont5].GetType().ToString() != 
										"mdlComponentesGraficos.ListView") &&
										(this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].Controls[cont5].Name != 
										"m_btCoresPrimarias")&&
										(this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].Controls[cont5].Name != 
										"m_btCoresSecundarias"))
									{
										this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].Controls[cont5].BackColor = this.BackColor;
									}
								}
							}
						}
					}
				}
			} 
			catch (Exception erro) 
			{ 
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Banner
			public void setToolTipBanner(string strToolTip)
			{
				if (UserCtrlCores != null)
					UserCtrlCores.setToolTipBanner(strToolTip);
			}
		#endregion
	}
}
