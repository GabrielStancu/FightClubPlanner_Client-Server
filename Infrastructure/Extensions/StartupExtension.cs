using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.TournamentStrategies;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class StartupExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddScoped(typeof(IUserRepository<>), (typeof(UserRepository<>)));
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IFighterRepository, FighterRepository>();
            services.AddScoped<ITournamentFighterRepository, TournamentFighterRepository>();
            services.AddScoped<ICovidTestRepository, CovidTestRepository>();
            services.AddScoped<IFightRepository, FightRepository>();
            services.AddScoped<IInviteRepository, InviteRepository>();
            services.AddScoped<IIsolationBubbleRepository, IsolationBubbleRepository>();
            services.AddScoped<ITournamentRepository, TournamentRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IFighterService, FighterService>();
            services.AddScoped<IFightsGenerateService, FightsGenerateService>();
            services.AddScoped<IInvitableFightersSelectService, InvitableFightersSelectService>();
            services.AddScoped<IInviteService, InviteService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<ISignupCheckService, SignupCheckService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ITournamentService, TournamentService>();
        }

        public static void RegisterStrategy(this IServiceCollection services)
        {
            services.AddScoped<IMatchGenerator, MatchGenerator>();
            services.AddScoped<ITournamentScheduler, TournamentScheduler>();
        }
    }
}
