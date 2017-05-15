using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QGame
{
	public class KeyRegisterInfo
	{
		public ButtonKeyType t;
		public KeyCode k;
		public Action a;
	}

    public class InputGo : ICore
    {
		//Dictionary<ButtonKeyType, Dictionary<KeyCode, Action>> keyRegisters = new Dictionary<ButtonKeyType, Dictionary<KeyCode, Action>>();
		List<KeyRegisterInfo> keyRegisters = new List<KeyRegisterInfo>();

        public ICore Init()
        {
            var msgGo = CoreGo.GetCore(CoreEnum.MessageGo) as MessageGo;
            msgGo.Register0(MessageType.NormalUpdate, OnUpdate);
            return this;
        }

        public ICore Reset()
        {
            keyRegisters.Clear();
            return this;
        }

        public void RegisterKeyAction(KeyCode key, Action a, ButtonKeyType t)
        {
			foreach (var kri in keyRegisters)
			{
				if (kri.t == t && kri.k == key)
				{
					kri.a += a;
					return;
				}
			}

			var _kri = new KeyRegisterInfo();
			_kri.a = a;
			_kri.k = key;
			_kri.t = t;

			keyRegisters.Add(_kri);
        }

        public void RemoveKeyAction(KeyCode key, Action a, ButtonKeyType t)
        {
			if (a == null) return;

			int i = 0;

			foreach (var kri in keyRegisters)
			{
				if (kri.t == t && kri.k == key)
				{
					if (kri.a != null)
					{
						kri.a = kri.a - a;
					}

					if (kri.a == null)
					{
						keyRegisters.RemoveAt (i);
					}

					return;
				}

				++i;
			}
        }

        void OnUpdate()
        {
            foreach(var kri in keyRegisters)
            {
                if (kri.t == ButtonKeyType.Down)
                {
					if (kri.a != null)
					{
						if (Input.GetKeyDown(kri.k))
						{
							kri.a.Invoke();
						}
					}
                }
            }
        }
    }
}
