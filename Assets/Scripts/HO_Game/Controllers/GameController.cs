using UnityEngine;
using UnityEngine.SceneManagement;
using SpaceShooter.Views;
using SpaceShooter.Models;
using SpaceShooter.Core;
using SpaceShooter.Configs;
using SpaceShooter.Managers;

namespace SpaceShooter.Controllers {
    public class GameController : MonoBehaviour {
        #region --------------------- Private Variables ---------------------

        #region --------------------- SerializeField ---------------------
        [SerializeField] private GameUIView gameUIView;
        [SerializeField] private PlayerController playerController;
        #endregion -------------------------------------------------------

        #endregion -------------------------------------------------------

        #region --------------------- Private Methods --------------------

        #region ------------------- Non-MonoBehaviour -------------------
        private void DealDamage(Entity entity, int damage) {
            entity.DealDamage(damage);

            if (entity.IsDead()) {
                entity.Die();
            } else {
                entity.Hit();
            }
        }

        private void UpdateTotalScore() {
            int totalScore = PlayerPrefs.GetInt(GameStrings.totalScorePref, 0);
            totalScore += GameManager.Instance.CurrentScore;
            PlayerPrefs.SetInt(GameStrings.totalScorePref, totalScore);
        }
        #endregion -------------------------------------------------------

        #endregion -------------------------------------------------------

        #region --------------------- Public Methods ---------------------
        public void StartGame() {
            ContinueGame();
            playerController.SpawnPlayer();
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

        public void RestartGame() {
            GameManager.Instance.UpdateGameState(GameState.GAMEOVER);
            GameManager.Instance.ReplayWholeGameAfterPlayerDeath();
        }

        public void ExitGame() {
            GameManager.Instance.ReplayWholeGame();
        }

        public void DealProjectileHit(Entity entity, Projectile projectile) {
            if ((entity.CompareTag(GameStrings.playerTag) && projectile.IsEnemyBullet)
            || (entity.CompareTag(GameStrings.enemyTag) && !projectile.IsEnemyBullet)) {
                DealDamage(entity, projectile.Damage);
                Destroy(projectile.gameObject);
            }
        }

        public void DealPlayerDeath() {
            UpdateTotalScore();
            RestartGame();
            AudioManager.Instance.PlayOnPlayerDeath();
        }

        public void DealEnemyDeath() {
            GameManager.Instance.IncrementKillScore();
            UpdatePlayerScoreUI();
            AudioManager.Instance.PlayOnEnemyDeath();
        }

        public void UpdatePlayerScoreUI() {
            gameUIView.UpdatePlayerCredits(GameManager.Instance.CurrentScore);
        }

        public void UpdateHealthBarUI(float health) {
            gameUIView.UpdatePlayerHealth(health);
        }
        #endregion -------------------------------------------------------
    }
}