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
    public class ReconnectService : MonoBehaviourPunCallbacks
    {
        public void Use()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}