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
    /// 文字をポップ可能にするクラスです。
    /// </summary>
    public class Poppable : MonoBehaviour
    {
        [SerializeField] float m_PopSpeed = 10f;
        [SerializeField] float m_GravityScale = 10f;

        RectTransform rectTransform = default;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void Pop()
        {
            StartCoroutine(PopCoroutine());
        }

        IEnumerator PopCoroutine()
        {
            var startPosition = rectTransform.position;
            var timeElapsed = 0f;

            while (rectTransform.position.y >= startPosition.y)
            {
                rectTransform.position = startPosition + (Vector3.up * m_PopSpeed) + (0.5f * Physics.gravity * m_GravityScale * timeElapsed * timeElapsed);
                yield return null;

                timeElapsed += Time.deltaTime;
            }

            rectTransform.position = startPosition;
        }
    }
}