
using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;
using Microsoft.AspNetCore.SignalR;

namespace backend.servicios
{
    public static class CarritoCompraServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>(){
            const string sql = "select * from carrito_compra";
            return BDManager.GetInstance.GetData<T>(sql);
        }

        public static T ObtenerById<T>(int id){
            const string sql = "select * from carrito_compra where ID = @Id and estado_registro = 1";
            var parameter = new DynamicParameters();
            parameter.Add("id", id, DbType.Int64);
            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameter);
            return result.FirstOrDefault();                      
        }

        public static int InsertCarritoCompra(CarritoCompra carritoCompra){
            const string sql = "INSERT INTO [dbo].[CARRITO_COMPRA]([FECHA], [ID_USUARIO]) VALUES (@fecha, @id_usuario) ";
            var parameter = new DynamicParameters();
            parameter.Add("fecha", carritoCompra.Fecha, DbType.DateTime);
            parameter.Add("id_usuario", carritoCompra.IdUsuario, DbType.Int64);
            var result = BDManager.GetInstance.SetData(sql, parameter);
            return result;
        }    

    }
}