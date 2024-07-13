using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManhwaManager : MonoBehaviour
{
    public List<Image> images = new List<Image>();
    public int index = 0;

    private void Start()
    {
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (index >= images.Count)
            {
                MCSceneManager.Instance.ChangeScene();
                return;
            }

            images[index].gameObject.SetActive(true);

            index++;
            
        }
    }
}
