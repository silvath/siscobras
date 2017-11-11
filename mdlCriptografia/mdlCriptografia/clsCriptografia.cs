using System;

namespace mdlCriptografia
{
	/// <summary>
	/// Summary description for clsCriptografia.
	/// </summary>
	public sealed class clsCriptografia
	{
		#region Exceção Estática
		private static System.Exception m_errException = null;
		public static System.Exception EXCECAO
		{
			get
			{
				return m_errException;
			}
		}
		#endregion
		#region Cifra String
		public static string strCifraString(string strTextoASerCifrado)
		{
			string strRetorno = "";
			try
			{
				byte[] byTextoASerCifrado;
				byte[] byKey = new byte[] {255,241,3,17,206,69,56,167,94,220,219,76,112,179,12,97,178,233,14,172,238,20,54,232,212,54,50,151,138,32,26,122};
				byte[] byIV = new byte[] {207,100,146,104,139,60,94,109,109,195,236,213,235,234,233,114};
				System.Text.UnicodeEncoding conversorTexto = new System.Text.UnicodeEncoding();
				System.Security.Cryptography.RijndaelManaged clsSecCrypRijndael = new System.Security.Cryptography.RijndaelManaged();
				clsSecCrypRijndael.Padding = System.Security.Cryptography.PaddingMode.Zeros;

				//Get an encryptor.
				System.Security.Cryptography.ICryptoTransform cifrador = clsSecCrypRijndael.CreateEncryptor(byKey, byIV);

				// Cria os Streams
				System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
				System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, cifrador, System.Security.Cryptography.CryptoStreamMode.Write);

				// Cria o Array para cifrar os dados
				byTextoASerCifrado = conversorTexto.GetBytes(strTextoASerCifrado);
				
				// Write all data to the crypto stream and flush it.
				cryptoStream.Write(byTextoASerCifrado, 0, byTextoASerCifrado.Length);//byTextoASerCifrado, 0, byTextoASerCifrado.Length);
				cryptoStream.FlushFinalBlock();

				byte[] byTemporario = memoryStream.ToArray();

				strRetorno = strRetornaDadosEmBase64(byTemporario);
			}
			catch (Exception err)
            {
				m_errException = err;
				return strRetorno;
			}
			return strRetorno;
		}
		#endregion
		#region Decifra String
		public static string strDecifraString(string strTextoASerDecifrado)
		{
			string strRetorno = "";
			try
			{
				byte[] byTextoASerDeCifrado, byTextoDeCifrado;
				byte[] byKey = new byte[] {255,241,3,17,206,69,56,167,94,220,219,76,112,179,12,97,178,233,14,172,238,20,54,232,212,54,50,151,138,32,26,122};
				byte[] byIV = new byte[] {207,100,146,104,139,60,94,109,109,195,236,213,235,234,233,114};
				System.Text.UnicodeEncoding conversorTexto = new System.Text.UnicodeEncoding();
				System.Security.Cryptography.RijndaelManaged clsSecCrypRijndael = new System.Security.Cryptography.RijndaelManaged();
				clsSecCrypRijndael.Padding = System.Security.Cryptography.PaddingMode.Zeros;

				//Get an encryptor.
				System.Security.Cryptography.ICryptoTransform decifrador = clsSecCrypRijndael.CreateDecryptor(byKey, byIV);

				byTextoASerDeCifrado = System.Convert.FromBase64String(strTextoASerDecifrado);

				// Cria os Streams
				System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(byTextoASerDeCifrado);
				System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, decifrador, System.Security.Cryptography.CryptoStreamMode.Read);

				byTextoDeCifrado = new byte[byTextoASerDeCifrado.Length];

				// Read all data to the crypto stream and flush it.
				cryptoStream.Read(byTextoDeCifrado, 0, byTextoDeCifrado.Length);

				strRetorno = conversorTexto.GetString(byTextoDeCifrado).Replace("\0","");
			}
			catch (Exception err)
			{
				m_errException = err;
				return strRetorno;
			}
			return strRetorno;
		}
		#endregion
		#region Converte Dados para String em Base 64
		private static string strRetornaDadosEmBase64(byte[] byDados)
		{
			try
			{
				// Convertendo
				int arrLenght = 4 * byDados.Length;
				arrLenght /= 3;
				if ((arrLenght % 4) != 0)
					arrLenght += 4 - arrLenght % 4;

				char[] base64CharArray = new char[arrLenght];
				System.Convert.ToBase64CharArray(byDados, 0, byDados.Length, base64CharArray, 0);
				return (new String(base64CharArray));
			}
			catch (Exception err)
			{
				return("");
			}
		}
		#endregion
	}
}
