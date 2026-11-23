using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class BouncingBall : MonoBehaviour
{
    [SerializeField] private float speedThreshold = 2.0f;
    [SerializeField] private Color slowColor = Color.red;

    private Rigidbody _rb;
    private Renderer _renderer;
    private Color _defaultColor;
    private bool _isTrackingSlowState = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    private void FixedUpdate()
    {
        if (_rb.linearVelocity.magnitude < speedThreshold && !_isTrackingSlowState)
        {
            StartCoroutine(TrackLowSpeedRoutine());
        }
    }

    private IEnumerator TrackLowSpeedRoutine()
    {
        _isTrackingSlowState = true;
        _renderer.material.color = slowColor;

        float timeBelowThreshold = 0f;

        do
        {
            yield return new WaitForFixedUpdate();
            timeBelowThreshold += Time.fixedDeltaTime;
        }
        while (_rb.linearVelocity.magnitude < speedThreshold);

        _renderer.material.color = _defaultColor;
        Debug.Log($"Скорость мяча была ниже порога ({speedThreshold}) в течение: {timeBelowThreshold:F3} сек.");

        _isTrackingSlowState = false;
    }
}
