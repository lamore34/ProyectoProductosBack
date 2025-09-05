﻿namespace Productos.Domain.DTO
{
    public class ProductoDto
    {
        public int CodigoProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string ReferenciaInterna { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; }
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
    }
}
