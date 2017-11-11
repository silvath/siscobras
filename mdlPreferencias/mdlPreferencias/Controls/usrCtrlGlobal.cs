using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace mdlPreferencias.Global
{
	/// <summary>
	/// Summary description for usrCtrlGlobal.
	/// </summary>
	internal class usrCtrlGlobal : System.Windows.Forms.UserControl
	{
		#region Atributos
		private bool m_bAtivado = true;
		private System.Windows.Forms.CheckBox m_ckbxMostrarBaloes;
		private System.Windows.Forms.CheckBox m_ckbxMostrarAssistentes;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region Construtores & Destrutores
		public usrCtrlGlobal()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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
		public delegate void delCallCarregaDadosInterface(ref System.Windows.Forms.CheckBox ckbxBaloes, ref System.Windows.Forms.CheckBox ckbxAssistentes);
		public delegate void delCallSalvaDadosInterface(ref System.Windows.Forms.CheckBox ckbxBaloes, ref System.Windows.Forms.CheckBox ckbxAssistentes);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_ckbxMostrarBaloes, ref m_ckbxMostrarAssistentes);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_ckbxMostrarBaloes, ref m_ckbxMostrarAssistentes);
		}
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_ckbxMostrarBaloes = new System.Windows.Forms.CheckBox();
			this.m_ckbxMostrarAssistentes = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// m_ckbxMostrarBaloes
			// 
			this.m_ckbxMostrarBaloes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckbxMostrarBaloes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_ckbxMostrarBaloes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckbxMostrarBaloes.Location = new System.Drawing.Point(16, 16);
			this.m_ckbxMostrarBaloes.Name = "m_ckbxMostrarBaloes";
			this.m_ckbxMostrarBaloes.Size = new System.Drawing.Size(183, 17);
			this.m_ckbxMostrarBaloes.TabIndex = 1;
			this.m_ckbxMostrarBaloes.Text = "Apresentar balões de dicas";
			this.m_ckbxMostrarBaloes.CheckedChanged += new System.EventHandler(this.m_ckbxMostrarBaloes_CheckedChanged);
			// 
			// m_ckbxMostrarAssistentes
			// 
			this.m_ckbxMostrarAssistentes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckbxMostrarAssistentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_ckbxMostrarAssistentes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckbxMostrarAssistentes.Location = new System.Drawing.Point(16, 40);
			this.m_ckbxMostrarAssistentes.Name = "m_ckbxMostrarAssistentes";
			this.m_ckbxMostrarAssistentes.Size = new System.Drawing.Size(269, 17);
			this.m_ckbxMostrarAssistentes.TabIndex = 2;
			this.m_ckbxMostrarAssistentes.Text = "Apresentar assistente ao criar documento";
			this.m_ckbxMostrarAssistentes.CheckedChanged += new System.EventHandler(this.m_ckbxMostrarAssistentes_CheckedChanged);
			// 
			// usrCtrlGlobal
			// 
			this.Controls.Add(this.m_ckbxMostrarAssistentes);
			this.Controls.Add(this.m_ckbxMostrarBaloes);
			this.Name = "usrCtrlGlobal";
			this.Size = new System.Drawing.Size(394, 368);
			this.Load += new System.EventHandler(this.usrCtrlGlobal_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
		#region Load
		private void usrCtrlGlobal_Load(object sender, System.EventArgs e)
		{
			if (m_bAtivado)
			{
				m_bAtivado = false;
				OnCallCarregaDadosInterface();
				m_bAtivado = true;
			}
		}
		#endregion
		#region Visible Changed
		private void usrCtrlGlobal_VisibleChanged(object sender, System.EventArgs e)
		{
			if (m_bAtivado)
			{
				m_bAtivado = false;
				m_bAtivado = true;
			}
		}
		#endregion
		#region Checked Changed
		private void m_ckbxMostrarBaloes_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_bAtivado)
			{
				m_bAtivado = false;
				OnCallSalvaDadosInterface();
				m_bAtivado = true;
			}
		}
		private void m_ckbxMostrarAssistentes_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_bAtivado)
			{
				m_bAtivado = false;
				OnCallSalvaDadosInterface();
				m_bAtivado = true;
			}
		}
		#endregion
		#endregion
	}
}
