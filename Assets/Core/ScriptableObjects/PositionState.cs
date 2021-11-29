using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New PlayerPositionState", menuName = "SO/PositionState", order = 51)]
    public class PositionState : ScriptableObject
    {
        public Vector2 pos;
    }
}