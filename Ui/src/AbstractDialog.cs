using System;
using TMPro;
using UnityEngine;

namespace HoneycakeBasics.Ui
{
    abstract public class AbstractDialog : MonoBehaviour
    {
        private TextMeshProUGUI headerText;
        private TextMeshProUGUI infoText;
        
        protected void Awake()
        {
            this.headerText = this.gameObject.transform.Find("HeaderLabel").GetComponent<TextMeshProUGUI>();
            this.infoText = this.gameObject.transform.Find("InfoText").GetComponent<TextMeshProUGUI>();
        }

        public void setHeader(string text)
        {
            this.headerText.text = text;
        }

        public void setInfo(string text)
        {
            this.infoText.text = text;
        }
    }
}