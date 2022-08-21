using System;
using System.Collections;


using UnityEngine;
using UnityEngine.SceneManagement;


using Photon.Pun;
using Photon.Realtime;


namespace WasaaMP {
    public class GameManager : MonoBehaviourPunCallbacks {

        #region Public Fields

        public static GameManager Instance ;

        [Tooltip("The prefab to use for representing the player")]
        public Navigation playerPrefab ;
        [Tooltip("XR Rig player")]
        public GameObject XROrigin;

        #endregion

        #region Private Fields
        private DeviceType platformType;
        private GameObject questPrefab;
        private GameObject XRInteractionManager;
        #endregion

        void Start () {

            /*Transform t0 = XROrigin.transform.GetChild(0);
            if(t0 != null) questPrefab = t0.gameObject;

            Transform t1 = XROrigin.transform.GetChild(1);
            if (t1 != null) XRInteractionManager = t1.gameObject;*/

            Instance = this ;
            platformType = SystemInfo.deviceType;
            if (playerPrefab == null) {
                Debug.LogError ("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this) ;
            } else {
                //Debug.LogFormat("We are Instantiating LocalPlayer from {0}", Application.loadedLevelName);
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                if(platformType == DeviceType.Desktop)
                {
                    if (Navigation.LocalPlayerInstance == null)
                    {
                        Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                        // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                        PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 0.5f, 0f), Quaternion.identity, 0);
                    }
                    else
                    {
                        Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
                    }
                }
                else
                {
                    Debug.Log("xr rig should be camera");
                    PhotonNetwork.Instantiate(this.XROrigin.name, new Vector3(0f, 1.5f, 0f), Quaternion.identity, 0);
                    
                }
            }
        }

        #region Private Methods

        #endregion

        #region Photon Callbacks

        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom () {
            SceneManager.LoadScene (0) ;
        }

        public override void OnPlayerEnteredRoom (Player other) {
            Debug.LogFormat ("OnPlayerEnteredRoom() {0}", other.NickName) ; // not seen if you're the player connecting
            // we load the Arena only once, for the first user who connects, it is made by the launcher
            if (PhotonNetwork.IsMasterClient) {
                Debug.LogFormat ("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient) ; // called before OnPlayerLeftRoom
            }
        }

        public override void OnPlayerLeftRoom (Player other) {
            Debug.LogFormat ("OnPlayerLeftRoom() {0}", other.NickName) ; // seen when other disconnects
        }

        #endregion

        #region Public Methods

        public void LeaveRoom () {
            PhotonNetwork.LeaveRoom () ;
        }

        #endregion

    }
}