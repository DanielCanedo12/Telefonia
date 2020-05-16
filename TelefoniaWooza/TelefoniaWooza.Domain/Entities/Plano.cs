using System;
using System.Collections.Generic;
using TelefoniaWooza.Domain.Enumerators;

namespace TelefoniaWooza.Domain.Entities
{


    public class Plano : EntityBase
    {
        public Plano()
        {
            DDDPlanos = new List<DDDPlano>();
        }

        public string Codigo { get; set; }
        public int Minutos { get; set; }
        public float FranquiaInternet { get; set; }
        public float Valor { get; set; }
        public TipoPlano Tipo { get; set; } 
        public string Operadora { get; set; }

        public ICollection<DDDPlano> DDDPlanos { get; set; }
    }

}


