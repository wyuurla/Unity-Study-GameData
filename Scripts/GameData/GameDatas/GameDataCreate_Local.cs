using System.Collections.Generic;


/**
 * @brief GameDataCreate_Local
 * @detail ������ �����ͺ��̽��� �������� �ʰ� ���ÿ� �����Ҷ� ����ϴ� GameData ���� Ŭ����.
 * @date 2024-02-01
 * @version 1.0.0
 * @author kij
 */
public class GameDataCreate_Local : GameDataCreate
{
    public override Dictionary<System.Type, IProxyGameData> Create()
    {
        Dictionary<System.Type, IProxyGameData> _list = new Dictionary<System.Type, IProxyGameData>();
      
        return _list;
    }
}
