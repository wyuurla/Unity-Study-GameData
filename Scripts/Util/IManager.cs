using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
    void Init();
    void UpdateLogic();
}


public interface IManagerLateUpdate
{
    void LateUpdateLogic();
}