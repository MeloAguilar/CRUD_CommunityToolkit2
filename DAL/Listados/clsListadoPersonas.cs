using DAL.Conexion;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL.Listados
{
	public class clsListadoPersonas
	{
		clsMiConexion miConexion;

		List<clsPersona> lista = new();

		public clsListadoPersonas()
		{
			miConexion = new clsMiConexion();
		}
		/// <summary>
		/// Método que se encarga de rellenar una lista de objetos tipo clsPersona
		/// a partir de una llamada a la base de datos.
		/// 
		/// </summary>
		/// <returns></returns>
		public List<clsPersona> getListadoCompletoPersonas() {

			if (lista?.Count > 0)
				return lista;

			SqlConnection cnn = null;
			try
			{
				cnn = miConexion.getConnection();
				SqlCommand cmd = new SqlCommand();
				SqlDataReader miLector;

				cmd.CommandText = "Select * From Personas";

				cmd.Connection = cnn;
				miLector = cmd.ExecuteReader();
				if (miLector.HasRows)
				{

					while (miLector.Read())
					{
						lista.Add(new clsPersona(miLector.GetInt32(0), miLector.GetString(1), miLector.GetString(2), miLector.GetString(3), miLector.GetString(4), miLector.GetString(5), miLector.GetDateTime(6), miLector.GetInt32(7)));

					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (cnn!=null)
				{
					miConexion.closeConnection(ref cnn);
				}
			}



			return lista;

		}


	}
}
