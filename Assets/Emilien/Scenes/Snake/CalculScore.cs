using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class CalculScore : MonoBehaviour
{

    public Snake snake;
    public KingSnake kingSnake;
    public TextMeshProUGUI text_score;
    public string levelToLoad;
    public int nbToReach=2;

    private int scoreDifference;

    private void Update()
    {
        scoreDifference = snake.score - kingSnake.scoreAnnulation;
        text_score.text = "Score : " + scoreDifference + "/" + nbToReach;
        if(scoreDifference==nbToReach){
            ChangerDeSceneFin();
        }
    }

    private void ChangerDeSceneFin(){
        SceneManager.LoadScene(6);
    }



}
