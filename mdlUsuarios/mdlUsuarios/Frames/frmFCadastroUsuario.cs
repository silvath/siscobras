using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlUsuarios.Frames
{
	/// <summary>
	/// Summary description for frmFCadastroUsuario.
	/// </summary>
	internal class frmFCadastroUsuario : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		private bool m_bModificado = false;

		private bool m_bExisteUsuarioMesmoLogin = false;

		private bool m_bCadastroAdministrador = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btTrocarCor;
		private mdlComponentesGraficos.TextBox m_tbSenha;
		private mdlComponentesGraficos.TextBox m_tbUsuario;
		private System.Windows.Forms.Label m_lSenha;
		private System.Windows.Forms.Label m_lUsuario;
		private System.Windows.Forms.Label m_lPrivilegios;
		private mdlComponentesGraficos.TextBox m_tbRedigitacaoSenha;
		#endregion
		private System.Windows.Forms.ToolTip m_ttUsuarios;
		private System.ComponentModel.IContainer components;

		#region Construtores & Destrutores
		public frmFCadastroUsuario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel, bool bCadastroAdministrador)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_bCadastroAdministrador = bCadastroAdministrador;
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

		#region Delegate
		// Delegate para BD
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbUsuario, ref mdlComponentesGraficos.TextBox tbSenha);
		public delegate void delCallChecaIntegridadeDados();
		public delegate bool delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbUsuario, ref mdlComponentesGraficos.TextBox tbSenha);
		public delegate void delCallSalvaDadosBD(bool modificado);
		#endregion
		#region Events
		// Events BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}
 
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref this.m_tbUsuario, ref this.m_tbSenha);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}

		protected virtual bool OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				return (eCallSalvaDadosInterface(ref this.m_tbUsuario,ref this.m_tbSenha));
			return false;
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bModificado);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFCadastroUsuario));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_tbRedigitacaoSenha = new mdlComponentesGraficos.TextBox();
			this.m_lPrivilegios = new System.Windows.Forms.Label();
			this.m_tbSenha = new mdlComponentesGraficos.TextBox();
			this.m_tbUsuario = new mdlComponentesGraficos.TextBox();
			this.m_lSenha = new System.Windows.Forms.Label();
			this.m_lUsuario = new System.Windows.Forms.Label();
			this.m_ttUsuarios = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(246, 158);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(3, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 13;
			this.m_ttUsuarios.SetToolTip(this.m_btTrocarCor, "Cor");
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
			this.m_btOk.Location = new System.Drawing.Point(63, 126);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 11;
			this.m_ttUsuarios.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(127, 126);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 12;
			this.m_ttUsuarios.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_tbRedigitacaoSenha);
			this.m_gbFields.Controls.Add(this.m_lPrivilegios);
			this.m_gbFields.Controls.Add(this.m_tbSenha);
			this.m_gbFields.Controls.Add(this.m_tbUsuario);
			this.m_gbFields.Controls.Add(this.m_lSenha);
			this.m_gbFields.Controls.Add(this.m_lUsuario);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(230, 114);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edi��o";
			// 
			// m_tbRedigitacaoSenha
			// 
			this.m_tbRedigitacaoSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbRedigitacaoSenha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbRedigitacaoSenha.Location = new System.Drawing.Point(65, 87);
			this.m_tbRedigitacaoSenha.Name = "m_tbRedigitacaoSenha";
			this.m_tbRedigitacaoSenha.PasswordChar = '*';
			this.m_tbRedigitacaoSenha.Size = new System.Drawing.Size(157, 20);
			this.m_tbRedigitacaoSenha.TabIndex = 9;
			this.m_tbRedigitacaoSenha.Text = "";
			this.m_ttUsuarios.SetToolTip(this.m_tbRedigitacaoSenha, "Repetir senha");
			this.m_tbRedigitacaoSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_tbRedigitacaoSenha_KeyDown);
			this.m_tbRedigitacaoSenha.Leave += new System.EventHandler(this.m_tbRedigitacaoSenha_Leave);
			this.m_tbRedigitacaoSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_tbRedigitacaoSenha_KeyPress);
			this.m_tbRedigitacaoSenha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tbRedigitacaoSenha_KeyUp);
			// 
			// m_lPrivilegios
			// 
			this.m_lPrivilegios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lPrivilegios.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPrivilegios.Location = new System.Drawing.Point(8, 89);
			this.m_lPrivilegios.Name = "m_lPrivilegios";
			this.m_lPrivilegios.Size = new System.Drawing.Size(58, 18);
			this.m_lPrivilegios.TabIndex = 8;
			this.m_lPrivilegios.Text = "Redigite:";
			// 
			// m_tbSenha
			// 
			this.m_tbSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbSenha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbSenha.Location = new System.Drawing.Point(65, 53);
			this.m_tbSenha.Name = "m_tbSenha";
			this.m_tbSenha.PasswordChar = '*';
			this.m_tbSenha.Size = new System.Drawing.Size(157, 20);
			this.m_tbSenha.TabIndex = 5;
			this.m_tbSenha.Text = "";
			this.m_ttUsuarios.SetToolTip(this.m_tbSenha, "Senha");
			this.m_tbSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_tbSenha_KeyDown);
			this.m_tbSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_tbSenha_KeyPress);
			this.m_tbSenha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tbSenha_KeyUp);
			// 
			// m_tbUsuario
			// 
			this.m_tbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbUsuario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbUsuario.Location = new System.Drawing.Point(65, 19);
			this.m_tbUsuario.Name = "m_tbUsuario";
			this.m_tbUsuario.Size = new System.Drawing.Size(157, 20);
			this.m_tbUsuario.TabIndex = 4;
			this.m_tbUsuario.Text = "";
			this.m_ttUsuarios.SetToolTip(this.m_tbUsuario, "Login");
			// 
			// m_lSenha
			// 
			this.m_lSenha.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSenha.Location = new System.Drawing.Point(8, 52);
			this.m_lSenha.Name = "m_lSenha";
			this.m_lSenha.Size = new System.Drawing.Size(55, 15);
			this.m_lSenha.TabIndex = 6;
			this.m_lSenha.Text = "Senha:";
			// 
			// m_lUsuario
			// 
			this.m_lUsuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lUsuario.Location = new System.Drawing.Point(8, 18);
			this.m_lUsuario.Name = "m_lUsuario";
			this.m_lUsuario.Size = new System.Drawing.Size(55, 15);
			this.m_lUsuario.TabIndex = 3;
			this.m_lUsuario.Text = "Usu�rio:";
			// 
			// m_ttUsuarios
			// 
			this.m_ttUsuarios.AutomaticDelay = 100;
			this.m_ttUsuarios.AutoPopDelay = 5000;
			this.m_ttUsuarios.InitialDelay = 100;
			this.m_ttUsuarios.ReshowDelay = 20;
			// 
			// frmFCadastroUsuario
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 160);
			this.Controls.Add(this.m_gbFrame);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFCadastroUsuario";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Usu�rio";
			this.Load += new System.EventHandler(this.frmFCadastroUsuario_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		public void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
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
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
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
								"System.Windows.Forms.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
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

		#region Eventos
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.trocaCor();
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.mostraCor();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFCadastroUsuario_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
				if (m_bCadastroAdministrador)
				{
					this.Text = "Administrador do SISCOBRAS";
					m_gbFields.Text = "Cadastro";
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Close();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_tbSenha.Text == m_tbRedigitacaoSenha.Text)
				{
					if (OnCallSalvaDadosInterface())
					{
						this.m_bModificado = true;
						OnCallSalvaDadosBD();
						this.Close();
					}
					else
					{
						mdlMensagens.clsMensagens.ShowError(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlUsuarios_frmFCadastroUsuario_UsuarioJaExistente));
						//MessageBox.Show("Usu�rio com o nome: " + m_tbUsuario.Text + " j� existe.",this.Text,System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					}
				}
				else
				{
					mdlMensagens.clsMensagens.ShowError(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlUsuarios_frmFCadastroUsuario_RedigitacaoSenhaIncorreta).Replace("\\n","\n"));
					//MessageBox.Show("As senhas n�o s�o iguais.\nPor favor, regidite a senha corretamente.", this.Text, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
					this.m_tbRedigitacaoSenha.Focus();
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region KeyPress TextBox Senha
		private void m_tbSenha_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		
		}
		#endregion
		#region Key Down
		private void m_tbSenha_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if ((e.Control) && (e.KeyCode == System.Windows.Forms.Keys.V))
				{
					System.Windows.Forms.Clipboard.SetDataObject("",true);
				}
				else if ((e.Shift) && (e.KeyCode == System.Windows.Forms.Keys.Insert))
				{
					System.Windows.Forms.Clipboard.SetDataObject("",true);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Key Up
		private void m_tbSenha_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if ((e.Control) && (e.KeyCode == System.Windows.Forms.Keys.C))
				{
					System.Windows.Forms.Clipboard.SetDataObject("",true);
				}
				else if ((e.Control) && (e.KeyCode == System.Windows.Forms.Keys.Insert))
				{
					System.Windows.Forms.Clipboard.SetDataObject("",true);
				}
				else if ((e.Control) && (e.KeyCode == System.Windows.Forms.Keys.V))
				{
					System.Windows.Forms.Clipboard.SetDataObject("",true);
				}
				else if ((e.Shift) && (e.KeyCode == System.Windows.Forms.Keys.Insert))
				{
					System.Windows.Forms.Clipboard.SetDataObject("",true);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Redigita��o Senha Leave
		private void m_tbRedigitacaoSenha_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if (m_tbRedigitacaoSenha.Text != "")
				{
					if (m_tbRedigitacaoSenha.Text != m_tbSenha.Text)
					{
						mdlMensagens.clsMensagens.ShowError(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlUsuarios_frmFCadastroUsuario_RedigitacaoSenhaIncorreta).Replace("\\n","\n"));
						//MessageBox.Show("As senhas n�o s�o iguais.\nPor favor, regidite a senha corretamente.",this.Text,System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
						m_tbRedigitacaoSenha.Text = "";
						this.m_tbRedigitacaoSenha.Focus();
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		
		}
		#endregion
		#region KeyPress TextBox Redigita��o Senha
		private void m_tbRedigitacaoSenha_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		
		}
		#endregion
		#region Key Down Redigita��o
		private void m_tbRedigitacaoSenha_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if ((e.Control) && (e.KeyCode == System.Windows.Forms.Keys.V))
				{
					System.Windows.Forms.Clipboard.SetDataObject("",true);
				}
				else if ((e.Shift) && (e.KeyCode == System.Windows.Forms.Keys.Insert))
				{
					System.Windows.Forms.Clipboard.SetDataObject("",true);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Key Up Redigita��o
		private void m_tbRedigitacaoSenha_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if ((e.Control) && (e.KeyCode == System.Windows.Forms.Keys.C))
				{
					System.Windows.Forms.Clipboard.SetDataObject("",true);
				}
				else if ((e.Control) && (e.KeyCode == System.Windows.Forms.Keys.Insert))
				{
					System.Windows.Forms.Clipboard.SetDataObject("",true);
				}
				else if ((e.Control) && (e.KeyCode == System.Windows.Forms.Keys.V))
				{
					System.Windows.Forms.Clipboard.SetDataObject("",true);
				}
				else if ((e.Shift) && (e.KeyCode == System.Windows.Forms.Keys.Insert))
				{
					System.Windows.Forms.Clipboard.SetDataObject("",true);
				}
				else
				{
					if (m_tbRedigitacaoSenha.Text.Length <= m_tbSenha.Text.Length)
					{
						if (m_tbRedigitacaoSenha.Text != m_tbSenha.Text.Substring(0,m_tbRedigitacaoSenha.Text.Length))
						{
							mdlMensagens.clsMensagens.ShowError(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlUsuarios_frmFCadastroUsuario_RedigitacaoSenhaIncorreta).Replace("\\n","\n"));
							//MessageBox.Show("As senhas n�o s�o iguais.\nPor favor, regidite a senha corretamente.",this.Text,System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
							m_tbRedigitacaoSenha.Text = "";
							this.m_tbRedigitacaoSenha.Focus();
						}
					}
					else
					{
						mdlMensagens.clsMensagens.ShowError(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlUsuarios_frmFCadastroUsuario_RedigitacaoSenhaIncorreta).Replace("\\n","\n"));
						//MessageBox.Show("As senhas n�o s�o iguais.\nPor favor, regidite a senha corretamente.",this.Text,System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
						m_tbRedigitacaoSenha.Text = "";
						this.m_tbRedigitacaoSenha.Focus();
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
	}
}
