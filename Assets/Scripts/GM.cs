using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public Text txtCoins;
    public Text txtWave;
    public Text txtLP;
    public Text timeText;

    public AudioSource audioSource;
    public AudioClip soundClip;

    private int coins;
    private int lp;
    private InfiniteWaveSpawner iws;

    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        iws = FindObjectOfType<InfiniteWaveSpawner>();
        coins = 300;
        elapsedTime = 0f;
        lp = 3;

        audioSource.clip = soundClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        txtCoins.text = "Monedas: " + coins.ToString();
        txtWave.text = "Oleada " + iws.getCurrentWave().ToString();
        txtLP.text = "Vidas: " + lp;
        elapsedTime += Time.deltaTime;

        string minutes = Mathf.Floor(elapsedTime / 60).ToString("00");
        string seconds = (elapsedTime % 60).ToString("00");

        timeText.text = "Tiempo: " + minutes + ":" + seconds;
    }
    public int getCoins(){
        return coins;
    }
    public void AddCoins(int coins){
        this.coins += coins;
    }
    public void DecreaseCoins(int coins){
        this.coins -= coins;
    }
    public void DecreaseLP(){
        lp -= 1;
        if(lp <= 0){
            SceneManager.LoadScene("Init");
        }
    }
}
