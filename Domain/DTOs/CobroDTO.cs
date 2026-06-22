using Domain.Enums;

namespace Domain.DTOs
{
    /// <summary>
    /// Resultado del popup de cobro.
    /// </summary>
    public class CobroDTO
    {
        public E_TipoComprobante TipoComprobante { get; set; }
        public E_FormaPago FormaPago { get; set; }
        public decimal MontoRecibido { get; set; }
        public decimal Vuelto { get; set; }
    }
}
