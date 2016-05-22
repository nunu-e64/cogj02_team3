﻿using UnityEngine;
using System.Collections;

public class Testlail : MonoBehaviour {

	// 追尾するパーティクル
	public ParticleSystem particle;
	// カメラ
	public Camera cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// ボタンが押しっぱなし
		if (Input.GetMouseButton(0))
		{
			// パーティクルがまだ生成されていないなら
			if (!particle.isPlaying)
			{
				// 生成開始
				particle.Play();
			}
			// 常に追尾するように
			// マウスのワールド座標までパーティクルを移動し、パーティクルエフェクトを1つ生成する
			var pos = cam.ScreenToWorldPoint(Input.mousePosition + cam.transform.forward * 10);
			particle.transform.position = pos;
		}
		// もしボタンが押されていないなら
		else
		{
			// まだ生成していたら
			if (particle.isPlaying)
			{
				// パーティクルを止めて全消去
				particle.Stop();
				particle.Clear();
			}
		}
	}
}
