using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using Core;
using Core.GameData.Storage;
using UnityEngine;

namespace StorageSystem
{
    public class LootBoxesSerializationSurrogate
    {
        public XElement SerializeLootBoxObj(List<LootBox> objects)
        {
            XElement gameObj = new XElement("loot-objects");
            foreach (var obj in objects)
            {
                gameObj.Add(new XElement(obj.name, obj.isUsed));
            }

            return gameObj;
        }

        public Dictionary<string, bool> DeserializeLootBoxObj(string sceneName, string xDocument)
        {
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            XElement objects = XDocument.Parse(xDocument).Element("root")?.Element(sceneName)?.Element("loot-objects");
            if (objects != null)
                foreach (var item in objects.Elements())
                {
                    result[item.Name.ToString()] = GetBool(item.Value);
                }

            return result;
        }

        bool GetBool(string str)
        {
            return str == "true";
        }
    }
}