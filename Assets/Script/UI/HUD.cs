using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private FloatVariable timerValue;
    
    [Header("Cooldown")]
    [SerializeField] private Image cooldownImage;
    [SerializeField] private FloatVariable cooldownValue;
    private float _cooldownMaxValue;
    
    [Header("Player Count")] 
    [SerializeField] private TextMeshProUGUI playerCountText;
    [SerializeField] [CanBeNull] private PlayerNames playerNames;
    private int _maxPlayerCount;
    private int _currentPlayerCount;

    private void Start()
    {
        if (playerNames != null)
        {
            _maxPlayerCount = playerNames.GetPlayerCount();
        }
        else
        {
            playerCountText.gameObject.SetActive(false);
        }

        cooldownImage.fillAmount = 0;
        slider.maxValue = timerValue.Value;
    }

    void Update()
    {
        if (playerNames != null)
        {
            _currentPlayerCount = playerNames.GetPlayerCount();
        }
        
        playerCountText.text = _currentPlayerCount + "/" + _maxPlayerCount;
        
        slider.value = timerValue.Value;

        if (timerValue.Value <= 0.1f)
        {
            _cooldownMaxValue = cooldownValue.Value;
            StartCoroutine(ShowCooldownCoroutine());
        }
    }
    
    private IEnumerator ShowCooldownCoroutine()
    {
        var timer = cooldownValue.Value;

        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            
            cooldownImage.fillAmount = timer / _cooldownMaxValue;
            
            yield return null;
        }
    }
}
