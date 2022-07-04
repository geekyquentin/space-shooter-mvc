using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using SpaceShooter.Models;
using SpaceShooter.Configs;
using SpaceShooter.Controllers;
using SpaceShooter.Core;

namespace SpaceShooter.Managers {
    public class GameManager : Singleton<GameManager> {
        #region --------------------------------------- Private variables ---------------------------------------

        #region SerializeField
        [SerializeField] private bool isLogEnabled;
        [SerializeField] private Player playerPrefab;
        [SerializeField] private Vector2 playerSpawn = new Vector2(0, -6.59f);
        [SerializeField] private Borders borders;
        [SerializeField] private BoxCollider2D boundaryCollider;
        [SerializeField] private float replayGameDelay = 3f;
        #endregion

        #region Non-SerializeField
        private GameState currentGameState = GameState.NONE;
        private Player player;
        private int currentScore = 0;
        private Camera cam;
        #endregion

        #endregion ---------------------------------------

        #region --------------------------------------- Public variables ---------------------------------------
        public Player Player { get => player; }
        public Borders Borders { get => borders; }
        public int CurrentScore { get => currentScore; }
        #endregion ---------------------------------------

        #region ---------------------------- Private Methods ----------------------------

        #region -------------- Monobehaviour --------------
        protected override void Awake() {
            base.Awake();
            cam = Camera.main;
            UnityEngine.Debug.unityLogger.logEnabled = isLogEnabled;
        }

        private void Start() {
            ResetData();
            SetPlayerBorders();
            SetProjectileBoundaries();
        }
        #endregion ----------------------------

        #region -------------- Non-Monobehaviour --------------
        private void ResetData() {
            int totalScore = PlayerPrefs.GetInt(GameStrings.highscorePref, 0) + currentScore;
            PlayerPrefs.SetInt(GameStrings.highscorePref, totalScore);
            currentScore = 0;
            currentGameState = GameState.NONE;
        }
        #endregion ----------------------------

        #endregion --------------------------------------------------------

        #region ---------------------------- Private Methods ----------------------------
        private void SetPlayerBorders() {
            borders.minX = cam.ViewportToWorldPoint(Vector2.zero).x + borders.xOffset;
            borders.minY = cam.ViewportToWorldPoint(Vector2.zero).y + borders.yOffset;
            borders.maxX = cam.ViewportToWorldPoint(Vector2.right).x - borders.xOffset;
            borders.maxY = cam.ViewportToWorldPoint(Vector2.up).y - borders.yOffset;
        }

        private void SetProjectileBoundaries() {
            Vector2 camSize = cam.ViewportToWorldPoint(new Vector2(1, 1)) * 2;
            boundaryCollider.size = new Vector2(camSize.x * 1.5f, camSize.y * 1.5f);
        }
        #endregion

        #region ---------------------------- Public Methods ----------------------------
        public void UpdateGameState(GameState newGameState) {
            currentGameState = newGameState;
        }

        public GameState GetCurrentGameState() {
            return currentGameState;
        }

        public void SpawnPlayer() {
            player = Instantiate(playerPrefab.gameObject, playerSpawn, Quaternion.identity).GetComponent<Player>();
        }

        public void ReplayWholeGame() {
            ResetData();
            SceneManager.LoadScene(GameStrings.gamePlayScene);
        }

        public void ReplayWholeGameAfterPlayerDeath() {
            Invoke(nameof(ReplayWholeGame), replayGameDelay);
        }

        public void MovePlayer(Vector2 touchPos) {
            player.transform.position = Vector2.MoveTowards(player.transform.position, touchPos, player.Speed * Time.deltaTime);
            player.transform.position = new Vector2(
                Mathf.Clamp(player.transform.position.x, borders.minX, borders.maxX),
                Mathf.Clamp(player.transform.position.y, borders.minY, borders.maxY)
            );
        }

        public void DealDamage(Collider2D other, float damage) {
            other.GetComponent<Health>().DealDamage(damage);

            if (other.GetComponent<Health>().IsDead()) {
                other.GetComponent<Entity>().Die();
            } else {
                other.GetComponent<Entity>().Hit();
            }
        }

        public void IncrementScore() {
            currentScore++;
        }
        #endregion --------------------------------------------------------
    }
}