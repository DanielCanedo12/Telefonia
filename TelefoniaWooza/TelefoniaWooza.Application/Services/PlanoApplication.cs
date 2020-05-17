using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using TelefoniaWooza.Application.Validators;
using TelefoniaWooza.Domain.Entities;
using TelefoniaWooza.Domain.Enumerators;
using TelefoniaWooza.Domain.Interfaces.Repositories;
using TelefoniaWooza.Infra.Data.Contexts;

namespace TelefoniaWooza.Application
{
    public class PlanoApplication : ApplicationBase
    {
       

        private readonly IPlanoRepository _planoRepository;
        private readonly IDDDRepository _dDDRepository;
        private readonly IDDDPlanoRepository _dDDPlanoRepository;


        public PlanoApplication(
            IPlanoRepository planoRepository,
            IDDDRepository dDDRepository,
            IDDDPlanoRepository dDDPlanoRepository,
            TelefoniaContext db) : base(db)
        {
            _planoRepository = planoRepository;
            _dDDRepository = dDDRepository;
            _dDDPlanoRepository = dDDPlanoRepository;
        }

        public IEnumerable<Plano> GetAll()
        {
          
            IEnumerable<Plano> planos =  _planoRepository.Get();
            return planos;
        }

        public IEnumerable<Plano> GetByTipo(string ddd , TipoPlano tipo)
        {
            IEnumerable<Plano> planos = _planoRepository.GetByTipo(ddd,tipo);
            return planos;
        }
        public IEnumerable<Plano> GetByOperadora(string ddd, string operadora)
        {
            IEnumerable<Plano> planos = _planoRepository.GetByOperadora(ddd, operadora);
            return planos;
        }
        public IEnumerable<Plano> GetByPlano(string ddd, string plano)
        {
            IEnumerable<Plano> planos = _planoRepository.GetByPlano(ddd, plano);
            return planos;
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
