using PersonDetails.Models;
using PersonDetails.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace PersonDetails
{
    public class PersonManager: IPersonManager
    {
        private IPersonsRepository _PersonsRepository;
        public PersonManager(IPersonsRepository personsRepository)
        {
            _PersonsRepository = personsRepository;
        }

        public List<Persons> GetAll()
        {
            return _PersonsRepository.All().ToList();

        }

        public void Add(Persons model)
        {
            _PersonsRepository.Add(model);


        }






    }
}