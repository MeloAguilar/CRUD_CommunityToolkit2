using BL.Gestion;
using BL.Listados;
using CRUD_CommunityToolkitUI.ViewModels.Utilities;
using DAL.Gestion;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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


		public clsVMEditarInsertarPersona()
		{
			DepartamentoSeleccionado = new clsDepartamento();

			deptBL = new();
			var depts = deptBL.getListadoDepartamentosBL();
			foreach (var departamento in depts)
			{
				ListaDepartamentos.Add(departamento);
			}
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
			PersonaSeleccionada.IdDepartamento = DepartamentoSeleccionado.Id;
			var result = await Shell.Current.DisplayAlert("Gestor Empleados", "¿Guardar?", "Si", "No");
			if (result.Equals(true))
			{
				clsGestionPersonasBL bl = new clsGestionPersonasBL();
				if (PersonaSeleccionada.Id > 0)
				{

					if (bl.editPersonaBL(PersonaSeleccionada, PersonaSeleccionada.Id))
					{
						await Shell.Current.DisplayAlert("Gestor Empleados", $"Se modificó el empleado {PersonaSeleccionada.NombreCompleto}", "OK");
						await Shell.Current.GoToAsync("..");
					}
					else
					{
						await Shell.Current.DisplayAlert("EWRROR!", $"Np se modificó el empleado {PersonaSeleccionada.NombreCompleto}", "OK");

					}
				}
				else
				{

					if (bl.insertarPersonaBL(PersonaSeleccionada))
					{
						await Shell.Current.DisplayAlert("ERROR!", $"No se insertó el empleado {PersonaSeleccionada.NombreCompleto}", "OK");
					}
					else
					{

					}
				}
			}
		}

		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			PersonaSeleccionada = query["PersonaSeleccionada"] as clsPersona;

		}
		#endregion



	}
}
