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

		public LuaMgr i
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
			lua.LuaSetTop(0);
			LuaBinder.Bind(lua);
			LuaCoroutine.Register(lua, this);
		}

	}
}
