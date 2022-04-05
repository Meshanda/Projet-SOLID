using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSpriteOrderManager : OrdonedMonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public int BaseLayer = 0;

    public override void DoAwake()
    {
        if (!SpriteRenderer) { return; }
        SpriteRenderer.sortingOrder = BaseLayer - (int)transform.position.y;
    }
    public override void DoUpdate()
    {

    }
}