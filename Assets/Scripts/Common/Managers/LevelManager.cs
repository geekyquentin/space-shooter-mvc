using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Core;
using SpaceShooter.Views;

namespace SpaceShooter.Managers {
    public class LevelManager : Singleton<LevelManager> {
        #region ----------- Private Variables -----------------

        #region ----------- SerializeField -----------------
        [Header("Enemy")]
        [SerializeField] private EnemyView enemyPrefab;
        [SerializeField] private float timeBetweenEnemies = 1f;

        [Header("Power Up")]
        [SerializeField] private SpriteRenderer powerUp;
        [SerializeField] private float timeForNewPowerup;

        [Header("Planets")]
        [SerializeField] private SpriteRenderer[] planets;
        [SerializeField] private float timeBetweenPlanets;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Public Variables -----------------
        public float TimeForNewPowerup { get => timeForNewPowerup; }
        public float TimeBetweenPlanets { get => timeBetweenPlanets; }
        public float TimeBetweenEnemies { get => timeBetweenEnemies; }
        #endregion --------------------------------------------

        #region ----------------- Private Methods -----------------

        #region -------------- Non-Monobehaviour --------------
        private Vector2 GetPosition(SpriteRenderer sprite) {
            float xMin = GameManager.Instance.BorderMinPoint.x;
            float xMax = GameManager.Instance.BorderMaxPoint.x;
            float y = GameManager.Instance.BorderMaxPoint.y + GameManager.Instance.BorderOffset.y;
            y += sprite.bounds.size.y / 2;

            return new Vector2(Random.Range(xMin, xMax), y);
        }
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Public Methods -----------------
        public EnemyView SpawnEnemy() {
            return Instantiate(enemyPrefab, GetPosition(enemyPrefab.GetComponent<SpriteRenderer>()), Quaternion.identity);
        }

        public void SpawnPlanet() {
            SpriteRenderer planet = planets[Random.Range(0, planets.Length)];
            Instantiate(planet, GetPosition(planet), Quaternion.identity);
        }

        public void SpawnPowerUp() {
            Instantiate(powerUp, GetPosition(powerUp), Quaternion.identity);
        }
        #endregion --------------------------------------------
    }
}
