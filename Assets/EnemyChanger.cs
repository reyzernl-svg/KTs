using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyChanger : MonoBehaviour
{
    [Header("UI Controls")]
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button filterHealthButton;
    [SerializeField] private Button filterLevelButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button promoteBossButton;

    private Enemy[] _enemies;

    private void Start()
    {
        _enemies = FindObjectsByType<Enemy>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        filterHealthButton.onClick.AddListener(FilterByHealth);
        filterLevelButton.onClick.AddListener(FilterByLevel);
        resetButton.onClick.AddListener(ResetAll);
        promoteBossButton.onClick.AddListener(PromoteToBoss);
    }

    public void FilterByHealth()
    {
        if (int.TryParse(inputField.text, out int minHealth))
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                bool isVisible = _enemies[i].Health > minHealth;
                _enemies[i].gameObject.SetActive(isVisible);
            }
        }
    }

    public void FilterByLevel()
    {
        if (int.TryParse(inputField.text, out int targetLevel))
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                bool isVisible = _enemies[i].Level == targetLevel;
                _enemies[i].gameObject.SetActive(isVisible);
            }
        }
    }

    public void ResetAll()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].ResetStats();
        }
    }

    public void PromoteToBoss()
    {
        string targetName = inputField.text.Trim();
        if (string.IsNullOrEmpty(targetName)) return;

        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i].UnitName.Equals(targetName, System.StringComparison.OrdinalIgnoreCase))
            {
                _enemies[i].SetStats("Boss", _enemies[i].Health * 3, _enemies[i].Level + 1);
            }
        }
    }
}
