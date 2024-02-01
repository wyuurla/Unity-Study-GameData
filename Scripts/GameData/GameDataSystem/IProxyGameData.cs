

public interface IProxyGameData
{
    public void Load();
    public void Check();
    public void Save();
    public void Logout();
    public void UpdateLogic();
    public GameData GetGameData();
}
