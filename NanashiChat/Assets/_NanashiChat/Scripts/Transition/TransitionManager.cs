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

namespace NanashiChat.Transition
{
    public class TransitionManager : MonoBehaviour
    {
        [SerializeField] UI.LoaderAnimeAdapter m_LoaderAnimeAdapter;

        public void TransitFromConnectingViewIntoChatView()
        {
            m_LoaderAnimeAdapter.StopLoaderAnimationSmoothly(1f, 5f);
        }
    }
}