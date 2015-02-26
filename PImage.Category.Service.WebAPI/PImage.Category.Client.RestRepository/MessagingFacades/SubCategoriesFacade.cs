using PImage.Category.Client.RestRepository.Repositories;
using System.Collections.Generic;

namespace PImage.Category.Client.RestRepository.MessagingFacades
{
    public class SubCategoriesFacade : FacadeBase
    {
        private SubCategoryRepository _subCategoryRepository;

        public SubCategoriesFacade(ServiceConnection serviceConnection)
            : base(serviceConnection)
        {
            _subCategoryRepository = new SubCategoryRepository();
        }

        public DTO.SubCategory New()
        {
            return _subCategoryRepository.New();
        }

        public void Update(DTO.SubCategory category)
        {
            _subCategoryRepository.Update(category, Connection.ServiceUri);
        }

        public List<DTO.SubCategory> Get()
        {
            return _subCategoryRepository.Get(Connection.ServiceUri);
        }

        public DTO.SubCategory Get(int id)
        {
            return _subCategoryRepository.Get(id, Connection.ServiceUri);
        }

        public void Create(DTO.SubCategory category)
        {
            _subCategoryRepository.Create(category, Connection.ServiceUri);
        }

        public void Delete(int id)
        {
            _subCategoryRepository.Delete(id, Connection.ServiceUri);
        }
    }
}
