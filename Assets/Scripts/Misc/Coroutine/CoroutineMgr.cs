using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineMgr : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(this.gameObject);
	}

	public void StartQcoroutine(IEnumerator coroutine)
	{
		StartCoroutine(coroutine);
	}
}
