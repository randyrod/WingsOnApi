using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain;
using WingsOn.Services.Abstract;
using WingsOn.Services.CustomExceptions;

namespace WingsOn.Services.Concrete
{
    public class PersonService : ServiceBase, IPersonService
    {
        public PersonService()
        {
            WingsOnDbContext = new WingsOnDbContext();
        }

        public Person Get(int id)
        {
            var person =  WingsOnDbContext.PersonRepository.Get(id);

            if (person != null) return person;
            
            throw new ElementNotFoundException($"Element with id: {id} was not found.");
        }

        public IEnumerable<Person> GetAll() => WingsOnDbContext.PersonRepository.GetAll();

        public IEnumerable<Person> GetPeopleByGender(GenderType gender)
        {
            var passengers = GetAll().Where(p => p.Gender == gender).ToArray();

            if (passengers.Any())
            {
                return passengers;
            }
            
            throw new ElementNotFoundException($"There were no passengers of gender: {gender.ToString()} found");
        }
    }
}
