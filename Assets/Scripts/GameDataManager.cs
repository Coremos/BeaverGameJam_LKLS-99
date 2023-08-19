public class GameDataManager : Singleton<GameDataManager>
{
    public IInventory PlayerInventory;
    public IInventory GlobalInventory;

    public GameDataManager()
    {
        PlayerInventory = new PlayerInventory();
        GlobalInventory = new GlobalInventory();
    }
}