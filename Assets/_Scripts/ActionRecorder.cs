//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using UnityEngine;
using System.Collections.Generic;
namespace MeteTurkay
{
    public class ActionRecorder : MonoBehaviour
    {
        private readonly Stack<ActionBase> ActionOrder = new();
        public void Record(ActionBase actionBase)
        {
            ActionOrder.Push(actionBase);
            actionBase.Execute();
        }
        public void Rewind()
        {

        }
    }
}
