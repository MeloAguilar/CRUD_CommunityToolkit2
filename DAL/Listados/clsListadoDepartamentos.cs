using DAL.Conexion;
using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listados
{
	public class clsListadoDepartamentos
	{

		/// <summary>
		/// Función que se encarga de recoger un listado de objetos clsDepartamento de la base de datos
		/// introducida en la instancia del objeto clsMiConexion.
		/// 
		/// </summary>
		/// <returns></returns>
		public static async Task<List<clsDepartamento>> getListadoCompletoDepartamentos()
		{
			string miCadenaUrl = clsUriBase.getUriBase();

			Uri miUri = new Uri($"{miCadenaUrl}departamentos");

			List<clsDepartamento> lista = new List<clsDepartamento>();

			HttpClient mihttpClient;


			string textoJsonRespuesta;

			//Instanciamos el cliente Http

			
			try
			{
				mihttpClient = new HttpClient();

				textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);

				mihttpClient.Dispose();

				lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<clsDepartamento>>(textoJsonRespuesta);
			}
			catch (Exception e)
			{
				throw e;
			}

			return lista;

		}
	}
}
