using UnityEngine;
using UnityEngine.EventSystems;
using SpaceShooter.Models;
using SpaceShooter.Managers;
using SpaceShooter.Controllers;

namespace SpaceShooter.Views {
    public class TouchView : MonoBehaviour {
        #region --------------------------------------- Private variables ---------------------------------------

        #region SerializeField
        [SerializeField] private TouchController touchController = null;
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
                HandleTouch(Input.mousePosition);
            }
#endif

#if UNITY_ANDROID || UNITY_IOS
            if (Input.touchCount > 0) {
                HandleTouch(Input.GetTouch(0).position);
            }
#endif
        }

        private void HandleTouch(Vector2 touchPos) {
            if (EventSystem.current.IsPointerOverGameObject()) {
                print("the pointer is over gameobject");
                return;
            }

            Debug.Log("Hey you touched the game world!");
            Vector2 worldTouchPos = Vector2.zero;
            worldTouchPos = Camera.main.ScreenToWorldPoint(touchPos);

            touchController.HandlePlayerMovement(worldTouchPos);
        }
        #endregion ----------------------------

        #endregion --------------------------------------------------------

        #region ---------------------------- Public Methods ----------------------------
        #endregion --------------------------------------------------------
    }
}