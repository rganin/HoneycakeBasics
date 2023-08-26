using System;
using UnityEngine;

namespace HoneycakeBasics.Ui
{
    public class ToggleButton: MonoBehaviour
    {
        private bool isOn = false;
        
        protected void Awake()
        {
            this.updateForState();
        }

        public void toggle()
        {
            this.setIsOn(!this.isOn);
        }

        public void setIsOn(bool value)
        {
            this.isOn = value;
            updateForState();
        }

        public bool getIsOn()
        {
            return this.isOn;
        }

        public void updateForState()
        {
            if (this.isOn)
            {
                gameObject.transform.Find("ON").gameObject.SetActive(true);
                gameObject.transform.Find("OFF").gameObject.SetActive(false);
            }
            else
            {
                gameObject.transform.Find("OFF").gameObject.SetActive(true);
                gameObject.transform.Find("ON").gameObject.SetActive(false);
            }
        }
    }
}