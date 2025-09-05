using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Productos.Domain.Entities;
using Productos.Domain.Interfaces.Repositories;
using Productos.Infrastructure.DBContext;
using System.Data;

namespace Productos.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DapperContext _context;
        private readonly ILogger<LoginRepository> _logger;

        public LoginRepository(DapperContext context, ILogger<LoginRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Usuario> GetUsuario(string usuario, string clave)
        {
            try
            {
                using var conn = _context.CreateConnection();

                _logger.LogInformation("Ejecutando SP LM_sp_ConsultarUsuario");

                var datosUsuario = await conn.QuerySingleOrDefaultAsync<Usuario>(
                    "LM_sp_ConsultarUsuario",
                    new { Usuario = usuario, Clave = clave },
                    commandType: CommandType.StoredProcedure
                );

                return datosUsuario;
            }
            catch (SqlException ex) when (ex.Number == 50000)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en SP LM_sp_ConsultarUsuario");
                throw;
            }
        }
    }
}
