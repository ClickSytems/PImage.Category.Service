using PImage.Category.Client.RestRepository.Repositories;
using System.Collections.Generic;

namespace PImage.Category.Client.RestRepository.MessagingFacades
{
    public class ProductsFacade : FacadeBase
    {
        private ProductRepository _productRepository;

        public ProductsFacade(ServiceConnection serviceConnection)
            : base(serviceConnection)
        {
            _productRepository = new ProductRepository();
        }

        public DTO.Product New()
        {
            return _productRepository.New();
        }

        public void Update(DTO.Product product)
        {
            _productRepository.Update(product, Connection.ServiceUri);
        }

        public List<DTO.Product> Get()
        {
            return _productRepository.Get(Connection.ServiceUri);
        }

        public DTO.Product Get(int id)
        {

            return _productRepository.Get(id, Connection.ServiceUri);

        }

        public void Create(DTO.Product product)
        {
            _productRepository.Create(product, Connection.ServiceUri);

        }

        public void Delete(int id)
        {
            _productRepository.Delete(id, Connection.ServiceUri);
        }

    }
}
