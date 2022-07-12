using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Teams.Apps.AskHR.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Teams.Apps.AskHR.DynamicService
{
    public class TicketService : ITicketService
    {
        private readonly ServiceConfig serviceConfig;

        public TicketService(ServiceConfig serviceConfig)
        {
            this.serviceConfig = serviceConfig;
        }

        public async Task<List<TicketModel>> GetMyTicketAsync(string username)
        {
            try
            {
                var result = new List<TicketModel>();
                //if (string.IsNullOrEmpty(username))
                //{
                //    username = "PSVdev@atomfrontier.com";
                //}

                using (var svc = new CDSWebApiService(serviceConfig))
                {
                    var formattedValueHeaders = new Dictionary<string, List<string>> {
                    { "Prefer", new List<string>
                        { "odata.include-annotations=\"OData.Community.Display.V1.FormattedValue\"" }
                    }
                };

                    string contactId = null;
                    JToken getContactByEmailAddress = svc.Get($"contacts?" +
                                                              "$select=contactid,fullname&" +
                                                              $"$filter=emailaddress1 eq '{username}' and statuscode ne 2", formattedValueHeaders);

                    if (getContactByEmailAddress["value"] != null && getContactByEmailAddress["value"].Children().Any())
                    {
                        contactId = getContactByEmailAddress["value"][0]["contactid"].ToString();
                    }
                    else
                    {
                        return new List<TicketModel>();
                    }

                    var getMyTickets = await svc.GetAsync("incidents?" +
                                                          "$select=ticketnumber,title,description,statuscode,createdon&" +
                                                          "$orderby=createdon desc&" +
                                                          $"$filter=_primarycontactid_value eq {contactId}", formattedValueHeaders);

                    if (getMyTickets != null && getMyTickets["value"] != null && getMyTickets["value"].Children().Any())
                    {
                        foreach (JObject item in getMyTickets["value"])
                        {
                            result.Add(new TicketModel
                            {
                                CaseNumber = item["ticketnumber"]?.ToString(),
                                TicketTitle = item["title"]?.ToString(),
                                Description = item["description"]?.ToString(),
                                TicketStatus = item["statuscode@OData.Community.Display.V1.FormattedValue"]?.ToString(),
                                CreatedDate = item["createdon@OData.Community.Display.V1.FormattedValue"]?.ToString(),
                            });
                        }
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}