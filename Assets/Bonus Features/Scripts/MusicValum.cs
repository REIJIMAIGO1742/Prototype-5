using UnityEngine;
using UnityEngine.UI;

public class MusicValum : MonoBehaviour
{

    public AudioSource audioSource;
    public Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = slider.value;
    }
}
