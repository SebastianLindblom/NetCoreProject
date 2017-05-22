using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudburryNet.Services.Helpers
{
    public class ApiClientHelper
    {
        private Data.ApplicationDbContext dbcontext { get; set; }
        private string api { get; set; }
        private System.Net.Http.HttpClient client { get; set; }
        public ApiClientHelper(string apiurl, Data.ApplicationDbContext _dbcontext)
        {
            client = new System.Net.Http.HttpClient();

            dbcontext = _dbcontext;
            api = apiurl;
            client.BaseAddress = new Uri(api);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/jsonp"));

        }

        //http://randomword.setgetgo.com/get.php
        public async Task<string> GetRandomNameAsync()
        {
            string result = "";
            try
            {
                while ((result == null || result == "") || (result != null && result != "" && dbcontext.User.Any(x => x.Alias != result)))
                {
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception e)
            {
                if (System.Diagnostics.Debugger.IsAttached) { throw e; }
            }
            return result;
        }
    }
}
