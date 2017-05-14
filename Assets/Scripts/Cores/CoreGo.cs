using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QGame
{
    public class CoreGo
    {
        static ICore[] cores = new ICore[10];

        public static void AddCore(CoreEnum name, ICore core)
        {
            int i = (int)name;
            cores[i] = core;
        }

        public static ICore GetCore(CoreEnum name)
        {
            int i = (int)name;
            return cores[i];
        }

        public static void Remove(CoreEnum name)
        {
            int i = (int)name;
            cores[i] = null;
        }

        public static void ResetCore(CoreEnum name)
        {
            int i = (int)name;
            cores[i].Reset();
        }

        public static void ResetAllCores()
        {
            foreach (var core in cores)
            {
                core.Reset();
            }
        }
    }
}