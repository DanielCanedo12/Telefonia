using System;
using System.Collections.Generic;

namespace TelefoniaWooza.Domain.Entities
{
    public class DDD : EntityBase
    {
        public DDD()
        {
            DDDPlanos = new List<DDDPlano>();
        }

        public string Sigla { get; set; }

        public ICollection<DDDPlano> DDDPlanos { get; set; }

    }
}
