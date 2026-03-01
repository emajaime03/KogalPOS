using Services.DAL.Contracts;

namespace DAL.Contracts
{
    /// <summary>
    /// Contenedor de repositorios de negocio.
    /// Cada nuevo repositorio de negocio se agrega como propiedad aquí.
    /// </summary>
    public interface IBusinessUnitOfWorkRepository
    {
        IGenericRepository<Domain.Proveedor> ProveedorRepository { get; }
        IGenericRepository<Domain.Articulo> ArticuloRepository { get; }
    }
}
