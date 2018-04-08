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
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>{
                new ApiResource ("api1","my api") };
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
                };
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
