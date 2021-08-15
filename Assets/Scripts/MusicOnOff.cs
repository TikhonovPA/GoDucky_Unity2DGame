using UnityEngine;
using UnityEngine.UI;

public class MusicOnOff : MonoBehaviour
{
    [SerializeField] private AudioListener _audio;
    [SerializeField] private Sprite musicOn, musicOff;
    private Image button;

    private void Awake()
    {
        button = GetComponent<Image>();
        if (PlayerPrefs.GetString("music") == "off")
        {
            button.sprite = musicOff;
            _audio.enabled = false;
        }
    }

    public void SetMusic()
    {
        _audio.enabled = !_audio.enabled;

        if (_audio.enabled)
        {
            button.sprite = musicOn;
            PlayerPrefs.SetString("music", "on");
        }
        else
        {
            button.sprite = musicOff;
            PlayerPrefs.SetString("music", "off");
        }

    }
}
