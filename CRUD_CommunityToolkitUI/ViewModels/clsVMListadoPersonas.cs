using BL.Gestion;
using BL.Listados;
using CommunityToolkit.Mvvm.Input;
using CRUD_CommunityToolkitUI.ViewModels.Utilities;
using CRUD_CommunityToolkitUI.Views;
using Entities;
using Microsoft.Data.SqlClient;
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


		String busqueda;

		[ObservableProperty]
		ObservableCollection<clsPersonaConDepartamento> listadoPersonas;
		#region Properties






		#endregion

		//Esta propiedad la haré manualmente ya que necesito ejecutar el comando de busqueda
		//cada vez que se modifique el texto del searchBar.
		public String Busqueda
		{

			get { return busqueda; }
			set
			{
				if (busqueda != value)
				{
					busqueda = value;
					//Notifico el cambio manualmente y llamo al comando Buscar ya que
					//esta propiedad solo se tocará cuando se introduzca texto en la barra de busqueda
					OnPropertyChanged();

					Buscar();
				}
			}
		}


		#region Constructors



		private clsVMListadoPersonas(ObservableCollection<clsPersonaConDepartamento> Data)
		{
			Title = "Gestor de Personas";
			//Recogemos la excepcion que se lanza desde clsMiConexion en caso de no tener acceso a la base de datos
			try
			{
				this.bl = new();
				
			}
			catch (SqlException e)
			{
				Shell.Current.DisplayAlert("ERROR!", $"No se pudo acceder a los datos, vuelva a intentarlo más tarde \n codigo de error: {e.Message}", "OK");
			}
			this.ListadoPersonas = Data;
			ListadoPersonasMostradas = ListadoPersonas;
		}


		/// <summary>
		/// Método que instancia el ViewModel y 
		/// </summary>
		/// <returns></returns>
		public static async Task<clsVMListadoPersonas> CreateAsync()
		{
			ObservableCollection<clsPersonaConDepartamento> tmpData = null;
			try
			{
				tmpData = await getListadoPersonasConNombreDepartamento();
			}
			catch (Exception e)
			{
				throw e;
			}
			return new clsVMListadoPersonas(tmpData);
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
		/// Comando que se encarga de realizar la accion del buscador de la vista.
		/// 
		/// </summary>
		[RelayCommand]

		async void Buscar()
		{
			//Compruebo que le programa no esté ocupado para no saturarlo
			if (IsBusy)
				return;
			IsBusy = true;
			//Compruebo que el string del query no esté vacío, para modificar la lista mostrada y pasarle todos los registros
			if (Busqueda.IsNullOrEmpty() || Busqueda.Equals(" "))
			{
				ListadoPersonasMostradas = ListadoPersonas;
				IsBusy = false;

			}
			//Si el String no está vacío buscamos en la lista de objetos clsPersona, los nombres o apellidos que contienen este  
			//string de búsqueda, los almacenamos en ListadoPersonasMostradas
			else
			{
				var listaAux = ListadoPersonas.ToList().FindAll(x => x.nombreCompleto.ToLower().Contains(Busqueda.ToLower()));
				ListadoPersonasMostradas = new ObservableCollection<clsPersonaConDepartamento>(listaAux);
				IsBusy = false;
			}

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
				var personas = await getListadoPersonasConNombreDepartamento();

				if (ListadoPersonas.Count > 0)
					ListadoPersonas.Clear();



				foreach (var p in personas)
					ListadoPersonas.Add(p);

				//Ordeno la lista por idDepartamento
				var first = ListadoPersonas.OrderBy(m =>
				m.idDepartamento).FirstOrDefault();

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
		private static async Task<ObservableCollection<clsPersonaConDepartamento>> getListadoPersonasConNombreDepartamento()
		{
			

			ObservableCollection<clsPersonaConDepartamento> personas = new();
			clsListadoDepartamentosBL deptBL = new();

			//Recojo un listado de departamentos para poder saber el nombre
			var departamentosList = await clsListadoDepartamentosBL.getListadoDepartamentosBL();

			//Recojo la lista de personas
			var personasList = await clsListadoPersonasBL.getListadoCompletoPersonasBL();


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
					if (p.idDepartamento == dpt.id)
					{
						//Establezco que se encontró el departamento
						isDptFind = true;
						//Convierto la persona en una que contenga el nombre del departamento
						var pc = new clsPersonaConDepartamento(p.id, p.nombre, p.apellidos, p.foto, dpt.nombre);

						//Añado el objeto clsPersonaConDepartamento a la lista
						personas.Add(pc);
					}
				}
			}

			return personas;
		}

	}
}
