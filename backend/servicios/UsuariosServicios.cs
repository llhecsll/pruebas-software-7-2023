
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
            // const string sql = "select * from usuarios";
            // return BDManager.GetInstance.GetData<T>(sql);
            const string storedProcedure = "ObtenerTodosLosUsuarios";
            var parameters = new DynamicParameters(); // Agrega parámetros si es necesario
            return BDManager.GetInstance.SPGetData<T>(storedProcedure, parameters);
        }

        public static T ObtenerById<T>(int id){
            // const string sql = "select * from usuarios where ID = @Id and estado_registro = 1";
            const string storedProcedureName = "GetUsuariosById";
            var parameter = new DynamicParameters();
            parameter.Add("id", id, DbType.Int64);
            // var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameter);
            var result =  BDManager.GetInstance.SPGetDataWithParameters<T>(storedProcedureName, parameter);
            return result.FirstOrDefault();                      
        }

        public static int InsertUsuarios(Usuarios usuarios){
            // const string sql = "INSERT INTO [dbo].[USUARIOS]([USER_NAME], [NOMBRE_COMPLETO], [PASSWORD]) VALUES (@user_name, @nombre_completo, @password)";
            const string storedProcedure = "InsertUsuario";
            var parameter = new DynamicParameters();
            parameter.Add("user_name", usuarios.UserName, DbType.String);
            parameter.Add("nombre_completo", usuarios.NombreCompleto, DbType.String);
            parameter.Add("password", usuarios.Password, DbType.String);            
            // var result = BDManager.GetInstance.SetData(sql, parameter);
            var result = BDManager.GetInstance.SPSetData(storedProcedure, parameter);
            return result;
        }    

         public static int UpdateUsuarios(Usuarios usuarios)
        {
            // const string sql = "UPDATE [dbo].[USUARIOS] SET [USER_NAME] = @user_name, [NOMBRE_COMPLETO] = @nombre_completo, [PASSWORD] = @password WHERE [ID] = @id";
            const string storedProcedure = "UpdateUsuario";
            var parameter = new DynamicParameters();
            parameter.Add("id", usuarios.Id, DbType.Int32);
            parameter.Add("user_name", usuarios.UserName, DbType.String);
            parameter.Add("nombre_completo", usuarios.NombreCompleto, DbType.String);
            parameter.Add("password", usuarios.Password, DbType.String);
            // var result = BDManager.GetInstance.SetData(sql, parameter);
            var result = BDManager.GetInstance.SPSetData(storedProcedure, parameter);
            return result;
        }

        public static int DeleteUsuarios(int id)
        {
            // const string sql = "DELETE FROM [dbo].[USUARIOS] WHERE [ID] = @id";
            const string storedProcedure = "DeleteUsuario";
            var parameter = new DynamicParameters();
            parameter.Add("id", id, DbType.Int32);
            // var result = BDManager.GetInstance.SetData(sql, parameter);
             var result = BDManager.GetInstance.SPSetData(storedProcedure, parameter);
            return result;
        }   


    }
}