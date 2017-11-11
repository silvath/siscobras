using System;
using System.IO;
using System.Threading;
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
		private string m_strEnderecoExecutavel = "C:\\Projetos\\Siscobras\\Binarios\\";
		private mdlModem.clsModem m_clsModem = null;
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratamentoErro = new mdlTratamentoErro.clsTratamentoErro();
		private System.Windows.Forms.TextBox m_tbTextoASerEnviado;
		private System.Windows.Forms.Button m_btEnviar;
		private System.Windows.Forms.TextBox m_tbTextoRecebido;
		private System.Windows.Forms.Label m_lEnviar;
		private System.Windows.Forms.Label m_lRecebido;
		private System.Windows.Forms.Button m_btBina;
		private System.Windows.Forms.Button m_btCancelar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region Construtores & Destrutores
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.m_tbTextoASerEnviado = new System.Windows.Forms.TextBox();
			this.m_btEnviar = new System.Windows.Forms.Button();
			this.m_tbTextoRecebido = new System.Windows.Forms.TextBox();
			this.m_lEnviar = new System.Windows.Forms.Label();
			this.m_lRecebido = new System.Windows.Forms.Label();
			this.m_btBina = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_tbTextoASerEnviado
			// 
			this.m_tbTextoASerEnviado.Location = new System.Drawing.Point(13, 32);
			this.m_tbTextoASerEnviado.Name = "m_tbTextoASerEnviado";
			this.m_tbTextoASerEnviado.Size = new System.Drawing.Size(224, 20);
			this.m_tbTextoASerEnviado.TabIndex = 0;
			this.m_tbTextoASerEnviado.Text = "";
			// 
			// m_btEnviar
			// 
			this.m_btEnviar.Location = new System.Drawing.Point(88, 72);
			this.m_btEnviar.Name = "m_btEnviar";
			this.m_btEnviar.TabIndex = 1;
			this.m_btEnviar.Text = "Enviar";
			this.m_btEnviar.Click += new System.EventHandler(this.m_btEnviar_Click);
			// 
			// m_tbTextoRecebido
			// 
			this.m_tbTextoRecebido.Location = new System.Drawing.Point(13, 128);
			this.m_tbTextoRecebido.Name = "m_tbTextoRecebido";
			this.m_tbTextoRecebido.Size = new System.Drawing.Size(224, 20);
			this.m_tbTextoRecebido.TabIndex = 2;
			this.m_tbTextoRecebido.Text = "";
			// 
			// m_lEnviar
			// 
			this.m_lEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_lEnviar.Location = new System.Drawing.Point(34, 8);
			this.m_lEnviar.Name = "m_lEnviar";
			this.m_lEnviar.Size = new System.Drawing.Size(183, 16);
			this.m_lEnviar.TabIndex = 3;
			this.m_lEnviar.Text = "Número do telefone a ser discado:";
			this.m_lEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_lRecebido
			// 
			this.m_lRecebido.Location = new System.Drawing.Point(25, 104);
			this.m_lRecebido.Name = "m_lRecebido";
			this.m_lRecebido.Size = new System.Drawing.Size(200, 16);
			this.m_lRecebido.TabIndex = 4;
			this.m_lRecebido.Text = "Texto Recebido";
			this.m_lRecebido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_btBina
			// 
			this.m_btBina.Location = new System.Drawing.Point(8, 72);
			this.m_btBina.Name = "m_btBina";
			this.m_btBina.Size = new System.Drawing.Size(40, 23);
			this.m_btBina.TabIndex = 5;
			this.m_btBina.Text = "Bina";
			this.m_btBina.Click += new System.EventHandler(this.m_btBina_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Location = new System.Drawing.Point(200, 72);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.Size = new System.Drawing.Size(40, 23);
			this.m_btCancelar.TabIndex = 6;
			this.m_btCancelar.Text = "Canc";
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 167);
			this.Controls.Add(this.m_btCancelar);
			this.Controls.Add(this.m_btBina);
			this.Controls.Add(this.m_lRecebido);
			this.Controls.Add(this.m_lEnviar);
			this.Controls.Add(this.m_tbTextoRecebido);
			this.Controls.Add(this.m_tbTextoASerEnviado);
			this.Controls.Add(this.m_btEnviar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Teste Comunicação Modem";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region MAIN
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		#endregion

		#region Eventos
		private void m_btEnviar_Click(object sender, System.EventArgs e)
		{
			m_tbTextoRecebido.Text = "";
			m_tbTextoRecebido.Text = m_clsModem.bRealizaLigacao(m_tbTextoASerEnviado.Text).ToString();
			//m_tbTextoRecebido.Text = m_clsModem.RESPOSTA;
		}
		private void Form1_Load(object sender, System.EventArgs e)
		{
			try
			{
				m_clsModem = new mdlModem.clsModem(ref m_cls_ter_tratamentoErro, m_strEnderecoExecutavel);
				m_clsModem.eCallIdenticadaChamada += new mdlModem.clsModem.delCallIdenticadaChamada(setaCampoRetorno);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratamentoErro.trataErro(ref erro);
			}
		}
		private void m_btBina_Click(object sender, System.EventArgs e)
		{
			bool teste = m_clsModem.bIdentificadorChamada();
		}
		#endregion

		private void setaCampoRetorno(string strNumeroChamador, string strNomeChamador)
		{
			m_tbTextoRecebido.Text = strNumeroChamador + " - " + strNomeChamador;
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (m_clsModem != null)
				m_clsModem.Dispose();
		}

		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			bool bRetorno = false;
			if (m_clsModem != null)
				bRetorno = m_clsModem.bCancelaLigação();

			MessageBox.Show("Ligação Cancelada: " + bRetorno.ToString(),this.Text);

		}
	}
}
