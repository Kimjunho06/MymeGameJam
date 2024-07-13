using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject optionPanel;
    public GameObject playerPanel;
    private bool IsOpenOption;

    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public Image fadeImage;
    public bool IsFadeEnd;

    public AudioClip menuSound;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI deathCountText;
    public Slider progressBar;

    public Image currentAlphabetImage;
    public Image captialLetterImage;
    public Image smallLetterImage;

    public Sprite transparentSprite;

    private void Start()
    {
        Init();
        SceneManager.sceneLoaded += Init;
        playerPanel.SetActive(false);
    }

    private void Init(Scene scene, LoadSceneMode loadSceneMode)
    {
        IsOpenOption = true;
        OnOption();
        if (!GameManager.Instance.IsGameStart)
        {
            GameManager.Instance.IsGameStart = true;
            playerPanel.SetActive(true);
        }

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
            SoundManager.Instance.Play(menuSound);
            OnOption();
        }

        SetBGMSetting();
        SetSfxSetting();

        timeText.SetText(GameManager.Instance.RecordPlayTime());
        deathCountText.SetText("Death Count : " + GameManager.Instance.deathCount.ToString());
        progressBar.value = GameManager.Instance.progress / 100;

        if (GameManager.Instance.IsGameStart)
        {
            if (GameManager.Instance.PlayerInstance.alphabet.IsPickUp)
            {
                Sprite captialSprite = GameManager.Instance.PlayerInstance.alphabet.pickUpAlphabet.AlphabetSO.capitalLetterSprite;
                Sprite smallSprite = GameManager.Instance.PlayerInstance.alphabet.pickUpAlphabet.AlphabetSO.smallLetterSprite;

                captialLetterImage.sprite = captialSprite;
                smallLetterImage.sprite = smallSprite;
                if (!GameManager.Instance.PlayerInstance.alphabet.pickUpAlphabet.AlphabetSO.isSamllLetter)
                {
                    currentAlphabetImage.sprite = captialSprite;

                    captialLetterImage.transform.localScale = Vector3.one * 1.2f;
                    captialLetterImage.color = Color.yellow;

                    smallLetterImage.transform.localScale = Vector3.one;
                    smallLetterImage.color = Color.gray;
                    smallLetterImage.material = null;
                }
                else
                {
                    currentAlphabetImage.sprite = smallSprite;

                    smallLetterImage.transform.localScale = Vector3.one * 1.2f;
                    smallLetterImage.color = Color.yellow;

                    captialLetterImage.transform.localScale = Vector3.one;
                    captialLetterImage.color = Color.gray;
                    captialLetterImage.material = null;
                }

            }
            else
            {
                currentAlphabetImage.sprite = transparentSprite;
                captialLetterImage.sprite = transparentSprite;
                smallLetterImage.sprite = transparentSprite;
            }
        }
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
