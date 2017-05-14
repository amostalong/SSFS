using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace QGame
{
    public class MessageGo : ICore
    {
        public delegate void CB0();
        public delegate void CB1(object o);

        Dictionary<MessageType, CB0> regedit0;
        Dictionary<MessageType, CB1> regedit1;
        CB0[] updateCB = new CB0[3];
        

        public ICore Init()
        {
            regedit0 = new Dictionary<MessageType, CB0>();
            regedit1 = new Dictionary<MessageType, CB1>();

            regedit0[MessageType.NormalUpdate] = null;
            regedit0[MessageType.EarlyUpdate] = null;
            regedit0[MessageType.LateUpdate] = null;

            return this;
        }

        public void Call(MessageType msg, object o = null)
        {
            CB0 cb0;
            CB1 cb1;

            int _msg = (int)msg;

            if (_msg < 3)
            {
                if ((cb0 = updateCB[_msg]) != null) cb0.Invoke();
            }
            else
            {
                if (regedit0.TryGetValue(msg, out cb0)) cb0.Invoke();
                if (regedit1.TryGetValue(msg, out cb1)) cb1.Invoke(o);
            }
        }

        public void Register0(MessageType msg, CB0 cb)
        {
            CB0 cb0;

            int _msg = (int)msg;

            if (_msg < 3)
            {
                if (updateCB[_msg] != null)
                {
                    updateCB[_msg] += cb;
                }
                else
                {
                    updateCB[_msg] = cb;
                }
            }
            else
            {
                if (regedit0.TryGetValue(msg, out cb0))
                {
                    if (cb0 != null)
                    {
                        regedit0[msg] += cb;
                        return;
                    }
                }

                regedit0[msg] = cb;
            }
        }

        public void Register1(MessageType msg, CB1 cb)
        {
            CB1 cb1;

            if (regedit1.TryGetValue(msg, out cb1))
            {
                if (cb1 != null)
                {
                    regedit1[msg] += cb;
                    return;
                }
            }
   
            regedit1[msg] = cb;
            
        }



        public ICore Reset()
        {
            Init();
            return this;
        }

        public void OnUpdate()
        {
            Call(MessageType.EarlyUpdate);
            Call(MessageType.NormalUpdate);
            Call(MessageType.LateUpdate);
        }
    }

    public enum MessageType
    {
        EarlyUpdate = 0,
        NormalUpdate = 1,
        LateUpdate = 2,

        InputKeyEvent,
    }

}