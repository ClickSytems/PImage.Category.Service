using System;
using System.Collections.Generic;
using System.Net;

namespace PImage.Category.Client.RestRepository.Repositories
{
    public class SubCategoryRepository : RepositoryBase<DTO.SubCategory>
    {
        public const string SUBCATEGORY_GET_URI = "/api/SubCategories";
        public const string SUBCATEGORY_GET_URI_TYPE = "GET";

        public const string SUBCATEGORY_GET_FILTER_URI = "/api/SubCategories/{0}";
        public const string SUBCATEGORY_GET_FILTER_URI_TYPE = "GET";

        public const string SUBCATEGORY_CREATE_URI = "/api/SubCategories";
        public const string SUBCATEGORY_CREATE_URI_TYPE = "POST";

        public const string SUBCATEGORY_UPDATE_URI = "/api/SubCategories/{0}";
        public const string SUBCATEGORY_UPDATE_URI_TYPE = "PUT";

        public const string SUBCATEGORY_DELETE_URI = "/api/SubCategories/{0}";
        public const string SUBCATEGORY_DELETE_URI_TYPE = "DELETE";

        public const string CONTENT_TYPE = "application/json";

        public SubCategoryRepository()
        {
        }

        public DTO.SubCategory New()
        {
            return new DTO.SubCategory();
        }

        public void Update(DTO.SubCategory category, string serviceURI)
        {
            try
            {
                string json = Helper.Serializer.Serialize<DTO.SubCategory>(category);

                string fullUri = string.Format(serviceURI + SUBCATEGORY_UPDATE_URI, category.Id);

                RestService.NotifyService(json, fullUri, SUBCATEGORY_UPDATE_URI_TYPE, CONTENT_TYPE);

            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpStatusCode httpResponse = ((HttpWebResponse)response).StatusCode;
                }
            }

        }

        public List<DTO.SubCategory> Get(string serviceURI)
        {
            List<DTO.SubCategory> categories = new List<DTO.SubCategory>();

            string fullUri = string.Format(serviceURI + SUBCATEGORY_GET_URI, "null");

            try
            {
                categories = RestService.ExecuteWebServiceSearch<List<DTO.SubCategory>>(fullUri);
            }
            catch (Exception e)
            {
                throw e;
            }

            return categories;
        }

        public DTO.SubCategory Get(int id, string serviceURI)
        {

            DTO.SubCategory category = new DTO.SubCategory();


            string fullUri = string.Format(serviceURI + SUBCATEGORY_GET_FILTER_URI, id);

            try
            {
                category = RestService.ExecuteWebServiceSearch<DTO.SubCategory>(fullUri);
            }
            catch (Exception e)
            {
                throw e;
            }

            return category;

        }

        public void Create(DTO.SubCategory category, string serviceURI)
        {
            try
            {
                string fullUri = string.Format(serviceURI + SUBCATEGORY_CREATE_URI, category.Id);

                var json = Helper.Serializer.Serialize<DTO.SubCategory>(category);

                serviceURI += SUBCATEGORY_CREATE_URI;

                RestService.NotifyService(json, serviceURI, SUBCATEGORY_CREATE_URI_TYPE, CONTENT_TYPE);

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

            string fullUri = string.Format(serviceURI + SUBCATEGORY_DELETE_URI, id);

            try
            {
                RestService.NotifyService("", fullUri, SUBCATEGORY_DELETE_URI_TYPE, CONTENT_TYPE);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
