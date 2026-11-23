using UnityEngine;

public class CubeSorter : MonoBehaviour
{
    [SerializeField] private Transform[] cubes;
    [SerializeField] private Vector3 startPosition = Vector3.zero;
    [SerializeField] private float spacing = 1.0f;

    private void Start()
    {
        if (cubes == null || cubes.Length == 0) return;

        BubbleSortDescending(cubes);
        ArrangeCubesInLine();
    }

    private void BubbleSortDescending(Transform[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                float sizeA = GetVolume(array[j]);
                float sizeB = GetVolume(array[j + 1]);

                if (sizeA < sizeB)
                {
                    Transform temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    private float GetVolume(Transform t)
    {
        return t.localScale.x * t.localScale.y * t.localScale.z;
    }

    private void ArrangeCubesInLine()
    {
        Vector3 currentPos = startPosition;

        for (int i = 0; i < cubes.Length; i++)
        {
            float yOffset = cubes[i].localScale.y / 2f;
            cubes[i].position = new Vector3(currentPos.x, startPosition.y + yOffset, currentPos.z);

            if (i < cubes.Length - 1)
            {
                float step = (cubes[i].localScale.x / 2f) + (cubes[i + 1].localScale.x / 2f) + spacing;
                currentPos.x += step;
            }
        }
    }
}
