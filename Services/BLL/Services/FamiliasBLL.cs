using Services.DAL.Factories;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Services
{
    public class FamiliasBLL
    {
        #region "Singleton"
        private readonly static FamiliasBLL _instance = new FamiliasBLL();

        public static FamiliasBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private FamiliasBLL()
        {
        }
        #endregion

        #region "OBTENER"
        public ResFamiliasObtener ObtenerLista(ReqFamiliasObtener req)
        {
            ResFamiliasObtener res = new ResFamiliasObtener();

            using (var context = ApplicationFactory.UnitOfWork.Create(false))
            {
                res.Familias = context.Repositories.FamiliaRepository.GetAll();
            }

            return res;
        }

        public ResFamiliaObtener Obtener(ReqFamiliaObtener req)
        {
            ResFamiliaObtener res = new ResFamiliaObtener();

            using (var context = ApplicationFactory.UnitOfWork.Create(false))
            {
                res.ListaFamilias = context.Repositories.FamiliaRepository.GetAll();
                res.ListaPatentes = context.Repositories.PatenteRepository.GetAll();

                if (req.Id != null && req.Id != Guid.Empty)
                {
                    res.Familia = context.Repositories.FamiliaRepository.GetById(req.Id);
                    // Excluir la familia actual y las que ya la contienen como hija (evitar ciclos)
                    res.ListaFamilias = res.ListaFamilias
                        .Where(f => !f.Accesos.Any(acceso => acceso.Id == res.Familia.Id) && f.Id != res.Familia.Id)
                        .ToList();
                }
            }

            return res;
        }
        #endregion

        #region "INSERTAR"
        public ResFamiliaInsertar Insertar(ReqFamiliaInsertar req)
        {
            ResFamiliaInsertar res = new ResFamiliaInsertar();

            // Validaciones
            if (string.IsNullOrWhiteSpace(req.Familia?.Descripcion))
            {
                res.Success = false;
                res.Message = "La descripción es requerida";
                return res;
            }

            // Validar que no haya ciclos potenciales
            if (req.FamiliasHijosIds != null && req.FamiliasHijosIds.Any())
            {
                string errorCiclo = ValidarCiclosRecursivos(req.Familia.Id, req.FamiliasHijosIds);
                if (!string.IsNullOrEmpty(errorCiclo))
                {
                    res.Success = false;
                    res.Message = errorCiclo;
                    return res;
                }
            }

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                req.Familia.Id = Guid.NewGuid();
                req.Familia.Estado = E_Estados.Activo;

                context.Repositories.FamiliaRepository.Add(req.Familia);

                // Agregar relaciones con familias hijos
                if (req.FamiliasHijosIds != null)
                {
                    foreach (var familiaHijoId in req.FamiliasHijosIds)
                    {
                        context.Repositories.FamiliaFamiliaRepository.Add(req.Familia.Id, familiaHijoId);
                    }
                }

                // Agregar relaciones con patentes
                if (req.PatentesIds != null)
                {
                    foreach (var patenteId in req.PatentesIds)
                    {
                        context.Repositories.FamiliaPatenteRepository.Add(req.Familia.Id, patenteId);
                    }
                }

                context.SaveChanges();

                res.Familia = req.Familia;
                res.Success = true;
                res.Message = "Familia creada exitosamente";
            }

            return res;
        }
        #endregion

        #region "MODIFICAR"
        public ResFamiliaModificar Modificar(ReqFamiliaModificar req)
        {
            ResFamiliaModificar res = new ResFamiliaModificar();

            // Validaciones
            if (req.Familia?.Id == null || req.Familia.Id == Guid.Empty)
            {
                res.Success = false;
                res.Message = "El ID de la familia es requerido";
                return res;
            }

            if (string.IsNullOrWhiteSpace(req.Familia.Descripcion))
            {
                res.Success = false;
                res.Message = "La descripción es requerida";
                return res;
            }

            // Validar que no haya ciclos potenciales
            if (req.FamiliasHijosIds != null && req.FamiliasHijosIds.Any())
            {
                string errorCiclo = ValidarCiclosRecursivos(req.Familia.Id, req.FamiliasHijosIds);
                if (!string.IsNullOrEmpty(errorCiclo))
                {
                    res.Success = false;
                    res.Message = errorCiclo;
                    return res;
                }
            }

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                // Actualizar la familia
                context.Repositories.FamiliaRepository.Update(req.Familia);

                // Eliminar relaciones anteriores
                context.Repositories.FamiliaFamiliaRepository.RemoveByFamilia(req.Familia.Id);
                context.Repositories.FamiliaPatenteRepository.RemoveByFamilia(req.Familia.Id);

                // Agregar nuevas relaciones con familias hijos
                if (req.FamiliasHijosIds != null)
                {
                    foreach (var familiaHijoId in req.FamiliasHijosIds)
                    {
                        context.Repositories.FamiliaFamiliaRepository.Add(req.Familia.Id, familiaHijoId);
                    }
                }

                // Agregar nuevas relaciones con patentes
                if (req.PatentesIds != null)
                {
                    foreach (var patenteId in req.PatentesIds)
                    {
                        context.Repositories.FamiliaPatenteRepository.Add(req.Familia.Id, patenteId);
                    }
                }

                context.SaveChanges();

                res.Familia = req.Familia;
                res.Success = true;
                res.Message = "Familia modificada exitosamente";
            }

            return res;
        }
        #endregion

        #region "ELIMINAR"
        public ResFamiliaEliminar Eliminar(ReqFamiliaEliminar req)
        {
            ResFamiliaEliminar res = new ResFamiliaEliminar();

            if (req.Id == Guid.Empty)
            {
                res.Success = false;
                res.Message = "El ID de la familia es requerido";
                return res;
            }

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                // Eliminación lógica (cambiar estado a Inactivo)
                context.Repositories.FamiliaRepository.Remove(req.Id);
                context.SaveChanges();

                res.Success = true;
                res.Message = "Familia eliminada exitosamente";
            }

            return res;
        }
        #endregion

        #region "RESTAURAR"
        public ResFamiliaRestaurar Restaurar(ReqFamiliaRestaurar req)
        {
            ResFamiliaRestaurar res = new ResFamiliaRestaurar();

            if (req.Id == Guid.Empty)
            {
                res.Success = false;
                res.Message = "El ID de la familia es requerido";
                return res;
            }

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                context.Repositories.FamiliaRepository.Restore(req.Id);
                context.SaveChanges();

                res.Success = true;
                res.Message = "Familia restaurada exitosamente";
            }

            return res;
        }
        #endregion

        #region "VALIDACIONES"
        /// <summary>
        /// Valida que no existan ciclos recursivos al asignar familias hijos.
        /// Evita que una familia sea su propio ancestro.
        /// </summary>
        private string ValidarCiclosRecursivos(Guid familiaId, List<Guid> familiasHijosIds)
        {
            if (familiasHijosIds.Contains(familiaId))
            {
                return "Una familia no puede ser hija de sí misma";
            }

            using (var context = ApplicationFactory.UnitOfWork.Create(false))
            {
                foreach (var hijoId in familiasHijosIds)
                {
                    // Verificar si el hijo potencial ya contiene a la familia actual en su árbol
                    var familiaHijo = context.Repositories.FamiliaRepository.GetById(hijoId);
                    if (familiaHijo != null && ContieneEnArbol(familiaHijo, familiaId, new HashSet<Guid>()))
                    {
                        return $"No se puede asignar '{familiaHijo.Descripcion}' como hija porque crearía un ciclo recursivo";
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Verifica recursivamente si una familia contiene a otra en su árbol de hijos.
        /// Usa un HashSet para evitar loops infinitos durante la verificación.
        /// </summary>
        private bool ContieneEnArbol(Familia familia, Guid idBuscado, HashSet<Guid> visitados)
        {
            if (visitados.Contains(familia.Id))
                return false; // Ya visitamos esta familia, evitamos loop

            visitados.Add(familia.Id);

            foreach (var acceso in familia.Accesos)
            {
                if (acceso.Id == idBuscado)
                    return true;

                if (acceso is Familia familiaHija)
                {
                    if (ContieneEnArbol(familiaHija, idBuscado, visitados))
                        return true;
                }
            }

            return false;
        }
        #endregion
    }
}
