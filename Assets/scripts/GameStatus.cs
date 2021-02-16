using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
   [Range(0.1f,10f)] [SerializeField] float GameSpeed =1f;
    [SerializeField] int PointsPerBlockDestroyed = 10;

    [SerializeField] TextMeshProUGUI scoretext;

    [SerializeField] int CurrentScore;
    // Start is called before the first frame update

    private void Awake()
    {
        int gamestatuscount = FindObjectsOfType<GameStatus>().Length;
        if(gamestatuscount > 1 )
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        scoretext.text = CurrentScore.ToString();
        
    }
    public void AddToScore()
    {
        CurrentScore += PointsPerBlockDestroyed;
        scoretext.text = CurrentScore.ToString();

    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = GameSpeed;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
