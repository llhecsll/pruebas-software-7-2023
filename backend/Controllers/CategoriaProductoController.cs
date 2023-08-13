using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;
public class CategoriaProductoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;

    public CategoriaProductoController(IConfiguration configuration)
    {
        _configuration = configuration;
        // connectionString = _configuration["workstation id=database-hermes.mssql.somee.com;packet size=4096;user id=hcayalo_SQLLogin_1;pwd=2itb6kw6gc;data source=database-hermes.mssql.somee.com;persist security info=False;initial catalog=database-hermes"];
        // BDManager.GetInstance.ConnectionString = connectionString;
        BDManager.GetInstance.ConnectionString = "workstation id=database-hermes.mssql.somee.com;packet size=4096;user id=hcayalo_SQLLogin_1;pwd=2itb6kw6gc;data source=database-hermes.mssql.somee.com;persist security info=False;initial catalog=database-hermes";
    }

    [HttpGet]
    [Route("GetAllCategoriaProducto")]
    public IActionResult GetAllCategoriaProducto()
    {
        try
        {
            var result = CategoriaProductoServicios.ObtenerTodo<CategoriaProducto>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}