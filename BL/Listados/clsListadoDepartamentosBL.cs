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
		public ObservableCollection<clsDepartamento> getListadoDepartamentosBL()
		{
			dal = new clsListadoDepartamentos();	
			
			return new ObservableCollection<clsDepartamento>(dal.getListadoCompletoDepartamentos());
		}
	}
}
