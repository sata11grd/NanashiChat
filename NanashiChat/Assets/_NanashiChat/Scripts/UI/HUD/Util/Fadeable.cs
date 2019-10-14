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

namespace NanashiChat.UI.Util
{
    /// <summary>
    /// 文字をフェードイン・フェードアウト可能にするクラスです。
    /// </summary>
    public class Fadeable : MonoBehaviour
    {
        enum FADE_TYPE
        {
            FadeIn,
            FadeOut,
        }

        TMPro.TextMeshProUGUI m_Text = default;

        private void Awake()
        {
            m_Text = GetComponent<TMPro.TextMeshProUGUI>();
        }

        void SetTextAlpha(float alpha)
        {
            m_Text.color = new Color(m_Text.color.r, m_Text.color.g, m_Text.color.b, alpha);
        }

        /// <summary>
        /// フェードインします。
        /// </summary>
        /// <param name="duration"></param>
        public void FadeIn(float duration, float delay = 0f)
        {
            StartCoroutine(FadeCoroutine(FADE_TYPE.FadeIn, duration, delay));
        }

        /// <summary>
        /// フェードアウトします。
        /// </summary>
        /// <param name="duration"></param>
        public void FadeOut(float duration, float delay = 0f)
        {
            StartCoroutine(FadeCoroutine(FADE_TYPE.FadeOut, duration, delay));
        }

        IEnumerator FadeCoroutine(FADE_TYPE fadeType, float duration, float delay = 0f)
        {
            yield return new WaitForSeconds(delay);

            var timeElapsed = 0f;

            while (timeElapsed <= duration)
            {
                timeElapsed += Time.deltaTime;

                switch (fadeType)
                {
                    case FADE_TYPE.FadeIn:
                        SetTextAlpha(timeElapsed / duration);
                        break;
                    case FADE_TYPE.FadeOut:
                        SetTextAlpha(1f - timeElapsed / duration);
                        break;
                }

                yield return null;
            }
        }
    }
}