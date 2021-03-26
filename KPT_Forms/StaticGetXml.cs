using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KPT_Forms
{
    /// <summary>
    /// Класс, необходимый для вывода в методах необходимые параметры ключа, по котором будет произведен поиск необходимых корней.
    /// </summary>
    public class StaticGetXml
    {
        public static IEnumerable<XElement> GetZonesAndTerritoriesBoundaries(XDocument xdoc)
        {
            return xdoc.Element("extract_cadastral_plan_territory").Element("cadastral_blocks").Element("cadastral_block").Elements("zones_and_territories_boundaries").Elements("zones_and_territories_record").Elements("b_object_zones_and_territories").Elements("b_object").Elements("reg_numb_border");
        }
        public static IEnumerable<XElement> GetMunicipalBoundaries(XDocument xdoc)
        {
            return xdoc.Element("extract_cadastral_plan_territory").Element("cadastral_blocks").Element("cadastral_block").Elements("municipal_boundaries").Elements("municipal_boundary_record").Elements("b_object_municipal_boundary").Elements("b_object").Elements("reg_numb_border");
        }

        public static IEnumerable<XElement> GetSpetialData(XDocument xdoc)
        {
            return xdoc.Element("extract_cadastral_plan_territory").Element("cadastral_blocks").Element("cadastral_block").Elements("spatial_data").Elements("entity_spatial").Elements("sk_id");
        }

        public static IEnumerable<XElement> GetConstruction(XDocument xdoc)
        {
            return xdoc.Element("extract_cadastral_plan_territory").Element("cadastral_blocks").Element("cadastral_block").Elements("record_data").Elements("base_data").Elements("construction_records").Elements("construction_record").Elements("object").Elements("common_data").Elements("cad_number");
        }

        public static IEnumerable<XElement> GetBuild(XDocument xdoc)
        {
            return xdoc.Element("extract_cadastral_plan_territory").Element("cadastral_blocks").Element("cadastral_block").Elements("record_data").Elements("base_data").Elements("build_records").Elements("build_record").Elements("object").Elements("common_data").Elements("cad_number");
        }

        public static IEnumerable<XElement> GetLandRecords(XDocument xdoc)
        {
            return xdoc.Element("extract_cadastral_plan_territory").Element("cadastral_blocks").Element("cadastral_block").Elements("record_data").Elements("base_data").Elements("land_records").Elements("land_record").Elements("object").Elements("common_data").Elements("cad_number");
        }

    }
}
