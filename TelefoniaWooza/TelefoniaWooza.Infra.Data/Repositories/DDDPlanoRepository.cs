using System;
using TelefoniaWooza.Domain.Entities;
using TelefoniaWooza.Domain.Interfaces.Repositories;
using TelefoniaWooza.Infra.Data.Contexts;

namespace TelefoniaWooza.Infra.Data.Repositories
{
    public class DDDPlanoRepository : RepositoryBase<DDDPlano>, IDDDPlanoRepository
    {
        public DDDPlanoRepository(TelefoniaContext db) : base(db)
        {
        }
    }
}
