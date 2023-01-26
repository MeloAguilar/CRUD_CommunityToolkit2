namespace DAL.Conexion
{
	public class clsUriBase
	{

		String UriBase { get; set; }

		public clsUriBase(String uriBase)
		{
			this.UriBase = uriBase;
		}

		public static String getUriBase()
		{
			return "https://apipersonaspaco.azurewebsites.net/api/";
		}
	}
}
