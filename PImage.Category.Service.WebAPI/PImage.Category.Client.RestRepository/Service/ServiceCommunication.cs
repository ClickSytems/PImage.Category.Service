using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace PImage.Category.Client.RestRepository.Service
{
    public class ServiceCommunication
    {
        #region Construction and Initialization

        public ServiceCommunication()
		{
		}

		#endregion

		#region Public Methods

		public void NotifyWebService(string json, string serviceURI, string requestMethod, string contentType, bool verifyResponse = false)
		{
            try
            {
                //Post
                System.Net.ServicePointManager.Expect100Continue = false;
                var request = WebRequest.Create(new Uri(serviceURI));
                request.Method = requestMethod;
                request.ContentType = contentType;

                byte[] bytes = Encoding.UTF8.GetBytes(json);
                request.ContentLength = bytes.Length;

                System.IO.Stream dataStream = request.GetRequestStream();
                dataStream.Write(bytes, 0, bytes.Length);
                dataStream.Close();

                if (verifyResponse)
                {
                    //Response
                    // Get the response.
                    WebResponse response = request.GetResponse();
                    // Display the status.
                    var status = ((HttpWebResponse)response).StatusDescription;
                    // Get the stream containing content returned by the server.
                    dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.
                    var reader = new System.IO.StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Clean up the streams.
                    reader.Close();
                    dataStream.Close();
                    response.Close();
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpStatusCode httpResponse = ((HttpWebResponse)response).StatusCode;
                }

                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		public T ExecuteWebServiceSearch<T>(string serviceUri)
		{
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(serviceUri);
            using (Stream webStream = webRequest.GetResponse().GetResponseStream())
            {
                var result = (T)Helper.Serializer.DeSerialize<T>(webRequest.GetResponse().GetResponseStream());
                webStream.Flush();
                webStream.Close();
                return result;
            }
		}

   		#endregion
    }
}
