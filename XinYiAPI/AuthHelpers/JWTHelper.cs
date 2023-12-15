using System;
using System.IO;

namespace XinYiAPI.AuthHelpers
{
    public class JWTHelper
    {
        public static string IssueJwt (TokenModelJwt tokenModel)
        {
            return "";
        }
        public class TokenModelJwt
        {
            public long Uid { get; set; }
            public string Role { get; set; }
            public string Work { get; set; }
        }
        public class AppSecretConfig
        {
            private static string Audience_Secret = AppSettings.app(new string[] { "Audience", "Secret" });
            private static string Audience_Secret_File = AppSettings.app(new string[] { "Audience", "Secret" });
            public static string Audience_Secret_String => InitAudience_Secret();
            private static string InitAudience_Secret()
            {
                var securityString = DifDBConnOfSecruity(Audience_Secret_File);
                if (string.IsNullOrEmpty(Audience_Secret_File) && string.IsNullOrEmpty(InitAudience_Secret()))
                {
                    return Audience_Secret;
                }
                else
                {
                    return File.ReadAllText(Audience_Secret_File);
                }
            }

            private static object DifDBConnOfSecruity(params string[] conn)
            {
                foreach(var item in conn)
                {
                    try
                    {
                        if (File.Exists(item))
                        {
                            return File.ReadAllText(item).Trim();
                        }
                    }
                catch (Exception)
                    {
                        continue;
                    }
                }
                return conn[conn.Length - 1];
            }
        }
    }
}
