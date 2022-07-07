using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Models;
using SpaceShooter.Managers;
using SpaceShooter.Views;

namespace SpaceShooter.Controllers {
    public class LevelController : MonoBehaviour {
        #region ----------- Private  Variables -----------------

        #region ----------- SerializeField -----------------
        [SerializeField] private GameController gameController;
        #endregion --------------------------------------------

        #region ----------- Non-SerializeField -----------------
        private float currentTimeForNewPowerup = 0;
        private float currentTimeBetweenPlanets = Mathf.Infinity;
        private float currentTimeBetweenEnemies = Mathf.Infinity;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Private  Variables -----------------

        #region ----------- MonoBehaviour -----------------
        private void Update() {
            SpawnPlanets();

            if (GameManager.Instance.GetCurrentGameState() != GameState.PLAY) { return; }

            SpawnPowerUps();
            SpawnEnemies();
        }
        #endregion --------------------------------------------

        #region ----------- Non-MonoBehaviour -----------------
        private void SpawnEnemies() {
            if (currentTimeBetweenEnemies < LevelManager.Instance.TimeBetweenEnemies) {
                currentTimeBetweenEnemies += Time.deltaTime;
                return;
            }

            currentTimeBetweenEnemies = 0;

            EnemyView enemy = LevelManager.Instance.SpawnEnemy();
            enemy.GameController = gameController;
        }

        private void SpawnPlanets() {
            if (currentTimeBetweenPlanets < LevelManager.Instance.TimeBetweenPlanets) {
                currentTimeBetweenPlanets += Time.deltaTime;
                return;
            }

            currentTimeBetweenPlanets = 0;
            LevelManager.Instance.SpawnPlanet();
        }

        private void SpawnPowerUps() {
            if (currentTimeForNewPowerup < LevelManager.Instance.TimeForNewPowerup) {
                currentTimeForNewPowerup += Time.deltaTime;
                return;
            }

            currentTimeForNewPowerup = 0;
            LevelManager.Instance.SpawnPowerUp();
        }
        #endregion --------------------------------------------

        #endregion --------------------------------------------
    }
}
