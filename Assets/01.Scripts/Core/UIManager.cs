using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Update()
    {
        SetBGMSetting();
        SetSfxSetting();
    }

    private void SetBGMSetting()
    {
        SoundManager.Instance._audioSources[(int)SoundEnum.BGM].volume = bgmSlider.value * masterSlider.value;
    }
    
    private void SetSfxSetting()
    {
        SoundManager.Instance._audioSources[(int)SoundEnum.EFFECT].volume = sfxSlider.value * masterSlider.value;
    }
}
