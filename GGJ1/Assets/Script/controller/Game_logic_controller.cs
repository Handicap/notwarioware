﻿using UnityEngine;
using System.Collections;

public class Game_logic_controller : MonoBehaviour {

    public float totalscore;
    public float timescale = 1.0f;

    // build settingseistä saa tasojen indeksit selville
    // tasotaulukon logiikka:
    // oliossa on levelin nimi, ja bool siitä onko pelattu jo
    public string[] tasot;
    public bool[] pelatut;
    public int nykyinenrandomi;
    public int pelattuja;

    public int score_level;
    public int lives = 3;

    public int fade = 0;
        [Range(-1,1)]
    public int next_still_random = 0;
        public string nextlevel;
        [Range(0f, 1f)]
        public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
        private bool sceneStarting = true; 

    void Awake()
    {
        //Time.fixedDeltaTime ehkä pitää implementoida jos fysiikat sekoilee
        Time.timeScale = timescale;
        fade = -1;
        // Set the texture so that it is the the size of the screen and covers it.
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
        
    }

    public void uusikentta(string seuraavataso)
    {
        fade = 1;
        nextlevel = seuraavataso;
        next_still_random = -1;
    }

    public void randomkentta()
    {
        fade = 1;
        next_still_random = 1;
    }

    void Update()
    {
        if (fade == -1) guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
        if (fade == 1) guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);

        if (guiTexture.color.a <= 0.05f && fade == -1)
        {
            // ... set the colour to clear and disable the GUITexture.
            fade = 0;
        }
        if (guiTexture.color.a >= 0.5f && fade == 1)
        {
            // ... reload the level.
            guiTexture.color = new Color(guiTexture.color.r, guiTexture.color.g, guiTexture.color.b, 1);
            fade = -1;
            if (next_still_random == -1) Application.LoadLevel(nextlevel);
            else
            {
                int randomitaso = Random.Range(0, tasot.Length);
                if (pelattuja == tasot.Length)
                {
                    tyhjennapelikerrat();
                    timescale = timescale * 1.5f;
                    Time.timeScale = timescale;
                }
                while (pelatut[randomitaso] == true)
                {
                    randomitaso = Random.Range(0, tasot.Length);
                }
                pelatut[randomitaso] = true;
                pelattuja++;
                Application.LoadLevel(tasot[randomitaso]);
            }
        }
    }

    //pistetään lista tyhjäksi
    public void tyhjennapelikerrat()
    {
        pelattuja = 0;
        for (int i = 0; i < tasot.Length; i++)
        {
            pelatut[i] = false;
        }
    }
}
