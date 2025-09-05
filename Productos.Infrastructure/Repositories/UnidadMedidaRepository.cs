using Dapper;
using Microsoft.Extensions.Logging;
using Productos.Domain.Entities;
using Productos.Domain.Interfaces.Repositories;
using Productos.Infrastructure.DBContext;
using System.Data;

namespace Productos.Infrastructure.Repositories
{
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        private readonly DapperContext _context;
        private readonly ILogger<UnidadMedidaRepository> _logger;

        public UnidadMedidaRepository(DapperContext context, ILogger<UnidadMedidaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IList<UnidadMedida>> GetAll()
        {
            try
            {
                using var conn = _context.CreateConnection();

                _logger.LogInformation("Ejecutando SP LM_sp_ConsultarUnidadesMedida");

                var datos = await conn.QueryAsync<UnidadMedida>(
                    "LM_sp_ConsultarUnidadesMedida",                    
                    commandType: CommandType.StoredProcedure                    
                );

                return datos.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en SP LM_sp_ConsultarUnidadesMedida");
                throw;
            }
        }
    }
}
