using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientFactoryConsoleApp.Services
{
    public interface IHttpUtils
    {
        Task<string> GetUrl(string url);

        string ConvertToBase64String(string url);
    }
}
