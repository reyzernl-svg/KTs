using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySystem : MonoBehaviour
{
    [SerializeField] private Image _fadePanel;
    [SerializeField] private Renderer _targetCube;

    [SerializeField] private Button _ability1Button;
    [SerializeField] private Button _ability2Button;
    [SerializeField] private Button _ability3Button;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            _fadePanel.color = new Color(0, 0, 0, i);
            yield return null;
        }
        _fadePanel.color = new Color(0, 0, 0, 0);
    }

    public void UseAbility1()
    {
        StartCoroutine(Ability1Routine());
    }

    public void UseAbility2()
    {
        StartCoroutine(Ability2Routine());
    }

    public void UseAbility3()
    {
        StartCoroutine(Ability3Routine());
    }

    private IEnumerator Ability1Routine()
    {
        _ability1Button.interactable = false;
        _targetCube.material.color = Color.red;

        yield return new WaitForSeconds(2f);

        _ability1Button.interactable = true;
    }

    private IEnumerator Ability2Routine()
    {
        _ability2Button.interactable = false;
        _targetCube.material.color = Color.green;

        yield return new WaitForSeconds(4f);

        _ability2Button.interactable = true;
    }

    private IEnumerator Ability3Routine()
    {
        _ability3Button.interactable = false;
        _targetCube.material.color = Color.blue;

        yield return new WaitForSeconds(6f);

        _ability3Button.interactable = true;
    }
}
