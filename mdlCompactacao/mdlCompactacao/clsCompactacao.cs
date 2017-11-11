using System;

namespace mdlCompactacao
{
	public class clsCompactacao
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;

		private int m_nNivelCompressao = (int)NIVELCOMPACTACAO.MAXIMO;
		#endregion
		#region Construtores & Destrutores
		public clsCompactacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro)
		{
			m_cls_ter_tratadorErro = tratadorErro;
		}
		#endregion

		#region Compactação
		/// <summary>
		/// Compacta a lista de Arquivos criando o arquivo zip passado como parâmetro
		/// </summary>
		/// <param name="filesName">Lista de arquivos a serem incluidos no .zip</param>
		/// <param name="strArquivoZip">Nome do arquivo .zip</param>
		public void compacta(ref System.Collections.ArrayList filesName, string strArquivoZip)
		{
			try
			{
				ICSharpCode.SharpZipLib.Checksums.Crc32 clsCrc = new ICSharpCode.SharpZipLib.Checksums.Crc32();
				ICSharpCode.SharpZipLib.Zip.ZipOutputStream clsZipOutStream = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(System.IO.File.Create(strArquivoZip));
		
				clsZipOutStream.SetLevel(m_nNivelCompressao);
		
				foreach (string file in filesName) 
				{
					System.IO.FileStream fs = System.IO.File.OpenRead(file);
			
					byte[] buffer = new byte[fs.Length];
					fs.Read(buffer, 0, buffer.Length);
					ICSharpCode.SharpZipLib.Zip.ZipEntry entry = new ICSharpCode.SharpZipLib.Zip.ZipEntry(file);
			
					entry.DateTime = DateTime.Now;
			
					entry.Size = fs.Length;
					fs.Close();
			
					clsCrc.Reset();
					clsCrc.Update(buffer);
			
					entry.Crc  = clsCrc.Value;
			
					clsZipOutStream.PutNextEntry(entry);
			
					clsZipOutStream.Write(buffer, 0, buffer.Length);
			
				}		
				clsZipOutStream.Finish();
				clsZipOutStream.Close();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		/// <summary>
		/// Compacta a lista de Arquivos criando o arquivo zip passado como parâmetro
		/// </summary>
		/// <param name="filesName">Lista de arquivos a serem incluidos no .zip</param>
		/// <param name="strArquivoZip">Nome do arquivo .zip</param>
		/// <param name="nNivelCompressao">Nível de compressão. Mín: NIVELCOMPACTACAO.MINIMO - Máx: NIVELCOMPACTACAO.MAXIMO</param>
		public void compacta(ref System.Collections.ArrayList filesName, string strArquivoZip, NIVELCOMPACTACAO enumNivelCompactacao)
		{
			m_nNivelCompressao = (int)enumNivelCompactacao;
			compacta(ref filesName, strArquivoZip);
		}
		#endregion

		#region Descompactação
		public void descompacta(string strNomeArquivoZip)
		{
			try
			{
				ICSharpCode.SharpZipLib.Zip.ZipInputStream clsZipInStream = new ICSharpCode.SharpZipLib.Zip.ZipInputStream(System.IO.File.OpenRead(strNomeArquivoZip));
	
				ICSharpCode.SharpZipLib.Zip.ZipEntry theEntry;
				while ((theEntry = clsZipInStream.GetNextEntry()) != null) 
				{
					if (theEntry.Size > 0)
					{
						byte[] conteudoArquivo = new byte[theEntry.Size];
						int bytesReaded, posInFile = 0;
						long fileSize = theEntry.Size;

						do 
						{
							bytesReaded = clsZipInStream.Read (conteudoArquivo, posInFile, (int) fileSize);
							posInFile += bytesReaded;
							fileSize -= bytesReaded;
						} while (fileSize > 0 || bytesReaded == 0);

						if (bytesReaded > 0) 
						{
							System.IO.FileStream fsOutFile = new System.IO.FileStream (theEntry.Name, System.IO.FileMode.Create, System.IO.FileAccess.Write);
							System.IO.BinaryWriter bwOutFile = new System.IO.BinaryWriter (fsOutFile);
							bwOutFile.Write (conteudoArquivo);
							bwOutFile.Flush();
							bwOutFile.Close();
							fsOutFile.Close();
						}

						conteudoArquivo = null;
					}
				}
				clsZipInStream.Close();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retorna Lista de Arquivos
		public string[] retornaListaDeArquivos(string strNomeArquivoZip)
		{
			string[] strArrayRetorno = new string[0];
			try
			{
				ICSharpCode.SharpZipLib.Zip.ZipInputStream clsZipInStream = new ICSharpCode.SharpZipLib.Zip.ZipInputStream(System.IO.File.OpenRead(strNomeArquivoZip));

				int nCount = 0;
				System.Collections.ArrayList arlArquivos = new System.Collections.ArrayList();
				ICSharpCode.SharpZipLib.Zip.ZipEntry theEntry;
				while ((theEntry = clsZipInStream.GetNextEntry()) != null) 
				{
					arlArquivos.Add(theEntry.Name);
					nCount++;
				}
				clsZipInStream.Close();
				strArrayRetorno = new string[nCount];
				int nIndice = 0;
				foreach (string strFile in arlArquivos)
				{
                    strArrayRetorno[nIndice] = strFile;
					nIndice++;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return strArrayRetorno;
		}
		#endregion
	}
}
