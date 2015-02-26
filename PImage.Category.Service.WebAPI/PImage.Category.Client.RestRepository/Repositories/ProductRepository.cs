using System;
using System.Collections.Generic;
using System.Net;

namespace PImage.Category.Client.RestRepository.Repositories
{
    public class ProductRepository : RepositoryBase<DTO.Product>
    {
        public const string PRODUCT_GET_URI = "/api/Products";
        public const string PRODUCT_GET_URI_TYPE = "GET";

        public const string PRODUCT_GET_FILTER_URI = "/api/Products/{0}";
        public const string PRODUCT_GET_FILTER_URI_TYPE = "GET";

        public const string PRODUCT_CREATE_URI = "/api/Products";
        public const string PRODUCT_CREATE_URI_TYPE = "POST";

        public const string PRODUCT_UPDATE_URI = "/api/Products/{0}";
        public const string PRODUCT_UPDATE_URI_TYPE = "PUT";

        public const string PRODUCT_DELETE_URI = "/api/Products/{0}";
        public const string PRODUCT_DELETE_URI_TYPE = "DELETE";

        public const string CONTENT_TYPE = "application/json";

        public ProductRepository()
        {
        }

        public DTO.Product New()
        {
            return new DTO.Product();
        }

        public void Update(DTO.Product product, string serviceURI)
        {
            try
            {
                string json = Helper.Serializer.Serialize<DTO.Product>(product);

                string fullUri = string.Format(serviceURI + PRODUCT_UPDATE_URI, product.Id);

                RestService.NotifyService(json, fullUri, PRODUCT_UPDATE_URI_TYPE, CONTENT_TYPE);

            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpStatusCode httpResponse = ((HttpWebResponse)response).StatusCode;
                }
            }

        }

        public List<DTO.Product> Get(string serviceURI)
        {
            List<DTO.Product> products = new List<DTO.Product>();

            string fullUri = string.Format(serviceURI + PRODUCT_GET_URI, "null");

            try
            {
                products = RestService.ExecuteWebServiceSearch<List<DTO.Product>>(fullUri);
            }
            catch (Exception e)
            {
                throw e;
            }

            return products;
        }

        public DTO.Product Get(int id, string serviceURI)
        {

            DTO.Product product = new DTO.Product();


            string fullUri = string.Format(serviceURI + PRODUCT_GET_FILTER_URI, id);

            try
            {
                product = RestService.ExecuteWebServiceSearch<DTO.Product>(fullUri);
            }
            catch (Exception e)
            {
                throw e;
            }

            return product;

        }

        public void Create(DTO.Product product, string serviceURI)
        {
            try
            {
                string fullUri = string.Format(serviceURI + PRODUCT_CREATE_URI, product.Id);

                var json = Helper.Serializer.Serialize<DTO.Product>(product);

                serviceURI += PRODUCT_CREATE_URI;

                RestService.NotifyService(json, serviceURI, PRODUCT_CREATE_URI_TYPE, CONTENT_TYPE);

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

            string fullUri = string.Format(serviceURI + PRODUCT_DELETE_URI, id);

            try
            {
                RestService.NotifyService("", fullUri, PRODUCT_DELETE_URI_TYPE, CONTENT_TYPE);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
