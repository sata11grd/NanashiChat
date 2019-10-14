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
    /// スライドを可能にするクラスです。
    /// </summary>
    public class Slidable : MonoBehaviour
    {
        /// <summary>
        /// スライドします。
        /// </summary>
        /// <param name="duration"></param>
        public void Slide(Vector3 start, Vector3 goal, float duration, float delay = 0f)
        {
            StartCoroutine(SlideCoroutine(start, goal, duration, delay));
        }

        IEnumerator SlideCoroutine(Vector3 start, Vector3 goal, float duration, float delay = 0f)
        {
            yield return new WaitForSeconds(delay);

            var timeElapsed = 0f;
            var rectTransform = GetComponent<RectTransform>();

            while (timeElapsed <= duration)
            {
                timeElapsed += Time.deltaTime;
                rectTransform.anchoredPosition = Vector3.Lerp(start, goal, timeElapsed / duration);

                yield return null;
            }

            rectTransform.anchoredPosition = goal;
        }
    }
}