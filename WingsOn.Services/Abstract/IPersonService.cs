using System.Collections.Generic;
using WingsOn.Domain;

namespace WingsOn.Services.Abstract
{
    public interface IPersonService : IService<Person>
    {
        IEnumerable<Person> GetAllMalePassengers();
    }
}
