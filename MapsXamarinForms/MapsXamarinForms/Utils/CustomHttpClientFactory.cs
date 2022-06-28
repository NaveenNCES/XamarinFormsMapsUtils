using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MapsXamarinForms.Utils
{
    public class CustomHttpClientFactory : DefaultHttpClientFactory
    {
        public override HttpClient CreateHttpClient(HttpMessageHandler handler)
        {
            if (handler is HttpClientHandler clientHandler)
                // bypass SSL certificate
                clientHandler.ServerCertificateCustomValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => { return true; };
            return base.CreateHttpClient(handler);
        }
    }
}
