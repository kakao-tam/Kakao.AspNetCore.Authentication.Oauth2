using System;
using Kakao.AspNetCore.Authentication.OAuth2;
using Microsoft.AspNetCore.Authentication;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class KakaoAuthenticationOptionsExtensions
    {
        public static AuthenticationBuilder AddKakao(this AuthenticationBuilder builder)
            => builder.AddKakao(KakaoDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddKakao(this AuthenticationBuilder builder, Action<KakaoOptions> configureOptions)
            => builder.AddKakao(KakaoDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddKakao(this AuthenticationBuilder builder, string authenticationScheme, Action<KakaoOptions> configureOptions)
            => builder.AddKakao(authenticationScheme, KakaoDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddKakao(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<KakaoOptions> configureOptions)
            => builder.AddOAuth<KakaoOptions, KakaoHandler>(authenticationScheme, displayName, configureOptions);
    }
}