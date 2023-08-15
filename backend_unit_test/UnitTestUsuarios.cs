using backend.connection;
using backend.entidades;
using backend.servicios;

namespace backend_unit_test
{
    public class UnitTestUsuarios
    {

        public UnitTestUsuarios()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=database-hermes.mssql.somee.com;packet size=4096;user id=hcayalo_SQLLogin_1;pwd=2itb6kw6gc;data source=database-hermes.mssql.somee.com;persist security info=False;initial catalog=database-hermes";
        }

        [Fact]
        public void Usuarios_Get_Verificar_NotNull()
        {
            var result = UsuariosServicios.ObtenerTodo<Usuarios>();
            Assert.NotNull(result);
        }

        [Fact]
        public void Usuarios_GetById_VerificarItem()
        {
            var result = UsuariosServicios.ObtenerById<Usuarios>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Usuarios_Insertar()
        {
            Usuarios usuarioTemp = new()
            {
                NombreCompleto = "Nombre Test",
                UserName = "UserName Test",
                Password = "Password Test"
            };

            var result = UsuariosServicios.InsertUsuarios(usuarioTemp);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Usuarios_Actualizar()
        {
            Usuarios usuarioTemp = new()
            {
                Id = 105,
                UserName = "untest1",
                NombreCompleto = "UserName Test1",
                Password = "Password Test1"
            };

            var result = UsuariosServicios.UpdateUsuarios(usuarioTemp);
            Assert.Equal(1, result);
        }


        [Fact]
        public void Usuarios_Eliminar()
        {
            var result = UsuariosServicios.DeleteUsuarios(105);
            Assert.Equal(1, result);
        }


    }

    

    

    



}