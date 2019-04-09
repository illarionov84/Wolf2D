namespace Wolf2D
{

    public interface IGameManager
    {
        ManagerStatus status { get; }

        void Startup();
    }

}
