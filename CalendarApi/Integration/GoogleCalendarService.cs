using System;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace CalendarApi.Integration
{
    public class GoogleCalendarService
    {
        private string jsonFile = "ezoteric-stream-318615-91d29934ede4.json";
        private string tatilGunleriCalendarId = @"tr.turkish#holiday@group.v.calendar.google.com";

        private string[] Scopes = { CalendarService.Scope.Calendar };

        private ServiceAccountCredential credential;

        private CalendarService service;

        public GoogleCalendarService()
        {
            bool initResult = Init();

            if (initResult == false)
            {
                Console.WriteLine("Your calendar service initialize failed!");
            }
        }

        public bool Init()
        {
            using (var stream = new FileStream(jsonFile, FileMode.Open, FileAccess.Read))
            {
                var confg = Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize<JsonCredentialParameters>(stream);
                credential = new ServiceAccountCredential
                (
                   new ServiceAccountCredential.Initializer(confg.ClientEmail)
                   {
                       Scopes = Scopes
                   }.FromPrivateKey(confg.PrivateKey)
                );
            }

            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });

            return true;
        }
        public Events GetHolidays(DateTime queryStartDate, DateTime queryEndDate)
        {
            var listRequest = service.Events.List(tatilGunleriCalendarId);
            listRequest.TimeMin = queryStartDate;
            listRequest.TimeMax = queryEndDate;
            listRequest.ShowDeleted = false;
            listRequest.SingleEvents = true;
            listRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = listRequest.Execute();

            return events;
        }
    }
}
