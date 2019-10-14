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
        [SerializeField] GameObject m_ChatPanel = default;

        [Space]

        [SerializeField] float m_TransitionDelay = 1f;
        [SerializeField] float m_TransitionDuration = 5f;
        [SerializeField] float m_ConnectingTextFadeOutDelay = 1f;
        [SerializeField] float m_ConnectingTextFadeOutDuration = 3f;
        [SerializeField] float m_ChatPanelFadeInDelay = 3f;
        [SerializeField] float m_ChatPanelFadeInDuration = 1f;
        [SerializeField] float m_ChatPanelRotationSpeed = 50f;

        private void Awake()
        {
            m_ChatPanel.transform.localScale = Vector3.zero;
        }

        public void TransitFromConnectingViewIntoChatView()
        {
            m_LoaderAnimeAdapter.StopLoaderAnimationSmoothly(m_TransitionDelay, m_TransitionDuration);

            foreach (Transform child in m_RootOfConnectionCharacters.transform)
            {
                child.GetComponent<UI.Util.Fadeable>().FadeOut(m_ConnectingTextFadeOutDuration, m_TransitionDelay + m_ConnectingTextFadeOutDelay);
            }

            m_ChatPanel.GetComponent<UI.Util.ScaleFadeable>().FadeIn(m_ChatPanelFadeInDuration, m_ChatPanelFadeInDelay);
            m_ChatPanel.GetComponent<UI.Util.Slidable>().Slide(Vector3.up * Screen.height / 2, Vector3.zero, m_ChatPanelFadeInDuration, m_ChatPanelFadeInDelay);
            m_ChatPanel.GetComponent<UI.Util.Rotatable>().Rotate(m_ChatPanelRotationSpeed, m_ChatPanelFadeInDuration, m_ChatPanelFadeInDelay);
        }
    }
}