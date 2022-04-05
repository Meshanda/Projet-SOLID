using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Object = UnityEngine.Object;

public class DisplayPlayerHealth : OrdonedMonoBehaviour
{
    [SerializeField] private PlayerIndexManager playerIndexManager;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private SpriteRenderer healthSprite;
    
    [Header("Heart Sprites")]
    [SerializeField] private Sprite spriteFullLife;
    [SerializeField] private Sprite spriteHalfLife;
    [SerializeField] private Sprite spriteLowLife;

    public override void DoUpdate()
    {
        var health = playerHealth.PlayerHealthList[playerIndexManager.Index];

        if (health >= playerHealth.MaxHealth)
        {
            healthSprite.sprite = spriteFullLife;
        }
        else if (health < playerHealth.MaxHealth && health > 1)
        {
            healthSprite.sprite = spriteHalfLife;
        }
        else if (health <= 1)
        {
            healthSprite.sprite = spriteLowLife;
        }
    }

    public override void DoAwake()
    {
        throw new NotImplementedException();
    }
}
