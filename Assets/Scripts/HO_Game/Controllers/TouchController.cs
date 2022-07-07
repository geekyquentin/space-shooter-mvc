using UnityEngine;
using UnityEngine.EventSystems;
using SpaceShooter.Managers;

namespace SpaceShooter.Controllers {
    public class TouchController : MonoBehaviour {
        #region --------------- Private Variables ---------------

        #region --------------- SerializeField ---------------
        [SerializeField] private PlayerController playerController;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region --------------- Non-SerializeField ---------------------
        public void HandleTouch(Vector2 touchPos) {
            if (EventSystem.current.IsPointerOverGameObject()) {
                print("the pointer is over gameobject");
                return;
            }

            Debug.Log("Hey you touched the game world!");
            Vector2 worldTouchPos = Vector2.zero;
            worldTouchPos = Camera.main.ScreenToWorldPoint(touchPos);

            playerController.HandlePlayerMovement(worldTouchPos);
        }
        #endregion --------------------------------------------------------
    }
}