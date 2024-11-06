using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Swipe : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberText;
    private int currentNumber;
    private int minValue = 0;
    private int maxValue = 10;

    private Vector3 startSwipePosition;
    private Vector3 endSwipePosition;

    private void Start()
    {
        currentNumber = 0;
        UpdateCurrentNumber(0);
    }

    private void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log("hola");
            
            if(touch.phase == TouchPhase.Began)
            {
                startSwipePosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endSwipePosition = touch.position;

                if (endSwipePosition.x < startSwipePosition.x)
                {
                    // Swipe from right to left
                    UpdateCurrentNumber(1);
                } 
                else if (endSwipePosition.x > startSwipePosition.x)
                {   
                    // Swipe from left to right
                    UpdateCurrentNumber(-1);
                }
            }
        }
    }

    private void UpdateCurrentNumber(int amountToAdd)
    {
        currentNumber += amountToAdd;
        if (currentNumber > maxValue)
        {
            currentNumber = 0;
        }
        else if (currentNumber < minValue)
        {
            currentNumber = maxValue;
        }


        numberText.text = currentNumber.ToString();
    }
}
