using PImage.Category.Client.RestRepository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
