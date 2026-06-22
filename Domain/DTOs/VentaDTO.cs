using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    /// <summary>
    /// Venta enriquecida para historial y detalle.
    /// </summary>
    public class VentaDTO
    {
        public Guid IdVenta { get; set; }
        public int NroVenta { get; set; }
        public DateTime Fecha { get; set; }
        public E_EstadoVenta Estado { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        public Guid? IdCliente { get; set; }
        public string DescripcionCliente { get; set; }
        public Guid IdListaPrecio { get; set; }
        public string DescripcionListaPrecio { get; set; }
        public List<VentaItemDTO> Items { get; set; }

        // Datos del comprobante emitido
        public int NroDocumento { get; set; }
        public E_TipoComprobante TipoComprobante { get; set; }
        public E_FormaPago FormaPago { get; set; }

        public VentaDTO()
        {
            IdVenta = Guid.Empty;
            DescripcionCliente = string.Empty;
            DescripcionListaPrecio = string.Empty;
            Items = new List<VentaItemDTO>();
        }
    }
}
