using System;
using System.Collections.Generic;
using System.Net;

namespace PImage.Category.Client.RestRepository.Repositories
{
    public class CategoryRepository : RepositoryBase<DTO.Category>
    {
        public const string CATEGORY_GET_URI = "/api/Categories";
        public const string CATEGORY_GET_URI_TYPE = "GET";

        public const string CATEGORY_GET_FILTER_URI = "/api/Categories/{0}";
        public const string CATEGORY_GET_FILTER_URI_TYPE = "GET";

        public const string CATEGORY_CREATE_URI = "/api/Categories";
        public const string CATEGORY_CREATE_URI_TYPE = "POST";

        public const string CATEGORY_UPDATE_URI = "/api/Categories/{0}";
        public const string CATEGORY_UPDATE_URI_TYPE = "PUT";

        public const string CATEGORY_DELETE_URI = "/api/Categories/{0}";
        public const string CATEGORY_DELETE_URI_TYPE = "DELETE";

        public const string CONTENT_TYPE = "application/json";

        public CategoryRepository()
        {
        }

        public DTO.Category New()
        {
            return new DTO.Category();
        }

        public void Update(DTO.Category category, string serviceURI)
        {
            try
            {
                string json = Helper.Serializer.Serialize<DTO.Category>(category);

                string fullUri = string.Format(serviceURI + CATEGORY_UPDATE_URI, category.Id);

                RestService.NotifyService(json, fullUri, CATEGORY_UPDATE_URI_TYPE, CONTENT_TYPE);

            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpStatusCode httpResponse = ((HttpWebResponse)response).StatusCode;
                }
            }

        }

        public List<DTO.Category> Get(string serviceURI)
        {
            List<DTO.Category> categories = new List<DTO.Category>();

            string fullUri = string.Format(serviceURI + CATEGORY_GET_URI, "null");

            try
            {
                categories = RestService.ExecuteWebServiceSearch<List<DTO.Category>>(fullUri);
            }
            catch (Exception e)
            {
                throw e;
            }

            return categories;
        }

        public DTO.Category Get(int id, string serviceURI)
        {

            DTO.Category category = new DTO.Category();


            string fullUri = string.Format(serviceURI + CATEGORY_GET_FILTER_URI, id);

            try
            {
                category = RestService.ExecuteWebServiceSearch<DTO.Category>(fullUri);
            }
            catch (Exception e)
            {
                throw e;
            }

            return category;

        }

        public void Create(DTO.Category category, string serviceURI)
        {
            try
            {
                string fullUri = string.Format(serviceURI + CATEGORY_CREATE_URI, category.Id);

                var json = Helper.Serializer.Serialize<DTO.Category>(category);

                serviceURI += CATEGORY_CREATE_URI;

                RestService.NotifyService(json, serviceURI, CATEGORY_CREATE_URI_TYPE, CONTENT_TYPE);

            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpStatusCode httpResponse = ((HttpWebResponse)response).StatusCode;
                }
            }

        }

        public void Delete(int id, string serviceURI)
        {

            string fullUri = string.Format(serviceURI + CATEGORY_DELETE_URI, id);

            try
            {
                RestService.NotifyService("", fullUri, CATEGORY_DELETE_URI_TYPE, CONTENT_TYPE);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
