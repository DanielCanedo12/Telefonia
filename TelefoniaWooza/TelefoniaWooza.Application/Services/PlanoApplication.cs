using System;
using System.Collections.Generic;
using FluentValidation;
using TelefoniaWooza.Application.Validators;
using TelefoniaWooza.Domain.Entities;
using TelefoniaWooza.Domain.Interfaces.Repositories;
using TelefoniaWooza.Infra.Data.Contexts;

namespace TelefoniaWooza.Application
{
    public class PlanoApplication : ApplicationBase
    {
       

        private readonly IPlanoRepository _planoRepository;
        public PlanoApplication(IPlanoRepository planoRepository, TelefoniaContext db) : base(db)
        {
            _planoRepository = planoRepository;
        }

        public IEnumerable<Plano> GetAll()
        {
            return _planoRepository.Get();
        }

        public Plano Get(int id)
        {
            return _planoRepository.Get(id);
        }

        public void Add(Plano obj)
        {
            Validate(obj, Activator.CreateInstance<PlanoValidator>());
            _planoRepository.Add(obj);
            Commit();
        }

        public void Update(Plano obj)
        {
            _planoRepository.Update(obj);
            Commit();
        }
        public void Delete(int obj)
        {
            _planoRepository.Delete(obj);
            Commit();
        }

        private void Validate(Plano obj, AbstractValidator<Plano> validator)
        {
            if (obj == null)
                throw new Exception("Objeto inconsistente!");

            validator.ValidateAndThrow(obj);
        }
    }
}
