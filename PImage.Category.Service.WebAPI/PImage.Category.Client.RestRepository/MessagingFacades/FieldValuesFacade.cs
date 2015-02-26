using PImage.Category.Client.RestRepository.Repositories;
using System.Collections.Generic;

namespace PImage.Category.Client.RestRepository.MessagingFacades
{
    public class FieldValuesFacade : FacadeBase
    {
        private FieldValuesRepository _fieldValuesRepository;

        public FieldValuesFacade(ServiceConnection serviceConnection)
            : base(serviceConnection)
        {
            _fieldValuesRepository = new FieldValuesRepository();
        }

        public DTO.FieldValues New()
        {
            return _fieldValuesRepository.New();
        }

        public void Update(DTO.FieldValues fieldsValue)
        {
            _fieldValuesRepository.Update(fieldsValue, Connection.ServiceUri);
        }

        public List<DTO.FieldValues> Get()
        {
            return _fieldValuesRepository.Get(Connection.ServiceUri);
        }

        public DTO.FieldValues Get(int id)
        {
            return _fieldValuesRepository.Get(id, Connection.ServiceUri);
        }

        public void Create(DTO.FieldValues fieldsValue)
        {
            _fieldValuesRepository.Create(fieldsValue, Connection.ServiceUri);
        }

        public void Delete(int id)
        {
            _fieldValuesRepository.Delete(id, Connection.ServiceUri);
        }

    }
}
