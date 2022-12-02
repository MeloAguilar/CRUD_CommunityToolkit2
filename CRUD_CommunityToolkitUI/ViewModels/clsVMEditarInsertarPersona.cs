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
	[QueryProperty(nameof(PersonaSeleccionada), nameof(PersonaSeleccionada))]
	public partial class clsVMEditarInsertarPersona : clsVMBase
	{

		[ObservableProperty]
		String nombreCompleto;

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
		public void GuardarEmpleado()
		{
			var result = Shell.Current.DisplayAlert("Gestor Empleados", "¿Guardar?", "Si", "No");
			if (result.Equals(true))
			{
				clsGestionPersonasBL bl = new clsGestionPersonasBL();
				if (PersonaSeleccionada.Id > 0)
				{

					bl.editPersonaBL(PersonaSeleccionada, PersonaSeleccionada.Id);
					Shell.Current.DisplayAlert("Gestor Empleados", $"Se modificó el empleado {PersonaSeleccionada.NombreCompleto}", "OK");
					Shell.Current.GoToAsync("..");
				}
				else
				{
					bl.insertarPersonaBL(PersonaSeleccionada);
					Shell.Current.DisplayAlert("Gestor Empleados", $"Se insertó el empleado {PersonaSeleccionada.NombreCompleto}", "OK");
				}
			}
		}
		#endregion



	}
}
