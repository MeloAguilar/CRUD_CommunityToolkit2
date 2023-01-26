using DAL.Conexion;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace DAL.Listados
{
	public class clsListadoPersonas
	{
		/// <summary>
		/// Método que se encarga de rellenar una lista de objetos tipo clsPersona
		/// a partir de una llamada a la base de datos.
		/// 
		/// Precondiciones: La Propiedad de la clase 
		/// Postcondiciones:
		/// </summary>
		/// <returns></returns>
		/// <summary>
		/// Método que se encarga de rellenar una lista de objetos tipo clsPersona
		/// a partir de una llamada a la base de datos.
		/// 
		/// </summary>
		/// <returns></returns>
		public static async Task<List<clsPersona>> getListadoCompletoPersonas()
		{

			string miCadenaUrl = clsUriBase.getUriBase();

			Uri miUri = new Uri($"{miCadenaUrl}personas");

			List<clsPersona> listadoPersonas = new List<clsPersona>();

			HttpClient mihttpClient;

			HttpResponseMessage miCodigoRespuesta;

			string textoJsonRespuesta;

			//Instanciamos el cliente Http

			
			try
			{

				mihttpClient = new HttpClient();

				textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);

				mihttpClient.Dispose();

				listadoPersonas = JsonConvert.DeserializeObject<List<clsPersona>>(textoJsonRespuesta);
			}
			catch (Exception e)
			{
				throw e;
			}

			return listadoPersonas;

		}


	}
}
