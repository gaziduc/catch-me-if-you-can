using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().value = AudioListener.volume;
    }
}
