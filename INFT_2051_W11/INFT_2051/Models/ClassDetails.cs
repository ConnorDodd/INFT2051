using INFT_2051.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFT_2051.Models
{
    public static class ClassDetails
    {
        public static string[] _classes;

        public static string[] Classes
        {
            get
            {
                if (_classes != null)
                    return _classes;
                else
                    return new string[0];
            }
            set
            {
                _classes = value;
            }
        }

        public static async void LoadCharacterClasses()
        {
            string json = await ApiService.GetJsonFromAPI("classes");
            var response = JsonConvert.DeserializeObject<ApiClassResponse>(json);
            string[] classNames = new string[response.Count];
            for (int i = 0; i < response.Count; i++)
            {
                classNames[i] = response.Results[i].Name;
            }
            _classes = classNames;
        }
    }
}
