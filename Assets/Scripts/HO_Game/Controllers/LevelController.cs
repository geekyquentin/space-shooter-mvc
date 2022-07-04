using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Models;
using SpaceShooter.Managers;

namespace SpaceShooter.Controllers {
    public class LevelController : MonoBehaviour {
        #region ----------- Private  Methods -----------------

        #region ----------- MonoBehaviour -----------------
        private void Update() {
            LevelManager.Instance.SpawnPlanets();

            if (GameManager.Instance.GetCurrentGameState() != GameState.PLAY) { return; }

            LevelManager.Instance.SpawnPowerUps();
        }
        #endregion --------------------------------------------

        #endregion --------------------------------------------
    }
}
