using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    //单例
    public static GameManager Instance;

    //Score
    public int score = 0;

    //History Score
    public static int highscore = 0;

    //Player
    protected Player player;

    public int left =0;
    public int top=0;
    public int width=0;
    public int height=0;

    void Awake() {
        Instance = this;
    }

    // Use this for initialization
    void Start() {
        player = Util.GetPlayer().GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() {
        if (Time.timeScale > 0 && Input.GetKeyDown(KeyCode.Return)) {
            Time.timeScale = 0;
        }
    }

    void OnGUI() {
        if (Time.timeScale == 0) {
            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.4f, 100, 30), "continue")) {
                //exit
                Time.timeScale = 1;
            }
        }

//         if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.6f, 100, 30), "exit")) {
//             Application.Quit();
//         }

        int hp = 0;
        if (player != null) {
            hp = player.hp;
        }
        else {
            GUI.skin.label.fontSize = 50;

            GUI.skin.label.alignment = TextAnchor.LowerCenter;
            GUI.Label(new Rect(0, Screen.height * 0.2f, Screen.width, 60), "Game Over");
            GUI.skin.label.fontSize = 20;

            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.5f, 100, 30), "Again")) {
                Application.LoadLevel(Application.loadedLevelName);
            }
        }

        GUI.skin.label.fontSize = 15;
        GUI.Label(new Rect(5,5,100,30),"HP:"+hp);
        GUI.skin.label.alignment = TextAnchor.LowerCenter;
        GUI.Label(new Rect(0, 25, Screen.width, 30), "Score:" + score);
        GUI.Label(new Rect(0,5,Screen.width,30),"High Score:"+highscore);
    }

    public void AddScore(int point) {
        score += point;

        if (highscore < score) {
            highscore = score;
        }
    }
}
