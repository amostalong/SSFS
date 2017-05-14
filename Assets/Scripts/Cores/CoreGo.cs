using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QGame
{
    public class CoreGo
    {
        static Dictionary<CoreEnum, ICore> coreDic = new Dictionary<CoreEnum, ICore>();

        public static void AddCore(CoreEnum name, ICore core)
        {
            coreDic[name] = core;
        }

        public static ICore GetCore(CoreEnum name)
        {
            return coreDic[name];
        }

        public static void Remove(CoreEnum name)
        {
            coreDic.Remove(name);
        }

        public static void ResetCore(CoreEnum name)
        {
            if (coreDic.ContainsKey(name))
            {
                coreDic[name].Reset();
            }
        }

        public static void ResetAllCores()
        {
            foreach (var core in coreDic)
            {
                core.Value.Reset();
            }
        }
    }
}