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

namespace NanashiChat.UI
{
    /// <summary>
    /// 席数の表示を扱うクラスです。
    /// </summary>
    public class SeatsText : MonoBehaviour
    {
        [SerializeField] string m_PreText = "席数: ";
        [SerializeField] string m_MiddleText = "席 / ";
        [SerializeField] string m_PostText = "席";

        TMPro.TextMeshProUGUI m_Text = default;

        private void Awake()
        {
            m_Text = GetComponent<TMPro.TextMeshProUGUI>();
        }

        private void Update()
        {
            if (!PhotonNetwork.InRoom)
            {
                return;
            }

            m_Text.text = m_PreText + PhotonNetwork.CurrentRoom.PlayerCount + m_MiddleText + PhotonNetwork.CurrentRoom.MaxPlayers + m_PostText;
        }
    }
}