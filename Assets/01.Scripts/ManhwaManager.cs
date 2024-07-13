using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManhwaManager : MonoBehaviour
{
    public List<Image> images = new List<Image>();
    public int index = 0;

    Image fadeImage;

    private void Start()
    {
        foreach (Image image in images)
        {
            Color color = image.color;
            color.a = 0;

            image.color = color;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (index >= images.Count)
            {
                UIManager.Instance.FadeIn();
                MCSceneManager.Instance.ChangeScene();
                return;
            }

            FadeIn(images[index]);

            index++;
            
        }
    }

    private Coroutine fadeCoroutine;

    public void FadeIn(Image img)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
            
            Color color = fadeImage.color;
            color.a = 1;

            fadeImage.color = color;
        }
        fadeCoroutine = null;

        fadeCoroutine = StartCoroutine(FadeInCoroutine(img));
    }

    private IEnumerator FadeInCoroutine(Image img)
    {
        while (img.color.a < 1)
        {
            fadeImage = img;

            Color color = img.color;
            color.a += Time.deltaTime;
            img.color = color;
            yield return null;
        }
    }
}
