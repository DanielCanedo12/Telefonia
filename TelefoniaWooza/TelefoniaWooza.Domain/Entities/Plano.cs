using System;
using TelefoniaWooza.Domain.Enumerators;

namespace TelefoniaWooza.Domain.Entities
{


    public class Plano : EntityBase
    {
        public string Codigo { get; set; }
        public int Minutos { get; set; }
        public float FranquiaInternet { get; set; }
        public float Valor { get; set; }
        public TipoPlano Tipo { get; set; } 
        public string Operadora { get; set; }
    }

}


