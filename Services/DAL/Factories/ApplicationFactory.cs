using Services.DAL.Contracts.UnitOfWork;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Factories
{
    public static class ApplicationFactory
    {
        private static string servicesPersistance = ApplicationSettings.Current.ServicesPersistance;

        /// <summary>
        /// Actualizo todos los repositorios a patrón UnitOfWork ya que todos los repositorios estarán contenidos
        /// dentro de un contexto transaccional
        /// </summary>
        public static IUnitOfWork UnitOfWork { get; private set; }

        static ApplicationFactory()
        {
            if (servicesPersistance == "sqlserver")
            {
                UnitOfWork = new Implementations.SqlServer.UnitOfWork.UnitOfWorkSqlServer();
            }
            else if (servicesPersistance == "plaintext")
            {
                //CustomerRepository = new DAL.Implementations.PlainText.CustomerRepository();
            }
            else if (servicesPersistance == "memory")
            {
                //AlmacenRepository = new DAL.Implementations.Memory.AlmacenRepository();
                //MovimientoRepository = new DAL.Implementations.Memory.MovimientoRepository();
            }
        }
    }
}
