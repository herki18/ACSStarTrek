using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApi.Models
{
    public class CrewMemberModel
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string FirstUrl { get; set; }
        public IconModel Icon { get; set; }
    }
}
