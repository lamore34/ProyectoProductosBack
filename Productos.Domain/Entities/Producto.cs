namespace Productos.Domain.Entities
{
    public class Producto
    {
        public int CodigoProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string ReferenciaInterna { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public UnidadMedida UnidadMedida { get; set; } = new UnidadMedida();
    }
}
