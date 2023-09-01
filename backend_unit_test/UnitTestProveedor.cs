using backend.connection;
using backend.entidades;
using backend.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_unit_test
{
    public class UnitTestProveedor
    {
        public UnitTestProveedor()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=database-hermes.mssql.somee.com;packet size=4096;user id=hcayalo_SQLLogin_1;pwd=2itb6kw6gc;data source=database-hermes.mssql.somee.com;persist security info=False;initial catalog=database-hermes";
        }

        [Fact]
        public void Proveedor_Get_Verificar_NotNull()
        {
            var result = ProveedorServicios.ObtenerTodo<Proveedor>();
            Assert.NotNull(result);
        }

        [Fact]
        public void Proveedor_GetById_VerificarItem()
        {
            var result = ProveedorServicios.ObtenerById<Proveedor>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Proveedor_Insertar()
        {
            Proveedor proveedorTemp = new()
            {

                RazonSocial = "RazonSocial Test",
                Nit = "7777013",
                Direccion = "Direccion Test",
                NombreProveedor = "NombreProveedor Test",
                Telefono = "7777777",
                Email = "test@email.com",


            };

            var result = ProveedorServicios.InsertProveedor(proveedorTemp);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Proveedor_Actualizar()
        {
            Proveedor proveedorTemp = new()
            {
                Id = 1,
                RazonSocial = "RazonSocial Test",
                Nit = "7777013",
                Direccion = "Direccion Test",
                NombreProveedor = "NombreProveedor Test",
                Telefono = "7777777",
                Email = "test@email.com",
            };

            var result = ProveedorServicios.UpdateProveedor(proveedorTemp);
            Assert.Equal(1, result);
        }


        [Fact]
        public void Proveedor_Eliminar()
        {
            var result = ProveedorServicios.DeleteProveedor(54);
            Assert.Equal(1, result);
        }

    }
}
