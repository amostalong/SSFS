using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TimeMgr : SingletonMonoBehaviour<TimeMgr> {

	int max_id = int.MinValue;

	List<TimerEntityInner> entitys = new List<TimerEntityInner>();

	class TimerEntityInner
	{
		public int id;
		public float t_passed;
		public bool pause;
		public TimerEntity entity;
	}

	class TimerEntity
	{
		//触发时间 如果是循环的话 触发后重置为0
		public float targetTime;
		//call back
		public Action callBack;
		//倍率 2倍时 1秒相当于2秒
		public float multiple;
		//循环触发
		public Boolean loop;

		public Boolean scale;

		public TimerEntity(float t, Action c) : this(t, c, 1, false, true) { }

		public TimerEntity(float t, Action c, float m) : this(t, c, m, false, true) { }

		public TimerEntity(float t, Action c, float m, Boolean l, Boolean scale)
		{
			targetTime = t;
			callBack = c;
			multiple = m;
			loop = l;
		}
	}


	float t0;
	float t1;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		t0 = Time.deltaTime;
		t1 = Time.unscaledDeltaTime;

		for (int i = 0; i < entitys.Count; ++i)
		{
			var e = entitys[i];

			if (!e.pause)
			{
				var p = e.t_passed += e.entity.scale ? t0 : t1;

				if (p > e.entity.targetTime)
				{
					e.entity.callBack.Invoke();
					if (e.entity.loop)
					{
						e.t_passed = 0;
					}
					else
					{
						entitys.RemoveAt(i--);
					}
				}
			}
		}
	}

	//增加一个计时触发器
	public int AddTimer(float cycle, Action callBack, float multiple, bool loop, bool scale = true)
	{
		var entity = new TimerEntity(cycle, callBack, multiple, loop, scale);
		var e_inner = new TimerEntityInner();

		e_inner.id = max_id++;
		e_inner.entity = entity;
		e_inner.t_passed = 0;

		entitys.Add(e_inner);

		return e_inner.id;
	}

	public void PauseTimer(int id, Boolean p)
	{
		entitys.Find((obj) => obj.id == id).pause = p;
	}

	public void RemoveTimer(int id)
	{
		entitys.RemoveAt(entitys.FindIndex((obj) => obj.id == id));
	}
}


