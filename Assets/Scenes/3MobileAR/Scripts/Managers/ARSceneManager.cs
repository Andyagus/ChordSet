using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes._3MobileAR.Scripts.Managers
{
    /// <summary>
    /// Manages the additive load, so that both Normcore scene and the ARScene can be
    /// loaded at the same time 
    /// </summary>
    public class ARSceneManager : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
    }
}
