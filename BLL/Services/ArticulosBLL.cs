using DAL.Factories;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public sealed class ArticulosBLL
    {
        #region Singleton
        private readonly static ArticulosBLL _instance = new ArticulosBLL();

        public static ArticulosBLL Current
        {
            get { return _instance; }
        }

        private ArticulosBLL()
        {
        }
        #endregion

        public ResArticulosObtener ObtenerLista(ReqArticulosObtener req)
        {
            ResArticulosObtener res = new ResArticulosObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Articulos = context.Repositories.ArticuloRepository.GetAll();
                res.Success = true;
            }

            return res;
        }

        public ResArticulosObtenerPorIds ObtenerPorIds(ReqArticulosObtenerPorIds req)
        {
            ResArticulosObtenerPorIds res = new ResArticulosObtenerPorIds();

            if (req.Ids == null || req.Ids.Count == 0)
            {
                res.Articulos = new System.Collections.Generic.List<Articulo>();
                res.Success = true;
                return res;
            }

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Articulos = new System.Collections.Generic.List<Articulo>(context.Repositories.ArticuloRepository.GetByIds(req.Ids));
                res.Success = true;
            }

            return res;
        }

        public ResArticuloObtener Obtener(ReqArticuloObtener req)
        {
            ResArticuloObtener res = new ResArticuloObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Articulo = context.Repositories.ArticuloRepository.GetById(req.Id);
                res.Success = res.Articulo != null;

                if (!res.Success)
                    res.Message = "Artículo no encontrado.";
            }

            return res;
        }

        /// <summary>
        /// Verifica, contra el stock actual en BD, qué artículos no tienen stock suficiente para lo pedido.
        /// </summary>
        public ResArticulosVerificarStock VerificarStock(ReqArticulosVerificarStock req)
        {
            ResArticulosVerificarStock res = new ResArticulosVerificarStock { Faltantes = new List<string>() };

            var cantidades = req.Cantidades ?? new Dictionary<Guid, decimal>();
            if (cantidades.Count == 0)
            {
                res.Success = true;
                return res;
            }

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                var articulos = context.Repositories.ArticuloRepository
                    .GetByIds(cantidades.Keys.ToList())
                    .ToList();

                foreach (var kv in cantidades)
                {
                    var art = articulos.FirstOrDefault(a => a.IdArticulo == kv.Key);
                    decimal disponible = art != null ? art.StockActual : 0;
                    if (kv.Value > disponible)
                        res.Faltantes.Add(art != null ? art.Descripcion : kv.Key.ToString());
                }

                res.Success = true;
            }

            return res;
        }

        public ResArticuloObtenerCatalogos ObtenerCatalogosAsignados(ReqArticuloObtenerCatalogos req)
        {
            ResArticuloObtenerCatalogos res = new ResArticuloObtenerCatalogos();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.IdsCatalogos = context.Repositories.CatalogoRepository.GetCatalogosDeArticulo(req.IdArticulo);
                res.Success = true;
            }

            return res;
        }

        public ResArticuloInsertar Insertar(ReqArticuloInsertar req)
        {
            ResArticuloInsertar res = new ResArticuloInsertar();

            req.Articulo.IdArticulo = Guid.NewGuid();
            req.Articulo.Estado = E_Estados.Activo;
            req.Articulo.StockActual = 0;

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ArticuloRepository.Add(req.Articulo);
                context.Repositories.CatalogoRepository.ReasignarCatalogosDeArticulo(
                    req.Articulo.IdArticulo,
                    req.IdsCatalogos ?? new System.Collections.Generic.List<Guid>());
                context.SaveChanges();
                res.Articulo = req.Articulo;
                res.Success = true;
                res.Message = "Artículo creado exitosamente.";
            }

            return res;
        }

        public ResArticuloModificar Modificar(ReqArticuloModificar req)
        {
            ResArticuloModificar res = new ResArticuloModificar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ArticuloRepository.Update(req.Articulo);
                context.Repositories.CatalogoRepository.ReasignarCatalogosDeArticulo(
                    req.Articulo.IdArticulo,
                    req.IdsCatalogos ?? new System.Collections.Generic.List<Guid>());
                context.SaveChanges();
                res.Articulo = req.Articulo;
                res.Success = true;
                res.Message = "Artículo modificado exitosamente.";
            }

            return res;
        }

        public ResArticuloEliminar Eliminar(ReqArticuloEliminar req)
        {
            ResArticuloEliminar res = new ResArticuloEliminar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ArticuloRepository.Remove(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Artículo eliminado exitosamente.";
            }

            return res;
        }

        public ResArticuloRestaurar Restaurar(ReqArticuloRestaurar req)
        {
            ResArticuloRestaurar res = new ResArticuloRestaurar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ArticuloRepository.Restore(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Artículo restaurado exitosamente.";
            }

            return res;
        }
    }
}
