//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using System.Collections.Generic;
using UnityEngine;
using System;
namespace MeteTurkay
{
    public class ActionController : MonoBehaviour
    {
        [SerializeField] ActionRecorder recorder;
        [SerializeField] PlayerUnit playerUnit;
        [SerializeField] Stack<string> commandList=new();
        [SerializeField] GameObject ActionContainer;
        public static event Action resetButtons;
        [SerializeField]bool isPlaying = false;
        private void Update()
        {
            if (playerUnit.canAct)
            {
                GetNextState();
            }
        }

        void GetNextState()
        {
            if (commandList.Count == 0)
            {
                return;
            }
            string action = commandList.Pop();
            switch (action)
            {
                case "Foward":
                    OnMoveFoward(Direction.Foward);
                    break;
                case "Jump":
                    OnJump();
                    break;
                case "TurnRight":
                    OnTurn(Direction.Right);
                    break;
                case "TurnLeft":
                    OnTurn(Direction.Left);
                    break;
                case "Press":
                    OnPress();
                    break;
                default:
                    break;
            }
        }
        //used in GO button
        public void SetCommandsFromList()
        {
            bool tempPlayer = isPlaying;
            if(isPlaying)
                Restart();
            int lastIndex = ActionContainer.transform.childCount;
            if (lastIndex == 0)
                return;
            commandList.Clear();
            //reverese for for getting first object last, to pop up first in stack
            for(int i = lastIndex-1; 0 <= i; i--)
            {
                commandList.Push(ActionContainer.transform.GetChild(i).tag);
            }
            if(!tempPlayer)
                SetCanAct(true);
            isPlaying = true;
        }
        //used in reset button
        public void ResetAll()
        {
            ActionContainer.transform.DestroyChildren();
            commandList.Clear();
            isPlaying = false;
            playerUnit.ResetPlayer();
            resetButtons?.Invoke();
        }
        public void Restart()
        {
            isPlaying = false;
            playerUnit.ResetPlayer();
            resetButtons?.Invoke();
        }
        //used in level selection, do code review here
        public void RestartIfPlaying()
        {
            if (!isPlaying)
                return;
            ActionContainer.transform.DestroyChildren();
            commandList.Clear();
            isPlaying = false;
            playerUnit.ResetPlayer();
            resetButtons?.Invoke();
        }
        public  void SetCanAct(bool act)
        {
            playerUnit.canAct = act;
        }
        #region Actions
        void OnJump()
        {
            var jumpAction = new JumpAction(playerUnit);
            recorder.Record(jumpAction);
        }
        void OnTurn(Direction side) 
        {
            var turn = new TurnAction(playerUnit,side);
            recorder.Record(turn);
        }
        void OnPress()
        {
            var press = new PressAction(playerUnit);
            recorder.Record(press);
        }
        void OnMoveFoward(Direction side)
        {
            var moveFoward = new MoveFowardAction(playerUnit, Direction.Foward);
            recorder.Record(moveFoward);
        }
        #endregion
    }
}
