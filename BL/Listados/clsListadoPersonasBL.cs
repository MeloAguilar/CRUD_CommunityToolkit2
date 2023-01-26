using DAL.Listados;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Listados
{
	public class clsListadoPersonasBL
	{
		clsListadoPersonas dal;

		public clsListadoPersonasBL()
		{
			dal = new();
		}


		/// <summary>
		/// 
		/// Método que se encarga de añadir la lógica de negocio al método 
		/// de la capa de acceso a datos "getListadoPersonas".
		/// 
		/// En este caso se convierte la lista que viene de la capa DAL a una ObservableCollection de objetos clsPersona.
		/// 
		/// Precondiciones: Ninguna
		/// Postcondiciones: Ninguna
		/// </summary>
		/// <param name="persona"></param>
		/// <returns></returns>
		public async static Task<ObservableCollection<clsPersona>> getListadoCompletoPersonasBL()
		{
			return new ObservableCollection<clsPersona>(await clsListadoPersonas.getListadoCompletoPersonas());
		}



		
	}
}
