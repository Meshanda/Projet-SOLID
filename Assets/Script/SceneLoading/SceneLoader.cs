using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Unload(StringVariable scene)
    {
        if (SceneManager.GetSceneByName(scene.Value).isLoaded)
        {
            SceneManager.UnloadSceneAsync(scene.Value);
        }
    }

    
    public void Load(StringVariable scene)
    {
        if (!SceneManager.GetSceneByName(scene.Value).isLoaded)
        {
            SceneManager.LoadScene(scene.Value, LoadSceneMode.Additive);
        }
    }
}
