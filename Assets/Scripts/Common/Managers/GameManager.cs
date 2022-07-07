using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using SpaceShooter.Models;
using SpaceShooter.Configs;
using SpaceShooter.Views;
using SpaceShooter.Core;

namespace SpaceShooter.Managers {
    public class GameManager : Singleton<GameManager> {
        #region ----------- Private  Variables -----------------

        #region ----------- SerializeField -----------------
        [SerializeField] private bool isLogEnabled;

        [Header("Scores")]
        [SerializeField] private int enemyKillScore = 10;
        [SerializeField] private int powerUpScore = 5;

        [Header("Player")]
        [SerializeField] private PlayerView playerPrefab;
        [SerializeField] private Vector2 playerSpawn = new Vector2(0, -6.59f);

        [Header("Player Border")]
        [SerializeField] private Vector2 borderOffset = new Vector2(1.5f, 1.5f);

        [Header("Boundary Collider")]
        [SerializeField] private BoxCollider2D boundaryCollider;
        [SerializeField] private Vector2 boundaryOffset = new Vector2(1.5f, 1.5f);

        [Header("Game Delay")]
        [SerializeField] private float replayGameDelay = 3f;
        #endregion

        #region Non-SerializeField
        private GameState currentGameState = GameState.NONE;
        private PlayerView player;
        private Vector2 borderMinPoint, borderMaxPoint;
        private int currentScore = 0;
        private Camera cam;
        #endregion --------------------------------------------

        #endregion ---------------------------------------

        #region --------------- Public variables ---------------
        public PlayerView Player { get => player; }
        public Vector2 BorderOffset { get => borderOffset; }
        public Vector2 BorderMinPoint { get => borderMinPoint; }
        public Vector2 BorderMaxPoint { get => borderMaxPoint; }
        public int CurrentScore { get => currentScore; }
        #endregion -----------------------------------------

        #region ----------------- Private Methods -----------------

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

        private void OnDrawGizmos() {
            Gizmos.color = Color.white;
            Vector2 centre = new Vector2(borderMaxPoint.x + borderMinPoint.x, borderMaxPoint.y + borderMinPoint.y) / 2;
            Vector2 direction = new Vector2(borderMaxPoint.x - borderMinPoint.x, borderMaxPoint.y - borderMinPoint.y);
            Gizmos.DrawWireCube(centre, direction);
        }
        #endregion --------------------------------------------

        #region -------------- Non-Monobehaviour --------------
        private void ResetData() {
            currentScore = 0;
            currentGameState = GameState.NONE;
        }

        private void SetPlayerBorders() {
            float minX = cam.ViewportToWorldPoint(Vector2.zero).x + borderOffset.x;
            float minY = cam.ViewportToWorldPoint(Vector2.zero).y + borderOffset.y;
            borderMinPoint = new Vector2(minX, minY);

            float maxX = cam.ViewportToWorldPoint(Vector2.right).x - borderOffset.x;
            float maxY = cam.ViewportToWorldPoint(Vector2.up).y - borderOffset.y;
            borderMaxPoint = new Vector2(maxX, maxY);
        }

        private void SetProjectileBoundaries() {
            Vector2 camSize = cam.ViewportToWorldPoint(new Vector2(1, 1)) * 2;
            boundaryCollider.size = new Vector2(camSize.x * boundaryOffset.x, camSize.y * boundaryOffset.y);
        }
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------------- Public Methods -----------------
        public void UpdateGameState(GameState newGameState) {
            currentGameState = newGameState;
        }

        public GameState GetCurrentGameState() {
            return currentGameState;
        }

        public PlayerView InstantiatePlayer() {
            return Instantiate(playerPrefab, playerSpawn, Quaternion.identity).GetComponent<PlayerView>();
        }

        public void SetPlayer(PlayerView player) {
            this.player = player;
        }

        public void ReplayWholeGame() {
            ResetData();
            SceneManager.LoadScene(GameStrings.gamePlayScene);
        }

        public void ReplayWholeGameAfterPlayerDeath() {
            Invoke(nameof(ReplayWholeGame), replayGameDelay);
        }

        public void IncrementKillScore() {
            currentScore += enemyKillScore;
        }

        public void IncrementPowerUpScore() {
            currentScore += powerUpScore;
        }
        #endregion --------------------------------------------
    }
}