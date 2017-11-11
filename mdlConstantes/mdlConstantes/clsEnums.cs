using System;

namespace mdlConstantes
{
	public enum Relatorio
	{
		Indefinido = 0,
		FaturaCotacao = 1,
		FaturaProforma = 2,
		FaturaComercial = 3,
		CertificadoOrigemMercosul = 4,
		CertificadoOrigemMercosulBO = 5,
		CertificadoOrigemMercosulCH = 6,
		CertificadoOrigemAladiAptr04 = 7,
		CertificadoOrigemAladiAce39 = 8,
		CertificadoOrigemAnexoIII = 9,
		CertificadoOrigemComum = 10,
		Romaneio = 11,
		Bordero = 12,
		Saque = 14,
		InstrucaoEmbarque = 15,
		Sumario = 21,
		RelatorioIndefinido = 23,
		BorderoSecundario = 24,
		RomaneioVolumes = 25,
		RomaneioSimplificado = 26,
		Reserva = 27,
		GuiaEntrada = 28,
		CertificadoOrigemAladiAce59 = 29,
		CertificadoOrigemFormA = 30
	}

	public enum CertificadoOrigem
	{
		Mercosul = 1,
		MercosulBolivia = 2,
		MercosulChile = 3,
		AladiAptr04 = 4,
		AladiAce39 = 5,
		AnexoIII = 6,	
		Comum = 7,
		Aladi59 = 29,
		FormA = 30
	}

	public enum Idioma
	{
		Portugues = 1,
		Espanhol = 2,
		Ingles = 3,
		Alemao = 4,
		Frances = 5,
		Italiano = 6,
		Arabe = 7,
		Russo = 8,
		Polones = 9,
		ChinesSimplificado = 10,
		Esperanto = 11,
		Japones = 12,
		Turco = 13,
		Holandes = 14,
		Grego = 15,
		Hebraico = 16,
		Coreano = 17
	}

	public enum Incoterm
	{
		EXW = 1,
		FCA = 2,
		FAS = 3,
		FOB = 4,
		CFR = 5,
		CIF = 6,
		CPT = 7,
		CIP = 8,
		DAF = 9,
		DES = 10,
		DEQ = 11,
		DDU = 12,
		DDP = 13
	}

	public enum UnidadeMedida
	{
		Milimetro = 1,
		Centimetro = 2,
		Decimetro = 3,
		Metro = 4,
		Kilometro = 5
	}
		
	public enum UnidadeMassa
	{
		Miligrama = 1,
		Grama = 2,	
		Kilograma = 3, 
		Tonelada = 4,
		Libra = 5
	}

	public enum SiscoMensagemInit
	{
		Never = 1,
		Siscobras = 2,
		ComputerStartup = 3
	}

	public enum SiscoMensagemState
	{
		Unknown = 300,
		Running = 301,
		Paused = 302,
		Stoped = 303
	}
}
