using Services.DAL.Contracts;
using DAL.Implementations.SqlServer;
using Domain;

namespace DAL.Contracts.UnitOfWork
{
    /// <summary>
    /// Contenedor de repositorios de negocio.
    /// Cada nuevo repositorio de negocio se agrega como propiedad aquí.
    /// </summary>
    public interface IBusinessUnitOfWorkRepository
    {
        IGenericRepository<Proveedor> ProveedorRepository { get; }
        IArticulosRepository ArticuloRepository { get; }
        IGenericRepository<Cliente> ClienteRepository { get; }
        IGenericRepository<MovimientoStock> MovimientoStockRepository { get; }
        IListaPreciosRepository ListaPrecioRepository { get; }
        IGenericRepository<Premio> PremiosRepository { get; }
        IConfiguracionesRepository<ConfiguracionLocal> ConfiguracionLocalRepository { get; }
        ILoyaltyRepository LoyaltyRepository { get; }
    }
}
