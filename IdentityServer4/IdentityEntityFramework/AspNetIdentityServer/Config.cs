using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        //增加oidc的identity的scope
        public static IEnumerable<IdentityResource> GetIdentityResource()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
        public static IEnumerable<Client> GetApiClients()
        {
            return new List<Client> {
                new Client(){
                    ClientId="client",
                     // 没有交互性用户，使用 clientid/secret 实现认证。
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    //用于认证的密码
                    ClientSecrets={new Secret("secret".Sha256())},
                    //客户端有权访问的范围
                    AllowedScopes ={ "api1"}
                },
                //密码认证模式
                 new Client(){
                    ClientId="ro.client",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    //用于认证的密码
                    ClientSecrets={new Secret("secret".Sha256())},
                    //客户端有权访问的范围
                    AllowedScopes ={ "api1"}
                },
                 new Client()
                 {
                     //客户端允许服务器到服务器API调用
                     ClientId="mvc",
                     ClientName="MVC Client",
                     AllowedGrantTypes=GrantTypes.HybridAndClientCredentials,
                      //用于认证的密码
                     ClientSecrets={new Secret("secret".Sha256())},
                     RequireConsent=true, //默认为ture
                     //登录后重定向到客户端
                     RedirectUris={"http://localhost:5002/signin-oidc" },
                     //注销后重定向到客户端
                     PostLogoutRedirectUris={"http://localhost:5002/signout-callback-oidc" },
                     AllowedScopes=new List<string>{
                         IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile,
                           "api1"
                     },
                       AllowOfflineAccess = true //允许为长时间的API访问请求刷新令牌
                 },
                 // JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:5003/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:5003" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                }
                };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource ("api1","my api") };
        }
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser> {
                new TestUser{
                SubjectId ="1",
                Username="alice",
                Password="alice",
                Claims = new List<Claim>
                 {
                        new Claim("name", "Alice"),
                        new Claim("website", "https://alice.com")
                    }
                },
                new TestUser{
                SubjectId ="2",
                Username="bob",
                Password="bob",
                  Claims = new List<Claim>
                    {
                        new Claim("name", "Bob"),
                        new Claim("website", "https://bob.com")
                    }
                },
            };
        }



    }
}
