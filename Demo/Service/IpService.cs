using Demo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Demo.Service
{
    public class IpService
    {
        public static string GetIPAddress(HttpRequestBase request)
        {
            string ip;
            try
            {
                ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!string.IsNullOrEmpty(ip))
                {
                    if (ip.IndexOf(",") > 0)
                    {
                        string[] ipRange = ip.Split(',');
                        int le = ipRange.Length - 1;
                        ip = ipRange[le];
                    }
                }
                else
                {
                    ip = request.UserHostAddress;
                }
            }
            catch { ip = null; }

            return ip;
        }

        public static string GetIPAddressViaSohuAPI()
        {
            string ip = string.Empty;

            var request = (HttpWebRequest)WebRequest.Create("http://pv.sohu.com/cityjson?ie=utf-8");
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            int startIndex = responseString.IndexOf("{");
            int endIndex = responseString.Length - 1 - startIndex;
            string json = responseString.Substring(startIndex, endIndex);

            SohuIp sohuIp = JsonConvert.DeserializeObject<SohuIp>(json);

            ip = sohuIp.cip;

            return ip;
        }
    }
}