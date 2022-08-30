using System;
using System.Collections.Concurrent;
using Azure;
using Azure.AI.Language.QuestionAnswering;
using Microsoft.Bot.Builder.AI.QnA;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Teams.Apps.AskHR.Services
{
    public class QuestionAnsweringFactory : IQuestionAnsweringFactory
    {
        private readonly IConfiguration configuration;
        private readonly ConcurrentDictionary<string, QuestionAnsweringClient> questionAnsweringInstances;

        public QuestionAnsweringFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.questionAnsweringInstances = new ConcurrentDictionary<string, QuestionAnsweringClient>();
        }

        public QuestionAnsweringClient GetQuestionAnsweringInstance(string projectName)
        {
            return this.questionAnsweringInstances.GetOrAdd(projectName, (kbId) =>
            {
                Uri endpoint = new Uri(this.configuration["QuestionAnsweringUrl"]);
                AzureKeyCredential credential = new AzureKeyCredential(this.configuration["QuestionAnsweringClientSecret"]);
                return new QuestionAnsweringClient(endpoint, credential);
            });
        }
    }
}