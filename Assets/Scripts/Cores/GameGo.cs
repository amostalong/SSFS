using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QGame
{
    public class GameGo : MonoBehaviour
    {
        private void Awake()
        {
            GameStart();
        }

        public static void GameStart()
        {
            InitCoresComponent();
        }

        public static void InitCoresComponent()
        {
            CoreGo.AddCore(CoreEnum.MessageGo, new MessageGo().Init());
            CoreGo.AddCore(CoreEnum.InputGo, new InputGo().Init());

        }
    }

    public enum CoreEnum
    {
        MessageGo,
        InputGo,
    }
        

}