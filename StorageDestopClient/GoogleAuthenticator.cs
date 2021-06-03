using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StorageDestopClient
{
    static class GoogleAuthenticator
    {
        public static async Task<UserCredential> GetUserCredential(string secretPath)
        {
            UserCredential credential;
            using (var stream = new FileStream(secretPath, FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { DriveService.Scope.Drive },
                    "user", CancellationToken.None);
            }            
            return credential;
        }
    }
}
