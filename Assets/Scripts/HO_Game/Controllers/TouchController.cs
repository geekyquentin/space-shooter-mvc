using UnityEngine;
using SpaceShooter.Managers;

namespace SpaceShooter.Controllers {
    public class TouchController : MonoBehaviour {
        #region --------------------------------------- Private variables ---------------------------------------
        #region SerializeField
        #endregion
        #region Non-SerializeField
        #endregion
        #endregion ---------------------------------------
        #region --------------------------------------- Public variables ---------------------------------------
        #endregion ---------------------------------------
        #region ---------------------------- Private Methods ----------------------------
        #region -------------- Monobehaviour --------------
        #endregion ----------------------------
        #region -------------- Non-Monobehaviour --------------
        #endregion ----------------------------
        #endregion --------------------------------------------------------
        #region ---------------------------- Public Methods ----------------------------
        public void HandlePlayerMovement(Vector2 touchPos) {
            GameManager.Instance.MovePlayer(touchPos);
        }
        #endregion --------------------------------------------------------
    }
}