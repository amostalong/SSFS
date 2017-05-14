using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QGame
{
    public interface ICore
    {
        /// <summary>
        /// 需要提供一个初始化函数
        /// </summary>
        ICore Init();

        /// <summary>
        /// 所有Core对象需要提供重置初始状态的函数
        /// </summary>
        ICore Reset();
    }
}
