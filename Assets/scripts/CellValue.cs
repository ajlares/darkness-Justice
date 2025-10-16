using UnityEngine;

public class CellValue : MonoBehaviour
{
    [SerializeField] private bool cellValue = false;

    public void SetCellValue(bool newValue)
    {
        cellValue = newValue;
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        if (newValue && sr != null)
        {
            sr.color = Color.black;
        }
        else if(!newValue && sr != null)
        {
            sr.color = Color.white;
        }
    }

    public bool GetCellValue()
    {
        return cellValue;
    }
}
