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

namespace NanashiChat.UI.HUD
{
    /// <summary>
    /// ローディングアニメーションの表現を扱うクラスのアダプタです。
    /// </summary>
    public class LoaderAnimeAdapter : Photon.Pun.Demo.PunBasics.LoaderAnime
    {
        [SerializeField] ParticleSystem m_ParticleSystem = default;

        private void Start()
        {
            base.StartLoaderAnimation();
        }

        /// <summary>
        /// 滑らかにアニメーションを停止します。
        /// </summary>
        public void StopLoaderAnimationSmoothly(float delay, float duration)
        {
            StartCoroutine(StopLoaderAnimationSmoothlyCoroutine(delay, duration));
        }

        IEnumerator StopLoaderAnimationSmoothlyCoroutine(float delay, float duration)
        {
            yield return new WaitForSeconds(delay);

            var timeElapsed = 0f;

            while (timeElapsed < duration)
            {
                timeElapsed += Time.deltaTime;

                transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, timeElapsed / duration);

                ParticleSystem.MainModule mainModule = m_ParticleSystem.main;
                mainModule.startColor = Color.Lerp(Color.white, new Color(1f, 1f, 1f, 0f), timeElapsed / duration);

                yield return null;
            }

            transform.localScale = Vector3.zero;
            base.StopLoaderAnimation();
        }
    }
}