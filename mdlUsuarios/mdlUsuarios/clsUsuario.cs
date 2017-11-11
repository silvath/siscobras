using System;

namespace mdlUsuarios
{
	/// <summary>
	/// Summary description for clsUsuario.
	/// </summary>
	public class clsUsuario
	{
		#region Atributos
			private static clsUsuario m_cls_Usuario = null;
			
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
			protected string m_strEnderecoExecutavel;

			private int m_nIdUsuario = -1;
			private string m_strSenha = "";
			private string m_strUsuario = "";
			private int m_nPrevilegioUsuario = -1;

			private clsUsuarioConcessoesPermissoes m_clsUsuarioConcessoesPermissoes = null;

			private string m_strSenhaCifrada = "";

			private bool m_bSenhaConfere = false;

			public bool m_bModificadoCadastro = false;
			public bool m_bModificadoLogin = false;

			private bool m_bCadastrarAdministrador = false;

			private Frames.frmFLoginUsuarios m_formFLoginUsuarios = null;
			private Frames.frmFCadastroUsuario m_formFCadastroUsuario = null;

			private mdlDataBaseAccess.Tabelas.XsdTbUsuarios m_typDatSetTbUsuarios = null;
		#endregion
		#region Propriedades
			public int IdUsuario
			{
				get
				{
					return(m_nIdUsuario);
				}
			}
			public string Usuario
			{
				get
				{
					return(m_strUsuario);
				}
			}
		#endregion
		#region Construtores & Destrutores
			public static clsUsuario New()
			{
				return(m_cls_Usuario);
			}

			public static clsUsuario New(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel) 
			{
				if (m_cls_Usuario == null)
					m_cls_Usuario = new clsUsuario(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel);
				return(m_cls_Usuario);
			}

			private clsUsuario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionBD = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel;
				carregaTypDatSet();
			}
		#endregion

		#region InitializeEventsFormLoginUsuarios
		private void InitializeEventsFormLoginUsuarios()
		{
			// Salva Dados Interface
			m_formFLoginUsuarios.eCallSalvaDadosInterface += new Frames.frmFLoginUsuarios.delCallSalvaDadosInterface(salvaDadosInterface);
		}
		#endregion

