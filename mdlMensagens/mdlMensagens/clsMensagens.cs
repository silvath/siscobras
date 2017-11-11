using System;

namespace mdlMensagens
{
	public class clsMensagens
	{
		#region Atributos
		static frmFMessage m_frmFMessage = null;
		#endregion
		#region Constructor
		static clsMensagens()
		{
			m_frmFMessage = new frmFMessage();
		}
		#endregion

		#region Show
		static public System.Windows.Forms.DialogResult Show (string strTexto) 
		{
			return Show ("Siscobras", strTexto);
		}

		static public System.Windows.Forms.DialogResult ShowError (string strTexto) 
		{
			return ShowError ("Siscobras", strTexto);
		}

		static public System.Windows.Forms.DialogResult ShowExclamation (string strTexto) 
		{
			return ShowExclamation ("Siscobras", strTexto);
		}

		static public System.Windows.Forms.DialogResult ShowInformation (string strTexto) 
		{
			return ShowInformation ("Siscobras", strTexto);
		}

		static public System.Windows.Forms.DialogResult ShowQuestion (string strTexto) 
		{
			return ShowQuestion ("Siscobras", strTexto);
		}

		static public System.Windows.Forms.DialogResult Show (string strTitulo, string strTexto) 
		{
			return m_frmFMessage.Show (strTitulo, strTexto, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
		}

		static public System.Windows.Forms.DialogResult ShowError (string strTitulo, string strTexto) 
		{
			return ShowError (strTitulo, strTexto, System.Windows.Forms.MessageBoxButtons.OK);
		}

		static public System.Windows.Forms.DialogResult ShowExclamation (string strTitulo, string strTexto) 
		{
			return ShowExclamation (strTitulo, strTexto, System.Windows.Forms.MessageBoxButtons.OK);
		}

		static public System.Windows.Forms.DialogResult ShowInformation (string strTitulo, string strTexto) 
		{
			return ShowInformation (strTitulo, strTexto, System.Windows.Forms.MessageBoxButtons.OK);
		}

		static public System.Windows.Forms.DialogResult ShowQuestion (string strTitulo, string strTexto) 
		{
			return ShowQuestion (strTitulo, strTexto, System.Windows.Forms.MessageBoxButtons.YesNo);
		}

		static public System.Windows.Forms.DialogResult Show (string strTitulo, string strTexto, System.Windows.Forms.MessageBoxButtons Buttons) 
		{
			return m_frmFMessage.Show (strTitulo, strTexto, Buttons, System.Windows.Forms.MessageBoxIcon.None);
		}

		static public System.Windows.Forms.DialogResult ShowError (string strTitulo, string strTexto, System.Windows.Forms.MessageBoxButtons Buttons) 
		{
			return m_frmFMessage.Show (strTitulo, strTexto, Buttons, System.Windows.Forms.MessageBoxIcon.Error);
		}

		static public System.Windows.Forms.DialogResult ShowExclamation (string strTitulo, string strTexto, System.Windows.Forms.MessageBoxButtons Buttons) 
		{
			return m_frmFMessage.Show (strTitulo, strTexto, Buttons, System.Windows.Forms.MessageBoxIcon.Exclamation);
		}

		static public System.Windows.Forms.DialogResult ShowInformation (string strTitulo, string strTexto, System.Windows.Forms.MessageBoxButtons Buttons) 
		{
			return m_frmFMessage.Show (strTitulo, strTexto, Buttons, System.Windows.Forms.MessageBoxIcon.Information);
		}

		static public System.Windows.Forms.DialogResult ShowQuestion (string strTitulo, string strTexto, System.Windows.Forms.MessageBoxButtons Buttons)
		{
			return m_frmFMessage.Show (strTitulo, strTexto, Buttons, System.Windows.Forms.MessageBoxIcon.Question);
		}

		static public System.Windows.Forms.DialogResult Show (string strTitulo, string strTexto, System.Windows.Forms.MessageBoxButtons Buttons, System.Windows.Forms.MessageBoxIcon Icon) 
		{
			return m_frmFMessage.Show (strTitulo, strTexto, Buttons, Icon);
		}
		#endregion
	}
}
