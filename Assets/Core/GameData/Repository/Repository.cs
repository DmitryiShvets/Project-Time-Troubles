namespace Core
{
    public abstract class Repository : IRepository
    {
        public abstract void Save();

        public virtual void OnCreate()
        {
        }

        public virtual void OnInitialize()
        {
        }

        public virtual void OnStart()
        {
        }
    }
}