using System;
namespace TelefoniaWooza.Domain.Entities
{
    public class DDDPlano : EntityBase
    {
        public DDDPlano()
        {
        }

        public int DDDId { get; set; }
        public int PLanoId { get; set; }


        public DDD Ddd { get; set; }
        public Plano Plano { get; set; }
    }
}
