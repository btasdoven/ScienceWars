using Assets.Scripts.Engine;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GUI
{
    class RunnerHandler : MonoBehaviour
    {
        void Update()
        {
            Chronos.deltaTime = Time.deltaTime;
            Runner.update();
        }
    }
}
