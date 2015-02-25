using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PImage.Category.Client.RestRepository.MessagingFacades
{
    public class FacadeBase
    {
        public ServiceConnection Connection
        {
            internal set;
            get;
        }

        public FacadeBase(ServiceConnection serviceConnection)
        {
            Connection = serviceConnection;
        }

    }
}
