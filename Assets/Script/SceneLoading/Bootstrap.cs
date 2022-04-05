using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] protected List<StringVariable> scenesToLoad;
    private void Awake()
    {
        foreach (var scene in scenesToLoad)
        {
            SceneManager.LoadScene(scene.Value, LoadSceneMode.Additive);
        }
    }
}
