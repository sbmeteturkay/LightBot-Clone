//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using UnityEngine;

namespace MeteTurkay{
	public class LevelGenerator : MonoBehaviour
	{
        [Header("Debug dont change")]
        public Level level;
        [SerializeField] private Vector3 levelRotation;
        private Vector3 _startPosition;
        private GameObject _levelGo;
        public int numbersOfPressObject=0;
        //private void Start() => Initialization();

        public void Initialization()
        {
            numbersOfPressObject = 0;
            level.Initialization();
            if (_levelGo!=null)
                Destroy(_levelGo);
            _levelGo = new GameObject
            {
                name = "Level",
            };
            _levelGo.transform.SetParent(transform);
            _startPosition = transform.position;
            int levelWidth = level.GetWidthAndHeight().Item1;
            print(levelWidth + " " + level.GetWidthAndHeight().Item2);
            //Start the loop on the third line since the first two is for the width and height number
            for (int y = 2; y < level.GetLevelStrings().Length; y++)
            {
                // We convert the whole horizontal line at the height position into char array
                string rowLineText = level.GetLevelStrings()[y];
                char[] chars = rowLineText.ToCharArray();
                // Now on each line, we loop on every char of the string in the text, and stop when we reach the width number
                for (int x = 0; x < levelWidth; x++)
                {
                    // Then we find out what the char/symbol in that position
                    char charText = chars[x];
                    // Finally we place the prefab based on the char position from the whole text
                    PlacePrefab(charText, x, y);
                }
            }
            _levelGo.transform.rotation = Quaternion.Euler(levelRotation);
        }
        private void PlacePrefab(char symbol, int xPosition, int yPosition)
        {
            //level.GetObjectCollection().TryGetValue(symbol, out GameObject obj);
           // Debug.Log($"OBJ NULL : {obj}");
            //You might want to leave a space empty...
            if (symbol == 0) { return; }
            Vector3 position = _startPosition + new Vector3(xPosition*level.spacingX,0, (2-yPosition) * level.spacingX);
            if (char.IsDigit(symbol))
            {
                for (int i=0; i < char.GetNumericValue(symbol); i++)
                {
                    if (i != 0)
                        position.y += Mathf.Pow(1,i)* level.spacingY;
                    GameObject temp = Instantiate(level.defaultButton, position, Quaternion.identity, _levelGo.transform);
                    temp.name = $"OBJECT {xPosition}:{yPosition}";
                }
            }
            else
            {
                int index = ((int)char.ToUpper(symbol)) - 64;
                for(int i= 0; i < index; i++)
                {
                    if(i!=0)
                        position.y +=level.spacingY;
                    if (i == index-1)
                    {
                        GameObject temp = Instantiate(level.pressButton, position, Quaternion.identity, _levelGo.transform);
                        numbersOfPressObject++;
                        temp.name = $"PRESS OBJECT {xPosition}:{yPosition}";
                    }
                    else
                    {
                        GameObject temp = Instantiate(level.defaultButton, position, Quaternion.identity, _levelGo.transform);
                        temp.name = $"OBJECT {xPosition}:{yPosition}";
                    }
                }
            }
        }
    }
}
