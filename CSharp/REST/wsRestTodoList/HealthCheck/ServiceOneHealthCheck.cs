using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace wsRestTodoList.HealthCheck
{
    /// <summary>
    /// Exemple d'implementation du service de controle d'etat.
    /// Renvois comme etat la valeur passé en parametre au constructeur.
    /// </summary>
    public class ServiceOneHealthCheck : IHealthCheck
    {
        /// <summary>
        /// CTOR
        /// Les arguments sont passés par le ligne de commande qui enregistre le HealthCheck
        /// exemple :
        /// builder.Services.AddHealthChecks()
        ///                 .AddTypeActivatedCheck<ServiceOneHealthCheck>("RestTodoListHealthCheckOne", 
        ///                                                               args: new object[] { HealthStatus.Healthy });
        /// voir program.cs
        /// </summary>
        public ServiceOneHealthCheck(HealthStatus _CheckStatus)
        {
            CheckStatus = _CheckStatus;
        }
        private HealthStatus CheckStatus;

        /// <summary>
        /// Methode invoqué par le gestionnaire pour verifier l'etat du service 1
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            // Renvoyer les differents etat possible
            // ils peuvent être créer par factory de la classe HealthCheckResult
            HealthCheckResult Result;
            switch (CheckStatus)
            {
                case HealthStatus.Degraded: 
                    Result = HealthCheckResult.Degraded("A DEGRADED result."); 
                    break;

                case HealthStatus.Unhealthy: 
                    Result = HealthCheckResult.Unhealthy("A UNHEALTHY result."); 
                    break;

                default: // par défaut tout va bien
                case HealthStatus.Healthy:
                    Result = HealthCheckResult.Healthy("A HEALTHY result.");
                    break;
            }


            //return Task.FromResult(
            //    new HealthCheckResult(
            //        context.Registration.FailureStatus, "An unhealthy result."));
            return Task.FromResult(Result);
        }
    }
}
