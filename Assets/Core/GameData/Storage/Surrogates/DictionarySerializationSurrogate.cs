using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace StorageSystem
{
    public class DictionarySerializationSurrogate

    {
        Sprite[] sprite = Resources.LoadAll<Sprite>("Items");

        public XElement Serialize(Dictionary<string, int> inventory)
        {
            XElement attributes = new XElement("inventory");
            foreach (var item in inventory)
            {
                attributes.Add(new XElement("item", new XAttribute(item.Key, item.Value)));
            }

            return attributes;
        }

        public XElement Serialize(Dictionary<string, Sprite> inventory)
        {
            XElement attributes = new XElement("inventorySprites");
            foreach (var item in inventory)
            {
                attributes.Add(new XElement("item", new XAttribute(item.Key, item.Value.texture.name)));
            }

            return attributes;
        }

        public Dictionary<string, int> DeserializeItems(string xDocument)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            XElement inventory = XDocument.Parse(xDocument).Element("root")?.Element("inventory");
            if (inventory != null)
                foreach (var item in inventory.Elements())
                {
                    result[item.FirstAttribute.Name.ToString()] = Convert.ToInt32(item.FirstAttribute.Value);
                }

            return result;
        }

        public Dictionary<string, Sprite> DeserializeSprite(string xDocument)
        {
            Dictionary<string, Sprite> result = new Dictionary<string, Sprite>();

            XElement inventory = XDocument.Parse(xDocument).Element("root")?.Element("inventorySprites");
            if (inventory != null)
                foreach (var item in inventory.Elements())
                {
                    result[item.FirstAttribute.Name.ToString()] = LoadSprite(item.FirstAttribute.Name.ToString());
                }

            return result;
        }

        private Sprite LoadSprite(string spiteName)
        {
            var spr = Resources.Load<Sprite>(spiteName);
            return spr != null ? spr : sprite[0];
        }
    }
}