using System;
using TMPro;
using UnityEngine;


namespace HoneycakeBasics.Ui
{
    public class ConfirmDialog : AbstractDialog
    {
        public GameObject yesButton;
        public GameObject noButton;
        
        public void setYesBtnCaption(string text)
        {
            this.yesButton.gameObject.transform.Find("Caption").GetComponent<TextMeshProUGUI>().text = text;
        }

        public void setNoBtnCaption(string text)
        {
            this.noButton.gameObject.transform.Find("Caption").GetComponent<TextMeshProUGUI>().text = text;
        }

        public void addYesButtonCallback(Action action)
        {
            this.yesButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                action();
            });
        }
        
        public void addNoButtonCallback(Action action)
        {
            this.noButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                action();
            });
        }
    }
}
