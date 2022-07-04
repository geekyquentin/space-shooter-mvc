using UnityEngine;
using UnityEngine.SceneManagement;
using SpaceShooter.Views;
using SpaceShooter.Models;
using SpaceShooter.Configs;
using SpaceShooter.Managers;

namespace SpaceShooter.Controllers {
    public class GameController : MonoBehaviour {
        #region Private Variables
        #region SerializeField
        [SerializeField] private GameUIView gameUIView;
        #endregion
        #endregion

        #region Public Methods
        public void StartGame() {
            ContinueGame();
            GameManager.Instance.SpawnPlayer();
            gameUIView.SetupPlayerStats();
        }

        public void PauseGame() {
            Time.timeScale = 0f;
            gameUIView.SetupPauseUI();
            GameManager.Instance.UpdateGameState(GameState.PAUSE);
        }

        public void ContinueGame() {
            Time.timeScale = 1f;
            gameUIView.SetupGamePlayUI();
            GameManager.Instance.UpdateGameState(GameState.PLAY);
        }

        public void ExitGame() {
            GameManager.Instance.ReplayWholeGame();
        }
        #endregion
    }
}