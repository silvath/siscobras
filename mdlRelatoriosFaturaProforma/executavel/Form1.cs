using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace executavel
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		#region Atributos
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD = null;
		private mdlTratamentoErro.clsTratamentoErro m_cls_tre_tratadorErro = null;

		private string m_strEnderecoExecutavel = "";

		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;

		private mdlRelatoriosFaturaProforma.frmRelatoriosFaturaProforma formTeste;
		internal System.Windows.Forms.TextBox txtIdCotacao;
		internal System.Windows.Forms.TextBox txtIdExportador; 
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region Construtores & Destrutores
		public Form1(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_tre_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.Button1 = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtIdCotacao = new System.Windows.Forms.TextBox();
			this.txtIdExportador = new System.Windows.Forms.TextBox();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add(this.Button1);
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.txtIdCotacao);
			this.GroupBox1.Controls.Add(this.txtIdExportador);
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
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point(8, 80);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(40, 16);
			this.Label2.TabIndex = 3;
			this.Label2.Text = "idPE";
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(9, 24);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(40, 16);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "idExp";
			// 
			// txtIdCotacao
			// 
			this.txtIdCotacao.Location = new System.Drawing.Point(8, 104);
			this.txtIdCotacao.Name = "txtIdCotacao";
			this.txtIdCotacao.Size = new System.Drawing.Size(56, 20);
			this.txtIdCotacao.TabIndex = 1;
			this.txtIdCotacao.Text = "394";
			this.txtIdCotacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtIdExportador
			// 
			this.txtIdExportador.Location = new System.Drawing.Point(8, 48);
			this.txtIdExportador.Name = "txtIdExportador";
			this.txtIdExportador.Size = new System.Drawing.Size(56, 20);
			this.txtIdExportador.TabIndex = 0;
			this.txtIdExportador.Text = "0";
			this.txtIdExportador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(768, 494);
			this.Controls.Add(this.GroupBox1);
			this.IsMdiContainer = true;
			this.Name = "Form1";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.GroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
		private void Button1_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.Form mdiParent = (System.Windows.Forms.Form)this;
			if (formTeste == null)
			{
				formTeste = new mdlRelatoriosFaturaProforma.frmRelatoriosFaturaProforma(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD, ref mdiParent,m_strEnderecoExecutavel,Int32.Parse(this.txtIdExportador.Text),txtIdCotacao.Text);
				formTeste.MdiParent = this;
				formTeste.Show();
			}
			else
			{
				formTeste.Close();
				formTeste = null;
			}
		}
		#endregion
	}
}
