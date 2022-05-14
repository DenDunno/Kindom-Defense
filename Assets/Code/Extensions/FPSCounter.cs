using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _fpsText;
    private float _clock;
    private int _frames;
    
    private void Update()
    {
        ++_frames;
        
        if (Time.time > _clock + 1)
        {
            _fpsText.text = "FPS = " + _frames;
            _clock = Time.time;
            _frames = 0;
        }
    }
}
