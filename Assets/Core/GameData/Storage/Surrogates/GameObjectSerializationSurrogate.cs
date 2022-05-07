using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using Core.GameData.Storage;
using UnityEngine;

namespace StorageSystem
{
    public class GameObjectSerializationSurrogate
    {
        public XElement SerializeGameObj(List<SaveableGameObject> objects)
        {
            XElement gameObj = new XElement("game-objects");
            foreach (var obj in objects)
            {
                gameObj.Add(new XElement(obj.name, obj.isActive));
            }

            return gameObj;
        }

        public Dictionary<string, bool> DeserializeGameObj(string sceneName, string xDocument)
        {
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            XElement objects = XDocument.Parse(xDocument).Element("root")?.Element(sceneName)?.Element("game-objects");
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