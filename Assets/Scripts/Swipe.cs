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
        if (Input.touchCount <= 0) return;

        Touch touch = Input.GetTouch(0);

        if(touch.phase != TouchPhase.Ended)
        {
            return;
        }

        Vector2 deltaPos = touch.deltaPosition;

        if (deltaPos.x > 0)
        {
            // Swipe from right to left
            UpdateCurrentNumber(1);
        }
        else if (deltaPos.x < 0)
        {
            // Swipe from left to right
            UpdateCurrentNumber(-1);
        }

    }

    private void UpdateCurrentNumber(int amountToAdd)
    {
        int newCurrentNumber = (currentNumber + amountToAdd) % (maxValue + 1);
        
        currentNumber = newCurrentNumber < 0 ? (maxValue + 1 + newCurrentNumber) : newCurrentNumber;

        numberText.text = currentNumber.ToString();
    }
}
