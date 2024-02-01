/**
 * @brief GameData
 * @detail 
 * @date 2024-02-01
 * @version 1.0.0
 * @author kij
 */
public class GameData : Subject
{
    private bool m_isSave;
    public bool isSave { get { return m_isSave; } }


    public void SaveNotify()
    {
        Save();
        Notify();
    }

    public void Save()
    {
        SetSave(true);
    }

    public void SetSave(bool _isSave)
    {
        m_isSave = _isSave;
    }

    public virtual void Init()
    {
    }

    public virtual void Logout()
    {
        Init();
    } 

    public virtual void Check()
    {
    }

    public virtual void UpdateLogic()
    {
    }
}
