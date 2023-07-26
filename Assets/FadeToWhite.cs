using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeToWhite : MonoBehaviour
{
    public GameObject collisionText;

    public void Fade()
    {

        StartCoroutine(FadeCoroutine());

    }

    IEnumerator FadeCoroutine()
    {
        //collisionText.SetActive(true);
        int fadeSpeed = 3;
        float fadeAmount;
        while(GetComponent<Image>().color.a < 1)
        {

            fadeAmount = GetComponent<Image>().color.a + (fadeSpeed * Time.deltaTime);
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, fadeAmount);
            yield return null;
            
        }

    }

    public void ResetFade()
    {
        //collisionText.SetActive(false);
        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);

    }

}
