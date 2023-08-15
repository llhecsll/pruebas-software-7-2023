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
    //-- Unit test  DetalleCarrito
    //

    public class UnitTestDetalleCarrito
    {
        public UnitTestDetalleCarrito()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=database-hermes.mssql.somee.com;packet size=4096;user id=hcayalo_SQLLogin_1;pwd=2itb6kw6gc;data source=database-hermes.mssql.somee.com;persist security info=False;initial catalog=database-hermes";
        }

        [Fact]
        public void DetalleCarrito_Get_Verificar_NotNull()
        {
            var result = DetalleCarritoServicios.ObtenerTodo<DetalleCarrito>();
            Assert.NotNull(result);
        }

        [Fact]
        public void DetalleCarrito_GetById_VerificarItem()
        {
            var result = DetalleCarritoServicios.ObtenerById<DetalleCarrito>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void DetalleCarrito_Insertar()
        {
            DetalleCarrito detalleCarritoTemp = new()
            {
                Cantidad = 1,
                IdProducto = 1,
                IdCarritoCompra = 1
            };

            var result = DetalleCarritoServicios.InsertDetalleCarrito(detalleCarritoTemp);
            Assert.Equal(1, result);
        }

        [Fact]
        public void DetalleCarrito_Actualizar()
        {
            DetalleCarrito detalleCarritoTemp = new()
            {
                Id = 105,
                Cantidad = 1,
                IdProducto = 1,
                IdCarritoCompra = 1
            };

            var result = DetalleCarritoServicios.UpdateDetalleCarrito(detalleCarritoTemp);
            Assert.Equal(1, result);
        }


        [Fact]
        public void DetalleCarrito_Eliminar()
        {
            var result = DetalleCarritoServicios.DeleteDetalleCarrito(105);
            Assert.Equal(1, result);
        }
    }
}
