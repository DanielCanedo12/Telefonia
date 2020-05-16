using System;
using TelefoniaWooza.Domain.Entities;
using TelefoniaWooza.Domain.Interfaces.Repositories;
using TelefoniaWooza.Infra.Data.Contexts;

namespace TelefoniaWooza.Infra.Data.Repositories
{
    public class DDDRepository : RepositoryBase<DDD>, IDDDRepository
    {
        public DDDRepository(TelefoniaContext db) : base(db)
        {
        }
    }
}
