using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes._1Desktop.Managers
{
    /// <summary>
    /// Additively loads Normcore Common Scene on top of desktop scene.
    /// </summary>
    public class DesktopSceneManager : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
    }
}
