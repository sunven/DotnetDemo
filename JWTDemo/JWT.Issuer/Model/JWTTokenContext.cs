using Microsoft.EntityFrameworkCore;

namespace AuthorizedServer.Model
{
    public class JWTTokenContext : DbContext
    {
        public JWTTokenContext(DbContextOptions<JWTTokenContext> options) :
            base(options)
        {

        }
        public DbSet<JWTToken> JWTTokens { get; set; }
    }
}
