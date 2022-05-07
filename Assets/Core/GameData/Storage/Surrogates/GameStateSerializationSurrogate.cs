using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using UnityEngine;

namespace StorageSystem
{
    public class GameStateSerializationSurrogate
    {
        private List<string> allScenes = new List<string>
            {"Menu", "home", "Temple", "FrozenMountain", "Forest", "Caves", "CampDesert"};

        public XElement SerializeLastScene(string lastScene)
        {
            return new XElement("last-scene", lastScene);
        }

        public XElement SerializationPlayerLocation(Vector3 position)
        {
            XElement xPosition = new XElement("player-pos", new XAttribute("x", position.x),
                new XAttribute("y", position.y), new XAttribute("z", position.z));
            return xPosition;
        }

        public string DeserializeLastScene(string xDocument)
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
                    if (scene.Name.ToString() != sceneName && allScenes.Contains(scene.Name.ToString()))
                        result.Add(scene);
                }
            }

            return result;
        }

        public Vector3 DeserializePlayerLocation(string sceneName, string xDocument)
        {
            Vector3 result = new Vector3();
            XElement pos = XDocument.Parse(xDocument).Element("root")?.Element(sceneName)
                ?.Element("player-pos");

            CultureInfo ci = (CultureInfo) CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
            if (pos != null)
            {
                result.x = float.Parse(pos.Attribute("x").Value, NumberStyles.Any, ci);
                result.y = float.Parse(pos.Attribute("y").Value, NumberStyles.Any, ci);
                result.z = float.Parse(pos.Attribute("z").Value, NumberStyles.Any, ci);


                return result;
            }

            return Vector3.zero;
        }
    }
}