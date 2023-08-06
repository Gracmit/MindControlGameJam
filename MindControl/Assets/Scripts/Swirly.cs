using UnityEngine;
using UnityEngine.UI;

public class Swirly : MonoBehaviour
{
    [SerializeField] private RectTransform _swirlyTransform;
    [SerializeField] private Image _swirly;

    private float _timer;
    private float _time = 3;
    private void Update()
    {
        _swirlyTransform.Rotate(0, 0, 1);

        if (_timer < Time.time)
        {
            _swirly.color = new Color(_swirly.color.r, _swirly.color.g, _swirly.color.b, 0);
        }
    }

    public void ShowSwirly()
    {
        _timer = Time.time + _time;
        _swirly.color = new Color(_swirly.color.r, _swirly.color.g, _swirly.color.b, 0.5f);
    }
}
