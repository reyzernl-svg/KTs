using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InternetShop : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _priceTexts;
    [SerializeField] private TMP_Text _cartText;

    private string[] _names = new string[] { "Яблоко", "Манго", "Апельсин", "Лук" };
    private int[] _prices = new int[] { 100, 200, 150, 110 };

    private List<int> _cartIndexes = new List<int>();

    private void Start()
    {
        UpdateShopTexts();
        _cartText.text = "Корзина:\n";
    }

    
    public void BuyItem(int index)
    {
        _cartIndexes.Add(index);
        int totalSum = CalculateCart();
        _cartText.text += "Итого: " + totalSum;
    }

    public void NextDay()
    {
        for (int i = 0; i < _prices.Length; i++)
        {
            DoublePrice(ref _prices[i]);
        }

        UpdateShopTexts();

        int totalSum = CalculateCart();
        _cartText.text += "Итого: " + totalSum;
    }

    private void DoublePrice(ref int price)
    {
        price = price * 2;
    }

    private int CalculateCart()
    {
        int sum = 0;
        _cartText.text = "Корзина:\n";

        for (int i = 0; i < _cartIndexes.Count; i++)
        {
            int itemIndex = _cartIndexes[i];
            int currentPrice = _prices[itemIndex];

            Debug.Log(currentPrice); 

            _cartText.text += _names[itemIndex] + " - " + currentPrice + "\n";
            sum = sum + currentPrice;
        }

        Debug.Log(sum);
        return sum;
    }

    private void UpdateShopTexts()
    {
        for (int i = 0; i < _priceTexts.Length; i++)
        {
            _priceTexts[i].text = _prices[i].ToString();
        }
    }
}
