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
    /// スケールのフェードイン・フェードアウト可能にするクラスです。
    /// </summary>
    public class ScaleFadeable : MonoBehaviour
    {
        enum FADE_TYPE
        {
            FadeIn,
            FadeOut,
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
                        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, timeElapsed / duration);
                        break;
                    case FADE_TYPE.FadeOut:
                        transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, timeElapsed / duration);
                        break;
                }

                yield return null;
            }
        }
    }
}