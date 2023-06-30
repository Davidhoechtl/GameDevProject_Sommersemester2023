using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Assets.YourMinigameName.Code.Scripts.DifficultySystem;
using System.Linq;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Image timerImage;
    public Image timerImageOutline;
    public TextMeshProUGUI timerText;
    public AudioClip tenSecSound;
    private AudioSource timerAudio;

    public int timeDelay = 3;
    public bool timerIsActive = false;

    public float timeDuration = 60f;
    float remainingTime;
    float passedTime;
    List<IHasDifficulty> difficultyContainer;
    void Start()
    {
        remainingTime = timeDuration;
        difficultyContainer = FindAllDifficultyContainer();
        timerAudio = GetComponent<AudioSource>();
        passedTime = timeDuration;
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsActive)
        {
            timerImage.fillAmount = remainingTime / timeDuration;
            UpdateTimer();
            RecalculateDifficulty();
            if (timerImage.fillAmount <= 0.3) // turns red when time is less than 30 percent
            {
                timerImage.CrossFadeColor(Color.red, 1f, true, true);
            }
        }
    }

    private IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(timeDelay);
        timerIsActive = true;
    }

    private void UpdateText(float remainingTime) // text that gets displayed
    {
        if (remainingTime == 10)
        {
            timerAudio.PlayOneShot(tenSecSound, 1.0f);

        }
        if (remainingTime <= 0) // when out of time
        {
            timerText.text = "";
            timerImageOutline.fillAmount = 0f;

            // Round end 
            // So circa
            //MenuHandler.Instance.GameOverMenu();
            SceneManager.LoadScene("GameOver");

        }
        else
        {
            string timeText = remainingTime.ToString("0.00"); // shows first 3 digits
            timerText.text = timeText;
        }
    }
    private void UpdateTimer() // counts down time and updates text 
    {
        remainingTime -= Time.deltaTime;
        passedTime = timeDuration - remainingTime;
        UpdateText(remainingTime);
    }

    private void RecalculateDifficulty()
    {
        difficultyContainer.ForEach(dc =>
        {
            dc.RecalculateDifficulty(passedTime);
        });
    }

    private List<IHasDifficulty> FindAllDifficultyContainer()
    {
        Debug.Log("This function was called");
        return GameObject
            .FindGameObjectsWithTag("DifficultyContainer")
            .Select(c => {
                IHasDifficulty comp = c.GetComponent<IHasDifficulty>();
                if (comp != null)
                {
                    Debug.Log("Difficulty Container: " + comp);
                    return comp;
                }
                else
                {
                    throw new System.Exception($"The Gameobject {c.name} has the DifficultyContainer Tag but does not implement the IHasDifficulty-Interface.");
                }
            })
            .ToList();
    }
}
