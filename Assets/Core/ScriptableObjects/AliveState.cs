using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New AliveState", menuName = "SO/AliveState", order = 52)]
    public class AliveState : ScriptableObject
    {
        public bool isAlive;

        public void ResetState()
        {
            this.isAlive = true;
        }
    }
}