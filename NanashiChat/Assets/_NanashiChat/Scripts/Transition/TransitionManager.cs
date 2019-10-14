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
        [SerializeField] UI.HUD.LoaderAnimeAdapter m_LoaderAnimeAdapter = default;
        [SerializeField] GameObject m_RootOfConnectionCharacters = default;
        [SerializeField] UI.Util.ScaleFadeable m_ChatPanel = default;

        [Space]

        [SerializeField] float m_TransitionDelay = 1f;
        [SerializeField] float m_TransitionDuration = 5f;
        [SerializeField] float m_ConnectingTextFadeOutDelay = 1f;
        [SerializeField] float m_ConnectingTextFadeOutDuration = 3f;
        [SerializeField] float m_ChatPanelFadeInDelay = 3f;
        [SerializeField] float m_ChatPanelFadeInDuration = 1f;

        public void TransitFromConnectingViewIntoChatView()
        {
            m_LoaderAnimeAdapter.StopLoaderAnimationSmoothly(m_TransitionDelay, m_TransitionDuration);

            foreach (Transform child in m_RootOfConnectionCharacters.transform)
            {
                child.GetComponent<UI.Util.Fadeable>().FadeOut(m_ConnectingTextFadeOutDuration, m_TransitionDelay + m_ConnectingTextFadeOutDelay);
            }

            m_ChatPanel.FadeIn(m_ChatPanelFadeInDuration, m_ChatPanelFadeInDelay);
        }
    }
}