using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using System.Configuration;
using System.Xml;

namespace ety
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            string URL = ConfigurationManager.AppSettings["ip"];
            WebClient webClient = new WebClient();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            NameValueCollection formData = new NameValueCollection();
            
            formData["user"] = userName;

            byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
            string responsefromserver = Encoding.UTF8.GetString(responseBytes);
            System.Diagnostics.Process.Start(ConfigurationManager.AppSettings["website"]);
        }
    }
}
