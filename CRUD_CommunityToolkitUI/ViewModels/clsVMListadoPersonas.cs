using BL.Gestion;
using BL.Listados;
using CommunityToolkit.Mvvm.Input;
using CRUD_CommunityToolkitUI.ViewModels.Utilities;
using CRUD_CommunityToolkitUI.Views;
using Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUD_CommunityToolkitUI.ViewModels
{
	public partial class clsVMListadoPersonas : clsVMBase
	{
		#region Atributes

		clsListadoPersonasBL bl;

		#endregion
		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(ListadoPersonas))]
		clsPersonaConDepartamento personaSeleccionada;


		[ObservableProperty]
		ObservableCollection<clsPersonaConDepartamento> listadoPersonasMostradas;

		[ObservableProperty]
		String busqueda;

		[ObservableProperty]
		ObservableCollection<clsPersonaConDepartamento> listadoPersonas;
		#region Properties






		#endregion



		#region Constructors

		public clsVMListadoPersonas()
		{
			Title = "Gestor de Personas";
			this.bl = new();
			this.ListadoPersonas = getListadoPersonasConNombreDepartamento();
			ListadoPersonasMostradas = ListadoPersonas;
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
		public async void DeletePersona()
		{

			var result = await Shell.Current.DisplayAlert("Gestor Empresa", "¿Está seguro de qesea eliminar el registro?", "Si", "No");
			if (result.Equals(true))
			{
				ListadoPersonas.Remove(PersonaSeleccionada);
				await Shell.Current.DisplayAlert("Gestor Empresa", "Se eliminó el registro", "OK");
			}
			PersonaSeleccionada = null;

		}


		/// <summary>
		/// 
		/// </summary>
		[RelayCommand]

		void Buscar()
		{
			if (Busqueda.IsNullOrEmpty() || Busqueda.Equals(" "))
			{
				ListadoPersonasMostradas = ListadoPersonas;
				return;
			}

			var listaAux = ListadoPersonas.ToList().FindAll(x => x.NombreCompleto.ToLower().Contains(Busqueda.ToLower()));
			ListadoPersonasMostradas = new ObservableCollection<clsPersonaConDepartamento>(listaAux);
			if (ListadoPersonasMostradas.Count == 0)
				ListadoPersonasMostradas = ListadoPersonas;
		}


			/// <summary>
			/// Comando que convierte personaSeleccionada en un 
			/// objeto clsPersona y lo envía a la Pagina DetallesPage
			/// 
			/// </summary>
			/// <returns></returns>

			[RelayCommand]
			public async void GotoEditInsertPersonaAsync()
			{
				var p = new clsPersona();
				var id = 0;
				if (PersonaSeleccionada is not null)
				{
					id = PersonaSeleccionada.IdPersona;
					clsGestionPersonasBL gestionBL = new();



					p = gestionBL.getPersonaByIdBL(id);

					//Navegamos a la pagina de detalles y le pasamos la persona coN un Dictionary
					//Para poder pasar el objeto
				}
				var diccionario = new Dictionary<string, object>
				{
					["PersonaSeleccionada"] = p
				};

		

				await Shell.Current.GoToAsync($"{nameof(DetallesPersonaPage)}", true, diccionario);
			

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
			async Task GetPersonasAsync()
			{
				//Si se está llamando a otro método
				if (IsBusy)
					return;

				try
				{
					//Le decimos a la vista que el viewModel está cargando su petición
					IsBusy = true;

					//Llamamos a la capa BL para que nos envíe un listado de objetos clsPersona
					var personas = getListadoPersonasConNombreDepartamento();

					if (ListadoPersonas.Count > 0)
						ListadoPersonas.Clear();


					foreach (var p in personas)
						ListadoPersonas.Add(p);

					//Ordeno la lista por idDepartamento
					var first = ListadoPersonas.OrderBy(m =>
					m.IdDepartamento).FirstOrDefault();

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


		/// <summary>
		/// 
		/// Método privado que sirve para transformar una lista de objetos clsPersona en una
		/// ObservableCollection de clsPersonaConDepartamento.
		/// A partir de una llamada a la capa BL recorre el listado recibido.
		/// 
		/// Precondiciones: Ninguna
		/// PostCondiciones: Ninguna
		/// </summary>
		/// <returns></returns>
		private ObservableCollection<clsPersonaConDepartamento> getListadoPersonasConNombreDepartamento()
		{

			ObservableCollection<clsPersonaConDepartamento> personas = new();
			clsListadoDepartamentosBL deptBL = new();

			//Recojo un listado de departamentos para poder saber el nombre
			var departamentosList = deptBL.getListadoDepartamentosBL();

			//Recojo la lista de personas
			var personasList = bl.getListadoCompletoPersonasBL();


			//Recorro la lista completa de personas
			foreach (var p in personasList)
			{
				var isDptFind = false;
				//Recorro la lista de departamentos hasta que se encuentre el que estoy buscando
				for (int i = 0; i < departamentosList.Count && !isDptFind; i++)
				{
					//Genero un departamento auxiliar para que el código sea más corto
					var dpt = departamentosList[i];
					//Si el idDepartamento que he recogido del bucle for es igual al idDepartamento de la persona recogida en el bucle foreach
					if (p.IdDepartamento == dpt.Id)
					{
						//Establezco que se encontró el departamento
						isDptFind = true;
						//Convierto la persona en una que contenga el nombre del departamento
						var pc = new clsPersonaConDepartamento(p.Id, p.Nombre, p.Apellidos, p.Foto, dpt.Nombre);

						//Añado el objeto clsPersonaConDepartamento a la lista
						personas.Add(pc);
					}
				}
			}

			return personas;
		}

	}
}
