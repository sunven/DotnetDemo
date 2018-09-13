using System.Linq;

namespace AuthorizedServer.Model
{
    public class JWTTokenRepository : IJWTTokenRepository
    {
        private readonly JWTTokenContext _db;

        public JWTTokenRepository(JWTTokenContext db)
        {
            _db = db;
        }

        public bool AddToken(JWTToken token)
        {
            _db.JWTTokens.Add(token);

            return _db.SaveChanges() > 0;
        }

        public bool ExpireToken(JWTToken token)
        {
            _db.JWTTokens.Update(token);

            return _db.SaveChanges() > 0;
        }

        public JWTToken GetToken(string refreshToken, string clientId)
        {
            return _db.JWTTokens.FirstOrDefault(x => x.ClientId == clientId && x.RefreshToken == refreshToken);
        }
    }
}
