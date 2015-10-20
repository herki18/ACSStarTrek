using System.Collections.Generic;
using System.Web.Http;
using ServiceApi.Models;

namespace ACS.StartTrekTesting.CrewManifestsTest
{
    public class CrewManifestsController : ApiController
    {
        // GET: api/CrewManifests
        public CrewManifestModel Get()
        {
            return new CrewManifestModel
            {
                Name = "Ship",
                Crew = new List<CrewMemberModel>() { new CrewMemberModel { Description = "Tere", Name = "Hallo", FirstUrl = ""} }
            };
        }

        // POST: api/CrewManifests
        public void Post(CrewManifestModel value)
        {
            
        }
    }
}
