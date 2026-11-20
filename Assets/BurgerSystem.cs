using UnityEngine;

public class BurgerSystem : MonoBehaviour
{
    [SerializeField] private string _ing1 = "Огурцы";
    [SerializeField ]private string _ing2 = "Салат";
    [SerializeField] private string _ing3 = "Лук";
    private string _answer;

    private void Start()
    {
        Input(_ing1, _ing2, _ing3, out _answer);

        Debug.Log(_answer);
        
    }
    void Input(string ing1, string ing2, string ing3, out string answer)
    {
      string[] cheaseburgerRecipe = new string[3] { "Огурцы", "Салат", "Лук"};
        string[] bigMak = new string[3] { "специальный соус", "булочка с кунжутом", "две котлеты" };

        answer = "блюдо не найдено";

        foreach (string ing in cheaseburgerRecipe)
        {
            if (cheaseburgerRecipe[0] == _ing1 && cheaseburgerRecipe[1] == _ing2 && cheaseburgerRecipe[2] == _ing3)
            {
                answer = "чизбургер";
            }

            
        }

        foreach (string ingBigMak in bigMak)
        {
            if (bigMak[0] == _ing1 && bigMak[1] == _ing2 && bigMak[2] == _ing3)
            {
                answer = "бигмак";
            }
        }





    }
}
