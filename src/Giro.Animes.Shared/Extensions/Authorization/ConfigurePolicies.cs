using Giro.Animes.Shared.Constants;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Giro.Animes.Shared.Extensions.Authorization
{
    public static class ConfigurePolicies
    {
        /// <summary>
        /// Método de extensão para adicionar políticas de autorização com base nas constantes definidas na classe Policies.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAuthorizationWithPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                // Obter todas as policies dinamicamente da classe Policies
                var policies = GetPoliciesFromConstants();

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

        /// <summary>
        /// Método para obter as policies a partir das constantes definidas na classe Policies.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string[]> GetPoliciesFromConstants()
        {
            var policies = new Dictionary<string, string[]>();

            // Obter todas as subclasses e constantes da classe Policies
            var nestedTypes = typeof(Policies).GetNestedTypes(BindingFlags.Public | BindingFlags.Static);
            foreach (var nestedType in nestedTypes)
            {
                var constants = nestedType.GetFields(BindingFlags.Public | BindingFlags.Static)
                                          .Where(f => f.FieldType == typeof(string))
                                          .Select(f => f.GetValue(null)?.ToString())
                                          .Where(value => value != null)
                                          .ToArray();

                foreach (var constant in constants)
                {
                    // Adicionar cada constante como uma policy com ela mesma como claim
                    policies[constant] = new[] { constant };
                }
            }

            return policies;
        }
    }
}
