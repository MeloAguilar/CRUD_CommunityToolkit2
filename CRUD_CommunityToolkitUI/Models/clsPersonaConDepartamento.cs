using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_CommunityToolkitUI.Models
{
	public class clsPersonaConDepartamento : clsPersona
	{

		public string NombreDepartamento { get; set; }

		public int IdPersona { get; set; }


		public clsPersonaConDepartamento(int id, string _nombre, string _apellidos, string urlFoto, string nombreDepartamento)
		{
			this.IdPersona = id;
			base.nombre = _nombre;
			base.apellidos = _apellidos;
			base.foto = urlFoto;
			NombreDepartamento = nombreDepartamento;

		}

		public clsPersonaConDepartamento()
		{
		}


	}
}
