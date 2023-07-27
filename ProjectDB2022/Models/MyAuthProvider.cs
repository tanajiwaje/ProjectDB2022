using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DatabaseOperationServices;
using Microsoft.Owin.Security.OAuth;
using ProjectDatabaseOperation;

namespace ProjectDB2022.Models
{
    public class MyAuthProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            projectDBEntities obj = new projectDBEntities();
            var userdata=obj.sp_login_user(context.UserName,context.Password).FirstOrDefault();
            if (userdata != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, userdata.first_name));
                identity.AddClaim(new Claim(ClaimTypes.Name, userdata.user_id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Email, userdata.email_address));

                identity.AddClaim(new Claim(ClaimTypes.MobilePhone, userdata.mobile_number));
                context.Validated(identity);
            }
           
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                context.Rejected();
            }
           
        }

    }
}