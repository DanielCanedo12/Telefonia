using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TelefoniaWooza.Domain.Entities;
using TelefoniaWooza.Domain.Enumerators;
using TelefoniaWooza.Domain.Interfaces.Repositories;
using TelefoniaWooza.Infra.Data.Contexts;

namespace TelefoniaWooza.Infra.Data.Repositories
{
    public class PlanoRepository : RepositoryBase<Plano>, IPlanoRepository
    {
        public PlanoRepository(TelefoniaContext db) : base(db)
        {
           
        }

        public override IEnumerable<Plano> Get()
        {
            return ((TelefoniaContext)Context).Planos
                            .Include(x => x.DDDPlanos)
                                .ThenInclude(y => y.Ddd);
        }


        public IEnumerable<Plano> GetByTipo(string ddd, TipoPlano tipo)
        {
            try
            {
                DDD dDD = ((TelefoniaContext)Context).DDDs.Where(x => x.Sigla == ddd).First();
                if (ddd is null)
                {
                    return null;
                }

                return ((TelefoniaContext)Context).Planos.Where(x => x.DDDPlanos.Any(y => y.DDDId == dDD.Id))
                                .Where(z => z.Tipo == tipo)
                                .Include(x => x.DDDPlanos)
                                    .ThenInclude(y => y.Ddd);
            }
            catch
            {
                return null;
            }
        }


        public IEnumerable<Plano> GetByOperadora(string ddd, string operadora)
        {
            try
            {
                DDD dDD = ((TelefoniaContext)Context).DDDs.Where(x => x.Sigla == ddd).First();
                if (ddd is null)
                {
                    return null;
                }

                return ((TelefoniaContext)Context).Planos.Where(x => x.DDDPlanos.Any(y => y.DDDId == dDD.Id))
                                .Where(z => z.Operadora.ToLower() == operadora.ToLower())
                                .Include(x => x.DDDPlanos)
                                    .ThenInclude(y => y.Ddd);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Plano> GetByPlano(string ddd, string plano)
        {
            try
            {
                DDD dDD = ((TelefoniaContext)Context).DDDs.Where(x => x.Sigla == ddd).First();
                if (ddd is null)
                {
                    return null;
                }

                return ((TelefoniaContext)Context).Planos.Where(x => x.DDDPlanos.Any(y => y.DDDId == dDD.Id))
                                .Where(z => z.Codigo.ToLower() == plano.ToLower())
                                .Include(x => x.DDDPlanos)
                                    .ThenInclude(y => y.Ddd);
            }
            catch
            {
                return null;
            }
        }
    }
}
