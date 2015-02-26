using System;
using System.Collections.Generic;
using System.Net;

namespace PImage.Category.Client.RestRepository.Repositories
{
    public class FieldRepository : RepositoryBase<DTO.Field>
    {
        public const string FIELD_GET_URI = "/api/Fields";
        public const string FIELD_GET_URI_TYPE = "GET";
                           
        public const string FIELD_GET_FILTER_URI = "/api/Fields/{0}";
        public const string FIELD_GET_FILTER_URI_TYPE = "GET";
                           
        public const string FIELD_CREATE_URI = "/api/Fields";
        public const string FIELD_CREATE_URI_TYPE = "POST";
                            
        public const string FIELD_UPDATE_URI = "/api/Fields/{0}";
        public const string FIELD_UPDATE_URI_TYPE = "PUT";
                           
        public const string FIELD_DELETE_URI = "/api/Fields/{0}";
        public const string FIELD_DELETE_URI_TYPE = "DELETE";

        public const string FIELD_CONTENT_TYPE = "application/json";
      
        public FieldRepository()
        {
        }

        public DTO.Field New()
        {
            return new DTO.Field();
        }

        public void Update(DTO.Field field, string serviceURI)
        {
            try
			{
                string json = Helper.Serializer.Serialize<DTO.Field>(field);

                string fullUri = string.Format(serviceURI + FIELD_UPDATE_URI, field.Id);

                RestService.NotifyService(json, fullUri, FIELD_UPDATE_URI_TYPE, FIELD_CONTENT_TYPE);
				
			}
			catch (WebException e)
			{
				using (WebResponse response = e.Response)
				{
					HttpStatusCode httpResponse = ((HttpWebResponse)response).StatusCode;
				}
			}

        }

        public List<DTO.Field> Get(string serviceURI)
        {
            List<DTO.Field> fields = new List<DTO.Field>();

            string fullUri = string.Format(serviceURI + FIELD_GET_URI, "null");

            try
            {
                fields = RestService.ExecuteWebServiceSearch<List<DTO.Field>>(fullUri);
            }
            catch (Exception e)
            {
                throw e;
            }

            return fields;
        }

        public DTO.Field Get(int id, string serviceURI)
        {

            DTO.Field field = new DTO.Field();


            string fullUri = string.Format(serviceURI + FIELD_GET_FILTER_URI, id);

            try
            {
                field = RestService.ExecuteWebServiceSearch<DTO.Field>(fullUri);
            }
            catch (Exception e)
            {
                throw e;
            }

            return field;

        }

        public void Create(DTO.Field field, string serviceURI)
        {
            try
            {
                string fullUri = string.Format(serviceURI + FIELD_CREATE_URI, field.Id);

                var json = Helper.Serializer.Serialize<DTO.Field>(field);

                serviceURI += FIELD_CREATE_URI;

                RestService.NotifyService(json, serviceURI, FIELD_CREATE_URI_TYPE, FIELD_CONTENT_TYPE);

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
            
            string fullUri = string.Format(serviceURI + FIELD_DELETE_URI, id);

            try
            {
                RestService.NotifyService("", fullUri, FIELD_DELETE_URI_TYPE, FIELD_CONTENT_TYPE);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
