using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//By RetrKill0
public class MusicPlayer : MonoBehaviour
{
    [Header("UI Elements")]
    public Button playPauseButton, nextTrackButton, previousTrackButton, stopButton;
    public Sprite playImage, pauseImage;
    public Slider volumeSlider;
    public TextMeshProUGUI currentTrackText;

    [Header("Settings")]
    public List<AudioClip> musicTracks;
    public List<string> trackNames; 

    [SerializeField] public AudioSource audioSource;
    private int currentTrack = 0;
    private bool isPaused = false;
    private bool isStopped = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        InitializeUI();
        //UpdateTrackText();

        //add isso
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void InitializeUI()
    {
        playPauseButton.onClick.AddListener(TogglePlayPause);
        nextTrackButton.onClick.AddListener(NextTrack);
        previousTrackButton.onClick.AddListener(PreviousTrack);
        stopButton.onClick.AddListener(StopMusic);
        volumeSlider.onValueChanged.AddListener(AdjustVolume);

        volumeSlider.value = audioSource.volume;
    }

    void Update()
    {
        if (!audioSource.isPlaying && !isPaused && !isStopped)
        {
            NextTrack();
        }
    }

    public void TogglePlayPause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            audioSource.Pause();
            playPauseButton.image.sprite = playImage;
        }
        else
        {
            isStopped = false;
            if (audioSource.clip == null)
            {
                PlayMusic();
            }
            else
            {
                audioSource.UnPause();
            }
            playPauseButton.image.sprite = pauseImage;
        }
    }

    public void PlayMusic()
    {
        if (musicTracks.Count > 0)
        {
            audioSource.clip = musicTracks[currentTrack];
            audioSource.Play();
            playPauseButton.image.sprite = pauseImage;
            UpdateTrackText();
        }
    }

    public void StopMusic()
    {
        audioSource.Stop();
        audioSource.clip = null;
        playPauseButton.image.sprite = playImage;
        currentTrackText.text = "Nenhuma faixa tocando";
        isStopped = true;
    }

    public void NextTrack()
    {
        if (musicTracks.Count <= 0) return;

        currentTrack = (currentTrack + 1) % musicTracks.Count;
        PlayMusic();
    }

    public void PreviousTrack()
    {
        if (musicTracks.Count <= 0) return;

        currentTrack = (currentTrack - 1 + musicTracks.Count) % musicTracks.Count;
        PlayMusic();
    }

    public void AdjustVolume(float value)
    {
        audioSource.volume = value;
    }

    private void UpdateTrackText()
    {
        if (currentTrackText != null && trackNames.Count > currentTrack)
        {
            currentTrackText.text = "Tocando: " + trackNames[currentTrack];
        }
    }

    //add isso
    void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopMusic();
    }
}
