using JetBrains.Annotations;
using UnityEngine;

namespace Core
{
    public class RQInfo : MonoBehaviour
    {
        public string sceneName;
        public string npcName;
        public string questName;
        [CanBeNull] public Quest quest;
        
    }
}