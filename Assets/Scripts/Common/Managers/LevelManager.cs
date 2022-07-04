using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Core;

namespace SpaceShooter.Managers {
    public class LevelManager : Singleton<LevelManager> {
        #region ----------- Private Variables -----------------

        #region ----------- SerializeField -----------------
        [SerializeField] private SpriteRenderer powerUp;
        [SerializeField] private float timeForNewPowerup;
        [SerializeField] private SpriteRenderer[] planets;
        [SerializeField] private float timeBetweenPlanets;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Non-SerializeField -----------------
        private float currentTimeForNewPowerup = 0;
        private float currentTimeBetweenPlanets = Mathf.Infinity;
        #endregion --------------------------------------------

        #region ----------- Public Methods -----------------
        public void SpawnPlanets() {
            if (currentTimeBetweenPlanets < timeBetweenPlanets) {
                currentTimeBetweenPlanets += Time.deltaTime;
                return;
            }

            currentTimeBetweenPlanets = 0;
            SpawnPlanet();
        }

        public void SpawnPowerUps() {
            if (currentTimeForNewPowerup < timeForNewPowerup) {
                currentTimeForNewPowerup += Time.deltaTime;
                return; ;
            }

            currentTimeForNewPowerup = 0;
            SpawnPowerUp();
        }
        #endregion --------------------------------------------

        #region ----------- Private Methods -----------------
        private void SpawnPlanet() {
            SpriteRenderer planet = planets[Random.Range(0, planets.Length)];
            Instantiate(planet.gameObject, GetPosition(planet), Quaternion.identity);
        }

        private void SpawnPowerUp() {
            Instantiate(powerUp.gameObject, GetPosition(powerUp), Quaternion.identity);
        }

        private Vector2 GetPosition(SpriteRenderer sprite) {
            float xMin = GameManager.Instance.Borders.minX;
            float xMax = GameManager.Instance.Borders.maxX;
            float y = GameManager.Instance.Borders.maxY + GameManager.Instance.Borders.yOffset;
            y += sprite.bounds.size.y / 2;

            return new Vector2(Random.Range(xMin, xMax), y);
        }
        #endregion --------------------------------------------
    }
}
