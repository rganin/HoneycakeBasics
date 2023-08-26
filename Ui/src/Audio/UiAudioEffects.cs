using HoneycakeBasics.Config;
using HoneycakeBasics.Util;
using Unity.VisualScripting;
using UnityEngine;

namespace HoneycakeBasics.Ui.Audio
{
    public class UiAudioEffects: SingletonBase<UiAudioEffects>
    {

        private AudioSource sfxAudioSource;

        public static UiAudioEffects getInstance()
        {
            return Instance;
        }

        public UiAudioEffects()
        {
            initAudioSource();
        }

        private void initAudioSource()
        {
            if (sfxAudioSource == null)
            {
                // source has to be attached to game object
                GameObject audioGameObject = new GameObject("UiSfxAudioSource");
                audioGameObject.AddComponent<AudioSource>();
                sfxAudioSource = audioGameObject.GetComponent<AudioSource>();
                sfxAudioSource.volume = ConfigManager.getInstance().getConfigInt(ConfigData.PATH_UI_SFX_VOLUME, 1) > 0 ? 0.5f : 0;
                ConfigManager.getInstance().bindOnChangeAction(ConfigData.PATH_UI_SFX_VOLUME, (configManagerInstance) =>
                {
                    sfxAudioSource.volume = configManagerInstance.getConfigInt(ConfigData.PATH_UI_SFX_VOLUME, 1) > 0 ? 0.5f : 0;
                });
            }
        }

        public AudioSource getAudioSource()
        {
            initAudioSource();
            return this.sfxAudioSource;
        }
    }
}