# LightBot-Clone
2 day case study Unity 3D game with command pattern

## Project overview
 This project build on Unity using URP. Test scene contains 10 different level. UI designed for portrait mode and scales for different aspect ratios. Camera set on orthographic mode, used Cinemachine transition effects, Player actions build used command desing pattern.
 You can select 2 different characters in begining and level that you want to play. Levels created using text based level generator and scriptable objects(details below).

 ## Level Creation
 
You can easily create a level with text and put directly on game with simple steps. You need a level text file first. Lets create one.
Example level.TXT file:

```
06
06
104401
021120
00AA00
100001
020020
```
The first 2 colons represents width and height. In this example our level contains 6x6 space in scene. 
Digits mean normal blocks and how many are them in that space in a row. for example we have 4 blocks top on each other on 1x3 coordinates.
Letters mean normal blocks+1 press button top of them. A means 1 press button. B means 1 normal block + 1 press button on it etc...

Lets look our scene for better example.
![image](https://user-images.githubusercontent.com/44952253/200057822-0e8981e5-c248-4ea6-9008-94a9d578589a.png)

After creating text file, you need to create a Level file on Resources/Levels. Right Click on Project window, Create->Level Generation->Level.
You can set up your default block prefab and press button prefab here. And you need to assign your level text file that you want to use in this level. You can look other Level files for other references.
After creation name this file simply level that you want to be. simply 1, 5, 10 etc. And you're done!
To use this level you need to add a button to reference. Go Test Scene Canvas->LevelCreationPanel->LevelGrid and CTRL+D a level button, set onClick StartLevel int reference to level you created. On Buttons child set level text to your level. This planned to be automated, i want to kept like this for now.

 ## Gameplay
 [ezgif.com-gif-maker.webm](https://user-images.githubusercontent.com/44952253/200060125-bbb2bb31-b4f1-4019-9bef-59d6e4af9e5a.webm)
