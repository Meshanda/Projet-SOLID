using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapLoader : MonoBehaviour
{
    [SerializeField] private string bootstrapSceneName;

    private void Awake()
    {
        bool isLoaded = false;

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == bootstrapSceneName)
            {
                isLoaded = true;
            }
        }

        if (!isLoaded)
        {
            SceneManager.LoadScene(bootstrapSceneName);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
