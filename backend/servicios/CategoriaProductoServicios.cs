
using backend.connection;

namespace backend.servicios
{
    public static class CategoriaProductoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>(){
            const string sql = "";
            return BDManager.GetInstance.GetData<T>(sql);
        }

    }
}