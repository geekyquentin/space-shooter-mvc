using UnityEngine;

namespace SpaceShooter.Core {
    public class RepeatingBackground : MonoBehaviour {
        #region ----------- Private  Variables -----------------

        #region ----------- SerializeField -----------------
        [SerializeField] private float verticalSize;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ------------ Private Methods -----------------

        #region ----------- Monobehaviour -----------------
        private void Update() {
            if (transform.position.y < -verticalSize) {
                RepositionBackground();
            }
        }
        #endregion --------------------------------------------

        #region ----------- Non-Monobehaviour -----------------
        private void RepositionBackground() {
            Vector2 groundOffSet = new Vector2(0, verticalSize * 2f);
            transform.position = (Vector2)transform.position + groundOffSet;
        }
        #endregion --------------------------------------------

        #endregion --------------------------------------------
    }
}
