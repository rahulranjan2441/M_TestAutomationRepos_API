using M_TestAutomation_API.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace M_TestAutomation_API
{
    [TestClass]
    public class M_SpaceXLanches
    {
        RestClient _restClient;
        RestRequest _restRequest;

        [TestMethod,Description("Scenario 01")]
        public void SpaceX_LaunchesLatest()
        {
            try
            {
                //send the request
                _restClient = new RestClient(@"https://api.spacexdata.com/v4/launches/latest");
                _restRequest = new RestRequest(Method.GET);
                //_restRequest.Credentials = CredentialCache.DefaultCredentials;
                _restRequest.AddHeader("Accept", "application/json");
                //Execute and get the response
                var _response = _restClient.Execute(_restRequest);
                string responseBody = _response.Content.ToString();

                Assert.IsTrue(responseBody.Length != 0);
                Assert.IsTrue(200 == (int)_response.StatusCode);
                Assert.IsTrue("OK".Equals(_response.StatusDescription.ToString()), "Actual Response Status Description: " + _response.StatusDescription);

                m_GetLatestLaunchesPropertiesClass myDeserializedClass = JsonConvert.DeserializeObject<m_GetLatestLaunchesPropertiesClass>(responseBody);
                int flightNumber = myDeserializedClass.flight_number;
                Console.WriteLine("Flight Number: " + flightNumber);
                string LaunchID = myDeserializedClass.id;
                Console.WriteLine("LaunchID: " + LaunchID);
                string webcast = myDeserializedClass.links.webcast;
                Console.WriteLine("webcast: " + webcast);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }

        }
        [TestMethod, Description("Scenario 02")]
        public void SpaceX_LaunchesNext()
        {
            try
            {
                //send the request
                _restClient = new RestClient(@"https://api.spacexdata.com/v4/launches/next");
                _restRequest = new RestRequest(Method.GET);
                //_restRequest.Credentials = CredentialCache.DefaultCredentials;
                _restRequest.AddHeader("Accept", "application/json");
                //Execute and get the response
                var _response = _restClient.Execute(_restRequest);
                string responseBody = _response.Content.ToString();

                Assert.IsTrue(responseBody.Length != 0);
                Assert.IsTrue(200 == (int)_response.StatusCode);
                Assert.IsTrue("OK".Equals(_response.StatusDescription.ToString()), "Actual Response Status Description: " + _response.StatusDescription);

                m_GetNextLaunchesPropertiesClass myDeserializedClass = JsonConvert.DeserializeObject<m_GetNextLaunchesPropertiesClass>(responseBody);
                string youtubeID = myDeserializedClass.links.youtube_id;
                Console.WriteLine("Youtube ID: " + youtubeID);
                bool tbd = myDeserializedClass.tbd;
                Assert.IsFalse(tbd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
           
        }
        [TestMethod, Description("Scenario 03")]
        public void SpaceX_GetOnePayload()
        {
            try
            {
                //send the request
                _restClient = new RestClient(@"https://api.spacexdata.com/v4/payloads");
                _restRequest = new RestRequest(Method.GET);
                //_restRequest.Credentials = CredentialCache.DefaultCredentials;
                _restRequest.AddHeader("Accept", "application/json");
                //Add parameters ex. id
                _restRequest.AddParameter("id", "5eb0e4c6b6c3bb0006eeb21e"); // add Parameters to pass along with the endpoint
                                                                             //Execute and get the response
                var _response = _restClient.Execute(_restRequest);
                string responseBody = _response.Content.ToString();
                Assert.IsTrue(responseBody.Length != 0);
                Assert.IsTrue(200 == (int)_response.StatusCode);
                Assert.IsTrue("OK".Equals(_response.StatusDescription.ToString()), "Actual Response Status Description: " + _response.StatusDescription);

                List<m_GetOnePayloadPropertiesClass> myDeserializedClass = JsonConvert.DeserializeObject<List<m_GetOnePayloadPropertiesClass>>(responseBody);
                string PayloadType = myDeserializedClass[0].type;
                Console.WriteLine("Payload type: " + PayloadType);
                Assert.AreEqual("Satellite", PayloadType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
            
        }

        [TestMethod, Description("Scenario 04")]
        public void SpaceX_GetAllCompanyInfo()
        {
            try
            {
                //send the request
                _restClient = new RestClient(@"https://api.spacexdata.com/v4/company");
                _restRequest = new RestRequest(Method.GET);
                //_restRequest.Credentials = CredentialCache.DefaultCredentials;
                _restRequest.AddHeader("Accept", "application/json");
                //Execute and get the response
                var _response = _restClient.Execute(_restRequest);
                string responseBody = _response.Content.ToString();

                Assert.IsTrue(responseBody.Length != 0);
                Assert.IsTrue(200 == (int)_response.StatusCode);
                Assert.IsTrue("OK".Equals(_response.StatusDescription.ToString()), "Actual Response Status Description: " + _response.StatusDescription);

                m_GetAllCompanyInfoPropertiesclass myDeserializedClass = JsonConvert.DeserializeObject<m_GetAllCompanyInfoPropertiesclass>(responseBody);
                Console.WriteLine("Company name: " + myDeserializedClass.name);
                Console.WriteLine("Company founder: " + myDeserializedClass.founder);
                Console.WriteLine("Company's website: " + myDeserializedClass.links.website);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
            

        }
    }
}
