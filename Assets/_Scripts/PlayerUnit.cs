//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay
using UnityEngine;
namespace MeteTurkay
{
    public class PlayerUnit : MonoBehaviour
    {
        [SerializeField] Animator animator;
        public bool canAct = false;
        public void Jump()
        {
            canAct = false;
            print("jump");
            canAct = true;
        }
        public void MoveFoward()
        {
            canAct = false;
            print("move");
            canAct = true;
        }
        public void PressAction()
        {
            canAct = false;
            print("press");
            canAct = true;
        }
        public void TurnAction(Direction side)
        {
            canAct = false;
            print("turn" + side.ToString()) ;
            canAct = true;
        }
    }
}
