using System.Collections.Generic;


/**
 * @brief GameDataCreate_Local
 * @detail 서버의 데이터베이스에 저장하지 않고 로컬에 저장할때 사용하는 GameData 생성 클래스.
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
