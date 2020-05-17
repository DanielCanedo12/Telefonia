using System;
using System.Collections.Generic;
using TelefoniaWooza.Domain.Entities;
using TelefoniaWooza.Domain.Enumerators;

namespace TelefoniaWooza.Domain.Interfaces.Repositories
{
    public interface IPlanoRepository : IRepositoryBase<Plano>
    {
        IEnumerable<Plano> GetByTipo(string ddd, TipoPlano tipo);
        IEnumerable<Plano> GetByOperadora(string ddd, string operadora);
        IEnumerable<Plano> GetByPlano(string ddd, string plano);
    }
}
