using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlBackup
{
	/// <summary>
	/// Summary description for frmFBackupRestore.
	/// </summary>
	internal class frmFBackupRestore : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delRestoreBackup(string strPath);
		#endregion
		#region Events
			public event delRestoreBackup eRestoreBackup;
		#endregion
		#region Events Methods
			internal bool OnRestoreBackup(string strPath)
			{
				if (eRestoreBackup != null)
					return(eRestoreBackup(strPath));
				else
					return(false);
			} 
		#endregion

		#region Atributes
			private System.Windows.Forms.GroupBox m_gbMain;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Label m_lbArquivo;
			private System.Windows.Forms.TextBox m_txtArquivo;
		internal System.Windows.Forms.Button m_btRestore;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
		#endregion
		#region Constructors and Destructors 
			public frmFBackupRestore()
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
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFBackupRestore));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_txtArquivo = new System.Windows.Forms.TextBox();
			this.m_lbArquivo = new System.Windows.Forms.Label();
			this.m_btRestore = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_txtArquivo);
			this.m_gbMain.Controls.Add(this.m_lbArquivo);
			this.m_gbMain.Controls.Add(this.m_btRestore);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(4, -3);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(468, 72);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_txtArquivo
			// 
			this.m_txtArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtArquivo.Location = new System.Drawing.Point(126, 12);
			this.m_txtArquivo.Name = "m_txtArquivo";
			this.m_txtArquivo.ReadOnly = true;
			this.m_txtArquivo.Size = new System.Drawing.Size(306, 20);
			this.m_txtArquivo.TabIndex = 78;
			this.m_txtArquivo.Text = "";
			// 
			// m_lbArquivo
			// 
			this.m_lbArquivo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbArquivo.Location = new System.Drawing.Point(8, 14);
			this.m_lbArquivo.Name = "m_lbArquivo";
			this.m_lbArquivo.Size = new System.Drawing.Size(120, 16);
			this.m_lbArquivo.TabIndex = 77;
			this.m_lbArquivo.Text = "Arquivo a Restaurar:";
			// 
			// m_btRestore
			// 
			this.m_btRestore.BackColor = System.Drawing.SystemColors.Control;
			this.m_btRestore.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRestore.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btRestore.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btRestore.Image = ((System.Drawing.Image)(resources.GetObject("m_btRestore.Image")));
			this.m_btRestore.Location = new System.Drawing.Point(438, 9);
			this.m_btRestore.Name = "m_btRestore";
			this.m_btRestore.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btRestore.Size = new System.Drawing.Size(25, 25);
			this.m_btRestore.TabIndex = 76;
			this.m_btRestore.Click += new System.EventHandler(this.m_btRestore_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(171, 41);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 74;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(235, 41);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 75;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFBackupRestore
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(474, 72);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFBackupRestore";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Siscobras - Restaurando Becape";
			this.m_gbMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
			#region Buttons
				private void m_btRestore_Click(object sender, System.EventArgs e)
				{
					RestoreFileChange();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					if (OnRestoreBackup(m_txtArquivo.Text))
					{
						this.Cursor = System.Windows.Forms.Cursors.Default;
						this.Close();
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}
			#endregion
		#endregion

		#region Restore
			private bool RestoreFileChange()
			{
				System.Windows.Forms.OpenFileDialog dlgOpen = new System.Windows.Forms.OpenFileDialog();
				if (m_txtArquivo.Text != "")
					dlgOpen.FileName = m_txtArquivo.Text;
				dlgOpen.CheckFileExists = true;
				dlgOpen.Filter = "Becape (*.bkp)|*.bkp";
				if (dlgOpen.ShowDialog() != System.Windows.Forms.DialogResult.OK )
					return(false);
				if ((dlgOpen.FileName == null) || (dlgOpen.FileName == ""))
					return(false);
				m_txtArquivo.Text = dlgOpen.FileName;
				return(true);
			}
		#endregion
	}
}
