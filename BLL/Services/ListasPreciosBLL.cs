using Domain.DTOs;
using Domain.BLL;
using System.Collections.Generic;
using System.Linq;
using Services.Domain.Enums;
using System;
using DAL.Factories;
using Domain;

namespace BLL.Services
{
    public sealed class ListasPreciosBLL
    {
        #region Singleton
        private readonly static ListasPreciosBLL _instance = new ListasPreciosBLL();

        public static ListasPreciosBLL Current
        {
            get { return _instance; }
        }

        private ListasPreciosBLL()
        {
        }
        #endregion

        public ResListaPreciosObtener ObtenerLista(ReqListaPreciosObtener req)
        {
            ResListaPreciosObtener res = new ResListaPreciosObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                var listas = context.Repositories.ListaPrecioRepository.GetAll();
                res.ListaPrecios = listas.Select(l => new ListaPrecioDTO {
                    IdListaPrecio = l.IdListaPrecio,
                    Descripcion = l.Descripcion,
                    Estado = l.Estado,
                    EsPredeterminada = l.EsPredeterminada,
                    VigenciaDesde = l.VigenciaDesde,
                    VigenciaHasta = l.VigenciaHasta
                }).ToList();
                res.Success = true;
            }

            return res;
        }

        public ResListaPrecioObtener Obtener(ReqListaPrecioObtener req)
        {
            ResListaPrecioObtener res = new ResListaPrecioObtener();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                var l = context.Repositories.ListaPrecioRepository.GetById(req.Id);
                res.Success = l != null;

                if (!res.Success)
                {
                    res.Message = "Lista de precios no encontrada.";
                    return res;
                }
                
                var dto = new ListaPrecioDTO {
                    IdListaPrecio = l.IdListaPrecio,
                    Descripcion = l.Descripcion,
                    Estado = l.Estado,
                    EsPredeterminada = l.EsPredeterminada,
                    VigenciaDesde = l.VigenciaDesde,
                    VigenciaHasta = l.VigenciaHasta
                };
                
                var reqArticulos = new ReqArticulosObtenerPorIds(req.Sesion) 
                { 
                    Ids = l.Items.Select(x => x.IdArticulo).Distinct().ToList() 
                };
                var articulosRes = ArticulosBLL.Current.ObtenerPorIds(reqArticulos);
                var listaArticulos = articulosRes.Success && articulosRes.Articulos != null ? articulosRes.Articulos : new List<Articulo>();

                foreach(var item in l.Items)
                {
                    var articulo = listaArticulos.FirstOrDefault(a => a.IdArticulo == item.IdArticulo);
                    dto.Items.Add(new ListaPrecioArticuloDTO
                    {
                        IdListaPrecioArticulo = item.IdListaPrecioArticulo,
                        IdListaPrecio = item.IdListaPrecio,
                        IdArticulo = item.IdArticulo,
                        Precio = item.Precio,
                        CodigoArticulo = articulo != null ? articulo.Codigo : string.Empty,
                        DescripcionArticulo = articulo != null ? articulo.Descripcion : "Articulo Inexistente"
                    });
                }
                res.ListaPrecio = dto;
            }

            return res;
        }

        public ResListaPrecioInsertar Insertar(ReqListaPrecioInsertar req)
        {
            ResListaPrecioInsertar res = new ResListaPrecioInsertar();

            var dominio = new ListaPrecio
            {
                IdListaPrecio = Guid.NewGuid(),
                Descripcion = req.ListaPrecio.Descripcion,
                Estado = E_Estados.Activo,
                EsPredeterminada = req.ListaPrecio.EsPredeterminada,
                VigenciaDesde = req.ListaPrecio.VigenciaDesde,
                VigenciaHasta = req.ListaPrecio.VigenciaHasta
            };

            foreach (var itemDto in req.ListaPrecio.Items)
            {
                dominio.Items.Add(new ListaPrecioArticulo
                {
                    IdListaPrecioArticulo = Guid.NewGuid(),
                    IdListaPrecio = dominio.IdListaPrecio,
                    IdArticulo = itemDto.IdArticulo,
                    Precio = itemDto.Precio
                });
            }

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ListaPrecioRepository.Add(dominio);
                context.SaveChanges();
                
                req.ListaPrecio.IdListaPrecio = dominio.IdListaPrecio;
                req.ListaPrecio.Estado = dominio.Estado;
                for (int i = 0; i < req.ListaPrecio.Items.Count; i++)
                {
                    req.ListaPrecio.Items[i].IdListaPrecioArticulo = dominio.Items[i].IdListaPrecioArticulo;
                    req.ListaPrecio.Items[i].IdListaPrecio = dominio.Items[i].IdListaPrecio;
                }
                
                res.ListaPrecio = req.ListaPrecio;
                res.Success = true;
                res.Message = "Lista de precios creada exitosamente.";
            }

            return res;
        }

        public ResListaPrecioModificar Modificar(ReqListaPrecioModificar req)
        {
            ResListaPrecioModificar res = new ResListaPrecioModificar();

            var dominio = new ListaPrecio
            {
                IdListaPrecio = req.ListaPrecio.IdListaPrecio,
                Descripcion = req.ListaPrecio.Descripcion,
                Estado = req.ListaPrecio.Estado,
                EsPredeterminada = req.ListaPrecio.EsPredeterminada,
                VigenciaDesde = req.ListaPrecio.VigenciaDesde,
                VigenciaHasta = req.ListaPrecio.VigenciaHasta
            };

            foreach (var itemDto in req.ListaPrecio.Items)
            {
                dominio.Items.Add(new ListaPrecioArticulo
                {
                    IdListaPrecioArticulo = itemDto.IdListaPrecioArticulo == Guid.Empty ? Guid.NewGuid() : itemDto.IdListaPrecioArticulo,
                    IdListaPrecio = dominio.IdListaPrecio,
                    IdArticulo = itemDto.IdArticulo,
                    Precio = itemDto.Precio
                });
            }

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ListaPrecioRepository.Update(dominio);
                context.SaveChanges();
                
                for (int i = 0; i < req.ListaPrecio.Items.Count; i++)
                {
                    req.ListaPrecio.Items[i].IdListaPrecioArticulo = dominio.Items[i].IdListaPrecioArticulo;
                    req.ListaPrecio.Items[i].IdListaPrecio = dominio.Items[i].IdListaPrecio;
                }
                
                res.ListaPrecio = req.ListaPrecio;
                res.Success = true;
                res.Message = "Lista de precios modificada exitosamente.";
            }

            return res;
        }

        public ResListaPrecioEliminar Eliminar(ReqListaPrecioEliminar req)
        {
            ResListaPrecioEliminar res = new ResListaPrecioEliminar();

            using (var context = BusinessFactory.UnitOfWork.Create(useTransaction: false))
            {
                // Validar que no sea la lista predeterminada
                if (context.Repositories.ListaPrecioRepository.EsPredeterminada(req.Id))
                {
                    res.Success = false;
                    res.Message = "No se puede eliminar la lista predeterminada.";
                    return res;
                }
            }

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ListaPrecioRepository.Remove(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Lista de precios eliminada exitosamente.";
            }

            return res;
        }

        public ResListaPrecioRestaurar Restaurar(ReqListaPrecioRestaurar req)
        {
            ResListaPrecioRestaurar res = new ResListaPrecioRestaurar();

            using (var context = BusinessFactory.UnitOfWork.Create())
            {
                context.Repositories.ListaPrecioRepository.Restore(req.Id);
                context.SaveChanges();
                res.Success = true;
                res.Message = "Lista de precios restaurada exitosamente.";
            }

            return res;
        }
    }
}
