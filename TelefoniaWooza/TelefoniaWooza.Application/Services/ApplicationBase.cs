using System;
using TelefoniaWooza.Infra.Data.Contexts;

namespace TelefoniaWooza.Application
{
    public class ApplicationBase 
    {

        private readonly TelefoniaContext _db;
        public ApplicationBase(TelefoniaContext db)
        {
            _db = db;
        }
        public void Commit()
        {
            _db.SaveChanges();
        }

    }
}
