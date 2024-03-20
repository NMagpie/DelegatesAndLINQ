using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._Delegates_and_LINQ
{
    // 5. Using extention methods on the collection

    public static class MovieExtention
    {
        public static string MovieAsJson(this Movie movie)
        {
            return JsonConvert.SerializeObject(movie);
        }
    }
}