		#region ShowDialogLogin
		public void ShowDialogLogin()
		{
			try
			{
				if (m_bCadastrarAdministrador == false)
				{
					m_formFLoginUsuarios = new Frames.frmFLoginUsuarios(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
					InitializeEventsFormLoginUsuarios();
					m_formFLoginUsuarios.ShowDialog();
					m_formFLoginUsuarios = null;
					if (m_bModificadoLogin)
					{
						m_clsUsuarioConcessoesPermissoes = clsUsuarioConcessoesPermissoes.Instance;
						m_clsUsuarioConcessoesPermissoes.nIdUsuario = m_nIdUsuario;
						m_clsUsuarioConcessoesPermissoes.clsDataBaseAccess = m_cls_dba_ConnectionBD;
						m_clsUsuarioConcessoesPermissoes.clsTratamentoErro = m_cls_ter_tratadorErro;
						m_clsUsuarioConcessoesPermissoes.EnderecoExecutavel = m_strEnderecoExecutavel;
					}
				}
				else
				{
					ShowDialogCadastro();
					if (m_bModificadoCadastro)
					{
						m_bModificadoLogin = true;
						m_clsUsuarioConcessoesPermissoes = clsUsuarioConcessoesPermissoes.Instance;
						m_clsUsuarioConcessoesPermissoes.nIdUsuario = m_nIdUsuario;
						m_clsUsuarioConcessoesPermissoes.clsDataBaseAccess = m_cls_dba_ConnectionBD;
						m_clsUsuarioConcessoesPermissoes.clsTratamentoErro = m_cls_ter_tratadorErro;
						m_clsUsuarioConcessoesPermissoes.EnderecoExecutavel = m_strEnderecoExecutavel;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
			}
		}
		#endregion

		#region InitializeEventsFormCadastroUsuario
		private void InitializeEventsFormCadastroUsuario()
		{
			// Salva Dados Interface
			m_formFCadastroUsuario.eCallSalvaDadosInterface += new Frames.frmFCadastroUsuario.delCallSalvaDadosInterface(salvaDadosInterfaceCadastro);

			// Salva Dados BD
			m_formFCadastroUsuario.eCallSalvaDadosBD += new Frames.frmFCadastroUsuario.delCallSalvaDadosBD(salvaDadosBDCadastro);
		}
		#endregion

		#region Show Dialog Cadastro
		public void ShowDialogCadastro()
		{
			try
			{
				m_formFCadastroUsuario = new Frames.frmFCadastroUsuario(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_bCadastrarAdministrador);
				InitializeEventsFormCadastroUsuario();
				m_formFCadastroUsuario.ShowDialog();
				m_formFCadastroUsuario = null;
			}
			catch (Exception err)
			{
				Object erro = err;
			}
		}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		private bool carregaDadosBD()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbUsuarios.tbUsuariosRow dtrwTbUsuarios;
				for (int nCount = 0; nCount < m_typDatSetTbUsuarios.tbUsuarios.Rows.Count; nCount++)
				{
					dtrwTbUsuarios = (mdlDataBaseAccess.Tabelas.XsdTbUsuarios.tbUsuariosRow)m_typDatSetTbUsuarios.tbUsuarios.Rows[nCount];
					if (dtrwTbUsuarios.strNome == m_strUsuario)
					{
						m_nIdUsuario = dtrwTbUsuarios.nIdUsuario;
						if (!dtrwTbUsuarios.IsstrSenhaNull())
                            m_strSenhaCifrada = dtrwTbUsuarios.strSenha;
						m_strSenha = mdlCriptografia.clsCriptografia.strDecifraString(m_strSenhaCifrada);
						return true;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
		}
		private void carregaTypDatSet()
		{
			try
			{
				m_typDatSetTbUsuarios = m_cls_dba_ConnectionBD.GetTbUsuarios(null,null,null,null,null);
				if (m_typDatSetTbUsuarios.tbUsuarios.Rows.Count == 0)
					m_bCadastrarAdministrador = true;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Salvamento dos Dados
		#region Interface
		private bool salvaDadosInterface(ref mdlComponentesGraficos.TextBox tbUsuario, ref mdlComponentesGraficos.TextBox tbSenha)
		{
			try
			{
				m_strUsuario = tbUsuario.Text.ToUpper();
				if (carregaDadosBD())
				{
					if (tbSenha.Text == m_strSenha)
					{
						m_bModificadoLogin = true;
						return true;
					}
					else
					{
						m_bModificadoLogin = false;
						return false;
					}
				}
				else
				{
					m_bModificadoLogin = false;
					return false;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			m_bModificadoLogin = false;
			return false;
		}
		#endregion
		#region Banco de Dados
		private void salvaDadosBD()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbUsuarios.tbUsuariosRow dtrwTbUsuarios = m_typDatSetTbUsuarios.tbUsuarios.NewtbUsuariosRow();
				dtrwTbUsuarios.nIdUsuario = m_nIdUsuario;
				dtrwTbUsuarios.strNome = m_strUsuario;
				dtrwTbUsuarios.strSenha = m_strSenhaCifrada;
				m_typDatSetTbUsuarios.tbUsuarios.AddtbUsuariosRow(dtrwTbUsuarios);
				m_cls_dba_ConnectionBD.SetTbUsuarios(m_typDatSetTbUsuarios);
				m_clsUsuarioConcessoesPermissoes = clsUsuarioConcessoesPermissoes.Instance;
				m_clsUsuarioConcessoesPermissoes.m_bPrecisaRecarregarDatSets = m_bModificadoCadastro;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Cadastro
		#region Salvamento de Dados
		private bool salvaDadosInterfaceCadastro(ref mdlComponentesGraficos.TextBox tbUsuario, ref mdlComponentesGraficos.TextBox tbSenha)
		{
			try
			{
				m_strUsuario = tbUsuario.Text.ToUpper();
				if (!carregaDadosBD())
				{
					m_strSenha = tbSenha.Text;
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
		}
		private int retornaIdLivreUsuario()
		{
			int nIdUsuario = 1;
			try
			{
				while (m_typDatSetTbUsuarios.tbUsuarios.FindBynIdUsuario(nIdUsuario) != null)
					nIdUsuario++;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return nIdUsuario;
		}
		private void salvaDadosBDCadastro(bool bModificado)
		{
			try
			{
				m_bModificadoCadastro = bModificado;
				m_nIdUsuario = retornaIdLivreUsuario();
				m_strSenhaCifrada = mdlCriptografia.clsCriptografia.strCifraString(m_strSenha);
				salvaDadosBD();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Retorna Valores
		public void retornaValoresLogin(out int nIdUsuario, out string strNomeUsuario)
		{
			nIdUsuario = m_nIdUsuario;
			strNomeUsuario = m_strUsuario;
		}
		#endregion
	}
}
