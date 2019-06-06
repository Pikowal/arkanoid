using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public int points;
    public int blockHP;
    public Sprite hitSprite;
    public Sprite hitSprite2;

    public void BreakBlock()
    {
        blockHP--;
        GetComponent<SpriteRenderer>().sprite = hitSprite;
    }

    public void SecondBreakBlock()
    {
        blockHP--;
        GetComponent<SpriteRenderer>().sprite = hitSprite2;
    }
}
