using System.Collections.Generic;
using System.Globalization;
using AdaptiveCards;
using Microsoft.Bot.Schema;
using Microsoft.Teams.Apps.AskHR.Models;
using Microsoft.Teams.Apps.AskHR.Properties;

namespace Microsoft.Teams.Apps.AskHR.Cards
{
    /// <summary>
    /// card response ticket statuses
    /// </summary>
    public class CheckTicketStatusCard
    {
        public static Attachment GetCard(List<TicketModel> tickets)
        {
            var textAlignment = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft ? AdaptiveHorizontalAlignment.Right : AdaptiveHorizontalAlignment.Left;
            AdaptiveCard adaptiveCard = new AdaptiveCard("1.0")
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Text = Resource.ListTicketMessage,
                        Wrap = true,
                        Weight = AdaptiveTextWeight.Bolder,
                        HorizontalAlignment = textAlignment
                    },
                }
            };

            foreach (var ticketModel in tickets)
            {
                adaptiveCard.Body.Add(new AdaptiveFactSet
                {
                    Facts = BuildFactSet(ticketModel),
                    Separator = true
                });
            }

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = adaptiveCard,
            };
        }

        private static List<AdaptiveFact> BuildFactSet(TicketModel ticketModel)
        {
            List<AdaptiveFact> factList = new List<AdaptiveFact>
            {
                new AdaptiveFact
                {
                    Title = Resource.TicketCaseNumber,
                    Value = ticketModel.CaseNumber,
                },
                new AdaptiveFact
                {
                    Title = Resource.TicketTitle,
                    Value = ticketModel.TicketTitle,
                },
                new AdaptiveFact
                {
                    Title = Resource.TicketDescription,
                    Value = ticketModel.Description,
                },
                new AdaptiveFact
                {
                    Title = Resource.TicketStatus,
                    Value = ticketModel.TicketStatus,
                },
                new AdaptiveFact
                {
                    Title = Resource.MyTicketCreatedDate,
                    Value = ticketModel.CreatedDate,
                }
            };

            return factList;
        }
    }
}