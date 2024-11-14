using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneLevelLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
