using System;
using TMPro;
using UnityEngine;

namespace HoneycakeBasics.Ui
{
    public class InfoDialog : AbstractDialog
    {
        public GameObject closeButton;

        public void setCloseButtonCaption(string text)
        {
            this.closeButton.gameObject.transform.Find("Caption").GetComponent<TextMeshProUGUI>().text = text;
        }

        public void addCloseButtonCallback(Action action)
        {
            this.closeButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                action();
            });
        }
    }
}