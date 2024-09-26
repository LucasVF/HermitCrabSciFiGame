using UnityEngine;

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

    public void TriggerThemeAudio() => TriggerAudio(ThemeAudio);
    public void TriggerButtonAudio() => TriggerAudio(ButtonAudio);
    public void TriggerCountdownAudio() => TriggerAudio(CountdownAudio);
    public void TriggerFailureAudio() => TriggerAudio(FailureAudio);
    public void TriggerSuccessAudio() => TriggerAudio(SuccessAudio);
    public void TriggerSlideAudio() => TriggerAudio(SlideAudio);
    public void TriggerJumpAudio() => TriggerAudio(JumpAudio);

    private void TriggerAudio(AudioSource audioToPlay)
    {
        audioToPlay.Play();
    }
}
