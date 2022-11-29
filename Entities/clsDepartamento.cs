namespace Entities
{
    public class clsDepartamento
    {
        #region Atributos
        private int id;
        private string nombre;
        #endregion

        #region Propiedades
        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        #endregion

        #region Constructores
        public clsDepartamento() { }
        public clsDepartamento(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        #endregion
    }
}
