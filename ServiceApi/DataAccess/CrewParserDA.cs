using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ServiceApi.Models;

namespace ServiceApi.DataAccess
{
    public class CrewParserDA : ICrewDA {
        private readonly string _url;

        public CrewParserDA(string url) {
            _url = url;
        }

        public List<CrewMemberModel> Get() {
            var synClient = new WebClient();

            var content = synClient.DownloadString(_url);

            return ParseJson(content);
        }

        private List<CrewMemberModel> ParseJson(string content)
        {
            var crewList = new List<CrewMemberModel>();


            dynamic json = JToken.Parse(content);
            foreach (var j in json.RelatedTopics)
            {
                var crew = new CrewMemberModel();
                crew.Description = j.Text.ToString();
                crew.FirstUrl = j.FirstURL.ToString();
                crew.Icon = new IconModel
                {
                    Url = j.Icon.URL.ToString(),
                    Height = j.Icon.Height.ToString(),
                    Width = j.Icon.Width.ToString()
                };

                crewList.Add(crew);
            }
            return crewList;
            
        } 
    }
}
