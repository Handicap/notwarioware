using UnityEngine;
using System.Collections;

public class Game_logic_controller : MonoBehaviour {

    public float totalscore;
    public float timescale = 1.0f;

    // build settingseistä saa tasojen indeksit selville
    // tasotaulukon logiikka:
    // indeksi: tason indeksi
    // bool: onko taso pelattu jo
    public bool[] tasot;

    public int score_level;
    public int lifes = 3;

    void Awake()
    {
        //Time.fixedDeltaTime ehkä pitää implementoida jos fysiikat sekoilee
        Time.timeScale = timescale;
    }
}
