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
        private readonly static int servicesPersistance = ApplicationSettings.Current.ServicesPersistance;

        /// <summary>
        /// Actualizo todos los repositorios a patrón UnitOfWork ya que todos los repositorios estarán contenidos
        /// dentro de un contexto transaccional
        /// </summary>
        public static IUnitOfWork<IUnitOfWorkRepository> UnitOfWork { get; private set; }

        static ApplicationFactory()
        {
            switch (servicesPersistance)
            {
                case (int)PersistanceType.SqlServer:
                    UnitOfWork = new Implementations.SqlServer.UnitOfWork.UnitOfWorkSqlServer();
                    break;
                case (int)PersistanceType.PlainText:
                    //CustomerRepository = new DAL.Implementations.PlainText.CustomerRepository();
                    break;
                case (int)PersistanceType.Memory:
                    //AlmacenRepository = new DAL.Implementations.Memory.AlmacenRepository();
                    //MovimientoRepository = new DAL.Implementations.Memory.MovimientoRepository();
                    break;
            }
        }

        enum PersistanceType
        {
            SqlServer,
            PlainText,
            Memory
        }
    }
}
