using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider volumeSlider; // Ссылка на слайдер для управления громкостью

    private const string VolumePrefKey = "Volume"; // Ключ для сохранения уровня громкости в PlayerPrefs

    private void Start()
    {
        // Загрузка сохраненного уровня громкости при запуске сцены
        LoadVolumeSettings();

        // Добавление слушателя для изменения значения слайдера
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
        // Установка уровня громкости звука
        AudioListener.volume = volume;

        // Сохранение уровня громкости в PlayerPrefs
        PlayerPrefs.SetFloat(VolumePrefKey, volume);
        PlayerPrefs.Save();
    }

    private void LoadVolumeSettings()
    {
        // Загрузка сохраненного уровня громкости из PlayerPrefs
        float volume = PlayerPrefs.HasKey(VolumePrefKey) ? PlayerPrefs.GetFloat(VolumePrefKey) : 1f;
        volumeSlider.value = volume;
        AudioListener.volume = volume;
    }
}
