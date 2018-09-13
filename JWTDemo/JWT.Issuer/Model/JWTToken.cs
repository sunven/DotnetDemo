namespace AuthorizedServer.Model
{
    public class JWTToken
    {
        public string Id { get; set; }

        public string ClientId { get; set; }

        public string RefreshToken { get; set; }

        public int IsStop { get; set; }
    }
}
