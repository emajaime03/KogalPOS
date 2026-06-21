using DAL.Factories;
using Domain;
using Domain.BLL;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public sealed class CatalogosBLL
    {
        #region Singleton
        private readonly static CatalogosBLL _instance = new CatalogosBLL();

        public static CatalogosBLL Current
        {
            get { return _instance; }
        }

        private CatalogosBLL() { }
        #endregion

        public ResCatalogosObtener ObtenerLista(ReqCatalogosObtener req)
        {
            ResCatalogosObtener res = new ResCatalogosObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Catalogos = context.Repositories.CatalogoRepository.GetAll();
                res.Success = true;
            }

            return res;
        }

        public ResCatalogoObtener Obtener(ReqCatalogoObtener req)
        {
            ResCatalogoObtener res = new ResCatalogoObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.Catalogo = context.Repositories.CatalogoRepository.GetById(req.Id);
                res.Success = res.Catalogo != null;

                if (!res.Success)
                    res.Message = "Catálogo no encontrado.";
            }

            return res;
        }

        public ResCatalogoObtenerArticulos ObtenerArticulosAsignados(ReqCatalogoObtenerArticulos req)
        {
            ResCatalogoObtenerArticulos res = new ResCatalogoObtenerArticulos();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                res.IdsArticulos = context.Repositories.CatalogoRepository.GetArticulosAsignados(req.IdCatalogo);
                res.Success = true;
            }

            return res;
        }

        public ResCatalogoInsertar Insertar(ReqCatalogoInsertar req)
        {
            ResCatalogoInsertar res = new ResCatalogoInsertar();

            req.Catalogo.IdCatalogo = Guid.NewGuid();
            req.Catalogo.Estado = E_Estados.Activo;

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.CatalogoRepository.Add(req.Catalogo);
                context.Repositories.CatalogoRepository.ReasignarArticulos(
                    req.Catalogo.IdCatalogo,
                    req.IdsArticulos ?? new System.Collections.Generic.List<Guid>());
                context.SaveChanges();
                res.Catalogo = req.Catalogo;
                res.Success = true;
                res.Message = "Catálogo creado exitosamente.";
            }

            return res;
        }

        public ResCatalogoModificar Modificar(ReqCatalogoModificar req)
        {
            ResCatalogoModificar res = new ResCatalogoModificar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.CatalogoRepository.Update(req.Catalogo);
                context.Repositories.CatalogoRepository.ReasignarArticulos(
                    req.Catalogo.IdCatalogo,
                    req.IdsArticulos ?? new System.Collections.Generic.List<Guid>());
                context.SaveChanges();
                res.Catalogo = req.Catalogo;
                res.Success = true;
                res.Message = "Catálogo modificado exitosamente.";
            }

            return res;
        }

        public ResCatalogoEliminar Eliminar(ReqCatalogoEliminar req)
        {
            ResCatalogoEliminar res = new ResCatalogoEliminar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.CatalogoRepository.Remove(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Catálogo eliminado exitosamente.";
            }

            return res;
        }

        public ResCatalogoRestaurar Restaurar(ReqCatalogoRestaurar req)
        {
            ResCatalogoRestaurar res = new ResCatalogoRestaurar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.CatalogoRepository.Restore(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Catálogo restaurado exitosamente.";
            }

            return res;
        }
    }
}
