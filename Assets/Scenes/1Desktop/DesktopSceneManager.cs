using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes._1Desktop
{
    public class DesktopSceneManager : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
    }
}
