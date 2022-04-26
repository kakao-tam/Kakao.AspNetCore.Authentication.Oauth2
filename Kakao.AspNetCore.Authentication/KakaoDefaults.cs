using System;
namespace Kakao.AspNetCore.Authentication.OAuth2
{
    public class KakaoDefaults
    {
        public const string AuthenticationScheme = "Kakao";

        public static readonly string DisplayName = "Kakao";

        // https://developers.kakao.com/docs/latest/ko/kakaologin/common#login
        public static readonly string AuthorizationEndpoint = "https://kauth.kakao.com/oauth/authorize";

        public static readonly string TokenEndpoint = "https://kauth.kakao.com/oauth/token";

        public static readonly string UserInformationEndpoint = "https://kapi.kakao.com/v2/user/me";
    }
}