using PImage.Category.Client.RestRepository.Repositories;
using System.Collections.Generic;

namespace PImage.Category.Client.RestRepository.MessagingFacades
{
    public class FieldsFacade : FacadeBase
    {
        private FieldRepository _fieldRepository;

        public FieldsFacade(ServiceConnection serviceConnection)
            : base(serviceConnection)
        {
            _fieldRepository = new FieldRepository();
        }

        public DTO.Field New()
        {
            return _fieldRepository.New();
        }

        public void Update(DTO.Field field)
        {
            _fieldRepository.Update(field, Connection.ServiceUri);
        }

        public List<DTO.Field> Get()
        {
            return _fieldRepository.Get(Connection.ServiceUri);
        }

        public DTO.Field Get(int id)
        {
            return _fieldRepository.Get(id, Connection.ServiceUri);
        }

        public void Create(DTO.Field field)
        {
            _fieldRepository.Create(field, Connection.ServiceUri);
        }

        public void Delete(int id)
        {
            _fieldRepository.Delete(id, Connection.ServiceUri);
        }

    }
}
