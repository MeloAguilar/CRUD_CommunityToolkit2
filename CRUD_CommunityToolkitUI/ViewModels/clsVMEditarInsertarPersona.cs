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
	[QueryProperty("PersonaAModificar", nameof(PersonaSeleccionada))]
	public partial class clsVMEditarInsertarPersona : clsVMBase
	{
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

			foreach(var departamento in deptBL.getListadoDepartamentosBL())
			{
				ListaDepartamentos.Add(departamento);
			}
			if (PersonaSeleccionada is not null)
			{
				Title = PersonaSeleccionada.NombreCompleto;
			}
			else
			{
				Title = "Nuevo Empleado";
			}
		}
		#endregion



		#region Commands

		#endregion



	}
}
