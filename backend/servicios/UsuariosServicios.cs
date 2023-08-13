
using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;
using Microsoft.AspNetCore.SignalR;

namespace backend.servicios
{
    public static class UsuariosServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>(){
            const string sql = "select * from usuarios";
            return BDManager.GetInstance.GetData<T>(sql);
        }

        public static T ObtenerById<T>(int id){
            const string sql = "select * from usuarios where ID = @Id and estado_registro = 1";
            var parameter = new DynamicParameters();
            parameter.Add("id", id, DbType.Int64);
            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameter);
            return result.FirstOrDefault();                      
        }

        public static int InsertUsuarios(Usuarios usuarios){
            const string sql = "INSERT INTO [dbo].[USUARIOS]([USER_NAME], [NOMBRE_COMPLETO], [PASSWORD]) VALUES (@user_name, @nombre_completo, @password)";
            var parameter = new DynamicParameters();
            parameter.Add("user_name", usuarios.UserName, DbType.String);
            parameter.Add("nombre_completo", usuarios.NombreCompleto, DbType.String);
            parameter.Add("password", usuarios.Password, DbType.String);
            var result = BDManager.GetInstance.SetData(sql, parameter);
            return result;
        }    

    }
}