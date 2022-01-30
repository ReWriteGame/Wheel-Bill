using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameRules : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private Text inputField;


    public UnityEvent startGameEvent;
    public UnityEvent stopGameEvent;
    public UnityEvent betPlayedEvent;
    public UnityEvent betNotPlayedEvent;

    public void StartGame()
    {
        CompareResults();
        startGameEvent?.Invoke();
    }




    public void StopGame()
    {
        stopGameEvent?.Invoke();
    }

    private void CompareResults()
    {
        
        float inputValue = string.IsNullOrEmpty(inputField.text) ? 0 : float.Parse(inputField.text);
        inputValue = Mathf.Abs(inputValue);

        float yourBid = inputValue > scoreCounter.Score ? scoreCounter.Score : inputValue;
        

        if (Random.Range(0,2) == 1)
        {
            scoreCounter.add(yourBid);
            betPlayedEvent?.Invoke();
        }
        else
        {
            scoreCounter.takeAway(yourBid * 2);
            betNotPlayedEvent?.Invoke();
        }

        
    }
    

}
