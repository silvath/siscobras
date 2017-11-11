using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace executavel
{
	/// <summary>
	/// Summary description for formParent.
	/// </summary>
	public class formParent : System.Windows.Forms.Form
	{
		#region Atributos
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD = null;
			private mdlTratamentoErro.clsTratamentoErro m_cls_tre_tratadorErro = null;

			private string m_strEnderecoExecutavel = "";
			private bool m_bPrestadorServico = false;
			private int m_nIdExportador = -1;
			private string m_strIdPe = "";

			internal System.Windows.Forms.GroupBox GroupBox1;
			internal System.Windows.Forms.Button Button1;
			public System.Windows.Forms.ImageList m_ilBandeiras;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Construtores & Destrutores
		public formParent(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel,bool bPrestadorServico,int nIdExportador,string strIdPe)
		{
			InitializeComponent();

			m_cls_tre_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_bPrestadorServico = bPrestadorServico;
			m_nIdExportador = nIdExportador;
			m_strIdPe = strIdPe;
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(formParent));
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.Button1 = new System.Windows.Forms.Button();
			this.m_ilBandeiras = new System.Windows.Forms.ImageList(this.components);
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add(this.Button1);
			this.GroupBox1.Location = new System.Drawing.Point(6, 9);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(80, 199);
			this.GroupBox1.TabIndex = 1;
			this.GroupBox1.TabStop = false;
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(8, 136);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(64, 24);
			this.Button1.TabIndex = 4;
			this.Button1.Text = "abrir";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilBandeiras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBandeiras.ImageStream")));
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// formParent
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(768, 494);
			this.Controls.Add(this.GroupBox1);
			this.IsMdiContainer = true;
			this.Name = "formParent";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.GroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
		private void Button1_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.Form referencia = (System.Windows.Forms.Form)this;
			mdlCadastros.clsCadastros obj = new mdlCadastros.clsCadastros(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_strEnderecoExecutavel,ref referencia,m_bPrestadorServico,m_nIdExportador,m_strIdPe);
			obj.Bandeiras = m_ilBandeiras;
			obj.Show();
		}
		#endregion
	}
}
