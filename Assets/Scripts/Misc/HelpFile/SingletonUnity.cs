using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> :MonoBehaviour where T : MonoBehaviour
{

	private static T _instance;
	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new GameObject("go").AddComponent<T>();
				_instance.hideFlags = HideFlags.HideAndDontSave;

#if UNITY_EDITOR
				_instance.gameObject.hideFlags = HideFlags.DontSave;
				Debug.Log("Create singleton monobehaviour");
				_instance.gameObject.name = _instance.GetType().FullName;
#endif
			}

			return _instance;
		}
	}
}
