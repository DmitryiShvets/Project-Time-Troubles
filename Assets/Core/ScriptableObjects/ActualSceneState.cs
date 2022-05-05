
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New ActualSceneState", menuName = "SO/ActualSceneState", order = 53)]
    public class ActualSceneState : ScriptableObject
    {
        public string lastScene;
    }
}