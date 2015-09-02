using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using ServiceApi.DataAccess;
using ServiceApi.Models;

namespace ACS.WebAPI.Controllers
{
    [EnableCors("http://localhost:64834", "*", "*")]
    public class CrewController : ApiController
    {
        private readonly ICrewDA _crewDA;

        public CrewController(ICrewDA crewDA) {
            _crewDA = crewDA;
        }

        // GET: api/Crew
        public IEnumerable<CrewMemberModel> Get()
        {
            return _crewDA.Get();
        }
    }
}
