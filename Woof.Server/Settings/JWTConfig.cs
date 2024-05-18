﻿namespace Woof.Server.Settings
{
    public class JWTConfig
    {
        public required string Secret { get; set; }
        public required string ValidIssuer { get; set; }
        public required string ValidAudience { get; set; }
    }
}
