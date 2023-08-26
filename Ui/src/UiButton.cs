using HoneycakeBasics.Ui.Audio;
using UnityEngine;

namespace HoneycakeBasics.Ui
{
    public class UiButton : MonoBehaviour
    {
        public AudioClip clickAudioCLip;

        public void Awake()
        {
            this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(this.playSound);
            // this.clickAudioCLip = Resources.Load<AudioClip>("Sfx/BtnClick");
        }
        
        /// <summary>
        /// Play button sound
        /// </summary>
        public void playSound()
        {
            if (this.clickAudioCLip)
            {
                UiAudioEffects.getInstance().getAudioSource().PlayOneShot(this.clickAudioCLip);
            }
        }
    }
}
