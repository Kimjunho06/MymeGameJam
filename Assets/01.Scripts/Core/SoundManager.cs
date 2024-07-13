using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum SoundEnum
{
    BGM,
    EFFECT,
    SOUNDCOUNT
}

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField]
    private AudioClip _bgm;

    [SerializeField]
    private AudioClip _sfx;

    public AudioClip uiClickSoundClip;

    public float soundFadeOnTime;

    public AudioSource[] _audioSources = new AudioSource[(int)SoundEnum.SOUNDCOUNT];

    protected override void Awake() // Awake
    {
        string[] soundNames = System.Enum.GetNames(typeof(SoundEnum));
        for (int i = 0; i < soundNames.Length - 1; i++)
        {
            GameObject go = new GameObject { name = soundNames[i] };
            _audioSources[i] = go.AddComponent<AudioSource>();
            _audioSources[i].playOnAwake = false;
            _audioSources[i].clip = (soundNames[i] == "BGM" ? _bgm : _sfx);
            go.transform.parent = transform;
        }

        _audioSources[(int)SoundEnum.BGM].loop = true;

    }

    public void Play(AudioClip audioClips, SoundEnum type = SoundEnum.EFFECT)
    {
        if (audioClips == null)
        {
            Debug.LogError("cannot find audioclips");
            return;
        }

        if (type == SoundEnum.BGM)
        {
            StopAllCoroutines();
            AudioSource audioSource = _audioSources[(int)SoundEnum.BGM];

            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.volume = 0;
            audioSource.clip = audioClips;
            audioSource.Play();

            StartCoroutine(SoundFade(true, _audioSources[(int)SoundEnum.BGM], soundFadeOnTime, 1, SoundEnum.BGM));
            StartCoroutine(SoundFade(false, _audioSources[(int)SoundEnum.BGM], soundFadeOnTime, 0, SoundEnum.BGM));
        }
        else
        {
            AudioSource audioSource = _audioSources[(int)SoundEnum.EFFECT];
            audioSource.PlayOneShot(audioClips); // ����� ��ø ���� �� �Լ�
        }
    }

    public void Stop()
    {
        foreach (var audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
    }

    public void ClickSound()
    {
        Play(uiClickSoundClip, SoundEnum.EFFECT);
    }

    IEnumerator SoundFade(bool fadeIn, AudioSource source, float duration, float endVolume, SoundEnum type)
    {
        if (!fadeIn)
        {
            //double lengthofSource = (double)source.clip.samples / source.clip.frequency; // ��ü ��� ���� 
            yield return new WaitForSeconds((float)(source.clip.length - duration));
        }

        float time = 0f;
        float startVolume = source.volume;

        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, endVolume, time / duration);
            yield return null;
        }

        if (!fadeIn)
            Play(source.clip, type);
    }
}