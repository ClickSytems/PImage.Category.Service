using PImage.Category.Client.RestRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PImage.Category.Client.RestRepository.MessagingFacades
{
    public class CategoriesFacade : FacadeBase
    {
        private CategoryRepository _categoryRepository;

        public CategoriesFacade(ServiceConnection serviceConnection)
			: base(serviceConnection)
		{
            _categoryRepository = new CategoryRepository();
		}

        public DTO.Category New()
        {
            return _categoryRepository.New();
        }

        public void Update(DTO.Category category)
        {
            _categoryRepository.Update(category, Connection.ServiceUri);
        }

        public List<DTO.Category> Get()
        {
            return _categoryRepository.Get(Connection.ServiceUri);
        }

        public DTO.Category Get(int id)
        {

            return _categoryRepository.Get(id, Connection.ServiceUri);

        }

        public void Create(DTO.Category category)
        {
            _categoryRepository.Create(category, Connection.ServiceUri);

        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id, Connection.ServiceUri);
        }

    }
}
