using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class chasi : MonoBehaviour
{
    [SerializeField] private Image _clock;
    private float _timer;
    [SerializeField] private TextMeshProUGUI _secondsText;
    [SerializeField] private TextMeshProUGUI _sphereText;
    private bool _isStarted = false;
    private int _sphereCount = 0;
    [SerializeField] private float _maxTime = 10f;
    void Start()
    {
        _timer = _maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStarted == true)
        {
            _timer -= Time.deltaTime;
            _secondsText.text = "Время " + _timer.ToString("F0");
            _clock.fillAmount = _timer / _maxTime;
            if (_timer <= 0)
            {
                Restart();
            }
        }


    }

    public void OnButtonClick()
    {
        _isStarted = true;
    }



    public void Restart()
    {
        _clock.fillAmount = 1f;
        _timer = _maxTime;
        _sphereCount++;
        _sphereText.text = "Счет: " + _sphereCount.ToString();
        _isStarted = false;
    }
}
