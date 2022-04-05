using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGOManager : OrdonedMonoBehaviour
{
    public PlayerIndexManager PlayerIndexManager;
    public PlayerGO PlayerGO;

    public override void DoAwake()
    {
        if (!PlayerIndexManager) { return; }
        if (!PlayerGO) { return; }
        PlayerGO.AddNew(gameObject);
    }
    public override void DoUpdate()
    {

    }
}
