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

		private clsMiConexion miConexion;

		public clsListadoDepartamentos()
		{
			miConexion = new clsMiConexion();
		}

		public clsListadoDepartamentos(string server, string name, string pass, string user)
		{
			miConexion = new clsMiConexion(server, name, user, pass);
		}


		/// <summary>
		/// Función que se encarga de recoger un listado de objetos clsDepartamento de la base de datos
		/// introducida en la instancia del objeto clsMiConexion.
		/// 
		/// </summary>
		/// <returns></returns>
		public List<clsDepartamento> getListadoCompletoDepartamentos()
		{
			SqlConnection cnn = null;
			List<clsDepartamento> lista = new List<clsDepartamento>();

			try
			{
				cnn = miConexion.getConnection();
				SqlCommand cmd = cnn.CreateCommand();
				SqlDataReader miLector;
				cmd.Connection = cnn;

				cmd.CommandText = "Select * From departamentos";
				miLector = cmd.ExecuteReader();
				while (miLector.Read())
				{
					if (miLector.HasRows)
					{
						clsDepartamento departamento = new clsDepartamento();
						departamento.Id = miLector.GetInt32(0);
						departamento.Nombre = miLector.GetString(1);
						lista.Add(departamento);
					}
				}
			}catch(Exception e)
			{
				throw e;
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
