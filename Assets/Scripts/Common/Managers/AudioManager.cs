using UnityEngine;
using System.Collections.Generic;
using SpaceShooter.Core;

namespace SpaceShooter.Managers {
    public class AudioManager : Singleton<AudioManager> {
        #region ---------------------------- Private Variables ----------------------------

        #region --- Serialized Fields ---
        [SerializeField] private List<AudioSource> sfxAudioSourceList = null;
        [SerializeField] private List<AudioClip> sfxClips;
        [SerializeField] private List<AudioClip> musicClips;
        #endregion ----------------------

        #region --- Non-Serialized Fields ---
        private AudioSource musicAudioSource = null;
        private bool isSoundEnabled = true;
        private bool isMusicEnabled = true;
        #endregion ----------------------

        #endregion --------------------------------------------------------

        #region ---------------------------- Public Variables ----------------------------
        #endregion --------------------------------------------------------

        #region ---------------------------- Private Methods -----------------------------------------

        #region ------------ Monobehaviour Methods -----------------
        protected override void Awake() {
            base.Awake();

            musicAudioSource = gameObject.AddComponent<AudioSource>();
            sfxAudioSourceList = new List<AudioSource>();
        }

        private void OnApplicationPause(bool pauseStatus) {
            Debug.Log("APP PAUSED = " + pauseStatus);
            if (pauseStatus) {
                StopAllSfx();
            } else {
                StopAllSfx();
            }
        }

        #endregion -------------------------------------------------------------

        #region ------------ Non-Monobehaviour Methods -----------
        private void PlaySfxClip(AudioClip clip, float volume, bool isLooping = false) {
            Debug.Log("Playing audio clip: " + clip.name);
            bool foundAudioSource = false;

            if (isSoundEnabled) {
                for (int k = 0; k < sfxAudioSourceList.Count; k++) {
                    if (!sfxAudioSourceList[k].isPlaying) {
                        foundAudioSource = true;
                        ApplyAudioClip(clip, k, volume, isLooping);

                        break;
                    }
                }

                if (!foundAudioSource) {
                    sfxAudioSourceList.Add(this.gameObject.AddComponent<AudioSource>());
                    ApplyAudioClip(clip, sfxAudioSourceList.Count - 1, volume, isLooping);
                }
            }
        }

        private void ApplyAudioClip(AudioClip clip, int index, float volume, bool isLoop = false) {
            sfxAudioSourceList[index].clip = clip;
            sfxAudioSourceList[index].volume = volume;
            sfxAudioSourceList[index].loop = isLoop;
            sfxAudioSourceList[index].Play();
        }

        private void StopSfxClip(AudioClip clip) {
            for (int k = 0; k < sfxAudioSourceList.Count; k++) {
                if (sfxAudioSourceList[k].clip.name == clip.name) {
                    sfxAudioSourceList[k].Stop();
                    break;
                }
            }
        }

        private void PlayMusicClip(AudioClip clip, float volume) {
            this.musicAudioSource.clip = clip;
            this.musicAudioSource.volume = volume;
            this.musicAudioSource.loop = true;
            this.musicAudioSource.Play();
        }

        private void ToggleSfx() {
            isSoundEnabled = !isSoundEnabled;
            foreach (AudioSource audioSource in sfxAudioSourceList) {
                audioSource.mute = !isSoundEnabled;
            }
        }

        private void ToggleMusic() {
            isMusicEnabled = !isMusicEnabled;
            musicAudioSource.mute = !isMusicEnabled;
        }
        #endregion -------------------------------------------------------

        #endregion ----------------------------------------------------------------------------------------

        #region ---------------------------- Public Methods ----------------------------
        public void StopAllSfx() {
            for (int k = 0; k < sfxAudioSourceList.Count; k++) {
                if (sfxAudioSourceList[k].isPlaying) {
                    sfxAudioSourceList[k].Stop();
                }
            }
        }

        #region-------------------- Audio Event Methods ---------------------
        public void PlayBGM() {
            PlayMusicClip(musicClips[0], 0.25f);
        }

        public void StopBGM() {
            musicAudioSource.Stop();
        }

        public void PlayOnClickButton() {
            PlaySfxClip(sfxClips[0], 1f);
        }

        public void PlayOnCorrectTouch() {
            PlaySfxClip(sfxClips[2], 1f);
        }

        public void PlayOnIncorrectTouch() {
            PlaySfxClip(sfxClips[3], 1f);
        }

        public void PlayOnClickHelp() {
            PlaySfxClip(sfxClips[4], 1f);
        }

        public void PlayOnTaskStarted() {
            PlaySfxClip(sfxClips[5], 0.8f);
        }

        public void PlayOnTaskComplete() {
            PlaySfxClip(sfxClips[1], 1f);
        }

        public void PlayOnElementToBlank() {
            PlaySfxClip(sfxClips[7], 1f);
        }

        public void PlayOnGameComplete() {
            PlaySfxClip(sfxClips[8], 1f);
        }

        public void PlayOnGameOver() {
            PlaySfxClip(sfxClips[9], 0.8f);
        }
        #endregion-------------------------------------------------------------

        public void ToggleSounds() {
            Debug.LogFormat("SFX status = {0}, Music Status = {1}", isSoundEnabled, isMusicEnabled);
            ToggleSfx();
            ToggleMusic();
        }

        public void SetAudioStatus(bool status) {
            isSoundEnabled = status;
        }

        public bool IsSoundOn() {
            return isSoundEnabled;
        }
        #endregion --------------------------------------------------------
    }
}
