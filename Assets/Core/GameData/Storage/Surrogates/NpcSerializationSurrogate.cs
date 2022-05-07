using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Core;
using UnityEngine;

namespace StorageSystem
{
    public class NpcSerializationSurrogate
    {
        public XElement Serialize(List<NPCController> npclist)
        {
            XElement npcXElement = new XElement("npc");
            foreach (var npc in npclist)
            {
                //  attributes.Add(new XElement("item", new XAttribute(item.Key, item.Value)));
                var xElement = new XElement(npc.name);
                foreach (var quest in npc.quests)
                {
                    xElement.Add(new XAttribute(quest.name, quest.isFinished));
                }

                npcXElement.Add(xElement);
            }

            return npcXElement;
        }

        public Dictionary<string, Dictionary<string, bool>> DeserializeItems(string sceneName, string xDocument)
        {
            Dictionary<string, Dictionary<string, bool>> result = new Dictionary<string, Dictionary<string, bool>>();
            XElement npclist = XDocument.Parse(xDocument).Element("root")?.Element(sceneName)?.Element("npc");
            if (npclist != null)
                foreach (var item in npclist.Elements())
                {
                    result[item.Name.ToString()] = new Dictionary<string, bool>();
                    foreach (var attribute in item.Attributes())
                    {
                        result[item.Name.ToString()][attribute.Name.ToString()] = GetBool(attribute.Value);
                    }
                }

            return result;
        }

        bool GetBool(string str)
        {
            return str == "true";
        }
    }
}