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
    /// 回転を可能にするクラスです。
    /// </summary>
    public class Rotatable : MonoBehaviour
    {
        /// <summary>
        /// 回転させます。
        /// </summary>
        /// <param name="duration"></param>
        public void Rotate(float speed, float duration, float delay = 0f)
        {
            StartCoroutine(RotateCoroutine(speed, duration, delay));
        }

        IEnumerator RotateCoroutine(float speed, float duration, float delay = 0f)
        {
            yield return new WaitForSeconds(delay);

            var timeElapsed = 0f;
            var rectTransform = GetComponent<RectTransform>();
            var rotated = Vector3.zero;
            var defaultRotation = rectTransform.rotation;

            while (timeElapsed <= duration)
            {
                timeElapsed += Time.deltaTime;
                rectTransform.Rotate(rotated);
                rotated += Vector3.forward * speed * Time.deltaTime;

                yield return null;
            }

            rectTransform.rotation = defaultRotation;
        }
    }
}