namespace Productos.Domain.DTO
{
    public class ProductoRequestModificarDto
    {
        public int CodigoProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string ReferenciaInterna { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; }
        public bool Estado { get; set; }
        public int IdUnidadMedida { get; set; }
    }
}
