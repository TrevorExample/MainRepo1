using Microsoft.Graph;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureAd1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Create().Wait();
            Console.ReadLine();
        }


        private static async Task Create()
        {
            var graph = new GraphServiceClient(new AzureAuthenticationProvider());
            try
            {
                var users = await graph.Users.Request().GetAsync();
                int requestNumber = 1;
                while (users.Count > 0)
                {
                    Console.WriteLine("Request number: {0}", requestNumber++);
                    foreach (var u in users)
                    {
                        Console.WriteLine("User: {0} ({1})", u.DisplayName,
                            u.UserPrincipalName);
                    }

                    if (users.NextPageRequest != null)
                    {
                        users = await users.NextPageRequest.GetAsync();
                    }
                    else
                    {
                        break;
                    }
                }

                PasswordProfile pp = new PasswordProfile();
                pp.Password = "Redwhiteblue13!";
                pp.ForceChangePasswordNextSignIn = true;


                User newUser = new User
                {
                    Id = "mqn9822",
                    //BusinessPhones = "68299990802",
                    DisplayName = "mqn9822",
                    GivenName = "man nguyen",
                    JobTitle = "developer",
                    Mail = "mqn982@gmail.com",
                    MobilePhone = "68299990802",
                    OfficeLocation = "dallas tx",
                    PreferredLanguage = "english",
                    //Surname = someUser.Surname,
                    //UserPrincipalName = someUser.UserPrincipalName
                    PasswordProfile = pp

                };
                //User createdUser = await graph.Users.Request().AddAsync(newUser);

                Console.WriteLine("created user");

                var invitation = new Invitation
                {
                    InvitedUserEmailAddress = "mqn982@gmail.com",
                    InviteRedirectUrl = "https://localhost:44321/",
                    SendInvitationMessage = true
                };

                await graph.Invitations
                    .Request()
                    .AddAsync(invitation);
                Console.WriteLine("sent invite");


            }
            catch (ServiceException x)
            {
                Console.WriteLine("Exception occured: {0}", x.Error);
            }
        }



        internal class AppModeConstants
        {
            public const string ClientId = "06053782-1f7e-4859-8b6e-b451227e9846";
            public const string ClientSecret = "hYHu2Y.w6dQn40vY.AF1-cuI.vm~A6-YQO";
            public const string TenantName = "mqn982live.onmicrosoft.com";  //somedomain.com
            public const string TenantId = "2691f822-91d1-468b-8957-231457777e22";
            public const string AuthString = GlobalConstants.AuthString + TenantName;
        }


        internal class GlobalConstants
        {
            public const string AuthString = "https://login.microsoftonline.com/";
            public const string ResourceUrl = "https://graph.microsoft.com";
            public const string GraphServiceObjectId = "00000002-0000-0000-c000-000000000000";
        }

        public class AzureAuthenticationProvider : IAuthenticationProvider
        {
            public async Task AuthenticateRequestAsync(HttpRequestMessage request)
            {


                AuthenticationContext authContext = new AuthenticationContext(AppModeConstants.AuthString, false);

                ClientCredential creds = new ClientCredential(AppModeConstants.ClientId, AppModeConstants.ClientSecret);

                AuthenticationResult authResult = await authContext.AcquireTokenAsync(GlobalConstants.ResourceUrl, creds);

                request.Headers.Add("Authorization", "Bearer " + authResult.AccessToken);
            }
        }




    }






}
