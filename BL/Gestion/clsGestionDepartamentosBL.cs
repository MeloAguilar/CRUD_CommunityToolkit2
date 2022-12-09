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
		/// de la capa de acceso a datos "insertarPersona"
		/// Precondiciones: Ninguna
		/// Postcondiciones: Ninguna
		/// </summary>
		/// <param name="persona"></param>
		/// <returns></returns>
		public bool insertarDepartamentoBL(clsDepartamento persona)
		{
			return dal.insertarDepartamento(persona);
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
		public bool deletePersonaBL(int id)
		{
			return dal.deleteDepartamento(id);
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
			return dal.editDepartamento(departamento, id);
		}



		public clsDepartamento getPersonaByIdBL(int id)
		{
			return dal.getDepartamentoById(id);
		}
	}
}
