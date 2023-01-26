using DAL.Gestion;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Gestion
{
	public class clsGestionDepartamentosBL
	{
		private clsGestionDepartamentos dal;

		public clsGestionDepartamentosBL()
		{
			dal = new clsGestionDepartamentos();
		}

		/// <summary>
		/// 
		/// Método que se encarga de añadir la lógica de negocio al método 
		/// de la capa de acceso a datos "insertarDepartamento"
		/// Precondiciones: Ninguna
		/// Postcondiciones: Ninguna
		/// </summary>
		/// <param name="departamento"></param>
		/// <returns></returns>
		public static async Task<HttpResponseMessage> insertarDepartamentoBL(clsDepartamento departamento)
		{
			return await clsGestionDepartamentos.insertarDepartamento(departamento);
		}

		/// <summary>
		/// Método que se encarga de añadir la lógica de negocio al método 
		/// de la capa de acceso a datos "deletePersona"
		/// 
		/// Precondiciones: Ninguna
		/// Postcondiciones: Ninguna
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static async Task<HttpResponseMessage> deleteDepartamentoBL(int id)
		{
			return await clsGestionDepartamentos.deleteDepartamento(id);
		}

		/// <summary>
		/// Método que se encarga de añadir la lógica de negocio al método 
		/// de la capa de acceso a datos "editPersona"
		/// </summary>
		/// <param name="id"></param>
		/// Precondiciones: Ninguna
		/// Postcondiciones: Ninguna 
		/// <returns></returns>
		public bool editDepartamentoBL(clsDepartamento departamento, int id)
		{
			return dal.EditDepartamento(departamento, id);
		}



		public clsDepartamento getPersonaByIdBL(int id)
		{
			return dal.getDepartamentoById(id);
		}
	}
}
