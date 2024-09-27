using UnityEngine;

// Singleton created to play multiple audio sources
public class AudioSingleton : MonoBehaviour
{
    public static AudioSingleton Instance { get; private set; }

    [SerializeField]
    AudioSource ThemeAudio;
    [SerializeField]
    AudioSource ButtonAudio;
    [SerializeField]
    AudioSource CountdownAudio;
    [SerializeField]
    AudioSource FailureAudio;
    [SerializeField]
    AudioSource SuccessAudio;
    [SerializeField]
    AudioSource SlideAudio;
    [SerializeField]
    AudioSource JumpAudio;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Method to trigger the Theme Audio to start playing
    public void TriggerThemeAudio() => TriggerAudio(ThemeAudio);
    //Method to trigger the Button Audio to play when a Button is pressed, except the Gameplay Buttons
    public void TriggerButtonAudio() => TriggerAudio(ButtonAudio);
    //Method to trigger the Countdown Audio to play before the player starts moving
    public void TriggerCountdownAudio() => TriggerAudio(CountdownAudio);
    //Method to trigger the Failure Audio to play in the Results View
    public void TriggerFailureAudio() => TriggerAudio(FailureAudio);
    //Method to trigger the Success Audio to play in the Results View
    public void TriggerSuccessAudio() => TriggerAudio(SuccessAudio);
    //Method to trigger the Slide Audio to play during Gameplay
    public void TriggerSlideAudio() => TriggerAudio(SlideAudio);
    //Method to trigger the Jump Audio to play during Gameplay
    public void TriggerJumpAudio() => TriggerAudio(JumpAudio);

    //Method that calls the AudioSource to play
    private void TriggerAudio(AudioSource audioToPlay)
    {
        audioToPlay.Play();
    }
}
