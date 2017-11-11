//using System;
//using NUnit.Framework;
//
//namespace mdlValidacaoTeste
//{
//	/// <summary>
//	/// Summary description for clsModuloOnzeTeste.
//	/// </summary>
//	[TestFixture] 
//	public class clsModuloOnzeTeste
//	{
//		[Test]
//		public void vTestModula11()
//		{
//			// Modula Valido
//			if (!mdlValidacao.clsModuloOnze.bCheckModula11("0298349698",false))
//			{
//				throw(new System.Exception("Modula 11 Ivalido"));
//			}
//			if (!mdlValidacao.clsModuloOnze.bCheckModula11("02983496988",false))
//			{
//				throw(new System.Exception("Modula 11 Ivalido"));
//			}
//
//			// CPF Invalidos
//			if (mdlValidacao.clsModuloOnze.bCheckModula11("0298349697",false))
//			{
//				throw(new System.Exception("Modula 11 Ivalido"));
//			}
//			if (mdlValidacao.clsModuloOnze.bCheckModula11("02983496987",false))
//			{
//				throw(new System.Exception("Modula 11 Ivalido"));
//			}
//		}
//	}
//}
