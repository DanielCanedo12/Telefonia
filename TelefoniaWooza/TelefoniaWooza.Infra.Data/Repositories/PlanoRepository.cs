using System;
using TelefoniaWooza.Domain.Entities;
using TelefoniaWooza.Domain.Interfaces.Repositories;
using TelefoniaWooza.Infra.Data.Contexts;

namespace TelefoniaWooza.Infra.Data.Repositories
{
    public class PlanoRepository : RepositoryBase<Plano>, IPlanoRepository
    {
        public PlanoRepository(TelefoniaContext db) : base(db)
        {
        }
    }
}
