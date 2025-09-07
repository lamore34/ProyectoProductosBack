using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Productos.Domain.DTO;
using Productos.Domain.Entities;
using Productos.Domain.Interfaces.Repositories;
using Productos.Infrastructure.DBContext;
using System.Data;

namespace Productos.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DapperContext _context;
        private readonly ILogger<ProductoRepository> _logger;

        public ProductoRepository(DapperContext context, ILogger<ProductoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IList<Producto>> GetProductos(int? codigo = null, string? nombre = null, bool? estado = null, int? idUnidadMedida = null)
        {
            try
            {
                using var conn = _context.CreateConnection();

                var parametros = new
                {
                    CodigoProducto = codigo,
                    Nombre = nombre,
                    Estado = estado,
                    IdUnidadMedida = idUnidadMedida
                };

                _logger.LogInformation("Ejecutando SP LM_sp_ConsultarProductos");

                var productos = await conn.QueryAsync<Producto, UnidadMedida, Producto>(
                    "LM_sp_ConsultarProductos",
                    (producto, unidad) =>
                    {
                        producto.UnidadMedida = unidad;
                        return producto;
                    },
                    param: parametros,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                );

                return productos.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en SP LM_sp_ConsultarProductos");
                throw;
            }
        }

        public async Task<bool> Insert(ProductoRequestCrearDto producto)
        {
            try
            {
                using var conn = _context.CreateConnection();

                _logger.LogInformation("Ejecutando SP LM_sp_CrearProducto");

                await conn.ExecuteAsync("LM_sp_CrearProducto", producto, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (SqlException ex) when (ex.Number == 50000) 
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en SP LM_sp_CrearProducto");
                throw;
            }
        }

        public async Task<bool> Update(ProductoRequestModificarDto producto)
        {
            try
            {
                using var conn = _context.CreateConnection();

                _logger.LogInformation("Ejecutando SP LM_sp_ActualizarProducto");

                await conn.ExecuteAsync("LM_sp_ActualizarProducto", producto, commandType: CommandType.StoredProcedure);
                return true;

            }
            catch (SqlException ex) when (ex.Number == 50000)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en SP LM_sp_ActualizarProducto");
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int codigo)
        {
            try
            {
                using var conn = _context.CreateConnection();

                _logger.LogInformation("Ejecutando SP LM_sp_EliminarProducto");

                await conn.ExecuteAsync("LM_sp_EliminarProducto", new { CodigoProducto = codigo }, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (SqlException ex) when (ex.Number == 50000)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en SP LM_sp_EliminarProducto");
                throw new Exception(ex.Message);
            }
        }
    }
}
