using System;

namespace mdlControladoraWindowsServices
{
	/// <summary>
	/// Summary description for clsManagerWindowsService.
	/// </summary>
	public class clsManagerWindowsService
	{
		#region Static
			public static bool bWindowsServiceSupport()
			{
				try
				{
					System.ServiceProcess.ServiceController[] scWindowsServices = System.ServiceProcess.ServiceController.GetServices(System.Environment.MachineName);
					return(true);
				}catch{
					return(false);
				}
			}

			public static bool bServiceRunning(string strServiceName)
			{
				System.ServiceProcess.ServiceController objServiceController = scServiceController(strServiceName);
				if (objServiceController == null)
					return(false);
				switch(objServiceController.Status)
				{
					case System.ServiceProcess.ServiceControllerStatus.Stopped:
						return(false);
					default:
						return(true);
				}
			}

			private static System.ServiceProcess.ServiceController scServiceController(string strServiceName)
			{
				try
				{
					System.ServiceProcess.ServiceController[] scWindowsServices = System.ServiceProcess.ServiceController.GetServices(System.Environment.MachineName);
					foreach(System.ServiceProcess.ServiceController scCurrentService in scWindowsServices)
					{
						if (scCurrentService.ServiceName == strServiceName)
							return(scCurrentService);
					}
					return(null);
				}
				catch
				{
					return(null);
				}
			}
		#endregion
	}
}
