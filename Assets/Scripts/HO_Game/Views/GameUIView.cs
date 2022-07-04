using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SpaceShooter.Core;
using SpaceShooter.Models;
using SpaceShooter.Configs;
using SpaceShooter.Managers;
using SpaceShooter.Components;
using SpaceShooter.Controllers;

namespace SpaceShooter.Views {
    public class GameUIView : MonoBehaviour {
        #region Private Variables

        #region SerializeField
        [SerializeField] private GameController gameController;
        [SerializeField] private List<UIScreenComponent> uiScreens;

        [Header("Start Game UI")]
        [SerializeField] private TextMeshProUGUI totalCreditsValue;
        [SerializeField] private Button playButton;

        [Header("Game Play UI")]
        [SerializeField] private Button pauseButton;
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TextMeshProUGUI inGameCreditsValue;

        [Header("Settings UI")]
        [SerializeField] private Button continueButton;
        [SerializeField] private Button sfxToggleButton;
        [SerializeField] private TextMeshProUGUI sfxToggleButtonText;
        [SerializeField] private Button exitButton;
        #endregion

        #region Non-SerializeField
        #endregion

        #endregion

        #region Private Methods

        #region MonoBehaviour
        private void Awake() {
            SetButtonListeners();
        }

        private void Start() {
            SetupStartUI();
            SetSFXToggleButtonText();
        }
        #endregion

        #region Non-MonoBehaviour
        private void SetButtonListeners() {
            playButton.onClick.AddListener(() => OnClickStart());
            pauseButton.onClick.AddListener(() => OnClickPause());
            continueButton.onClick.AddListener(() => OnClickContinue());
            sfxToggleButton.onClick.AddListener(() => OnClickSFXToggle());
            exitButton.onClick.AddListener(() => OnClickExit());
        }

        private void SetUIActive(UIScreen screenType) {
            foreach (var screen in uiScreens) {
                if (screen.uIType == screenType) {
                    screen.gameObject.SetActive(true);
                } else {
                    screen.gameObject.SetActive(false);
                }
            }
        }
        #endregion

        #region Button Clicks
        private void OnClickStart() {
            //AudioManager.Instance.PlayOnClickButton();
            gameController.StartGame();
        }

        private void OnClickPause() {
            //AudioManager.Instance.PlayOnClickButton();
            gameController.PauseGame();
        }

        private void OnClickContinue() {
            //AudioManager.Instance.PlayOnClickButton();
            gameController.ContinueGame();
        }

        private void OnClickSFXToggle() {
            //AudioManager.Instance.PlayOnClickButton();
            AudioManager.Instance.ToggleSounds();
            SetSFXToggleButtonText();
        }

        private void OnClickExit() {
            //AudioManager.Instance.PlayOnClickButton();
            gameController.ExitGame();
        }

        private void SetSFXToggleButtonText() {
            sfxToggleButtonText.text = AudioManager.Instance.IsSoundOn() ? "SFX: ON" : "SFX: OFF";
        }
        #endregion

        #endregion

        #region Public Methods
        public void SetupStartUI() {
            SetUIActive(UIScreen.StartUI);
            totalCreditsValue.text = PlayerPrefs.GetInt(GameStrings.highscorePref).ToString();
        }

        public void SetupGamePlayUI() {
            SetUIActive(UIScreen.GamePlayUI);
        }

        public void SetupPlayerStats() {
            healthSlider.maxValue = GameManager.Instance.Player.GetComponent<Health>().MaxHealth;
            healthSlider.value = GameManager.Instance.Player.GetComponent<Health>().CurrentHealth;
            inGameCreditsValue.text = GameManager.Instance.CurrentScore.ToString();
        }

        public void UpdatePlayerHealth(int health) {
            healthSlider.value = health;
        }

        public void UpdatePlayerCredits(int credits) {
            inGameCreditsValue.text = credits.ToString();
        }

        public void SetupPauseUI() {
            SetUIActive(UIScreen.SettingsUI);
        }
        #endregion
    }
}