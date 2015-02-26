using PImage.Category.Client.RestRepository.Service;
using System;
using System.Collections.Generic;

namespace PImage.Category.Client.RestRepository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    {

        public ServiceCommunication RestService
        {
            get;
            set;
        }

        public RepositoryBase()
        {
            RestService = new ServiceCommunication();
        }

        public T New()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public List<T> Get()
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
