using Services.DAL.Factories;
using Services.DAL.Implementations.SqlServer;
using Services.Domain;
using Services.Domain.BLL;
using Services.Domain.BLL.Base;
using Services.Domain.Enums;
using Services.Facade;
using Services.Facade.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Services
{
    internal class PatentesBLL
    {
        private readonly static PatentesBLL _instance = new PatentesBLL();

        public static PatentesBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private PatentesBLL()
        {
            //Implent here the initialization of your singleton
        }

        public ResPatentesObtener Obtener(ReqPatentesObtener req)
        {
            ResPatentesObtener res = new ResPatentesObtener();

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                res.Patentes = context.Repositories.PatenteRepository.GetAll();

                context.SaveChanges();
                    
            }

            return res;
        }

        public ResBase Sincronizar(ReqPatentesSincronizar req)
        {
            var res = new ResBase();

            using (var context = ApplicationFactory.UnitOfWork.Create())
            {
                var repo = context.Repositories.PatenteRepository;

                // 1) Patentes existentes en BD (me quedo con el código para comparar)
                var existentes = repo.GetAll()
                                     .Select(p => p.DataKey)
                                     .ToHashSet();

                // 2) Todas las del enum
                var enumPatentes = Enum.GetValues(typeof(E_Patentes))
                                       .Cast<E_Patentes>();

                // 3) Armo solo las faltantes
                var faltantes = enumPatentes
                    .Where(e => !existentes.Contains(e))
                    .Select(e => new Patente
                    {
                        Id = Guid.NewGuid(),
                        Estado = E_Estados.Activo,
                        DataKey = e,
                        Descripcion = e.ToString(),
                    })
                    .ToList();

                if (faltantes.Count > 0)
                {
                    // 4) Inserto en bloque
                    repo.AddMany(faltantes);
                }

                context.SaveChanges();
            }

            return res;
        }


    }
}
