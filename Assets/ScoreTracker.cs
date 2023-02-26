using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    // Start is called before the first frame update
    float score = 50000;
    public PoolType playerDeets;
    TMP_Text text; 

    TMP_Text gainedScore;
    public float fadeTime;

    
    void Awake()
    {
        text = GetComponent<TMP_Text>();
        gainedScore = transform.GetChild(0).GetComponent<TMP_Text>();
        gainedScore.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        score -= Time.deltaTime * (playerDeets.poolCountLimit - playerDeets.activeCount + 1);
        text.text = "Score: " + score.ToString();
    }

    public void AddScore(float newScore){
        score += newScore;
        Debug.Log(gainedScore);
        gainedScore.text = "+ " + newScore.ToString() + "(Hit the middle of one screen)";
        //gainedScore.color = Color.white;
        //StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut(){
        yield return new WaitForSeconds(fadeTime);
        gainedScore.color = Color.clear;
        yield return new WaitForSeconds(0);
    }

    
}
