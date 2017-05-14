using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QGame
{
    public class InputGo : ICore
    {
        Dictionary<ButtonKeyType, Dictionary<KeyCode, Action>> keyRegisters = new Dictionary<ButtonKeyType, Dictionary<KeyCode, Action>>();

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

        public void RegisterKeyAction(KeyCode key, Action cb, ButtonKeyType t)
        {
            if (!keyRegisters.ContainsKey(t))
            {
                keyRegisters[t] = new Dictionary<KeyCode, Action>();
            }

            if (!keyRegisters[t].ContainsKey(key))
            {
                keyRegisters[t][key] = cb;
            }
            else
            {
                keyRegisters[t][key] += cb;
            }
        }

        public void RemoveKeyAction(KeyCode key, Action cb, ButtonKeyType t)
        {
            var cbs = keyRegisters[t][key];

            if (keyRegisters[t][key] != null)
            {
                keyRegisters[t][key] -= cb;
            }
        }

        void OnUpdate()
        {
            foreach(var k in keyRegisters)
            {
                if (k.Key == ButtonKeyType.Down)
                {
                    foreach(var sa in keyRegisters[k.Key])
                    {
                        if (sa.Value != null)
                        {
                            if (Input.GetKeyDown(sa.Key))
                            {
                                sa.Value.Invoke();
                            }
                        }
                    }
                }
            }
        }
    }
}
