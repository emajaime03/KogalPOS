using Services.Domain.Enums;
using System;

namespace Domain
{
    public class ConfiguracionLocal
    {
        public Guid IdConfig { get; set; }
        public decimal Loyalty_MontoRequerido { get; set; }
        public decimal Loyalty_PuntosOtorgados { get; set; }
        public bool Loyalty_IsEnabled { get; set; }
        public string Loyalty_ApiEndpoint { get; set; }
        public string Loyalty_ApiAccessKey { get; set; }

        public ConfiguracionLocal()
        {
            IdConfig = Guid.Empty;
            Loyalty_MontoRequerido = 0;
            Loyalty_PuntosOtorgados = 0;
            Loyalty_IsEnabled = false;
            Loyalty_ApiEndpoint = "";
            Loyalty_ApiAccessKey = "";
        }
    }
}
