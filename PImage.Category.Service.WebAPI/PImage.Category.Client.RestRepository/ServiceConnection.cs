using PImage.Category.Client.RestRepository.MessagingFacades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PImage.Category.Client.RestRepository
{
    public sealed class ServiceConnection
    {
		public string ServiceUri
		{
			internal set;
			get;
		}

		public CategoriesFacade Categories
		{
			get;
			private set;
		}

        public SubCategoriesFacade SubCategories
        {
            get;
            private set;
        }

		static ServiceConnection()
		{
		}

		private ServiceConnection()
		{
			InitializeFacades();
		}

		public ServiceConnection(string serviceUri)
			: this()
		{
			if (string.IsNullOrEmpty(serviceUri))
			{
				throw new ArgumentNullException("ServiceUri");
			}

			ServiceUri = serviceUri;
		}


		private void InitializeFacades()
		{
			Categories = new CategoriesFacade(this);
			SubCategories = new SubCategoriesFacade(this);
		}
    }
}
