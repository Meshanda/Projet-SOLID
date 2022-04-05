using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{
    [SerializeField] private GameObject levelPrefab;
    private GameObject _level;

    public void OnStartGame()
    {
         _level = Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
    }

    public void OnEndGame()
    {
        Destroy(_level);
        _level = null;
    }
}
