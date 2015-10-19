using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ServiceApi.Models;

namespace ACS.StartTrekTesting
{
    public class CrewManifestsController : ApiController
    {
        // GET: api/CrewManifests
        public CrewManifestModel Get()
        {
            return new CrewManifestModel();
        }

        // POST: api/CrewManifests
        public void Post(CrewManifestModel value)
        {
            
        }
    }
}
