
using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;
using Microsoft.AspNetCore.SignalR;

namespace backend.servicios
{
    public static class DetalleCarritoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>(){
            const string sql = "select * from DETALLE_CARRITO";
            return BDManager.GetInstance.GetData<T>(sql);
        }

        public static T ObtenerById<T>(int id){
            const string sql = "select * from DETALLE_CARRITO where ID = @Id and estado_registro = 1";
            var parameter = new DynamicParameters();
            parameter.Add("id", id, DbType.Int64);
            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameter);
            return result.FirstOrDefault();                      
        }

        public static int InsertDetalleCarrito(DetalleCarrito detalleCarrito){
            const string sql = "INSERT INTO [dbo].[DETALLE_CARRITO]([CANTIDAD], [ID_PRODUCTO], [ID_CARRITO_COMPRA]) VALUES (@cantidad, @id_producto, @id_carrito_compra)";
            var parameter = new DynamicParameters();
            parameter.Add("cantidad", detalleCarrito.Cantidad, DbType.Int64);
            parameter.Add("id_producto", detalleCarrito.IdProducto, DbType.Int64);
            parameter.Add("id_carrito_compra", detalleCarrito.IdCarritoCompra, DbType.Int64);
            var result = BDManager.GetInstance.SetData(sql, parameter);
            return result;
        }    

    }
}