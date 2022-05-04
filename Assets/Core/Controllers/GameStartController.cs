using UnityEngine;

namespace Core
{
    public class GameStartController : MonoBehaviour
    {
        private static bool isInitialized;

        void Awake()
        {
            if (!isInitialized)
            {
                isInitialized = true;
                DontDestroyOnLoad(gameObject);
                Game.Run();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}