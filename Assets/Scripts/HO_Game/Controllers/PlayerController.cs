using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Views;
using SpaceShooter.Configs;
using SpaceShooter.Managers;

namespace SpaceShooter.Controllers {
    public class PlayerController : MonoBehaviour {
        #region --------------------- Private Variables ---------------------

        #region --------------------- SerializeField ---------------------
        [SerializeField] private GameController gameController;
        #endregion -------------------------------------------------------

        #endregion -------------------------------------------------------

        #region --------------------- Private Methods --------------------

        #region ------------------- Non-MonoBehaviour -------------------
        private void IncrementWeaponPower() {
            if (GameManager.Instance.Player.WeaponPower < GameManager.Instance.Player.MaxWeaponPower) {
                GameManager.Instance.Player.WeaponPower++;
            }
        }
        #endregion -------------------------------------------------------

        #endregion -------------------------------------------------------

        #region --------------------- Public Methods ---------------------
        public void SpawnPlayer() {
            PlayerView player = GameManager.Instance.InstantiatePlayer();
            player.GameController = gameController;
            player.PlayerController = this;
            GameManager.Instance.SetPlayer(player);
        }

        public void HandlePlayerMovement(Vector2 touchPos) {
            PlayerView player = GameManager.Instance.Player;
            player.transform.position = Vector2.MoveTowards(player.transform.position, touchPos, player.Speed * Time.deltaTime);

            Vector2 mn = GameManager.Instance.BorderMinPoint;
            Vector2 mx = GameManager.Instance.BorderMaxPoint;
            player.transform.position = new Vector2(
                Mathf.Clamp(player.transform.position.x, mn.x, mx.x),
                Mathf.Clamp(player.transform.position.y, mn.y, mx.y)
            );
        }

        public void DealPowerUpEquip() {
            GameManager.Instance.IncrementPowerUpScore();
            AudioManager.Instance.PlayOnPowerUpEquip();
            IncrementWeaponPower();
            gameController.UpdatePlayerScoreUI();
        }
        #endregion -------------------------------------------------------
    }
}
