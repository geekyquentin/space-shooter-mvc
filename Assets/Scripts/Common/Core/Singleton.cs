using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Core {
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
        #region ----------- Private  Variables -----------------

        #region ----------- Non-SerializeField -----------------
        private static T instance;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ------------------- Public Methods -----------------
        public static T Instance {
            get {
                if (instance == null) {
                    instance = FindObjectOfType<T>();

                    if (instance == null) {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
        #endregion --------------------------------------------

        #region ------------------- Protected Methods -----------------
        protected virtual void Awake() {
            if (instance == null) {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            } else {
                Destroy(gameObject);
            }
        }
        #endregion --------------------------------------------
    }
}