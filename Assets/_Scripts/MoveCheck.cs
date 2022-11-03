//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using UnityEngine;

namespace MeteTurkay{
	public class MoveCheck : MonoBehaviour
	{
        public bool canDo = false;
        private void OnTriggerStay(Collider other)
        {
            canDo = other.CompareTag("Block");
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Block"))
                canDo = false;
        }
    }
}
