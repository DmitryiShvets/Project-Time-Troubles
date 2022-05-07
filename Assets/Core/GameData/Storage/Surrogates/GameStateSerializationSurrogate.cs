using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace StorageSystem
{
    public class GameStateSerializationSurrogate
    {
        private List<string> allScenes = new List<string> {"Menu","home","Temple","FrozenMountain","Forest","Caves","CampDesert"};

        public XElement Serialize(string lastScene)
        {
            XElement attributes = new XElement("game-state");

            attributes.Add(new XElement("last-scene", lastScene));

            return attributes;
        }

        public string DeserializeItems(string xDocument)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            XElement gameState = XDocument.Parse(xDocument).Element("root")?.Element("game-state")
                ?.Element("last-scene");
            return gameState != null ? gameState.Value : "Menu";
        }

        public List<XElement> DeserializeScenes(string sceneName, string xDocument)
        {
            List<XElement> result = new List<XElement>();
            XElement root = XDocument.Parse(xDocument).Element("root");
            if (root != null)
            {
                foreach (var scene in root.Elements())
                {
                    if (scene.Name.ToString() != sceneName && allScenes.Contains(scene.Name.ToString())) result.Add(scene);
                }
            }

            return result;
        }
    }
}