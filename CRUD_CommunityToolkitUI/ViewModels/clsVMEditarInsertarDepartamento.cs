using BL.Gestion;
using BL.Listados;
using CRUD_CommunityToolkitUI.ViewModels.Utilities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_CommunityToolkitUI.ViewModels
{
	[QueryProperty("DepartamentoSeleccionado", nameof(DepartamentoSeleccionado))]
	public partial class clsVMEditarInsertarDepartamento : clsVMBase, IQueryAttributable
	{

		#region Atributtes
		clsListadoDepartamentosBL deptBL;

		[ObservableProperty]
		clsDepartamento departamentoSeleccionado;

		#endregion

		#region Properties 
		public ObservableCollection<clsDepartamento> ListaDepartamentos { get; } = new();

		#endregion

		#region Constructors

		#endregion

		private clsVMEditarInsertarDepartamento(ObservableCollection<clsDepartamento> Data)
		{
			
			ListaDepartamentos = Data;
			deptBL = new();
		}


		/// <summary>
		/// Método que instancia el ViewModel y pide a la capa BL un listado de objetos tipo clsDepartamento
		/// </summary>
		/// <returns></returns>
		public static async Task<clsVMEditarInsertarDepartamento> CreateAsync()
		{
			var tmpData = new ObservableCollection<clsDepartamento>();
			try
			{

				tmpData = await clsListadoDepartamentosBL.getListadoDepartamentosBL();

			}
			catch (Exception e)
			{
				throw e;
			}
			return new clsVMEditarInsertarDepartamento(tmpData);
		}


		#region Commands



		/// <summary>
		/// Descripcion: Comando que se encarga de pedir a la capa BL que pida a la capa DAL acceso a la
		/// insercion o edicion de un registro de la tabla Pêrsonas de la base de datos.
		/// </summary>
		[RelayCommand]
		async void GuardarDepartamento()
		{

			var result = await Shell.Current.DisplayAlert("Gestor Empleados", "¿Guardar?", "Si", "No");
			if (result.Equals(true))
			{
				var bl = new clsGestionDepartamentosBL();
				if (DepartamentoSeleccionado.id > 0)
				{

					if (bl.editDepartamentoBL(DepartamentoSeleccionado, DepartamentoSeleccionado.id))
					{
						await Shell.Current.DisplayAlert("Gestor Empleados", $"Se modificó el departamento {DepartamentoSeleccionado.nombre}", "OK");

					}
					else
					{
						await Shell.Current.DisplayAlert("ERROR!", $"No se modificó el departamento {DepartamentoSeleccionado.nombre}", "OK");

					}
				}
				else
				{
					bool statusCode = clsGestionDepartamentosBL.insertarDepartamentoBL(DepartamentoSeleccionado).Result.IsSuccessStatusCode;
					bool isFault = statusCode;
					if (!isFault)
					{
						await Shell.Current.DisplayAlert("ERROR!", $"No se insertó el departamento {DepartamentoSeleccionado.nombre}", "OK");
						await Shell.Current.GoToAsync("..");
					}
				}
				await Shell.Current.GoToAsync("..");
			}
		}



		/// <summary>
		/// Método que, cuando se instancia un nuevo viewModel, busca los datos 
		/// que se han recibido del Query y los establece a la propiedad clsDepartamento
		/// DepartamentoSeleccionado
		/// </summary>
		/// <param name="query"></param>
		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			DepartamentoSeleccionado = query["DepartamentoSeleccionado"] as clsDepartamento;
		}
		#endregion



	}
}
