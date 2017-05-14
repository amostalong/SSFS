using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class HttpGo : MonoBehaviour
{
	public BaseSetting baseSetting;

	// Use this for initialization
	void Start()
	{
		//StartCoroutine(TestScenario1());
		//StartCoroutine(TestScenario2());
		//StartCoroutine(TestScenario3());
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void UploadFile()
	{
		
	}

#region Test Scenario
	IEnumerator TestScenario3()
	{
		// 封装表单
		WWWForm form = new WWWForm();
		//form.AddField("field1", "value");

		/*
		添加文件表单项
		public void AddBinaryData(string fieldName, byte[] contents, string fileName = null, string mimeType = null);
		*/

		form.AddBinaryData("file", System.Text.Encoding.UTF8.GetBytes("test"), "test.txt", null);  // 默认的 mimeType 为 application/octet-stream
		form.AddBinaryData("file", System.Text.Encoding.UTF8.GetBytes("test1"), "test1.txt", null);  // 默认的 mimeType 为 application/octet-stream

		using (UnityWebRequest www = UnityWebRequest.Post(baseSetting.httpFileAddress, form))
		{
			yield return www.Send();

			if (www.isError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log(www.uploadedBytes);
				Debug.Log("Post complete!");
			}
		}
	}

	IEnumerator TestScenario1()
	{
		List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
		formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
		formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));

		using (UnityWebRequest www = UnityWebRequest.Post(baseSetting.httpFileAddress + "/myfile.txt", formData))
		{
			yield return www.Send();

			if (www.isError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log(www.uploadedBytes);
				Debug.Log("Post complete!");
			}
		}
	}

	IEnumerator TestScenario2()
	{
		using (UnityWebRequest www = UnityWebRequest.Get(Path.Combine(baseSetting.httpFileAddress, "whatever.txt")))
		{
			yield return www.Send();

			if (www.isError)
			{
				Debug.Log(www.error);
			}
			else
			{
				string path = Path.Combine(Application.streamingAssetsPath, "whatever.txt.bytes");
				Debug.Log("Create file: " + path);
				using (var fs = File.Create(path))
				{
					fs.Write(www.downloadHandler.data, 0, www.downloadHandler.data.Length);
				}

#if UNITY_EDITOR
				AssetDatabase.Refresh();
				Debug.Log("Get complete!");
#endif
			}
		}
	}
#endregion
}
