using Domain;
using Services.DAL.Contracts;
using System;
using System.Collections.Generic;

namespace DAL.Contracts
{
    public interface ICatalogosRepository : IGenericRepository<Catalogo>
    {
        List<Guid> GetArticulosAsignados(Guid idCatalogo);
        void ReasignarArticulos(Guid idCatalogo, List<Guid> idsArticulos);

        List<Guid> GetCatalogosDeArticulo(Guid idArticulo);
        void ReasignarCatalogosDeArticulo(Guid idArticulo, List<Guid> idsCatalogos);
    }
}
