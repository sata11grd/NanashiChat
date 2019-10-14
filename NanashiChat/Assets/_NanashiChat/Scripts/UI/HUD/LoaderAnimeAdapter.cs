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

namespace NanashiChat.UI
{
    /// <summary>
    /// ローディングアニメーションの表現を扱うクラスのアダプタです。
    /// </summary>
    public class LoaderAnimeAdapter : Photon.Pun.Demo.PunBasics.LoaderAnime
    {
        private void Start()
        {
            base.StartLoaderAnimation();
        }
    }
}