using Giro.Animes.Domain.Enums;
using Giro.Animes.Shared.Constants;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Shared.Extensions.Authorization
{
    public static class ConfigurePolicies
    {
        public static IServiceCollection AddAuthorizationWithPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                // Define as políticas dinamicamente
                var policies = new Dictionary<string, string[]>
                {
                        { Policies.Animes.CAN_GET_ALL, new[] { Policies.Animes.CAN_GET_ALL } },
                        { Policies.Animes.CAN_GET_DETAIL, new[] { Policies.Animes.CAN_GET_ALL } }
                };

                foreach (var (policyName, claims) in policies)
                {
                    options.AddPolicy(policyName, policy =>
                    {
                        foreach (var claim in claims)
                        {
                            policy.RequireClaim(Policies.CLAIM_NAME, claim);
                        }
                    });
                }
            });

            return services;
        }
    }
}
