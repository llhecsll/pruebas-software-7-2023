
using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;
using Microsoft.AspNetCore.SignalR;

namespace backend.servicios
{
    public static class ProductoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>(){
            // const string sql = "select * from producto";
            const string storedProcedureName = "GetAllProducts";
            // return BDManager.GetInstance.GetData<T>(sql);
            var parameters = new DynamicParameters(); // Agrega parámetros si es necesario
            return BDManager.GetInstance.SPGetData<T>(storedProcedureName, parameters);

        }

        public static T ObtenerById<T>(int id){
            // const string sql = "select * from producto where ID = @Id and estado_registro = 1";
            const string storedProcedureName = "GetProductoById";
            var parameter = new DynamicParameters();
            parameter.Add("id", id, DbType.Int64);
            // var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameter);
            var result =  BDManager.GetInstance.SPGetDataWithParameters<T>(storedProcedureName, parameter);
            return result.FirstOrDefault();                      
        }

        public static int InsertProducto(Producto producto){
            // const string sql = "INSERT INTO [dbo].[PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES (@nombre, @id_categoria) ";
            const string storedProcedureName = "InsertProducto";
            var parameter = new DynamicParameters();
            parameter.Add("nombre", producto.Nombre, DbType.String);
            parameter.Add("id_categoria", producto.IdCategoria, DbType.Int64);
            // var result = BDManager.GetInstance.SetData(sql, parameter);
            var result = BDManager.GetInstance.SPSetData(storedProcedureName, parameter);
            return result;
        }    

         public static int UpdateProducto(Producto producto)
        {
            // const string sql = "UPDATE [PRODUCTO] SET [NOMBRE] = @nombre, [ID_CATEGORIA] = @id_categoria WHERE [ID] = @id";
            const string storedProcedureName = "UpdateProducto";
            var parameter = new DynamicParameters();
            parameter.Add("id", producto.Id, DbType.Int32);
            parameter.Add("nombre", producto.Nombre, DbType.String);
            parameter.Add("id_categoria", producto.IdCategoria, DbType.Int32);
            // var result = BDManager.GetInstance.SetData(sql, parameter);
            var result = BDManager.GetInstance.SPSetData(storedProcedureName, parameter);
            return result;
        }

        public static int DeleteProducto(int id)
        {
            // const string sql = "DELETE FROM [PRODUCTO] WHERE [ID] = @id";
            const string storedProcedureName = "DeleteProducto";
            var parameter = new DynamicParameters();
            parameter.Add("id", id, DbType.Int32);
            // var result = BDManager.GetInstance.SetData(sql, parameter);
            var result = BDManager.GetInstance.SPSetData(storedProcedureName, parameter);
            return result;
        }

    }
}