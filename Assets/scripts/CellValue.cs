using UnityEngine;

public class CellValue : MonoBehaviour
{
    [SerializeField] private bool cellValue = false;

    private SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetCellValue(bool newValue)
    {
        cellValue = newValue;
        sr = gameObject.GetComponent<SpriteRenderer>();
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
