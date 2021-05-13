using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Clock : MonoBehaviour
{
    [SerializeField] private float _timeRemaining;
    [SerializeField] private bool _isRunning;
    [SerializeField] private Text _text;
    [SerializeField] private VideoPlayer _videoPlayer;

    public static float GetTimeInSeconds(int hours, int minutes, float seconds) => (hours * 60 * 60) + (minutes * 60) + seconds;

    private void Start(){
        _isRunning = true;
        _timeRemaining = (float) _videoPlayer.length;
    } 

    private void Update()
    {
        if (_isRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                DisplayTime(_timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                _timeRemaining = 0;
                _isRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}