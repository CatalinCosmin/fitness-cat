using Core.Abstractions.Services.Verification;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.RecaptchaEnterprise.V1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Verification
{
    internal class RecaptchaService : IRecaptchaService
    {
        private readonly IConfiguration _configuration;
        public RecaptchaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<string> CreateAssessment(string _token, string _action)
        {
            var _projectId = _configuration["ReCAPTCHA:ProjectId"];
            var _siteKey = _configuration["ReCAPTCHA:SiteKey"];
            var response = new List<string>();

            RecaptchaEnterpriseServiceClient client = RecaptchaEnterpriseServiceClient.Create();

            ProjectName projectName = new ProjectName(_projectId);

            // Build the assessment request.
            CreateAssessmentRequest createAssessmentRequest = new CreateAssessmentRequest()
            {
                Assessment = new Assessment()
                {
                    // Set the properties of the event to be tracked.
                    Event = new Event()
                    {
                        SiteKey = _siteKey,
                        Token = _token,
                        ExpectedAction = _action
                    },
                },
                ParentAsProjectName = projectName
            };

            Assessment assessmentResponse = client.CreateAssessment(createAssessmentRequest);

            // Check if the token is valid.
            if (assessmentResponse.TokenProperties.Valid == false)
            {
                response.Add("The CreateAssessment call failed because the token was: " +
                    assessmentResponse.TokenProperties.InvalidReason.ToString());
                return response;
            }

            // Check if the expected action was executed.
            if (assessmentResponse.TokenProperties.Action != _action)
            {
                response.Add("The action attribute in reCAPTCHA tag is: " +
                    assessmentResponse.TokenProperties.Action.ToString());
                response.Add("The action attribute in the reCAPTCHA tag does not " +
                    "match the action you are expecting to score");
                return response;
            }

            // Get the risk score and the reason(s).
            // For more information on interpreting the assessment,
            // see: https://cloud.google.com/recaptcha-enterprise/docs/interpret-assessment
            var score = (double)assessmentResponse.RiskAnalysis.Score;
            if (score < 0.2)
            {
                response.Add("The reCAPTCHA score is: " + score);
                foreach (RiskAnalysis.Types.ClassificationReason reason in assessmentResponse.RiskAnalysis.Reasons)
                {
                    response.Add(reason.ToString());
                }
            }

            return response;
        }
    }
}
