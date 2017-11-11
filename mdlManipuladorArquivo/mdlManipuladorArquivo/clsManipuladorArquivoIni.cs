using System;

namespace mdlManipuladorArquivo
{
	/// <summary>
	/// Summary description for clsManipuladorArquivoIni.
	/// </summary>
	public class clsManipuladorArquivoIni
	{
		#region Atributes
			string m_strPathArquivo;
		#endregion
		#region Constructors and Destructors
			public clsManipuladorArquivoIni(string strPathArquivo)
			{
				m_strPathArquivo = strPathArquivo;
			}
		#endregion

		#region Arquivo
			public bool bArquivoExiste()
			{
				return(System.IO.File.Exists(m_strPathArquivo));
			}

			public bool bArquivoValido()
			{
				bool bRetorno = false;
				if (System.IO.File.Exists(m_strPathArquivo))
				{
					System.Data.DataSet dtSetArquivoConfiguracao = new System.Data.DataSet();
					try
					{
						dtSetArquivoConfiguracao.ReadXml(m_strPathArquivo);
						bRetorno = true;
					}
					catch
					{ // Arquivo XML esta incorreto
						return(bRetorno);
					}
				}
				return (bRetorno);
			}

			public bool bCriaArquivo()
			{
				bool bRetorno = false;
				try
				{
					System.Data.DataSet dtSetArquivoConfiguracao = new System.Data.DataSet("Siscobras");
					if (System.IO.File.Exists(m_strPathArquivo))
					{
						System.IO.File.Delete(m_strPathArquivo);
					}
					dtSetArquivoConfiguracao.WriteXml(m_strPathArquivo);
					bRetorno = true;
				}catch{
				}
				return(bRetorno);
			}
		#endregion

		#region RetornaValor
			public string retornaValor(string strSessao, string strNomeVariavel)
			{
				return(strRetornaValor(strSessao,strNomeVariavel,""));
			}

			public string retornaValor(string strSessao, string strNomeVariavel, string strValorDefault)
			{
				return(strRetornaValor(strSessao,strNomeVariavel,strValorDefault));
			}

			public bool retornaValor(string strSessao, string strNomeVariavel, bool bValorDefault)
			{
				try
				{
					return(bool.Parse(strRetornaValor(strSessao,strNomeVariavel,bValorDefault.ToString())));
				}catch{
					return(bValorDefault);
				}
			}
 
			private string strRetornaValor(string strSessao, string strNomeVariavel, string strValorDefault)
			{
				string strRetorno = "";
				if (System.IO.File.Exists(m_strPathArquivo))
				{
                    System.Data.DataSet dtSetArquivoConfiguracao = new System.Data.DataSet();
					try
					{
						dtSetArquivoConfiguracao.ReadXml(m_strPathArquivo);
					}
					catch
					{ // Arquivo XML esta incorreto
						return(strValorDefault);
					}

					// Procurando a Sessao
					System.Data.DataTable dttbSessao = null;
					for (int nCont = 0; nCont < dtSetArquivoConfiguracao.Tables.Count;nCont++)
					{
						if (dtSetArquivoConfiguracao.Tables[nCont].TableName == strSessao)
						{
							dttbSessao = dtSetArquivoConfiguracao.Tables[nCont];
						}
					}
					// Sessao nao existe , criando ela 
					if (dttbSessao == null)
					{
						dttbSessao = dtSetArquivoConfiguracao.Tables.Add(strSessao);
					}

					// Procurando a Variavel
					bool bAchouVariavel = false;
					for (int nCont = 0; nCont < dttbSessao.Columns.Count;nCont++)
					{
						if (dttbSessao.Columns[nCont].ColumnName == strNomeVariavel)
						{
							bAchouVariavel = true;
							if (dttbSessao.Rows.Count == 0)
							{
								System.Data.DataRow dtrwSessao = dttbSessao.NewRow();
								dttbSessao.Rows.Add(dtrwSessao);
							}
							strRetorno = dttbSessao.Rows[0][dttbSessao.Columns[nCont].ColumnName].ToString();
							if (strRetorno == "")
							{
								strRetorno = strValorDefault;
								dttbSessao.Rows[0][dttbSessao.Columns[nCont].ColumnName] = strRetorno;
							}
						}
					}
					// Variavel nao existe, criando ela 
					if (!bAchouVariavel)
					{
						dttbSessao.Columns.Add(strNomeVariavel);
						if (dttbSessao.Rows.Count == 0)
						{
							System.Data.DataRow dtrwSessao = dttbSessao.NewRow();
							dttbSessao.Rows.Add(dtrwSessao);
						}
						strRetorno = dttbSessao.Rows[0][strNomeVariavel].ToString();
						if (strRetorno == "")
						{
							strRetorno = strValorDefault;
							dttbSessao.Rows[0][strNomeVariavel] = strRetorno;
						}
  					}

					// Salvando o Arquivo XML
					try
					{
						dtSetArquivoConfiguracao.WriteXml(m_strPathArquivo);
					}catch{

					}
				}
				return (strRetorno);
			} 
		#endregion
		#region ColocaValor
			public bool colocaValor(string strSessao, string strNomeVariavel, string strValor)
			{
				bool bRetorno = false;
				if (System.IO.File.Exists(m_strPathArquivo))
				{
					System.Data.DataSet dtSetArquivoConfiguracao = new System.Data.DataSet();
					try
					{
						dtSetArquivoConfiguracao.ReadXml(m_strPathArquivo);
					}
					catch
					{ // Arquivo XML esta incorreto
					}

					// Procurando a Sessao
					System.Data.DataTable dttbSessao = null;
					for (int nCont = 0; nCont < dtSetArquivoConfiguracao.Tables.Count;nCont++)
					{
						if (dtSetArquivoConfiguracao.Tables[nCont].TableName == strSessao)
						{
							dttbSessao = dtSetArquivoConfiguracao.Tables[nCont];
						}
					}
					// Sessao nao existe , criando ela 
					if (dttbSessao == null)
					{
						dttbSessao = dtSetArquivoConfiguracao.Tables.Add(strSessao);
					}

					// Procurando a Variavel
					bool bAchouVariavel = false;
					for (int nCont = 0; nCont < dttbSessao.Columns.Count;nCont++)
					{
						if (dttbSessao.Columns[nCont].ColumnName == strNomeVariavel)
						{
							bAchouVariavel = true;
							if (dttbSessao.Rows.Count == 0)
							{
								System.Data.DataRow dtrwSessao = dttbSessao.NewRow();
								dttbSessao.Rows.Add(dtrwSessao);
							}
							dttbSessao.Rows[0][dttbSessao.Columns[nCont].ColumnName] = strValor;
							bRetorno = true;
						}
					}
					// Variavel nao existe, criando ela 
					if (!bAchouVariavel)
					{
						dttbSessao.Columns.Add(strNomeVariavel);
						if (dttbSessao.Rows.Count == 0)
						{
							System.Data.DataRow dtrwSessao = dttbSessao.NewRow();
							dttbSessao.Rows.Add(dtrwSessao);
						}
						dttbSessao.Rows[0][strNomeVariavel] = strValor;
						bRetorno = true;
					}

					// Salvando o Arquivo XML
					try
					{
						dtSetArquivoConfiguracao.WriteXml(m_strPathArquivo);
					}
					catch
					{
						bRetorno = false;
					}
				}
				return(bRetorno);
			} 
		#endregion

	}
}
