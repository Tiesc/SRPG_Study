namespace ELGame
{
    public abstract class BaseManager<T>
        : MonoBehaviourSingleton<T>
        where T : BaseManager<T>
    {
        public virtual string MangerName => "BaseManager";

        public virtual void InitManager()
        {
        }

        public virtual void ResetManager()
        {
        }
    }
}