using UnityEngine;
using SpaceShooter.Managers;
using SpaceShooter.Configs;

namespace SpaceShooter.Core {
    public class Bonus : MonoBehaviour {
        #region -----------Private  Variables -----------------
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag(GameStrings.playerTag)) {
                if (GameManager.Instance.Player.WeaponPower < GameManager.Instance.Player.MaxWeaponPower) {
                    GameManager.Instance.Player.WeaponPower++;
                }
                Destroy(gameObject);
            }
        }
        #endregion --------------------------------------------
    }
}
