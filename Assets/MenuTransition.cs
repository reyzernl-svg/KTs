using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuTransition : MonoBehaviour
{
    [SerializeField] private Image _fadePanel;

    public void StartGame()
    {
        StartCoroutine(FadeOutAndLoad());
    }

    private IEnumerator FadeOutAndLoad()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            _fadePanel.color = new Color(0, 0, 0, i);
            yield return null;
        }

        _fadePanel.color = new Color(0, 0, 0, 1);
        SceneManager.LoadScene("GameScene");
    }
}
