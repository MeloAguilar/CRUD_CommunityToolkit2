namespace Entities
{
    public class clsDepartamento
    {
        #region Atributos
        private int _id;
        private string _nombre;
        #endregion

        #region Propiedades
        public int id { get { return _id; } set { _id = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        #endregion

        #region Constructores
        public clsDepartamento() { }
        public clsDepartamento(int id, string nombre)
        {
            this._id = id;
            this._nombre = nombre;
        }
        #endregion
    }
}
