using Azure.AI.Language.QuestionAnswering;

namespace Microsoft.Teams.Apps.AskHR.Services
{
    public interface IQuestionAnsweringFactory
    {
        QuestionAnsweringClient GetQuestionAnsweringInstance(string projectName);
    }
}