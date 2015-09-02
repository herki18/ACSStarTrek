using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceApi.Models;

namespace ServiceApi.DataAccess
{
    public interface ICrewManifestDA {
        CrewManifestModel Create();
        CrewManifestModel Retrieve();
        CrewManifestModel Save(CrewManifestModel crewManifest);
    }
}
