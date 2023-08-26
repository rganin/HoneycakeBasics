using Levels;
using Levels.Data;
using UnityEngine;

namespace HoneycakeBasics.Ui
{
    public class LevelSelector : MonoBehaviour
    {
        public GameObject buttonsContainer;
        public GameObject levelButtonPrefab;
    
        public void Awake()
        {
            var levels = LevelLoaderWords.getInstance();
            var maxDisclosedLevel = StatsManager.getInstance().getMaxLevel();
            foreach (var levelIndex in levels.getLevelKeys())
            {
                var levelBtn = Instantiate(this.levelButtonPrefab, this.buttonsContainer.transform);
                levelBtn.gameObject.GetComponent<LevelButton>().setLevelIndex(levelIndex);
                // levelBtn.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = levelIndex <= maxDisclosedLevel;
            }
        }

        public void onClickCancel()
        {
            Destroy(this.gameObject);
        }
    }
}
