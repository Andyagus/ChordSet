using UnityEngine;
using UnityEngine.SceneManagement;

public class ARSceneManager : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}
