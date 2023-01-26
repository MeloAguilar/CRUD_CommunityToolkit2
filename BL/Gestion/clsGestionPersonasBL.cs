using DAL.Gestion;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL.Gestion
{
	public class clsGestionPersonasBL
	{
		private clsGestionPersonas dal;

		public clsGestionPersonasBL()
		{
			dal = new clsGestionPersonas();
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
		public async Task<HttpStatusCode> insertarPersonaBL(clsPersona persona)
		{
			return await clsGestionPersonas.insertarPersona(persona);
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
		public async Task<HttpResponseMessage> deletePersonaBL(int id)
		{
			return await clsGestionPersonas.deletePersona(id);
		}

		/// <summary>
		/// Método que se encarga de añadir la lógica de negocio al método 
		/// de la capa de acceso a datos "editPersona"
		/// </summary>
		/// <param name="id"></param>
		/// Precondiciones: Ninguna
		/// Postcondiciones: Ninguna 
		/// <returns></returns>
		public bool editPersonaBL(clsPersona persona, int id)
		{
			return dal.editPersona(persona,id);
		}



		public clsPersona getPersonaByIdBL(int id)
		{
			return dal.getPersonaById(id);
		}
	}
}
