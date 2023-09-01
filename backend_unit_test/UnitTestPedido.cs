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
    public class UnitTestPedido
    {
        public UnitTestPedido() {
            BDManager.GetInstance.ConnectionString = "workstation id=database-hermes.mssql.somee.com;packet size=4096;user id=hcayalo_SQLLogin_1;pwd=2itb6kw6gc;data source=database-hermes.mssql.somee.com;persist security info=False;initial catalog=database-hermes";

        }

        [Fact]
        public void Pedido_Get_Verificar_NotNull()
        {
            var result = PedidoServicios.ObtenerTodo<Pedido>();
            Assert.NotNull(result);
        }

        [Fact]
        public void Pedido_GetById_VerificarItem()
        {
            var result = PedidoServicios.ObtenerById<Pedido>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Pedido_Insertar()
        {
            Pedido pedidoTemp = new()
            {
                IdUsuario = 10,
                FechaPedido = DateTime.Now, 
            };
            var result = PedidoServicios.InsertPedido(pedidoTemp);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Pedido_Actualizar()
        {
            Pedido pedidoTemp = new()
            {
                Id = 1,
                IdUsuario = 10,
                FechaPedido = DateTime.Now,
            };

            var result = PedidoServicios.UpdatePedido(pedidoTemp);
            Assert.Equal(1, result);
        }


        [Fact]
        public void Pedido_Eliminar()
        {
            var result = PedidoServicios.DeletePedido(103);
            Assert.Equal(1, result);
        }

    }
}
