using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Fusion;

public class mapGenerator : NetworkBehaviour
{
    private List<List<GameObject>> map = new List<List<GameObject>>();
    public int mapSquaresAmount;
    public Sprite squereSprite;

    private void Start()
    {
        GenerateMapPoints();
        
    }

    private void GenerateMapPoints()
    {
        if (mapSquaresAmount == 0)
        {
            return;
        }
        int gridSize = Mathf.CeilToInt(Mathf.Sqrt(mapSquaresAmount));
        float spacing = 1f;
        for (int x = 0; x < gridSize; x++)
        {
            List<GameObject> temp = new List<GameObject>();
            for (int y = 0; y < gridSize; y++)
            {
                int index = x * gridSize + y;
                if (index >= mapSquaresAmount) return;
                GameObject square = new GameObject("Square_" + index);
                square.transform.position = new Vector3(x * spacing, y * spacing, 0);
                square.transform.parent = this.transform;
                SpriteRenderer sr = square.AddComponent<SpriteRenderer>();
                sr.sprite = squereSprite;
                square.AddComponent<CellValue>();
                square.GetComponent<CellValue>().SetCellValue(true);
                temp.Add(square);
            }
            map.Add(temp);
        }
        Debug.Log(map.Count);
        StartCoroutine(updatemap());
    }

    private IEnumerator updatemap()
    {
        int gridSize = map.Count;
        if (gridSize == 0 || map[0].Count == 0)
        {
            Debug.Log("no map");
            yield break;
        }
        List<Vector2Int> allCoords = new List<Vector2Int>();
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < map[x].Count; y++)
            {
                allCoords.Add(new Vector2Int(x, y));
            }
        }
        Shuffle(allCoords);
        int quarterCount = Random.Range(10, 20);
        List<List<Vector2Int>> quarters = new List<List<Vector2Int>>();
        for (int i = 0; i < quarterCount; i++)
        {
            quarters.Add(new List<Vector2Int>());
        }
        for (int i = 0; i < allCoords.Count; i++)
        {
            int groupIndex = i % quarterCount;
            quarters[groupIndex].Add(allCoords[i]);
        }
        
        foreach (var quarter in quarters)
        {
            foreach (var coord in quarter)
            {
                UpdateCell(coord.x, coord.y);
            }
            yield return new WaitForSeconds(0.5f);
            if (CheckMap())
            {
                Debug.Log("map generated");
                yield break;
            }
        }
    }

    private void UpdateCell(int x, int y)
    {
        if (x < map.Count && y < map[x].Count)
        {
            CellValue cell = map[x][y].GetComponent<CellValue>();
            if (cell != null)
            {
                bool newValue = !cell.GetCellValue();
                cell.SetCellValue(newValue);
            }
        }
    }
    private void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randIndex = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[randIndex];
            list[randIndex] = temp;
        }
    }

    private bool CheckMap()
    {
        
        return false;
    }
    
}
