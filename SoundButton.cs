using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private GameObject iconOn;
    [SerializeField] private GameObject iconOff;

    private bool isOn;

    private void Start()
    {
        isOn = true;
        UpdateIcon();
    }

    public void ToggleSound()
    {
        isOn = !isOn;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ToggleSound();
        }

        UpdateIcon();
    }

    private void UpdateIcon()
    {
        iconOn.SetActive(isOn);
        iconOff.SetActive(!isOn);
    }
}