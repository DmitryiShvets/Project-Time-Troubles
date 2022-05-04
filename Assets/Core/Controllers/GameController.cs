using UnityEngine;


namespace Core
{
    /// <summary>
    /// The global game controller. It contains the game model and executes the schedule.
    /// </summary>
    public class GameController : MonoBehaviour
    {
   
        public GameModel model;

        // void Awake()
        // {
        //     Game.Run();
        // }

        protected virtual void OnEnable()
        {
            Schedule.SetModel<GameModel>(model);
        }

        protected virtual void Update()
        {
            Schedule.Tick();
        }
    }
}