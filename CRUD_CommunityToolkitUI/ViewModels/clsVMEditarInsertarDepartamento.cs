using BL.Gestion;
using BL.Listados;
using CRUD_CommunityToolkitUI.ViewModels.Utilities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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


		public clsVMEditarInsertarDepartamento()
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
		public void GuardarDepartamento()
		{
			var result = Shell.Current.DisplayAlert("Gestor Empleados", "¿Guardar?", "Si", "No");
			if (result.Equals(true))
			{
				clsGestionDepartamentosBL bl = new();
				if (DepartamentoSeleccionado.Id > 0)
				{

					bl.editDepartamentoBL(DepartamentoSeleccionado, DepartamentoSeleccionado.Id);
					Shell.Current.DisplayAlert("Gestor Empleados", $"Se modificó el empleado {DepartamentoSeleccionado.Nombre}", "OK");
					Shell.Current.GoToAsync("..");
				}
				else
				{
					bl.insertarDepartamentoBL(DepartamentoSeleccionado);
					Shell.Current.DisplayAlert("Gestor Empleados", $"Se insertó el empleado {DepartamentoSeleccionado.Nombre}", "OK");
				}
			}
		}

		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			DepartamentoSeleccionado = query["DepartamentoSeleccionado"] as clsDepartamento;
		}
		#endregion



	}
}
