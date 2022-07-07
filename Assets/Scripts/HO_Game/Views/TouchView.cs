using UnityEngine;
using UnityEngine.EventSystems;
using SpaceShooter.Models;
using SpaceShooter.Managers;
using SpaceShooter.Controllers;

namespace SpaceShooter.Views {
    public class TouchView : MonoBehaviour {
        #region --------------------------------------- Private variables ---------------------------------------

        #region SerializeField
        [SerializeField] private TouchController touchController;
        #endregion

        #region Non-SerializeField
        #endregion

        #endregion ---------------------------------------

        #region --------------------------------------- Public variables ---------------------------------------
        #endregion ---------------------------------------

        #region ---------------------------- Private Methods ----------------------------

        #region -------------- Monobehaviour --------------
        private void Update() {
            if (GameManager.Instance.GetCurrentGameState() != GameState.PLAY) { return; }

            CheckForTouch();
        }
        #endregion ----------------------------

        #region -------------- Non-Monobehaviour --------------
        private void CheckForTouch() {
#if UNITY_EDITOR || UNITY_STANDALONE
            if (Input.GetMouseButton(0)) {
                touchController.HandleTouch(Input.mousePosition);
            }
#endif

#if UNITY_ANDROID || UNITY_IOS
            if (Input.touchCount > 0) {
                touchController.HandleTouch(Input.GetTouch(0).position);
            }
#endif
        }
        #endregion ----------------------------

        #endregion --------------------------------------------------------

        #region ---------------------------- Public Methods ----------------------------
        #endregion --------------------------------------------------------
    }
}