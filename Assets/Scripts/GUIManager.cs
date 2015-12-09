using UnityEngine;


public class GUIManager : MonoBehaviour 
{

    private static readonly float ScreenCWidth = Screen.width / 2.66f;

    private static readonly float ScreenCHeight = Screen.height / 8;

    private static readonly float ScreenStartX = Screen.width / 2 - ScreenCWidth / 2;

    private static readonly float ScreenStartY = Screen.height / 2 - ScreenCHeight - 25;


    private Rect PlayGame = new Rect(ScreenStartX, ScreenStartY, ScreenCWidth, ScreenCHeight);
    private Rect Credits = new Rect(ScreenStartX, ScreenStartY + ScreenCHeight + 5, ScreenCWidth, ScreenCHeight);

    private Rect Score = new Rect(20, 0, 100, 20);
    private Rect Deaths = new Rect(Screen.width - 90, 0, 100, 20);

    private Rect Key1 = new Rect(Screen.width / 2, 0, 44, 40);
    private Rect Key2 = new Rect(Screen.width / 2 + 44, 0, 44, 40);
    private Rect Key3 = new Rect(Screen.width / 2 + 88, 0, 44, 40);
    private Rect Key4 = new Rect(Screen.width / 2 + 44 + 88, 0, 44, 40);

    public Texture Key1Empty;
    public Texture Key2Empty;
    public Texture Key3Empty;
    public Texture Key4Empty;

    public Texture Key1F;
    public Texture Key2F;
    public Texture Key3F;
    public Texture Key4F;

    public GUISkin Skin;

    public static int keys;

    public void OnGUI()
    {

        if (Application.loadedLevel == 1)
        {
            if (Skin != null)
                GUI.skin = Skin;
           
            GUI.Label(Score, "Score: " + ScoreManager.GetScore());
            GUI.Label(Deaths, "Deaths: " + PlayerManager.GetDeaths());
            DrawKeys(keys);
        }
        else if (Application.loadedLevel == 2)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 8, 1000, 100), "Score " + ScoreManager.GetScore() + " Deaths " + PlayerManager.GetDeaths());
            GUI.Label(new Rect((Screen.width / 2), (Screen.height / 4), 1000, 100), "Credits:");
            GUI.Label(new Rect((Screen.width / 2) , (Screen.height / 4)+50, 1000, 100), "Development/Programming: Sinn Development");
            GUI.Label(new Rect((Screen.width / 2) , (Screen.height / 4) +100, 1000, 100), "Art pack thanks to Kenny");
            GUI.Label(new Rect((Screen.width / 2), (Screen.height / 4) +150, 1000, 100), "Graphics/Design: Katlin Walsh");
            GUI.Label(new Rect((Screen.width / 2), (Screen.height / 4) + 200, 1000, 100), "Audio by Approaching Nirvana\n http://youtube.com/approachingnirvana \nSong: Lights Are Out ft. Brendon Mattheus\n Buy it here! http://bit.ly/1cI15zQ");
            if (GUI.Button(new Rect(0, (Screen.height / 4) +350, Screen.width, 100), "Exit"))
            {
                Application.Quit();
            }
        }
        else
        {
            if (GUI.Button(PlayGame, "Play"))
            {
                LevelManager.LoadLevel();
            }
            if (GUI.Button(Credits, "Credits"))
            {
                Application.LoadLevel(2);
            }
        }
    }
    public void DrawKeys(int totalcount)
    {
        if(totalcount.Equals(0))
        {
            GUI.DrawTexture(Key1, Key1Empty);
            GUI.DrawTexture(Key2, Key2Empty);
            GUI.DrawTexture(Key3, Key3Empty);
            GUI.DrawTexture(Key4, Key4Empty);
        }
        else if(totalcount.Equals(1))
        {
            GUI.DrawTexture(Key1, Key1F);
            GUI.DrawTexture(Key2, Key2Empty);
            GUI.DrawTexture(Key3, Key3Empty);
            GUI.DrawTexture(Key4, Key4Empty);
        }
        else if(totalcount.Equals(2))
        {
            GUI.DrawTexture(Key1, Key1F);
            GUI.DrawTexture(Key2, Key2F);
            GUI.DrawTexture(Key3, Key3Empty);
            GUI.DrawTexture(Key4, Key4Empty);
        }
        else if (totalcount.Equals(3))
        {
            GUI.DrawTexture(Key1, Key1F);
            GUI.DrawTexture(Key2, Key2F);
            GUI.DrawTexture(Key3, Key3F);
            GUI.DrawTexture(Key4, Key4Empty);
        }
        else if (totalcount >= 4)
        {
            GUI.DrawTexture(Key1, Key1F);
            GUI.DrawTexture(Key2, Key2F);
            GUI.DrawTexture(Key3, Key3F);
            GUI.DrawTexture(Key4, Key4F);
        }
    }
    public static void AddKey()
    {
        keys++;
    }
}
