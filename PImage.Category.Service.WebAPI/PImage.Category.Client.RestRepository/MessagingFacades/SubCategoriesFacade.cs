using PImage.Category.Client.RestRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
