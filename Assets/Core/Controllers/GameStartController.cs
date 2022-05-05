using UnityEngine;

namespace Core
{
    public class GameStartController : MonoBehaviour
    {
        private static bool isInitialized;
        [SerializeField]
        private string sceneName="Temple";

        void Awake()
        {
            if (!isInitialized)
            {
                isInitialized = true;
                DontDestroyOnLoad(gameObject);
                Game.Run();
               // Game.LoadScene(sceneName);
            }
            else
            {
              
                Destroy(gameObject);
            }
        }
    }
}