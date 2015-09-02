using System.Web.Http;
using System.Web.Http.Cors;
using ServiceApi.DataAccess;
using ServiceApi.Models;

namespace ACS.WebAPI.Controllers
{
    [EnableCors("http://localhost:64834", "*", "*")]
    public class CrewManifestsController : ApiController
    {
        private readonly ICrewManifestDA _crewManifestDA;

        public CrewManifestsController(ICrewManifestDA crewManifestDA) {
            _crewManifestDA = crewManifestDA;
        }

        // GET: api/CrewManifests
        public CrewManifestModel Get()
        {
            return _crewManifestDA.Retrieve();
        }

        // POST: api/CrewManifests
        public void Post(CrewManifestModel value)
        {
            _crewManifestDA.Save(value);
        }
    }
}
