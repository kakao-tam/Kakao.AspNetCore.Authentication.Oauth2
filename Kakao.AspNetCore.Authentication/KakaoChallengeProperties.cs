using Microsoft.AspNetCore.Authentication.OAuth;

namespace Kakao.AspNetCore.Authentication.OAuth2
{
    public class KakaoChallengeProperties : OAuthChallengeProperties
    {
        /// <summary>
        /// The parameter key for the "prompt" argument being used for a challenge request.
        /// </summary>
        public static readonly string PromptParameterKey = "prompt";
    }
}
