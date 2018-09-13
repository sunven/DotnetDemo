using System;
using Microsoft.IdentityModel.Tokens;

namespace AuthorizedServer.Model
{
    public class JWTTokenOptions
    {
        /// <summary>
        /// 签发者
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 接收者
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 签名证书
        /// </summary>
        public SigningCredentials Credentials { get; set; }
    }
}