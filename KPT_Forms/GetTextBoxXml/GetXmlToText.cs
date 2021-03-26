using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KPT_Forms.GetTextBoxXml
{
    /// <summary>
    /// Абстрактный класс, с помощью которого выбирается по названию стобца какой объект будет отображаться в richTextBox(сделан для того, чтобы избежать условные конструкции в классе с формой).
    /// </summary>
    public abstract class GetXmlToText
    {
        public static GetXmlToText Create(string type)
        {
            switch (type)
            {
                case "ParcelID":
                    return new GetTextParcelID();
                case "SpatialDataID":
                    return new GetTextSpatialDataID();
                case "BoundID":
                    return new GetTextBoundID();
                case "ZoneID":
                    return new GetTextZoneID();
                case "BuildID":
                    return new GetTextBuildID();
                case "ConstructionID":
                    return new GetTextConstructionID();
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Метод, который возвращает название имени используемого столбца.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cadastralNumber"></param>
        /// <returns></returns>
        public abstract string GetItem(XDocument item, string cadastralNumber);
    }

    public class GetTextConstructionID : GetXmlToText
    {
        public override string GetItem(XDocument item, string cadastralNumber)
        {
            foreach (XElement i in item.Descendants("construction_record"))
            {
                if (i.Element("object").Element("common_data").Element("cad_number").Value == cadastralNumber)
                {
                    return i.ToString();
                }
            }
            return null;
        }
    }

    public class GetTextBuildID : GetXmlToText
    {
        public override string GetItem(XDocument item, string cadastralNumber)
        {
            foreach (XElement i in item.Descendants("build_record"))
            {
                if (i.Element("object").Element("common_data").Element("cad_number").Value == cadastralNumber)
                {
                    return i.ToString();
                }
            }
            return null;
        }
    }
    public class GetTextZoneID : GetXmlToText
    {
        public override string GetItem(XDocument item, string cadastralNumber)
        {
            foreach (XElement i in item.Descendants("zones_and_territories_record"))
            {
                if (i.Element("b_object_zones_and_territories").Element("b_object").Element("reg_numb_border").Value == cadastralNumber)
                {
                    return i.ToString();                   
                }
            }
            return null;
        }
    }



    public class GetTextSpatialDataID : GetXmlToText
    {
        public override string GetItem(XDocument item, string cadastralNumber)
        {
            foreach (XElement i in item.Descendants("spatial_data"))
            {
                if (i.Element("entity_spatial").Element("sk_id").Value == cadastralNumber)
                {
                    return i.ToString();
                }

            }
            return null;
        }
    }

    public class GetTextParcelID : GetXmlToText
    {
        public override string GetItem(XDocument item, string cadastralNumber)
        {
            foreach (XElement i in item.Descendants("land_record"))
            {
                if (i.Element("object").Element("common_data").Element("cad_number").Value == cadastralNumber)
                {
                    return  i.ToString();
                }
            }
            return null;
        }
    }
    public class GetTextBoundID : GetXmlToText
    {
        public override string GetItem(XDocument item, string cadastralNumber)
        {
            foreach (XElement i in item.Descendants("municipal_boundary_record"))
            {
                if (i.Element("b_object_municipal_boundary").Element("b_object").Element("reg_numb_border").Value == cadastralNumber)
                {
                    return i.ToString();
                }
            }
            return null;
        }
    }
}
