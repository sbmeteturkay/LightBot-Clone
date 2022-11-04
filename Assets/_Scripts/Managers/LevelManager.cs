//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;
using TMPro;
using UnityEngine.UI;
namespace MeteTurkay{
	public class LevelManager : MonoBehaviour
	{
		[SerializeField] LevelGenerator levelGenerator;
		[SerializeField] int pressNeededButton = 0;
        List<PushButton> pushButtons = new();
        public static event Action finished;
        [SerializeField]int currentLevel = 0;
        [SerializeField]int levelCount=0;
        [SerializeField] Animator cameraAnimator;
        [Header("UI")]
        [SerializeField] GameObject stackUI;
        [SerializeField] GameObject completedUI;
        private void Start()
        {
            PushButton.buttonPressed += PushButton_buttonPressed;
            ActionController.resetButtons += ActionController_resetButtons;
            //CreateLevelButtons();
            string filePath = Application.dataPath + "/Resources/Levels";
            levelCount = Directory.GetFiles(filePath).Length / 2;
        }

        private void ActionController_resetButtons()
        {
            pressNeededButton= levelGenerator.numbersOfPressObject;
            pushButtons.Clear();
        }

        private void PushButton_buttonPressed(PushButton obj)
        {
            if (!pushButtons.Contains(obj))
            {
                pushButtons.Add(obj);
            }
            if (pushButtons.Count == pressNeededButton)
            {
                LevelCompleteActions();
            }
        }

        private void LevelCompleteActions()
        {
            finished?.Invoke();
            cameraAnimator.SetTrigger("closeUp");
            stackUI.SetActive(false);
            completedUI.SetActive(true);
            pushButtons.Clear();
        }

        public void StartLevel(int i)
        {
            Level level = Resources.Load<Level>("Levels/" + i.ToString());
            currentLevel = i;
            levelGenerator.level = level;
			levelGenerator.Initialization();
			pressNeededButton = levelGenerator.numbersOfPressObject;
            cameraAnimator.SetTrigger("mainPosition");
            stackUI.SetActive(true);
            completedUI.SetActive(false);
        }
        //used in next level button, this button also contains ActionController.Reset() on click
        public void NextLevel()
        {
            if (currentLevel + 1 <= levelCount)
            {
                StartLevel(currentLevel + 1);
            }
            else
            {
                StartLevel(1);
            }
        }
        //We can Create buttons dynamically, but i will look it later

        //void CreateLevelButtons()
        //{
        //    string filePath = Application.dataPath + "/Resources/Levels";
        //    int fileCount = Directory.GetFiles(filePath).Length / 2;
        //    Debug.Log(fileCount);
        //    for (int i = 0; i < fileCount; i++)
        //    {
        //        levels.Add(Resources.Load<Level>("Levels/" + i.ToString()));
        //        var button = Instantiate(levelButton, gridParentForButtons.transform);
        //        button.transform.GetChild(0).GetComponent<TMP_Text>().text = (i + 1).ToString();
        //        button.GetComponent<Button>().onClick.AddListener(delegate { StartLevel(i); gridParentForButtons.transform.parent.gameObject.SetActive(false);gridParentForButtons.transform.parent.gameObject.transform.parent.GetChild(1).gameObject.SetActive(true); });
        //    }
        //} 

	}
}
