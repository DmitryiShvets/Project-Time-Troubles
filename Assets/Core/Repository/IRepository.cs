
namespace Core
{
    public interface IRepository
    {
        /// <summary>
        /// Called when all repositories and interactors created;
        /// </summary>
        void OnCreate();

        /// <summary>
        /// Called when all repositories and interactors initialized;
        /// </summary>
        void OnInitialize();

        /// <summary>
        /// Called when all repositories and interactors started;
        /// </summary>
        void OnStart();
        
     
    }
}