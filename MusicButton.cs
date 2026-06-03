using UnityEngine;

public class MusicButton : MonoBehaviour
{
    [SerializeField] private GameObject iconOn;
    [SerializeField] private GameObject iconOff;

    private bool isOn;

    private void Start()
    {
        isOn = true;

        iconOn.SetActive(isOn);
        iconOff.SetActive(!isOn);
    }

    public void ToggleMusic()
    {
        isOn = !isOn;

        iconOn.SetActive(isOn);
        iconOff.SetActive(!isOn);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ToggleMusic();
        }
    }
}