using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{ 

    public float CanvasCoolDownTime;
    public bool OutOfRangeTimerComplete;
    private bool inRange = false;
    private bool _startTimer = false;
    public bool collidingWithPlayer = false;
    public Canvas Canvas;
    private float _timer;


    // Start is called before the first frame update
    void Start()
    {
        Canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_startTimer)
        {
            _timer += Time.deltaTime;
        }

        if (_timer > CanvasCoolDownTime)
        {
            OutOfRangeTimerComplete = true;
        }
        if (Canvas != null && OutOfRangeTimerComplete)
        {
            Canvas.enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag.Equals("Player"))
        {
            collidingWithPlayer = true;
            Canvas.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag.Equals("Player"))
        {
            collidingWithPlayer = false;
            Canvas.enabled = false;
        }
    }
    public void TogglePlayerInRange()
    {
        if (collidingWithPlayer)
        {
            inRange = !inRange;
            if (inRange)
            {
                _timer = 0f;
                OutOfRangeTimerComplete = false;
                _startTimer = false;
            }
            else
            {
                collidingWithPlayer = false;
                _startTimer = true;
            }
        }
    }

}
