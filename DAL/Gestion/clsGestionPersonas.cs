using DAL.Conexion;
using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Gestion
{
	public class clsGestionPersonas
	{
		private clsMiConexion miConexion;

		public clsGestionPersonas()
		{
			miConexion = new clsMiConexion();
		}

		public clsGestionPersonas(string server, string name, string pass, string user)
		{
			miConexion = new clsMiConexion(server, name, user, pass);
		}


		/// <summary>
		/// <Header> inserPersona(clsPersona persona) : bool </Header>
		/// Método que se encarga de insertar un registro en la tabla 
		/// Personas de la base de datos dado un objeto clsPersona 
		/// como parámetro.
		/// 
		/// </summary>
		/// <param name="persona">
		///		objeto clsPersona instanciado con atributos != null
		/// </param>
		/// <returns>
		///		exito 
		///			-false: no se pudo insertar el registro en la base de datos.
		///			-true: los datos se insertaron satisfactoriamente.
		/// </returns>
		public bool insertarPersona(clsPersona persona)
		{
			bool exito;
			SqlConnection cnn = null;
			try
			{
				cnn = miConexion.getConnection();
				SqlCommand comando = new SqlCommand();
				comando.Connection = cnn;
				comando.CommandText = "Insert into personas values(@nombre, @apellidos, @telefono, @direccion, @foto, @fechaNac, @idDepartamento)";
				comando.Parameters.AddWithValue("@nombre", persona.Nombre);
				comando.Parameters.AddWithValue("@apellidos", persona.Apellidos);
				comando.Parameters.AddWithValue("@telefono", persona.Telefono);
				comando.Parameters.AddWithValue("@direccion", persona.Direccion);
				comando.Parameters.AddWithValue("@foto", persona.Foto);
				comando.Parameters.AddWithValue("@fechaNac", persona.FechaNacimiento);
				comando.Parameters.AddWithValue("@idDepartamento", persona.IdDepartamento);

				comando.ExecuteNonQuery();
				exito = true;

			}
			catch (Exception e)
			{
				throw e;
				exito = false;
			}
			finally
			{
				if (cnn != null)
				{
					miConexion.closeConnection(ref cnn);
				}
			}
			return exito;
		}




		/// <summary>
		/// <Header> deletePersona(int id) : bool </Header>
		/// Método que se encarga de eliminar un registro en la tabla 
		/// Personas de la base de datos dado un entero que corresponda
		/// a la propiedad id de un registro de la base de datos
		/// como parámetro.
		/// 
		/// <pre>
		///		id debe ser un entero correspondiente al id de un registro de la tabla Personas de la base de datos.
		/// </pre>
		/// </summary>
		/// <param name="id">
		///		entero correspondiente al atributo Id de un objeto clsPersona	
		/// </param>
		/// <returns>
		///		exito 
		///			-false: no se pudo eliminar el registro en la base de datos.
		///			-true: el registro se eliminó satisfactoriamente.
		/// </returns>
		public bool deletePersona(int id)
		{
			bool exito;
			SqlConnection cnn = null;
			try
			{
				cnn =  miConexion.getConnection();
				SqlCommand comando = new SqlCommand();
				comando.Connection = cnn;
				comando.CommandText = "Delete From Personas where id = @id";
				comando.Parameters.AddWithValue("@id", id);
				comando.ExecuteNonQuery();

				exito = true;
			}
			catch (Exception)
			{
				exito = false;
			}
			finally
			{
				if (cnn != null)
				{
					miConexion.closeConnection(ref cnn);
				}
			}

			return exito;

		}



		/// <summary>
		/// <Header> editPersona(int id) : bool </Header>
		/// Método que se encarga de editar un registro de la tabla 
		/// Personas de la base de datos dado un entero que corresponda
		/// a la propiedad id de un registro de la base de datos
		/// y un objeto clsPersona con los cambios que se deseen realizar
		/// como parámetro y un entero correspondiente al id del registro que se desea atacar.
		/// 
		/// <pre>
		///		id debe ser un entero correspondiente al id de un registro de la tabla Personas de la base de datos.
		/// </pre>
		/// </summary>
		/// <param name="id">
		///		entero correspondiente al atributo Id de un objeto clsPersona	
		/// </param>
		/// <param name="persona">
		///		objeto clsPersona con los cambios que se desea reaalizar en el registro
		/// </param>
		/// <returns>
		///		exito 
		///			-false: no se pudo editar el registro en la base de datos.
		///			-true: el registro se editó satisfactoriamente.
		/// </returns>
		/// 
		public bool editPersona(clsPersona persona, int id)
		{
			bool exito;
			SqlConnection cnn = null;
			try
			{


				cnn =  miConexion.getConnection();
				SqlCommand comando = new SqlCommand();
				comando.Connection = cnn;
				comando.CommandText = "Update Personas set nombre = @nombre, apellidos = @apellidos, direccion = @direccion, telefono = @telefono, fechaNacimiento = @fechaNacimiento, foto = @foto, idDepartamento = @idDepartamento Where id = @id";
				comando.Parameters.AddWithValue("@id", id);
				comando.Parameters.AddWithValue("@nombre", persona.Nombre);
				comando.Parameters.AddWithValue("@apellidos", persona.Apellidos);
				comando.Parameters.AddWithValue("@telefono", persona.Telefono);
				comando.Parameters.AddWithValue("@idDepartamento", persona.IdDepartamento);
				comando.Parameters.AddWithValue("@direccion", persona.Direccion);
				comando.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
				comando.Parameters.AddWithValue("@foto", persona.Foto);
				comando.ExecuteNonQuery();

				exito = true;
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				if (cnn != null)
				{
					miConexion.closeConnection(ref cnn);
				}
			}

			return exito;

		}



		/// <summary>
		/// <Header> editPersona(int id) : bool </Header>
		/// Método que se encarga de editar un registro de la tabla 
		/// Personas de la base de datos dado un entero que corresponda
		/// a la propiedad id de un registro de la base de datos
		/// y un objeto clsPersona con los cambios que se deseen realizar
		/// como parámetro y un entero correspondiente al id del registro que se desea atacar.
		/// 
		/// <pre>
		///		id debe ser un entero correspondiente al id de un registro de la tabla Personas de la base de datos.
		/// </pre>
		/// </summary>
		/// <param name="id">
		///		entero correspondiente al atributo Id de un objeto clsPersona	
		/// </param>
		/// <param name="persona">
		///		objeto clsPersona con los cambios que se desea reaalizar en el registro
		/// </param>
		/// <returns>
		///		exito 
		///			-false: no se pudo editar el registro en la base de datos.
		///			-true: el registro se editó satisfactoriamente.
		/// </returns>
		/// 
		public clsPersona getPersonaById(int id)
		{
			clsPersona persona = new();
			SqlConnection cnn = null;
			try
			{


				cnn =  miConexion.getConnection();
				SqlCommand comando = new SqlCommand();
				SqlDataReader lector;
				comando.Connection = cnn;
				comando.CommandText = "Select * From Personas where id = @id";
				comando.Parameters.AddWithValue("@id", id);
			
				lector = comando.ExecuteReader();
				if (lector.HasRows)
				{
					while (lector.Read())
					{
						persona = new(
							lector.GetInt32(0), 
							lector.GetString(1),
							lector.GetString(2),
							lector.GetString(3),
							lector.GetString(4),
							lector.GetString(5),
							lector.GetDateTime(6),
							lector.GetInt32(7)
							);
					}
				}


			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (cnn != null)
					miConexion.closeConnection(ref cnn);
			}
			return persona;
		}


	}
}
