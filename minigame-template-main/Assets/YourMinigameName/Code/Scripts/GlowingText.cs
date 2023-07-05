using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlowingText : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private Coroutine glowCoroutine;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        glowCoroutine = StartCoroutine(GlowText());
    }

    private IEnumerator GlowText()
    {
        Color originalColor = textMeshPro.color;
        float time = 0f;
        while (true)
        {
            time += Time.deltaTime;
            float t = Mathf.PingPong(time, 1f); // Calculate the lerp parameter

            // Modify both color and alpha components
            float glowIntensity = Mathf.Lerp(0.5f, 1f, t);
            Color glowColor = originalColor * glowIntensity;
            glowColor.a = originalColor.a;

            textMeshPro.color = glowColor;

            // Check if the text content is not "Press any key" and stop the coroutine
            if (textMeshPro.text != "Press any key")
            {
                StopCoroutine(glowCoroutine);
                break;
            }

            yield return null;
        }
    }
}
