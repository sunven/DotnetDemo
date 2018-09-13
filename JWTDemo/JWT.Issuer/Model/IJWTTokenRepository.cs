namespace AuthorizedServer.Model
{
    public interface IJWTTokenRepository
    {
        bool AddToken(JWTToken token);

        bool ExpireToken(JWTToken token);

        JWTToken GetToken(string refreshToken, string clientId);
    }
}
