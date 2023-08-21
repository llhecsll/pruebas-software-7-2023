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
    //
    //
    // --- UnitTestCarritoCompra
    //
    public class UnitTestCarritoCompra
    {

        public UnitTestCarritoCompra()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=database-hermes.mssql.somee.com;packet size=4096;user id=hcayalo_SQLLogin_1;pwd=2itb6kw6gc;data source=database-hermes.mssql.somee.com;persist security info=False;initial catalog=database-hermes";
        }

        [Fact]
        public void CarritoCompra_Get_Verificar_NotNull()
        {
            var result = CarritoCompraServicios.ObtenerTodo<CarritoCompra>();
            Assert.NotNull(result);
        }

        [Fact]
        public void CarritoCompra_GetById_VerificarItem()
        {
            var result = CarritoCompraServicios.ObtenerById<CarritoCompra>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void CarritoCompra_Insertar()
        {
            CarritoCompra carritoCompraTemp = new()
            {
                Fecha = DateTime.Now,
                IdUsuario = 101

            };

            var result = CarritoCompraServicios.InsertCarritoCompra(carritoCompraTemp);
            Assert.Equal(1, result);
        }

        [Fact]
        public void CarritoCompra_Actualizar()
        {
            CarritoCompra carritoCompraTemp = new()
            {
                Id = 105,
                Fecha = DateTime.Now,
                IdUsuario = 101
            };

            var result = CarritoCompraServicios.UpdateCarritoCompra(carritoCompraTemp);
            Assert.Equal(1, result);
        }


        [Fact]
        public void CarritoCompra_Eliminar()
        {
            var result = CarritoCompraServicios.DeleteCarritoCompra(105);
            Assert.Equal(1, result);
        }


    }
}
