public class GameDataManager : Singleton<GameDataManager>
{
    public PlayerInventory PlayerInventory;
    public GlobalInventory GlobalInventory;

    public GameDataManager()
    {
        PlayerInventory = new PlayerInventory();
        GlobalInventory = new GlobalInventory();
    }
}