using BL.Gestion;
using BL.Listados;
using CRUD_CommunityToolkitUI.ViewModels.Utilities;
using CRUD_CommunityToolkitUI.Views;
using Entities;

namespace CRUD_CommunityToolkitUI.ViewModels
{
	public partial class clsVMListadoDepartamentos : clsVMBase
	{

		#region Atributes

		clsListadoDepartamentosBL bl;

		clsGestionDepartamentosBL gestionBL;

		#endregion
		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(ListadoDepartamentos))]
		clsDepartamento departamentoSeleccionado;

		[ObservableProperty]
		ObservableCollection<clsDepartamento> listadoDepartamentos;

		[ObservableProperty]
		ObservableCollection<clsDepartamento> listadoDepartamentosMostrado;
		#region Properties






		#endregion



		#region Constructors

		public clsVMListadoDepartamentos()
		{
			Title = "Gestor de Departamentos";
			this.bl = new();
			this.ListadoDepartamentos = bl.getListadoDepartamentosBL();
		}






		#endregion


		#region CommandImplementation

		/// <summary>
		/// 
		/// Descripcion: Método que se encarga de asegurar que el usuario quería realizar la accion y,
		/// en caso positivo, énvia una peticion a la capa BL para que nos permita eliminar un registro de la 
		/// tabla Personas de la base de datos.
		/// Precondiciones:
		/// PostCondiciones: 
		/// 
		/// </summary>
		[RelayCommand]
		public async void DeleteDepartamento()
		{

			var result = await Shell.Current.DisplayAlert("Gestor Empresa", "¿Está seguro de qesea eliminar el registro?", "Si", "No");
			if (result.Equals(true))
			{
				ListadoDepartamentosMostrado.Remove(DepartamentoSeleccionado);
				await Shell.Current.DisplayAlert("Gestor Empresa", "Se eliminó el registro", "OK");
			}
			DepartamentoSeleccionado = null;

		}




		/// <summary>
		/// Comando que convierte personaSeleccionada en un 
		/// objeto clsPersona y lo envía a la Pagina DetallesPage
		/// 
		/// </summary>
		/// <returns></returns>

		[RelayCommand]
		public async void GotoEditInsertDepartamentoAsync()
		{
			var p = new clsPersona();
			var id = 0;
			if (DepartamentoSeleccionado is not null)
			{
				id = DepartamentoSeleccionado.Id;
				clsGestionPersonasBL gestionBL = new();



				p = gestionBL.getPersonaByIdBL(id);

				//Navegamos a la pagina de detalles y le pasamos la persona coN un Dictionary
				//Para poder pasar el objeto
			}
			var diccionario = new Dictionary<string, object>
			{
				["DepartamentoSeleccionado"] = p
			};



			await Shell.Current.GoToAsync($"{nameof(DetallesDepartamentoPage)}", true, diccionario);


		}



		/// <summary>
		/// Descripción: Comando que se encarga de rellenar la lista de personas a 
		/// partir de una llamada a la función de la capa BL.
		/// 
		/// Precondiciones: Ninguna
		/// Postcondiciones: Ninguna
		/// </summary>
		/// <returns></returns>
		[RelayCommand]
		async Task GetDepartamentoAsync()
		{
			//Si se está llamando a otro método
			if (IsBusy)
				return;

			try
			{
				//Le decimos a la vista que el viewModel está cargando su petición
				IsBusy = true;


				ListadoDepartamentosMostrado = bl.getListadoDepartamentosBL();
				if (ListadoDepartamentos.Count > 0)
					ListadoDepartamentos.Clear();


				foreach (var p in ListadoDepartamentosMostrado)
					ListadoDepartamentos.Add(p);

				//Ordeno la lista por idDepartamento
				var first = ListadoDepartamentos.OrderBy(m =>
				m.Id).FirstOrDefault();

				//Compruebo que el preimero no sea null
				if (first == null)
					return;
			}
			catch (Exception e)
			{
				//Muestro un Alert que informará sobre el error que ha sucedido
				await Shell.Current.DisplayAlert("Error!", $"Imposible Mostrar el listado de Personas: {e.Message}", "OK");
			}
			finally
			{
				//Le decimos que el viewModel ya no está ocupado
				IsBusy = false;
			}
		}





		#endregion

	}
}
