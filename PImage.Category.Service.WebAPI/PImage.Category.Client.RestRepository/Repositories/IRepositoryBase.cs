using PImage.Category.Client.RestRepository.Service;
using System.Collections.Generic;

namespace PImage.Category.Client.RestRepository.Repositories
{
    public interface IRepositoryBase<T>
    {
        ServiceCommunication RestService
        {
            get;
            set;
        }

        T New();

        void Update(T item);

        List<T> Get();

        T Get(int id);

        void Create(T item);

        void Delete(int id);

    }
}
