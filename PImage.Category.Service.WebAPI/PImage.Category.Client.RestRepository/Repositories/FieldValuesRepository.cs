using System;
using System.Collections.Generic;
using System.Net;

namespace PImage.Category.Client.RestRepository.Repositories
{
    public class FieldValuesRepository : RepositoryBase<DTO.FieldValues>
    {
        public const string FIELD_VALUES_GET_URI = "/api/FieldValues";
        public const string FIELD_VALUES_GET_URI_TYPE = "GET";

        public const string FIELD_VALUES_GET_FILTER_URI = "/api/FieldValues/{0}";
        public const string FIELD_VALUES_GET_FILTER_URI_TYPE = "GET";

        public const string FIELD_VALUES_CREATE_URI = "/api/FieldValues";
        public const string FIELD_VALUES_CREATE_URI_TYPE = "POST";

        public const string FIELD_VALUES_UPDATE_URI = "/api/FieldValues/{0}";
        public const string FIELD_VALUES_UPDATE_URI_TYPE = "PUT";

        public const string FIELD_VALUES_DELETE_URI = "/api/FieldValues/{0}";
        public const string FIELD_VALUES_DELETE_URI_TYPE = "DELETE";

        public const string CONTENT_TYPE = "application/json";

        public FieldValuesRepository()
        {
        }

        public DTO.FieldValues New()
        {
            return new DTO.FieldValues();
        }

        public void Update(DTO.FieldValues fieldValues, string serviceURI)
        {
            try
            {
                string json = Helper.Serializer.Serialize<DTO.FieldValues>(fieldValues);

                string fullUri = string.Format(serviceURI + FIELD_VALUES_UPDATE_URI, fieldValues.Id);

                RestService.NotifyService(json, fullUri, FIELD_VALUES_UPDATE_URI_TYPE, CONTENT_TYPE);

            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpStatusCode httpResponse = ((HttpWebResponse)response).StatusCode;
                }
            }

        }

        public List<DTO.FieldValues> Get(string serviceURI)
        {
            List<DTO.FieldValues> fieldValuesList = new List<DTO.FieldValues>();

            string fullUri = string.Format(serviceURI + FIELD_VALUES_GET_URI, "null");

            try
            {
                fieldValuesList = RestService.ExecuteWebServiceSearch<List<DTO.FieldValues>>(fullUri);
            }
            catch (Exception e)
            {
                throw e;
            }

            return fieldValuesList;
        }

        public DTO.FieldValues Get(int id, string serviceURI)
        {

            DTO.FieldValues fieldValues = new DTO.FieldValues();


            string fullUri = string.Format(serviceURI + FIELD_VALUES_GET_FILTER_URI, id);

            try
            {
                fieldValues = RestService.ExecuteWebServiceSearch<DTO.FieldValues>(fullUri);
            }
            catch (Exception e)
            {
                throw e;
            }

            return fieldValues;

        }

        public void Create(DTO.FieldValues fieldValues, string serviceURI)
        {
            try
            {
                string fullUri = string.Format(serviceURI + FIELD_VALUES_CREATE_URI, fieldValues.Id);

                var json = Helper.Serializer.Serialize<DTO.FieldValues>(fieldValues);

                serviceURI += FIELD_VALUES_CREATE_URI;

                RestService.NotifyService(json, serviceURI, FIELD_VALUES_CREATE_URI_TYPE, CONTENT_TYPE);

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

            string fullUri = string.Format(serviceURI + FIELD_VALUES_DELETE_URI, id);

            try
            {
                RestService.NotifyService("", fullUri, FIELD_VALUES_DELETE_URI_TYPE, CONTENT_TYPE);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
