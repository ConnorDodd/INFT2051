using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFT_2051.Models
{
    internal class ApiClassResponse
    {
        public int Count { get; set; }
        public ApiClassModel[] Results { get; set; }
    }
}
