using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshOrderManager : OrdonedMonoBehaviour
{
    public TextMeshPro TextMeshPro;
    public int BaseLayer = 0;

    public override void DoAwake()
    {
        
    }
    public override void DoUpdate()
    {
        if (!TextMeshPro) { return; }
        TextMeshPro.sortingOrder = BaseLayer - (int)transform.parent.position.y;
    }
}