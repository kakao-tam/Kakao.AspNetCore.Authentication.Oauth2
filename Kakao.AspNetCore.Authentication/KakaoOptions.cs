using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Kakao.AspNetCore.Authentication.OAuth2
{
    /// <summary>
    /// Configuration options for <see cref="KakaoHandler"/>.
    /// </summary>
    public class KakaoOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new <see cref="KakaoOptions"/>.
        /// </summary>
        public KakaoOptions()
        {
            CallbackPath = new PathString("/signin-kakao");
            AuthorizationEndpoint = KakaoDefaults.AuthorizationEndpoint;
            TokenEndpoint = KakaoDefaults.TokenEndpoint;
            UserInformationEndpoint = KakaoDefaults.UserInformationEndpoint;

            Fields.Add("email");
            Fields.Add("name");
            Fields.Add("phone");

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            ClaimActions.MapJsonSubKey(ClaimTypes.Name, "kakao_account", "profile.nickname");
            ClaimActions.MapJsonSubKey(ClaimTypes.Email, "kakao_account", "email");
            ClaimActions.MapJsonSubKey(ClaimTypes.Gender, "kakao_account", "gender");
            ClaimActions.MapJsonSubKey(ClaimTypes.MobilePhone, "kakao_account", "phone_number");
        }

        /// <summary>
        /// Check that the options are valid.  Should throw an exception if things are not ok.
        /// </summary>
        public override void Validate()
        {
            if (string.IsNullOrEmpty(ClientId))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Exception_OptionMustBeProvided, nameof(ClientId)), nameof(ClientId));
            }

            if (string.IsNullOrEmpty(ClientSecret))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Exception_OptionMustBeProvided, nameof(ClientSecret)), nameof(ClientSecret));
            }

            base.Validate();
        }
        public ICollection<string> Fields { get; } = new HashSet<string>();


        /// <summary>
        /// Gets or sets the provider-assigned Prompt.
        /// 
        /// login: 기존 사용자 인증 여부와 상관없이 사용자에게 카카오계정 로그인 화면을 출력하여 다시 사용자 인증을 수행하고자 할 때 사용, 카카오톡 인앱 브라우저에서는 이 기능이 제공되지 않음
        /// none: 사용자에게 동의 화면과 같은 대화형 UI를 노출하지 않고 인가 코드 발급을 요청할 때 사용, 인가 코드 발급을 위해 사용자의 동작이 필요한 경우 에러 응답 전달
        /// </summary>
        public string Prompt { get; set; }


    }
}
