using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject optionPanel;
    private bool IsOpenOption;

    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public Image fadeImage;
    public bool IsFadeEnd;

    private void Start()
    {
        Init();
        SceneManager.sceneLoaded += Init;

    }

    private void Init(Scene scene, LoadSceneMode loadSceneMode)
    {
        IsOpenOption = true;
        OnOption();

        fadeImage.gameObject.SetActive(true);
        fadeImage.color = Color.black;
        FadeOut();
    }

    private void Init()
    {
        IsOpenOption = true;
        OnOption();

        fadeImage.gameObject.SetActive(true);
        fadeImage.color = Color.black;
        FadeOut();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnOption();
        }

        SetBGMSetting();
        SetSfxSetting();
    }

    public void OnOption()
    {
        IsOpenOption = !IsOpenOption;

        if (!optionPanel)
        {
            optionPanel = transform.GetChild(0).GetChild(0).gameObject;
        }
        optionPanel.SetActive(IsOpenOption);
    }

    private void SetBGMSetting()
    {
        SoundManager.Instance._audioSources[(int)SoundEnum.BGM].volume = bgmSlider.value * masterSlider.value;
    }
    
    private void SetSfxSetting()
    {
        SoundManager.Instance._audioSources[(int)SoundEnum.EFFECT].volume = sfxSlider.value * masterSlider.value;
    }

    private Coroutine fadeCoroutine;
    public void FadeOut()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = null;

        IsFadeEnd = false;
        fadeCoroutine = StartCoroutine(FadeOutCoroutine());
    }
    
    public void FadeIn()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = null;

        IsFadeEnd = false;
        fadeCoroutine = StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        while (fadeImage.color.a > 0)
        {
            Color color = fadeImage.color;
            color.a -= Time.deltaTime;
            fadeImage.color = color;
            yield return null;
        }
    }

    private IEnumerator FadeInCoroutine()
    {
        while (fadeImage.color.a < 1)
        {
            Color color = fadeImage.color;
            color.a += Time.deltaTime;
            fadeImage.color = color;
            yield return null;
        }
        IsFadeEnd = true;
    }
}
