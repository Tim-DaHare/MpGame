using UnityEngine;
using UnityEngine.UI;

public class MainMenuMusicUI : MonoBehaviour {

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private Image musicPausedLine;
    [SerializeField]
    private Slider musicVolumeSlider;

    bool musicPaused = false;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MainMenuMusicVolume"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("MainMenuMusicVolume");
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MainMenuMusicVolume");
        }
        if (PlayerPrefs.HasKey("MainMenuMusicPaused"))
        {
            if (PlayerPrefs.GetInt("MainMenuMusicPaused") == 1)
            {
                musicPaused = true;
                PauseMusic();
            }
        }
    }

    private void PauseMusic()
    {
        audioSource.Pause();
        musicPausedLine.enabled = true;
        PlayerPrefs.SetInt("MainMenuMusicPaused", 1);
    }

    private void UnPauseMusic()
    {
        audioSource.UnPause();
        musicPausedLine.enabled = false;
        PlayerPrefs.SetInt("MainMenuMusicPaused", 0);
    }

    public void SwitchMusicPauseState()
    {
        musicPaused = !musicPaused;
        
        if (musicPaused)
        {
            PauseMusic();
        } else
        {
            UnPauseMusic();
        }
    }

    public void AdjustMusicVolume()
    {
        audioSource.volume = musicVolumeSlider.value;
        PlayerPrefs.SetFloat("MainMenuMusicVolume", musicVolumeSlider.value);
    }
}
