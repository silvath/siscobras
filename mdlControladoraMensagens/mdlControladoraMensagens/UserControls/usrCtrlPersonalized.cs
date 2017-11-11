using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace mdlControladoraMensagens.UserControls
{
	/// <summary>
	/// Summary description for usrCtrlPersonalized.
	/// </summary>
	public class usrCtrlPersonalized : System.Windows.Forms.UserControl
	{
		#region Delegates
			public delegate void delCallLoadSchedulerActivated(int nIdType,out bool bActivated);
			public delegate void delCallSaveSchedulerActivated(int nIdType,bool bActivated);
		#endregion
		#region Events
			public event delCallLoadSchedulerActivated eCallLoadSchedulerActivated;
			public event delCallSaveSchedulerActivated eCallSaveSchedulerActivated;
		#endregion
		#region Events Methods
			protected virtual void OnCallLoadSchedulerActivated()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bActivated = false;
				if (eCallLoadSchedulerActivated != null)
					eCallLoadSchedulerActivated(mdlConstantes.clsConstantes.ID_SCHEDULER_PERSONALIZED,out bActivated);
				m_ckAtivado.Checked = bActivated;
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallSaveSchedulerActivated()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallSaveSchedulerActivated != null)
					eCallSaveSchedulerActivated(mdlConstantes.clsConstantes.ID_SCHEDULER_PERSONALIZED,m_ckAtivado.Checked);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region Atributes
			private System.Windows.Forms.Label m_lbDeadlines;
			private System.Windows.Forms.CheckBox m_ckAtivado;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public usrCtrlPersonalized()
			{
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
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_lbDeadlines = new System.Windows.Forms.Label();
			this.m_ckAtivado = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// m_lbDeadlines
			// 
			this.m_lbDeadlines.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbDeadlines.Location = new System.Drawing.Point(72, 16);
			this.m_lbDeadlines.Name = "m_lbDeadlines";
			this.m_lbDeadlines.Size = new System.Drawing.Size(144, 24);
			this.m_lbDeadlines.TabIndex = 1;
			this.m_lbDeadlines.Text = "Personalizadas";
			// 
			// m_ckAtivado
			// 
			this.m_ckAtivado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckAtivado.Location = new System.Drawing.Point(24, 64);
			this.m_ckAtivado.Name = "m_ckAtivado";
			this.m_ckAtivado.Size = new System.Drawing.Size(192, 16);
			this.m_ckAtivado.TabIndex = 2;
			this.m_ckAtivado.Text = "Serviço de mensagem ativado.";
			this.m_ckAtivado.CheckedChanged += new System.EventHandler(this.m_ckAtivado_CheckedChanged);
			// 
			// usrCtrlPersonalized
			// 
			this.Controls.Add(this.m_ckAtivado);
			this.Controls.Add(this.m_lbDeadlines);
			this.Name = "usrCtrlPersonalized";
			this.Size = new System.Drawing.Size(280, 448);
			this.Load += new System.EventHandler(this.usrCtrlPersonalized_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void usrCtrlPersonalized_Load(object sender, System.EventArgs e)
				{
					OnCallLoadSchedulerActivated();
				}
			#endregion
			#region CheckBoxes
				private void m_ckAtivado_CheckedChanged(object sender, System.EventArgs e)
				{
					OnCallSaveSchedulerActivated();
				}
			#endregion
		#endregion
	}
}
