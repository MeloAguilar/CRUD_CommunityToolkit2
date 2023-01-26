using BL.Gestion;
using BL.Listados;
using CRUD_CommunityToolkitUI.ViewModels.Utilities;
using DAL.Gestion;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_CommunityToolkitUI.ViewModels
{
	[QueryProperty("PersonaSeleccionada", nameof(PersonaSeleccionada))]
	public partial class clsVMEditarInsertarPersona : clsVMBase, IQueryAttributable
	{

		[ObservableProperty]
		String nombreCompleto;

		[ObservableProperty]
		clsDepartamento departamentoSeleccionado;

		#region Atributtes
		clsListadoDepartamentosBL deptBL;

		[ObservableProperty]
		clsPersona personaSeleccionada;

		[ObservableProperty]
		clsDepartamento departaMentoSeleccionado;

		#endregion

		#region Properties 
		public ObservableCollection<clsDepartamento> ListaDepartamentos { get; } = new();

		#endregion

		#region Constructors



		private clsVMEditarInsertarPersona(ObservableCollection<clsDepartamento> Data)
		{
			ListaDepartamentos = Data;
		}


		/// <summary>
		/// Método que instancia el ViewModel y 
		/// </summary>
		/// <returns></returns>
		public static async Task<clsVMEditarInsertarPersona> CreateAsync()
		{
			var tmpData= new ObservableCollection<clsDepartamento>();
			try
			{
				

				tmpData = await clsListadoDepartamentosBL.getListadoDepartamentosBL();

			}
			catch (Exception e)
			{
				throw e;
			}
			return new clsVMEditarInsertarPersona(tmpData);
		}

		#endregion



		#region Commands



		/// <summary>
		/// Descripcion: Comando que se encarga de pedir a la capa BL que pida a la capa DAL acceso a la
		/// insercion o edicion de un registro de la tabla Pêrsonas de la base de datos.
		/// </summary>
		[RelayCommand]
		async void GuardarEmpleado()
		{
			PersonaSeleccionada.idDepartamento = DepartamentoSeleccionado.id;
			var result = await Shell.Current.DisplayAlert("Gestor Empleados", "¿Guardar?", "Si", "No");
			if (result.Equals(true))
			{
				clsGestionPersonasBL bl = new clsGestionPersonasBL();
				if (PersonaSeleccionada.id > 0)
				{

					if (bl.editPersonaBL(PersonaSeleccionada, PersonaSeleccionada.id))
					{
						await Shell.Current.DisplayAlert("Gestor Empleados", $"Se modificó el empleado {PersonaSeleccionada.nombreCompleto}", "OK");
						
					}
					else
					{
						await Shell.Current.DisplayAlert("EWRROR!", $"Np se modificó el empleado {PersonaSeleccionada.nombreCompleto}", "OK");

					}
				}
				else
				{
					HttpStatusCode statusCode = await bl.insertarPersonaBL(PersonaSeleccionada);

					bool isFaulted = statusCode.Equals(HttpStatusCode.OK);

					if (!isFaulted)
					{
						await Shell.Current.DisplayAlert("ERROR!", $"No se insertó el empleado {PersonaSeleccionada.nombreCompleto}", "OK");
						await Shell.Current.GoToAsync("..");
					}
				}
				await Shell.Current.DisplayAlert($"Gestor empleados", $"Nuevo empleado introducido id:{PersonaSeleccionada.id}", "OK");

				await Shell.Current.GoToAsync("..");
			}
		}



		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			PersonaSeleccionada = query["PersonaSeleccionada"] as clsPersona;

		}
		#endregion



	}
}
