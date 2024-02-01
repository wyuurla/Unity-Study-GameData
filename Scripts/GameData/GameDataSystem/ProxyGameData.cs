using UnityEngine;

/**
 * @brief ProxyGameData
 * @detail GameData�� ���� �Ǵ� �ҷ����� ����� �븮�Ѵ�.
 * @date 2024-02-01
 * @version 1.0.0
 * @author kij
 */
public class ProxyGameData<TGameData> : IProxyGameData where TGameData : GameData, new()
{
    TGameData m_gameData;
    string m_filePath;

    public GameData GetGameData() { return m_gameData; }

    /**
     * _filiePath�� null�̸� �������� �ʴ´�. ������ �����͸� �޾Ƽ� ����Ҷ� null�� �ִ´�.
     */
    public ProxyGameData(string _filiePath)
    {
        m_filePath = _filiePath;
    }
   
    public void Init()
    {
        m_gameData = new TGameData();
        m_gameData.Init();
    }
    
    /**
     *  m_filePath�� ��η� ������ �ε��Ѵ�.
     */
    public void Load()
    {
        if (string.IsNullOrWhiteSpace(m_filePath) == true)
        {
            Init();
            return;
        }

        try
        {
            string _fileData = FileUtil.Load(m_filePath);
            m_gameData = JsonUtility.FromJson<TGameData>(_fileData);
            if (null == m_gameData)            
                Init();
        }
        catch (System.Exception _e)
        {
            Init();
            Debug.LogError("JsonUtility.FromJson() : " + _e.ToString());
        }
    }

    /**
     *  m_filePath�� ��η� ������ �����Ѵ�.
     */
    public void Save()
    {
        if (null == m_gameData)
            return;

        if (string.IsNullOrWhiteSpace(m_filePath) == true)
            return;

        try
        {
            string _data = JsonUtility.ToJson(m_gameData);
            if (FileUtil.Save(m_filePath, _data) == false)
            {
                Debug.LogError("save failed : " + m_filePath);
                return;
            }
        }
        catch (System.Exception _e)
        {
            Debug.LogError("JsonUtility.FromJson() : " + _e.ToString());
        }
    }

    /**
     *  ������ �ε��� ó���ؾ� �ϴ� ������ �����Ѵ�. 
     *  �⼮���󿡼� ������ ó���ؾ� �ϴ� ���.
     */
    public void Check()
    {
        if (null == m_gameData)
            return;

        m_gameData.Check();
    }
    
    public void Logout()
    {
        if (null == m_gameData)
            return;

        m_gameData.Logout();
    }

    public void UpdateLogic()
    {
        if (null == m_gameData)
            return;

        if (m_gameData.isSave)
        {
            Save();
            m_gameData.SetSave(false);
        }

        m_gameData.UpdateNotify();
        m_gameData.UpdateLogic();
    }
}