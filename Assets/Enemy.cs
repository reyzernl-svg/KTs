using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text levelText;

    [Header("Initial Stats")]
    [SerializeField] private string initialName = "Goblin";
    [SerializeField] private int initialHealth = 100;
    [SerializeField] private int initialLevel = 1;

    public string UnitName { get; private set; }
    public int Health { get; private set; }
    public int Level { get; private set; }

    private void Awake()
    {
        ResetStats();
    }

    public void SetStats(string newName, int newHealth, int newLevel)
    {
        UnitName = newName;
        Health = newHealth;
        Level = newLevel;
        UpdateUI();
    }

    public void ResetStats()
    {
        UnitName = initialName;
        Health = initialHealth;
        Level = initialLevel;
        gameObject.SetActive(true);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (nameText != null) nameText.text = UnitName;
        if (healthText != null) healthText.text = $"HP: {Health}";
        if (levelText != null) levelText.text = $"LVL: {Level}";
    }
}
