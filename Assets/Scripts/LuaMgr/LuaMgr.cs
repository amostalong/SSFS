using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

namespace QGame
{
	public class LuaMgr : MonoBehaviour
	{
		LuaState lua;
		LuaLooper loop;

		LuaMgr _i;

		public LuaMgr Instance
		{
			get
			{
				if (_i == null)
				{
					_i = GameObject.Find("Lua").GetComponent<LuaMgr>();
				}

				return _i;
			}
		}

		void Awake()
		{
			DontDestroyOnLoad(gameObject);
			lua = new LuaState();
			OpenLibs();
			lua.LuaSetTop(0);

			LuaBinder.Bind(lua);
			LuaCoroutine.Register(lua, this);
		}
		/// <summary>
		/// 初始化加载第三方库
		/// </summary>
		void OpenLibs()
		{
			lua.OpenLibs(LuaDLL.luaopen_pb);
			lua.OpenLibs(LuaDLL.luaopen_sproto_core);
			lua.OpenLibs(LuaDLL.luaopen_protobuf_c);
			lua.OpenLibs(LuaDLL.luaopen_lpeg);
			lua.OpenLibs(LuaDLL.luaopen_bit);
			lua.OpenLibs(LuaDLL.luaopen_socket_core);

			//this.OpenCJson();
		}

		/// <summary>
		/// 初始化Lua代码加载路径
		/// </summary>
		void InitLuaPath()
		{
			if (AppSetting.appBaseSetting.runningType == ProjectRunningType.DevelopmentBuild)
			{
				string rootPath = LuaFramework.AppConst.FrameworkRoot;
				lua.AddSearchPath(rootPath + "/Lua");
				lua.AddSearchPath(rootPath + "/ToLua/Lua");
			}
			else
			{
				lua.AddSearchPath(LuaFramework.Util.DataPath + "lua");
			}
		}
	}
}
