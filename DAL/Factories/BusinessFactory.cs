using DAL.Contracts.UnitOfWork;
using DAL.Implementations.SqlServer.UnitOfWork;
using Services.DAL.Contracts.UnitOfWork;
using System.Configuration;

namespace DAL.Factories
{
    /// <summary>
    /// Factory estática para la capa de negocio.
    /// Provee acceso al UnitOfWork de negocio con su propio connection string.
    /// </summary>
    public static class BusinessFactory
    {
        public static IUnitOfWork<IBusinessUnitOfWorkRepository> UnitOfWork { get; private set; }

        static BusinessFactory()
        {
            UnitOfWork = new BusinessUnitOfWork();
        }
    }
}
