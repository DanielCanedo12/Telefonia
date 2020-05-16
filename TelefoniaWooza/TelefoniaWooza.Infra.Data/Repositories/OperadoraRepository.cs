using System;
using TelefoniaWooza.Domain.Entities;
using TelefoniaWooza.Domain.Interfaces.Repositories;
using TelefoniaWooza.Infra.Data.Contexts;

namespace TelefoniaWooza.Infra.Data.Repositories
{
    public class OperadoraRepository : RepositoryBase<Operadora>, IOperadoraRepository
    {
        public OperadoraRepository(TelefoniaContext db) : base(db)
        {
        }
    }
}
