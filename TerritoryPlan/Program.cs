using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace TerritoryPlan
{
    class Program
    {
        static void Main(string[] args)
        {

            XDocument xdoc = XDocument.Load("24_21_1003001_2017-05-29_kpt11 (1).xml");

            //Вывод номеров земельных участков
            //GetNumberObjext(GetLandRecords(xdoc));

            //// Вывод номеров зданий
            //GetNumberObjext(GetBuild(xdoc));

            ////Вывод номеров сооружений
            //GetNumberObjext(GetConstruction(xdoc));

            ////Вывод номеров пространственных данных
            //GetNumberObjext(GetStetialData(xdoc));

            ////Вывод номеров границ муниципального образования
            //GetNumberObjext(GetMunicipalBoundaries(xdoc));

            ////Вывод номеров зон с особыми условиями использования территории
            //GetNumberObjext(GetZonesAndTerritoriesBoundaries(xdoc));

            foreach (var i in xdoc.Descendants("land_record"))
            {
                if(i.Element("object").Element("common_data").Element("cad_number").Value == "24:21:1003001:99")           
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        private static void GetNumberObjext(IEnumerable<XElement> xElements)
        {
            foreach (XElement cadastrElement in xElements)
            {
                Console.WriteLine(cadastrElement.Value);
            }
            Console.WriteLine();

        }

        private static IEnumerable<XElement> GetZonesAndTerritoriesBoundaries(XDocument xdoc)
        {
            return xdoc.Element("extract_cadastral_plan_territory").Element("cadastral_blocks").Element("cadastral_block").Elements("zones_and_territories_boundaries").Elements("zones_and_territories_record").Elements("b_object_zones_and_territories").Elements("b_object").Elements("reg_numb_border");
        }
        private static IEnumerable<XElement> GetMunicipalBoundaries(XDocument xdoc)
        {
            return xdoc.Element("extract_cadastral_plan_territory").Element("cadastral_blocks").Element("cadastral_block").Elements("municipal_boundaries").Elements("municipal_boundary_record").Elements("b_object_municipal_boundary").Elements("b_object").Elements("reg_numb_border");
        }

        private static IEnumerable<XElement> GetStetialData(XDocument xdoc)
        {
            return xdoc.Element("extract_cadastral_plan_territory").Element("cadastral_blocks").Element("cadastral_block").Elements("spatial_data").Elements("entity_spatial").Elements("sk_id");
        }

        private static IEnumerable<XElement> GetConstruction(XDocument xdoc)
        {
            return xdoc.Element("extract_cadastral_plan_territory").Element("cadastral_blocks").Element("cadastral_block").Elements("record_data").Elements("base_data").Elements("construction_records").Elements("construction_record").Elements("object").Elements("common_data").Elements("cad_number");
        }

        private static IEnumerable<XElement> GetBuild(XDocument xdoc)
        {
            return xdoc.Element("extract_cadastral_plan_territory").Element("cadastral_blocks").Element("cadastral_block").Elements("record_data").Elements("base_data").Elements("build_records").Elements("build_record").Elements("object").Elements("common_data").Elements("cad_number");
        }

        private static IEnumerable<XElement> GetLandRecords(XDocument xdoc)
        {
            return xdoc.Element("extract_cadastral_plan_territory").Element("cadastral_blocks").Element("cadastral_block").Elements("record_data").Elements("base_data").Elements("land_records").Elements("land_record").Elements("object").Elements("common_data").Elements("cad_number");
        }
    }
}
