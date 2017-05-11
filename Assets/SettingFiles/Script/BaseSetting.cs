using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Project base setting for build this project
/// </summary>
[CreateAssetMenuAttribute]
public class BaseSetting : ScriptableObject {

	public ProjectRunningType runningType;
	public ResourceType resourceType;

	public string httpFileAddress;
}

public enum ProjectRunningType
{
	DevelopmentBuild, //开发状态
	ReleaseBuild, //正式运行
}

public enum ResourceType
{
	AssetBundle, //Use AB system
	Resources, //Use default system
}
