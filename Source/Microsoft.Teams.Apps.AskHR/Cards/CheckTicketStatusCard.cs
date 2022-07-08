﻿using System.Collections.Generic;
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
                    new AdaptiveFactSet
                    {
                        Facts = BuildFactSet(tickets)
                    }
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = adaptiveCard,
            };
        }

        private static List<AdaptiveFact> BuildFactSet(List<TicketModel> tickets)
        {
            List<AdaptiveFact> factList = new List<AdaptiveFact>();

            foreach (var ticketModel in tickets)
            {
                factList.Add(new AdaptiveFact
                {
                    Title = Resource.TicketCaseNumber,
                    Value = ticketModel.CaseNumber,
                });

                factList.Add(new AdaptiveFact
                {
                    Title = Resource.TicketTitle,
                    Value = ticketModel.TicketTitle,
                });

                factList.Add(new AdaptiveFact
                {
                    Title = Resource.TicketDescription,
                    Value = ticketModel.Description,
                });

                factList.Add(new AdaptiveFact
                {
                    Title = Resource.TicketStatus,
                    Value = ticketModel.TicketStatus,
                });
            }

            return factList;
        }
    }
}