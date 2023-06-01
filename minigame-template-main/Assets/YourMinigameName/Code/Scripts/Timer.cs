using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Image timerImage;
    public Image timerImageOutline;
    public TextMeshProUGUI timerText;

    public float timeDuration = 60f;
    float passedTime;

    void Start()
    {
        passedTime = timeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        timerImage.fillAmount = passedTime / timeDuration; 
        UpdateTimer();
        
        if (timerImage.fillAmount <= 0.3) // turns red when time is less than 30 percent
        {
            timerImage.CrossFadeColor(Color.red, 1f, true, true);
        }
    }

    private void UpdateText(float remainingTime) // text that gets displayed
    {
        if (remainingTime <= 0) // when out of time
        {
            timerText.text = "";
            timerImageOutline.fillAmount = 0f;

            // Round end 
            // So circa
            //MenuHandler.Instance.GameOverMenu();

        }
        else
        {
            string timeText = remainingTime.ToString("0.00"); // shows first 3 digits
            timerText.text = timeText;
        }
    }
    private void UpdateTimer() // counts down time and updates text 
    {
        passedTime -= Time.deltaTime;
        UpdateText(passedTime);
    }

}
