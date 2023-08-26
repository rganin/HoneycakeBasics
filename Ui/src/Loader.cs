using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

namespace HoneycakeBasics.Ui
{
    public class Loader : MonoBehaviour
    {
        public Slider progressBar;

        private AsyncOperation loadingOperation;

        private Action onLoadCompleteCallback;

        public void loadSceneAtIndex(int index, Action onLoadedCallback)
        {
            this.onLoadCompleteCallback = onLoadedCallback;
            loadingOperation = SceneManager.LoadSceneAsync(index);
            loadingOperation.completed += OnLoadSceneComplete;
        }

        private void OnDestroy()
        {
            if (loadingOperation != null)
            {
                loadingOperation.completed -= OnLoadSceneComplete;
            }
        }

        private void OnLoadSceneComplete(AsyncOperation operation)
        {
            this.onLoadCompleteCallback();
        }

        void LateUpdate()
        {
            if (!loadingOperation.isDone && this.progressBar != null)
            {
                float progress = Mathf.Clamp01(loadingOperation.progress / 0.9f);
                // Debug.Log("Loading " + progress * 100 + "%");
                this.progressBar.value = progress > 1f ? 1f : progress;
            }
            else if (loadingOperation.isDone)
            {
                this.onLoadCompleteCallback();
            }
        }
    }
}