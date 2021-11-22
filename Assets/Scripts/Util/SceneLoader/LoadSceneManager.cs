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

        private static string LastSceneLoaded;

        private string CurrentScene => SceneManager.GetActiveScene().name;

        /// <summary> Load the current scene. </summary>
        public void ReloadScene() => LoadScene(CurrentScene);

        public void LoadScene(SceneNames name) => LoadScene(name.ToString());

        public void LoadLastScene()
        {
            bool isLastSceneValid = LastSceneLoaded != null && LastSceneLoaded != "";
            string sceneToLoad = isLastSceneValid ? LastSceneLoaded : CurrentScene;
            LoadScene(sceneToLoad);
        }

        private bool IsASetupScene(string nextScene)
        {
            bool isASetupScene = nextScene == SceneNames.Acesso.ToString();
            isASetupScene |= nextScene == SceneNames.BaixarMedia.ToString();
            isASetupScene |= nextScene == SceneNames.BaixarPersonalizacao.ToString();

            return isASetupScene;
        }

        public void LoadScene(string sceneName)
        {
            if(!IsASetupScene(CurrentScene))
                LastSceneLoaded = CurrentScene;

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