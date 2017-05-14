using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace QGame
{
    public class MessageGo : MonoBehaviour, ICore
    {
        public delegate void CB0();
        public delegate void CB1(object o);

        Dictionary<MessageType, CB0> regedit0 = new Dictionary<MessageType, CB0>();
        Dictionary<MessageType, CB1> regedit1 = new Dictionary<MessageType, CB1>();

        public void Call(MessageType msg, object o = null)
        {
            if (regedit0.ContainsKey(msg)) regedit0[msg].Invoke();
            if (regedit1.ContainsKey(msg)) regedit1[msg].Invoke(o);
        }

        public void Register0(MessageType msg, CB0 cb)
        {
            regedit0[msg] += cb;
        }

        public void Register1(MessageType msg, CB1 cb)
        {
            regedit1[msg] += cb;
        }

        public ICore Init()
        {
            return this;
        }

        public ICore Reset()
        {
            return this;
        }
    }

    public enum MessageType
    {
        EarlyUpdate,
        NormalUpdate,
        LateUpdate,

        InputKeyEvent,
    }

}