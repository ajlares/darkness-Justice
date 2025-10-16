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
        // segun copilot y stack overflow lo que hace esta linea es usando la funcion math.sqrt es sacar la raiz del numero requerido 
        // y luego usa la funcion ceiltoint para general un grid del tamaño de esa raiz 
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
    }
    
    
}
