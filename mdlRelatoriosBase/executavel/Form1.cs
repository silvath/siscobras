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
		#region Atributes
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro;
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_Connection;
		private string m_strEnderecoExecutavel;

		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;

		private frmRelatoriosTeste formTeste;
		internal System.Windows.Forms.TextBox txtIdCodigo;
		internal System.Windows.Forms.TextBox txtIdTipo;
		internal System.Windows.Forms.TextBox txtIdExportador;
		internal System.Windows.Forms.Button m_btMostrar;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtIdRelatorio;

		private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors And Destructors 
		public Form1(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_Connection,string strEnderecoExecutavel)
		{
			m_cls_ter_TratadorErro = cls_ter_TratadorErro;
			m_cls_dba_Connection = cls_dba_Connection;
			m_strEnderecoExecutavel = strEnderecoExecutavel;

			InitializeComponent();
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
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtIdRelatorio = new System.Windows.Forms.TextBox();
			this.m_btMostrar = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtIdCodigo = new System.Windows.Forms.TextBox();
			this.Button1 = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtIdTipo = new System.Windows.Forms.TextBox();
			this.txtIdExportador = new System.Windows.Forms.TextBox();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add(this.label4);
			this.GroupBox1.Controls.Add(this.txtIdRelatorio);
			this.GroupBox1.Controls.Add(this.m_btMostrar);
			this.GroupBox1.Controls.Add(this.Label3);
			this.GroupBox1.Controls.Add(this.txtIdCodigo);
			this.GroupBox1.Controls.Add(this.Button1);
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.txtIdTipo);
			this.GroupBox1.Controls.Add(this.txtIdExportador);
			this.GroupBox1.Location = new System.Drawing.Point(8, 8);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(80, 440);
			this.GroupBox1.TabIndex = 1;
			this.GroupBox1.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 193);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "idRel";
			// 
			// txtIdRelatorio
			// 
			this.txtIdRelatorio.Location = new System.Drawing.Point(10, 217);
			this.txtIdRelatorio.Name = "txtIdRelatorio";
			this.txtIdRelatorio.Size = new System.Drawing.Size(56, 20);
			this.txtIdRelatorio.TabIndex = 8;
			this.txtIdRelatorio.Text = "-1";
			// 
			// m_btMostrar
			// 
			this.m_btMostrar.Location = new System.Drawing.Point(8, 336);
			this.m_btMostrar.Name = "m_btMostrar";
			this.m_btMostrar.Size = new System.Drawing.Size(64, 24);
			this.m_btMostrar.TabIndex = 7;
			this.m_btMostrar.Text = "Mostrar";
			this.m_btMostrar.Click += new System.EventHandler(this.m_btMostrar_Click);
			// 
			// Label3
			// 
			this.Label3.Location = new System.Drawing.Point(10, 135);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(48, 16);
			this.Label3.TabIndex = 6;
			this.Label3.Text = "idCod";
			// 
			// txtIdCodigo
			// 
			this.txtIdCodigo.Location = new System.Drawing.Point(8, 159);
			this.txtIdCodigo.Name = "txtIdCodigo";
			this.txtIdCodigo.Size = new System.Drawing.Size(56, 20);
			this.txtIdCodigo.TabIndex = 5;
			this.txtIdCodigo.Text = "001";
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(8, 304);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(64, 24);
			this.Button1.TabIndex = 4;
			this.Button1.Text = "abrir";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point(13, 80);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(40, 16);
			this.Label2.TabIndex = 3;
			this.Label2.Text = "Tipo";
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(8, 24);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(40, 16);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "idExp";
			// 
			// txtIdTipo
			// 
			this.txtIdTipo.Location = new System.Drawing.Point(8, 104);
			this.txtIdTipo.Name = "txtIdTipo";
			this.txtIdTipo.Size = new System.Drawing.Size(56, 20);
			this.txtIdTipo.TabIndex = 1;
			this.txtIdTipo.Text = "3";
			// 
			// txtIdExportador
			// 
			this.txtIdExportador.Location = new System.Drawing.Point(8, 48);
			this.txtIdExportador.Name = "txtIdExportador";
			this.txtIdExportador.Size = new System.Drawing.Size(56, 20);
			this.txtIdExportador.TabIndex = 0;
			this.txtIdExportador.Text = "1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 470);
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
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.Form mdiParentTeste = (System.Windows.Forms.Form)this;
			if (formTeste == null)
			{
	           formTeste = new frmRelatoriosTeste(ref m_cls_ter_TratadorErro,ref m_cls_dba_Connection,ref mdiParentTeste,m_strEnderecoExecutavel,Int32.Parse(this.txtIdTipo.Text),Int32.Parse(this.txtIdExportador.Text),this.txtIdCodigo.Text);
			   formTeste.MdiParent = this;
			   formTeste.Show();
  			   formTeste.SendToBack();

			}else{
               formTeste.Close();
               formTeste = null;
			}
		}

		private void m_btMostrar_Click(object sender, System.EventArgs e)
		{
			if (formTeste != null)
			{
				formTeste.SetIdRelatorio(Int32.Parse(this.txtIdRelatorio.Text));
				formTeste.bMostrarRelatorio();
			}
		}
		#endregion
	}
}
