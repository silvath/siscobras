using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlUsuarios.Frames
{
	/// <summary>
	/// Summary description for frmFPermissoesUsuario.
	/// </summary>
	internal class frmFPermissoesUsuario : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btTrocarCor;
		private mdlComponentesGraficos.ComboBox m_cbUsuarios;
		private mdlComponentesGraficos.ComboBox m_cbPermissoes;
		private mdlComponentesGraficos.ComboBox m_cbConcessoes;
		private System.Windows.Forms.Label m_lPermitir;
		private System.Windows.Forms.Label m_lItem;
		private System.Windows.Forms.Button m_btSalvar;
		private mdlComponentesGraficos.ComboBox m_cbItemsEspecificos;
		#endregion
		private System.Windows.Forms.ToolTip m_ttUsuarios;
		private System.ComponentModel.IContainer components;

		#region Construtores & Destrutores
		public frmFPermissoesUsuario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
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

		#region Delegates
		public delegate void delCalCarregaDadosComboBoxUsuarios(ref mdlComponentesGraficos.ComboBox cbUsuarios);
		public delegate void delCallCarregaDadosComboBoxConcessoes(ref mdlComponentesGraficos.ComboBox cbConcessoes);
		public delegate void delCallCarregaDadosComboBoxPermissoes(ref mdlComponentesGraficos.ComboBox cbConcessoes, ref mdlComponentesGraficos.ComboBox cbPermissoes, ref mdlComponentesGraficos.ComboBox cbItems);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.ComboBox cbConcessoes, ref mdlComponentesGraficos.ComboBox cbUsuarios, ref mdlComponentesGraficos.ComboBox cbPermissoes, ref mdlComponentesGraficos.ComboBox cbItemsEspecificos);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		public delegate void delCallAnulaTypDatSet();
		#endregion
		#region Events
		public event delCalCarregaDadosComboBoxUsuarios eCalCarregaDadosComboBoxUsuarios;
		public event delCallCarregaDadosComboBoxConcessoes eCallCarregaDadosComboBoxConcessoes;
		public event delCallCarregaDadosComboBoxPermissoes eCallCarregaDadosComboBoxPermissoes;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		public event delCallAnulaTypDatSet eCallAnulaTypDatSet;
		#endregion
		#region Events Methods
		protected virtual void OnCalCarregaDadosComboBoxUsuarios()
		{
			if (eCalCarregaDadosComboBoxUsuarios != null)
				eCalCarregaDadosComboBoxUsuarios(ref m_cbUsuarios);
		}
		protected virtual void OnCallCarregaDadosComboBoxConcessoes()
		{
			if (eCallCarregaDadosComboBoxConcessoes != null)
				eCallCarregaDadosComboBoxConcessoes(ref m_cbConcessoes);
		}
		protected virtual void OnCallCarregaDadosComboBoxPermissoes()
		{
			if (eCallCarregaDadosComboBoxPermissoes != null)
				eCallCarregaDadosComboBoxPermissoes(ref m_cbConcessoes, ref m_cbPermissoes, ref m_cbItemsEspecificos);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_cbConcessoes, ref m_cbUsuarios, ref m_cbPermissoes, ref m_cbItemsEspecificos);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(m_bModificado);
		}
		protected virtual void OnCallAnulaTypDatSet()
		{
			if (eCallAnulaTypDatSet != null)
				eCallAnulaTypDatSet();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFPermissoesUsuario));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_btSalvar = new System.Windows.Forms.Button();
			this.m_cbItemsEspecificos = new mdlComponentesGraficos.ComboBox();
			this.m_lItem = new System.Windows.Forms.Label();
			this.m_cbConcessoes = new mdlComponentesGraficos.ComboBox();
			this.m_cbPermissoes = new mdlComponentesGraficos.ComboBox();
			this.m_lPermitir = new System.Windows.Forms.Label();
			this.m_cbUsuarios = new mdlComponentesGraficos.ComboBox();
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
			this.m_gbFrame.Size = new System.Drawing.Size(422, 157);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 10);
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
			this.m_btOk.Location = new System.Drawing.Point(151, 125);
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
			this.m_btCancelar.Location = new System.Drawing.Point(215, 125);
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
			this.m_gbFields.Controls.Add(this.m_btSalvar);
			this.m_gbFields.Controls.Add(this.m_cbItemsEspecificos);
			this.m_gbFields.Controls.Add(this.m_lItem);
			this.m_gbFields.Controls.Add(this.m_cbConcessoes);
			this.m_gbFields.Controls.Add(this.m_cbPermissoes);
			this.m_gbFields.Controls.Add(this.m_lPermitir);
			this.m_gbFields.Controls.Add(this.m_cbUsuarios);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(406, 113);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_btSalvar
			// 
			this.m_btSalvar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btSalvar.Location = new System.Drawing.Point(346, 85);
			this.m_btSalvar.Name = "m_btSalvar";
			this.m_btSalvar.Size = new System.Drawing.Size(56, 24);
			this.m_btSalvar.TabIndex = 6;
			this.m_btSalvar.Text = "Salvar";
			this.m_ttUsuarios.SetToolTip(this.m_btSalvar, "Salvar alteração");
			this.m_btSalvar.Click += new System.EventHandler(this.m_btSalvar_Click);
			// 
			// m_cbItemsEspecificos
			// 
			this.m_cbItemsEspecificos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbItemsEspecificos.Location = new System.Drawing.Point(150, 83);
			this.m_cbItemsEspecificos.Name = "m_cbItemsEspecificos";
			this.m_cbItemsEspecificos.Size = new System.Drawing.Size(147, 22);
			this.m_cbItemsEspecificos.TabIndex = 5;
			this.m_ttUsuarios.SetToolTip(this.m_cbItemsEspecificos, "Selecionar item");
			// 
			// m_lItem
			// 
			this.m_lItem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lItem.Location = new System.Drawing.Point(110, 85);
			this.m_lItem.Name = "m_lItem";
			this.m_lItem.Size = new System.Drawing.Size(40, 14);
			this.m_lItem.TabIndex = 4;
			this.m_lItem.Text = "o item";
			// 
			// m_cbConcessoes
			// 
			this.m_cbConcessoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbConcessoes.Location = new System.Drawing.Point(103, 19);
			this.m_cbConcessoes.Name = "m_cbConcessoes";
			this.m_cbConcessoes.Size = new System.Drawing.Size(200, 22);
			this.m_cbConcessoes.TabIndex = 3;
			this.m_ttUsuarios.SetToolTip(this.m_cbConcessoes, "Concessões");
			this.m_cbConcessoes.SelectedIndexChanged += new System.EventHandler(this.m_cbConcessoes_SelectedIndexChanged);
			// 
			// m_cbPermissoes
			// 
			this.m_cbPermissoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbPermissoes.Location = new System.Drawing.Point(280, 55);
			this.m_cbPermissoes.Name = "m_cbPermissoes";
			this.m_cbPermissoes.Size = new System.Drawing.Size(118, 22);
			this.m_cbPermissoes.TabIndex = 2;
			this.m_ttUsuarios.SetToolTip(this.m_cbPermissoes, "Selecionar permissão");
			// 
			// m_lPermitir
			// 
			this.m_lPermitir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPermitir.Location = new System.Drawing.Point(24, 57);
			this.m_lPermitir.Name = "m_lPermitir";
			this.m_lPermitir.Size = new System.Drawing.Size(99, 15);
			this.m_lPermitir.TabIndex = 1;
			this.m_lPermitir.Text = "Permitir ao usuário";
			// 
			// m_cbUsuarios
			// 
			this.m_cbUsuarios.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbUsuarios.Location = new System.Drawing.Point(125, 55);
			this.m_cbUsuarios.Name = "m_cbUsuarios";
			this.m_cbUsuarios.Size = new System.Drawing.Size(147, 22);
			this.m_cbUsuarios.TabIndex = 0;
			this.m_ttUsuarios.SetToolTip(this.m_cbUsuarios, "Selecionar usuário");
			// 
			// m_ttUsuarios
			// 
			this.m_ttUsuarios.AutomaticDelay = 100;
			this.m_ttUsuarios.AutoPopDelay = 5000;
			this.m_ttUsuarios.InitialDelay = 100;
			this.m_ttUsuarios.ReshowDelay = 20;
			// 
			// frmFPermissoesUsuario
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(426, 159);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFPermissoesUsuario";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Permissões";
			this.Load += new System.EventHandler(this.frmFPermissoesUsuario_Load);
			this.Activated += new System.EventHandler(this.frmFPermissoesUsuario_Activated);
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
		private void frmFPermissoesUsuario_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
                OnCallCarregaDadosComboBoxConcessoes();
				OnCalCarregaDadosComboBoxUsuarios();
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
				OnCallAnulaTypDatSet();
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
				this.m_bModificado = true;
				OnCallSalvaDadosBD();
				OnCallAnulaTypDatSet();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				this.Close();				
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Concessoes Selected Index Changed
		private void m_cbConcessoes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				OnCallCarregaDadosComboBoxPermissoes();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Activated
		private void frmFPermissoesUsuario_Activated(object sender, System.EventArgs e)
		{
			m_cbConcessoes.Focus();
		}
		#endregion
		#region Botao Salvar
		private void m_btSalvar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (m_cbConcessoes.ReturnObjectSelectedItem() != null)
				{
					if (m_cbPermissoes.ReturnObjectSelectedItem() != null)
					{
						if (m_cbUsuarios.ReturnObjectSelectedItem() != null)
						{
							if (m_cbItemsEspecificos.ReturnObjectSelectedItem() != null)
							{
								OnCallSalvaDadosInterface();
							}
						}
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
