using UnityEngine;
public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _gameMusic;
    [SerializeField] private AudioClip _gameOverMusic;
    [SerializeField] private AudioClip _victoryMusic;
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip PickupFragmentSound;
    [SerializeField] private AudioClip BonusSound;
    [SerializeField] private AudioClip MalusSound;
    [SerializeField] private AudioClip PoisonZoneSound;
    [SerializeField] private AudioClip MemoryZoneSound;
    [SerializeField] private AudioClip JumpSound;
    [SerializeField] private AudioClip PickupKeySound;
    

    private void Start()
    {
        if (musicSource != null && _menuMusic != null)
        {
            musicSource.clip = _menuMusic;
            musicSource.Play();
        }
    }

    public void PlayGameMusic()
    {
        musicSource.Stop();
        musicSource.clip=_gameMusic;
        musicSource.Play();
    }
    public void PlayHoverSound()
    {
        sfxSource.clip= hoverSound;
        sfxSource.Play();
    }

    public void PlayClickSound()
    {
        sfxSource.clip=clickSound;
        sfxSource.Play();
    }
    public void PlayGameOverMusic()
    {
        musicSource.Stop();
        musicSource.PlayOneShot(_gameOverMusic);
    }
    public void PlayVictoryMusic()
    {
        musicSource.Stop();
        musicSource.PlayOneShot(_victoryMusic);
    }
    public void PlayPickupFragmentSound()
    {
        sfxSource.clip= PickupFragmentSound;
        sfxSource.Play();
    }
    public void PlayBonusSound()
    {
        sfxSource.clip= BonusSound;
        sfxSource.Play();
    }
    public void PlayMalusSound()
    {
        sfxSource.clip= MalusSound;
        sfxSource.Play();
    }
    public void PlayMemoryZoneSound()
    {
        sfxSource.clip= MemoryZoneSound;
        sfxSource.Play();
    }
    public void PlayPoisonZoneSound()
    {
        sfxSource.clip= PoisonZoneSound;
        sfxSource.Play();
    }
    public void PlayJumpSound()
    {
        sfxSource.clip= JumpSound;
        sfxSource.Play();
    }
    public void PlayPickupKeySound()
    {
        sfxSource.clip= PickupKeySound;
        sfxSource.Play();
    }
}
