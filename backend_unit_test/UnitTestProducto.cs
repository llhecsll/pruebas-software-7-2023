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
    //--- Unit Test Producto
    //
    public class UnitTestProducto
    {

        public UnitTestProducto()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=database-hermes.mssql.somee.com;packet size=4096;user id=hcayalo_SQLLogin_1;pwd=2itb6kw6gc;data source=database-hermes.mssql.somee.com;persist security info=False;initial catalog=database-hermes";
        }

        [Fact]
        public void Producto_Get_Verificar_NotNull()
        {
            var result = ProductoServicios.ObtenerTodo<Producto>();
            Assert.NotNull(result);
        }

        [Fact]
        public void Producto_GetById_VerificarItem()
        {
            var result = ProductoServicios.ObtenerById<Producto>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Producto_Insertar()
        {
            Producto productoTemp = new()
            {
                Nombre = "Producto Test",
                IdCategoria = 1
            };

            var result = ProductoServicios.InsertProducto(productoTemp);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Producto_Actualizar()
        {
            Producto productoTemp = new()
            {
                Id = 104,
                Nombre = "Producto Test",
                IdCategoria = 2
            };

            var result = ProductoServicios.UpdateProducto(productoTemp);
            Assert.Equal(1, result);
        }


        [Fact]
        public void Procduto_Eliminar()
        {
            var result = ProductoServicios.DeleteProducto(104);
            Assert.Equal(1, result);
        }

    }

}
