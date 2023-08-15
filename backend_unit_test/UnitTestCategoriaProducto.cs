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
    //--- UnitTestCategoriaProducto
    //
    public class UnitTestCategoriaProducto
    {

        public UnitTestCategoriaProducto()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=database-hermes.mssql.somee.com;packet size=4096;user id=hcayalo_SQLLogin_1;pwd=2itb6kw6gc;data source=database-hermes.mssql.somee.com;persist security info=False;initial catalog=database-hermes";
        }

        [Fact]
        public void CategoriaProducto_Get_Verificar_NotNull()
        {
            var result = CategoriaProductoServicios.ObtenerTodo<CategoriaProducto>();
            Assert.NotNull(result);
        }

        [Fact]
        public void CategoriaProducto_GetById_VerificarItem()
        {
            var result = CategoriaProductoServicios.ObtenerById<CategoriaProducto>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void CategoriaProducto_Insertar()
        {
            CategoriaProducto categoriaProductoTemp = new()
            {
                Nombre = "Nombre Test"
            };

            var result = CategoriaProductoServicios.InsertCategoriaProducto(categoriaProductoTemp);
            Assert.Equal(1, result);
        }

        [Fact]
        public void CategoriaProducto_Actualizar()
        {
            CategoriaProducto categoriaProductoTemp = new()
            {
                Id = 105,
                Nombre = "Nombre Test Edit"
            };

            var result = CategoriaProductoServicios.UpdateCategoriaProducto(categoriaProductoTemp);
            Assert.Equal(1, result);
        }


        [Fact]
        public void CategoriaProducto_Eliminar()
        {
            var result = CategoriaProductoServicios.DeleteCategoriaProducto(105);
            Assert.Equal(1, result);
        }
    }
}
