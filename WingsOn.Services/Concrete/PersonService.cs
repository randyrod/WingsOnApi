using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain;
using WingsOn.Services.Abstract;

namespace WingsOn.Services.Concrete
{
    public class PersonService : ServiceBase, IPersonService
    {
        public PersonService()
        {
            WingsOnDbContext = new WingsOnDbContext();
        }

        public Person Get(int id) => WingsOnDbContext.PersonRepository.Get(id);

        public IEnumerable<Person> GetAll() => WingsOnDbContext.PersonRepository.GetAll();

        public IEnumerable<Person> GetAllMalePassengers() => GetAll().Where(p => p.Gender == GenderType.Male);
    }
}
