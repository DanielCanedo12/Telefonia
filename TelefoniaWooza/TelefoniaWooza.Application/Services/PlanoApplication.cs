using System;
using System.Collections.Generic;
using System.Linq;
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
            return _planoRepository.Get();
        }

        public Plano Get(int id)
        {
            return _planoRepository.Get(id);
        }

        public void Add(Plano obj)
        {
            Validate(obj, Activator.CreateInstance<PlanoValidator>());


           /* foreach(DDDPlano dDDPlano in obj.DDDPlanos)
            {

                DDD ddd = _dDDRepository.Get().Where(x => x.Sigla == dDDPlano.Ddd.Sigla).FirstOrDefault();
                 if(ddd is null)
                {
                    ddd = new DDD()
                    {
                        Sigla = dDDPlano.Ddd.Sigla
                    };

                    _dDDRepository.Add(ddd);
                   
                }

                dDDPlano.DDDId = ddd.Id;
                dDDPlano.PLanoId = obj.Id;
                dDDPlano.Ddd = null;
                dDDPlano.Plano = null;
                _dDDPlanoRepository.Add(dDDPlano);
            }

            obj.DDDPlanos = null;*/
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
