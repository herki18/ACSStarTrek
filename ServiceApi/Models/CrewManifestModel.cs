using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApi.Models
{
    public class CrewManifestModel
    {
        public string Name { get; set; }
        public List<CrewMemberModel> Crew { get; set; } 
    }
}
