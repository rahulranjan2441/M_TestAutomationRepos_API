using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_TestAutomation_API.TestData
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Dragon
    {
        public string capsule { get; set; }
        public string mass_returned_kg { get; set; }
        public string mass_returned_lbs { get; set; }
        public string flight_time_sec { get; set; }
        public string manifest { get; set; }
        public bool? water_landing { get; set; }
        public bool? land_landing { get; set; }
    }

    public class m_GetOnePayloadPropertiesClass
    {
        public Dragon dragon { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool reused { get; set; }
        public string launch { get; set; }
        public List<string> customers { get; set; }
        public List<int> norad_ids { get; set; }
        public List<string> nationalities { get; set; }
        public List<string> manufacturers { get; set; }
        public string mass_kg { get; set; }
        public double? mass_lbs { get; set; }
        public string orbit { get; set; }
        public string reference_system { get; set; }
        public string regime { get; set; }
        public double? longitude { get; set; }
        public double? semi_major_axis_km { get; set; }
        public double? eccentricity { get; set; }
        public double? periapsis_km { get; set; }
        public double? apoapsis_km { get; set; }
        public double? inclination_deg { get; set; }
        public double? period_min { get; set; }
        public string lifespan_years { get; set; }
        public DateTime? epoch { get; set; }
        public double? mean_motion { get; set; }
        public double? raan { get; set; }
        public double? arg_of_pericenter { get; set; }
        public double? mean_anomaly { get; set; }
        public string id { get; set; }
    }
}
