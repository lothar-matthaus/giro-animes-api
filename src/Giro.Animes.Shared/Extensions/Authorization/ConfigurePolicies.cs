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
                options.AddPolicy(Policies.Animes.CAN_GET_ALL, policy =>
                {
                    policy.RequireClaim(Policies.CLAIM_NAME, Policies.Animes.CAN_GET_ALL);
                });

                options.AddPolicy(Policies.Animes.CAN_GET_DETAIL, policy =>
                {
                    policy.RequireClaim(Policies.CLAIM_NAME, Policies.Animes.CAN_GET_ALL);
                });

                // 
                options.AddPolicy(Policies.Authors.CAN_GET_ALL, policy =>
                {
                    policy.RequireClaim(Policies.CLAIM_NAME, Policies.Authors.CAN_GET_ALL);
                });

                options.AddPolicy(Policies.Authors.CAN_GET_DETAIL, policy =>
                {
                    policy.RequireClaim(Policies.CLAIM_NAME, Policies.Authors.CAN_GET_DETAIL);
                });
            });

            return services;
        }
    }
}
