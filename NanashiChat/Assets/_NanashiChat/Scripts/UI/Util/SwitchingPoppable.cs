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
    /// 1文字ずつ切り替えながらポップしていく表現を扱うクラスです。
    /// </summary>
    public class SwitchingPoppable : MonoBehaviour
    {
        /// <summary>
        /// 各要素をポップさせる間隔です。
        /// </summary>
        [SerializeField] float m_PopInterval = 0.1f;

        List<Poppable> m_Poppables = new List<Poppable>();

        int m_NextPopIndex = default;

        private void Awake()
        {
            // 子オブジェクトの中から、Poppableなオブジェクトだけを取得しておきます。
            foreach (Transform child in transform)
            {
                var poppable = child.GetComponent<Poppable>();

                if (poppable == null)
                {
                    continue;
                }

                m_Poppables.Add(poppable);
            }

            StartCoroutine(IntervalPopCoroutine());
        }

        void MoveNextPopIndex()
        {
            if (m_NextPopIndex < m_Poppables.Count - 1)
            {
                m_NextPopIndex++;
            }
            else
            {
                m_NextPopIndex = 0;
            }

            Debug.Assert(0 <= m_NextPopIndex && m_NextPopIndex < m_Poppables.Count);
        }

        IEnumerator IntervalPopCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(m_PopInterval);
                m_Poppables[m_NextPopIndex].Pop();
                MoveNextPopIndex();
            }
        }
    }
}