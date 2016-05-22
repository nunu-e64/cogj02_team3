﻿using UnityEngine;
using System.Collections;
using System;

public class ResultVoice : MonoBehaviour {

	// ここはGameManagerクラスが確立したら消す
	private enum ScoreRank
	{
		None = -1, TooBad, Bad, Good, Great, Perfect
	};

	[SerializeField, Tooltip("上からTooBad～Perfectの順に設定すること")]
	private ResultVoiceObject voiceObj;

	[SerializeField, Tooltip("デバッグ兼確認用")]
	private ScoreRank rank = ScoreRank.None;

	// 念のためコンポーネント格納用の変数を用意
	private AudioSource audioSource;

	private void SetVoice()
	{
		// 異常値チェック
		if (rank == ScoreRank.None)
		{
			Debug.LogAssertion("Rank Is Assertion!!!!");
			return;
		}

		// ランクに応じて表情設定
		audioSource.clip = voiceObj.clips[(int)rank];

		// nullチェック
		if (audioSource.clip != null) return;

		Debug.LogAssertion(rank + "Voice Clip Is null!!!!");
	}

	// 最高評価かどうか
	public bool IsMaxRank() { return rank == ScoreRank.Perfect ? true : false; }

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		SetVoice();
	}

	// 一応任意のタイミングでボイス再生
	public void PlayVoice(Action callBack)
	{
		audioSource.Play();
		StartCoroutine(PlayingVoice(callBack));
	}

	IEnumerator PlayingVoice(Action callBack)
	{
		if (audioSource.isPlaying) yield return null;

		// ボイスが終わったらコールバック
		callBack();
	}

}
