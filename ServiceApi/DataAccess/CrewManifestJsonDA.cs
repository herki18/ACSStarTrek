using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using Newtonsoft.Json;
using ServiceApi.Models;

namespace ServiceApi.DataAccess
{
    public class CrewManifestJsonDA : ICrewManifestDA {
        private readonly string _filePath;

        public CrewManifestJsonDA(string filePath) {
            _filePath = filePath;
        }

        /// <summary>
        /// Create a new CrewManifest with default values
        /// </summary>
        /// <returns></returns>
        public CrewManifestModel Create() {
            CrewManifestModel crewManifest = new CrewManifestModel {
                Crew = new List<CrewMemberModel>(),
                Name = "NCC Over 9000"
            };
            return crewManifest;
        }

        /// <summary>
        /// Retrives the list of CrewManifests
        /// </summary>
        /// <returns></returns>
        public CrewManifestModel Retrieve()
        {
            var filePath = HostingEnvironment.MapPath(_filePath);

            var json = File.ReadAllText(filePath);

            var crewManifest = JsonConvert.DeserializeObject<CrewManifestModel>(json);

            return crewManifest;
        }

        /// <summary>
        /// Saves a new CrewManifest
        /// </summary>
        /// <param name="crewManifest"></param>
        /// <returns></returns>
        public CrewManifestModel Save(CrewManifestModel crewManifest) {
            WriteData(crewManifest);
            
            return crewManifest;
        }

        private bool WriteData(CrewManifestModel manifestModel) {
            // Write out the Json
            var filePath = HostingEnvironment.MapPath(_filePath);

            var json = JsonConvert.SerializeObject(manifestModel, Formatting.Indented);
            File.WriteAllText(filePath, json);

            return true;
        }
    }
}
