﻿/************************************************
TransformResearch.cs

Copyright (c) 2016 LotosLabo

This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
************************************************/

using UnityEngine;
using System.Collections;
using System.Linq;

/* オブジェクト・コンポーネント検索クラス. */
public class TransformResearch : MonoBehaviour {

    /// <summary>
    /// 自身のコンポーネントを取得する.
    /// </summary>
    /// <param name="obj">ゲームオブジェクトを指定.</param>
    /// <returns>コンポーネントを返す.</returns>
    public static T SelfGetComponent<T>(GameObject obj) where T : Component {
        return obj.GetComponent<T>();
    }

    /// <summary>
    /// 指定したコンポーネントの子オブジェクトを取得する（自分自身は取得しない).
    /// </summary>
    /// <param name="obj">ゲームオブジェクトを指定.</param>
    /// <param name="include">非アクティブオブジェクトを含むか.</param>
    public static T[] SelfGetComponentArray<T>(GameObject obj, bool include = false) where T : Component {
        return obj
            .GetComponentsInChildren<T>(include)
            .Where(c => obj != c.gameObject)
            .ToArray();
    }

    /// <summary>
    /// 指定したオブジェクトのコンポーネントの子オブジェクトをすべて取得.
    /// </summary>
    /// <param name="obj">ゲームオブジェクトを指定.</param>
    /// <param name="include">非アクティブオブジェクトを含むか.</param>
    /// <returns>GameObjectの配列型</returns>
    public static GameObject[] GetChildren(GameObject obj, bool include = false) {
        return obj
            .GetComponentsInChildren<Transform>(include)
            .Where(c => c != obj.transform)
            .Select(c => c.gameObject)
            .ToArray();
    }

    /// <summary>
    /// シーン内の指定したコンポーネントを取得.
    /// </summary>
    /// <returns>はじめに見つけたコンポーネント情報を返す.</returns>
    public static T FindComponentObject<T>() where T : Component {
        return GameObject.FindObjectOfType<T>();
    }


}
