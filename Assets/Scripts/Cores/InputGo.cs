using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QGame
{
    public class InputGo : ICore
    {
        MessageGo msgGo;

        public ICore Init()
        {
            msgGo = CoreGo.GetCore(CoreEnum.MessageGo) as MessageGo;
            msgGo.Register0(MessageType.NormalUpdate, OnUpdate);
            return this;
        }

        public ICore Reset()
        {
            return this;
        }

        void OnUpdate()
        {
            if (Input.GetKey("w")) msgGo.Call(MessageType.InputKeyEvent, "w");
        }
    }
}
