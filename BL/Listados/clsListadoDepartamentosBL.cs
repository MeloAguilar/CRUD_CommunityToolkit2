using DAL.Listados;
using Entities;
using System.Collections.ObjectModel;


namespace BL.Listados
{
	public class clsListadoDepartamentosBL
	{

		clsListadoDepartamentos dal;


		/// <summary>
		/// 
		/// Método que llama a capa de acceso a los datos
		/// y devuelve una ObservableCollection de objetos clsDepartamento
		/// 
		/// </summary>
		/// <returns></returns>
		public static async Task<ObservableCollection<clsDepartamento>> getListadoDepartamentosBL()
		{
			return new ObservableCollection<clsDepartamento>(await clsListadoDepartamentos.getListadoCompletoDepartamentos());
		}

	}
}
