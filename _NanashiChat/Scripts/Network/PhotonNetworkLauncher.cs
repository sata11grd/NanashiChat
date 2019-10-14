using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace NanashiChat.Network
{
    /// <summary>
    /// Photonネットワークに参加するためのクラスです。
    /// </summary>
    public class PhotonNetworkLauncher : MonoBehaviour, IConnectionCallbacks, IMatchmakingCallbacks
    {
        /// <summary>
        /// デバッグログを有効にします。
        /// </summary>
        [SerializeField] bool m_DebugLogging = true;

        /// <summary>
        /// ルームに入室可能な人数です。
        /// </summary>
        [Space]
        [SerializeField] byte m_MaxPlayers = 20;

        /// <summary>
        /// ルームの名前です。
        /// 表示されることはありません。
        /// </summary>
        [SerializeField] string m_RoomName = "Default";

        private void Awake()
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        private void OnEnable()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        private void OnDisable()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        void IConnectionCallbacks.OnConnected()
        {
            if (m_DebugLogging)
            {
                Debug.Log("Connected.");
            }
        }

        void IConnectionCallbacks.OnConnectedToMaster()
        {
            if (m_DebugLogging)
            {
                Debug.Log("Connected to master.");
            }

            var roomOptions = new RoomOptions();
            roomOptions.IsOpen = true;
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = m_MaxPlayers;
            PhotonNetwork.JoinOrCreateRoom(m_RoomName, roomOptions, TypedLobby.Default);
        }

        void IMatchmakingCallbacks.OnJoinedRoom()
        {
            if (m_DebugLogging)
            {
                Debug.Log("Joined room.");
            }
        }

        void IMatchmakingCallbacks.OnCreatedRoom()
        {
            if (m_DebugLogging)
            {
                Debug.Log("Room created.");
            }
        }

        void IConnectionCallbacks.OnCustomAuthenticationFailed(string debugMessage) { }
        void IConnectionCallbacks.OnCustomAuthenticationResponse(Dictionary<string, object> data) { }
        void IConnectionCallbacks.OnDisconnected(DisconnectCause cause) { }
        void IConnectionCallbacks.OnRegionListReceived(RegionHandler regionHandler) { }

        void IMatchmakingCallbacks.OnFriendListUpdate(List<FriendInfo> friendList) { }
        void IMatchmakingCallbacks.OnCreateRoomFailed(short returnCode, string message) { }
        void IMatchmakingCallbacks.OnJoinRoomFailed(short returnCode, string message) { }
        void IMatchmakingCallbacks.OnJoinRandomFailed(short returnCode, string message) { }
        void IMatchmakingCallbacks.OnLeftRoom() { }
    }
}