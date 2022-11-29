namespace Entities
{
    public class clsPersona
    {
        #region Atributos
        private int id;
        private string nombre;
        private string apellidos;
        private string telefono;
        private string direccion;
        private string foto;
        private DateTime fechaNacimiento;
        private int idDepartamento;
        #endregion

        #region Propiedades
        public int Id { get { return id; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellidos { get { return apellidos; } set { apellidos = value; } }
        public string NombreCompleto => $"{Nombre} {Apellidos}";
        public string Telefono { get { return telefono; } set { telefono = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public string Foto { get { return foto; } set { foto = value; } }
        public DateTime FechaNacimiento { get { return fechaNacimiento; } set { fechaNacimiento= value; } }
        public int IdDepartamento { get { return idDepartamento; } set { idDepartamento = value;}  }
        #endregion

        #region Constructores
        public clsPersona() { }
        public clsPersona(int id, string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            this.fechaNacimiento = fechaNacimiento;
            this.idDepartamento = idDepartamento;
        }
        #endregion
    }
}
