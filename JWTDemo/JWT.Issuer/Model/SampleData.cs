using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorizedServer.Model
{
    public static class SampleData
    {
        internal static async Task InitializeFortunesAsync(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<JWTTokenContext>();

                if (await db.Database.EnsureCreatedAsync())
                {
                    await InsertFortunes(db);
                }
            }

        }

        private static async Task InsertFortunes(JWTTokenContext db)
        {
            var fortunes = GetFortunes();
            foreach (var fortune in fortunes)
            {
                db.JWTTokens.Add(fortune);
            }
            await db.SaveChangesAsync();
        }

        private static JWTToken[] GetFortunes()
        {
            var fortunes = new JWTToken[]
            {
                new JWTToken{Id = "1",ClientId = "1",IsStop = 1,RefreshToken = "1"},
                new JWTToken { Id = "2",ClientId = "2",IsStop = 0,RefreshToken = "2"}
            };

            return fortunes;
        }
    }
}

