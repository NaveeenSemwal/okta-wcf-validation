using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfServiceWithOkta
{
    /// <summary>
    /// https://stackoverflow.com/questions/28846695/oauth-and-wcf-soap-service
    /// 
    /// http://adilmughal.com/blog/2011/10/client-additional-parameters-using-custom-headers-in-wcf/
    /// </summary>
    public class OAuthAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            //Extract the Authorization header, and parse out the credentials converting the Base64 string:  
            var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            if ((authHeader != null) && (authHeader != string.Empty))
            {
                return true;
            }
            else
            {
                //Throw an exception with the associated HTTP status code equivalent to HTTP status 401  
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
        }
    }
}