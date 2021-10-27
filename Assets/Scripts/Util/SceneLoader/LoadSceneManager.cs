using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Lavid.Libraske.Util
{
    public class LoadSceneManager : MonoBehaviour
    {
        [SerializeField] private GameObject _progressMenu;
        [SerializeField] private Image _progressBar;

        /// <summary> Load the current scene. </summary>
        public void ReloadScene() => LoadScene(SceneManager.GetActiveScene().name);

        public void LoadScene(SceneNames name) => LoadScene(name.ToString());

        public void LoadScene(string sceneName)
        {
            if (_progressMenu != null)
                _progressMenu.SetActive(true);

            if (_progressBar == null)
                StartCoroutine(LoadSceneCoroutine(sceneName));
            else
                StartCoroutine(LoadSceneWithProgressBarCoroutine(sceneName));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            var status = SceneManager.LoadSceneAsync(sceneName);

            while (!status.isDone)
                yield return null;
        }

        private IEnumerator LoadSceneWithProgressBarCoroutine(string sceneName)
        {
            var status = SceneManager.LoadSceneAsync(sceneName);

            while (!status.isDone)
            {
                _progressBar.fillAmount = status.progress;
                yield return null;
            }
        }
    }
}