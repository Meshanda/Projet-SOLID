using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSpriteOrderManager : OrdonedMonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public int BaseLayer = 0;

    public override void DoAwake()
    {
        
    }
    public override void DoUpdate()
    {
        if (!SpriteRenderer) { return; }
        SpriteRenderer.sortingOrder = BaseLayer - (int)transform.position.y;
    }
}