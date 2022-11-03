//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using UnityEngine;

namespace MeteTurkay{
	public class MoveCheck : MonoBehaviour
	{
        public bool canDo = false;
        [SerializeField] private string checkTag;
        private void OnTriggerStay(Collider other)
        {
            if (canDo)
                return;
            canDo = other.CompareTag(checkTag);
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(checkTag))
                canDo = false;
        }
    }
}
