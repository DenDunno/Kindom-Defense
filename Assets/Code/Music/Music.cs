using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioClip _menu;
    [SerializeField] private AudioClip _preBattle;
    [SerializeField] private AudioClip _battle;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMenu()
    {
        Play(_menu);
    }
    
    public void PlayPreBattle()
    {
        Play(_preBattle);
    }
    
    public void PlayBattle()
    {
        Play(_battle);
    }

    private void Play(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}