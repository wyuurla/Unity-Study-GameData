using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @brief GameDataManager
 * @detail GameData를 관리하는 클래스.
 * @date 2024-02-01
 * @version 1.0.0
 * @author kij
 */


public class GameDataManager : ClassSingleton<GameDataManager>, IManager
{
    protected Dictionary<System.Type, IProxyGameData> m_dataList;
    protected bool m_isInit;

    public GameDataManager()
    {
        Init();
    }

    public void Init()
    {
        if (m_isInit == true)
            return;

        GameDataCreate _create = new GameDataCreate_Local();
        m_dataList = _create.Create();
        Load();

        m_isInit = true;
    }  

    public void Load()
    {
        var _var = m_dataList.GetEnumerator();
        while (_var.MoveNext())
        {
            _var.Current.Value.Load();
        }
    }

    public void Check()
    {
        var _var = m_dataList.GetEnumerator();
        while (_var.MoveNext())
        {
            _var.Current.Value.Check();
        }
    }

    public void Save()
    {
        var _var = m_dataList.GetEnumerator();
        while (_var.MoveNext())
        {
            _var.Current.Value.Save();
        }
    }

    public void Logout()
    {
        var _Var = m_dataList.GetEnumerator();
        while(_Var.MoveNext())
        {
            _Var.Current.Value.Logout();
        }
    }

    public void UpdateLogic()
    {
        var _Var = m_dataList.GetEnumerator();
        while (_Var.MoveNext())
        {
            _Var.Current.Value.UpdateLogic();
        }
    }
    public TGameData GetGameData<TGameData>() where TGameData : GameData
    {
        System.Type _key = typeof(TGameData);
        if (null == m_dataList)
        {
            Debug.LogError("GameDataManager::GetData()[ DataList == null ] : " + _key.ToString());
            return null;
        }

        IProxyGameData _proxyGameData;
        if (m_dataList.TryGetValue(_key, out _proxyGameData) == false)
        {
            Debug.LogError("GameDataManager::GetData()[ no Have : " + _key.ToString());
            return null;
        }

        return _proxyGameData.GetGameData() as TGameData;
    }
}
