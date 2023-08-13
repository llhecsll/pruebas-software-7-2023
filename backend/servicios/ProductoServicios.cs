
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
            const string sql = "select * from producto";
            return BDManager.GetInstance.GetData<T>(sql);
        }

        public static T ObtenerById<T>(int id){
            const string sql = "select * from producto where ID = @Id and estado_registro = 1";
            var parameter = new DynamicParameters();
            parameter.Add("id", id, DbType.Int64);
            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameter);
            return result.FirstOrDefault();                      
        }

        public static int InsertProducto(Producto producto){
            const string sql = "INSERT INTO [dbo].[PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES (@nombre, @id_categoria) ";
            var parameter = new DynamicParameters();
            parameter.Add("nombre", producto.Nombre, DbType.String);
            parameter.Add("id_categoria", producto.IdCategoria, DbType.Int64);
            var result = BDManager.GetInstance.SetData(sql, parameter);
            return result;
        }    

    }
}