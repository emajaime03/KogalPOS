using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade.Observer
{
    public interface IObserver
    {
        void Update<T>(T value, object data = null);  // Método de actualización que llama el sujeto
    }
}
