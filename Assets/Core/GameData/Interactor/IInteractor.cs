namespace Core
{
    public interface IInteractor
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