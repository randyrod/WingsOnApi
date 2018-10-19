using System.Collections.Generic;

namespace WingsOn.Services.Abstract
{
    public interface IService<out T>
    {
        T Get(int id);

        IEnumerable<T> GetAll();
    }
}
