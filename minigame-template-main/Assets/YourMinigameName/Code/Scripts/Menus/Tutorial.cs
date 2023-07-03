using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] images;
    int index = 0;
    void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
            images[0].gameObject.SetActive(true);
        }
    }
    public void NextImage()
    {
        index++;

        if (index > (images.Length - 1))
        {
            index = 0; // start at first image
        }

        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
            images[index].gameObject.SetActive(true);
        }
        Debug.Log("index: " + index);
    }

    public void PreviousImage()
    {
        index--;

        if (index < 0)
        {
            index = (images.Length - 1); // loop through images
        }

        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
            images[index].gameObject.SetActive(true);
        }
        Debug.Log("index: " + index);
    }
}
