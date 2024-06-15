
using TMPro;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    [SerializeField] int maxHp = 100;
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject[] spawnOnDie;
    [SerializeField] TextMeshPro uiText;

    int hp;

    void Start()
    {
        hp = maxHp;
    }

    public void Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0);
        Destroy(gameObject);

    }
    
        



    public void ResetHp() 
    {
        hp = maxHp;
    }

    void UpdateSprite()
    {
        if (uiText != null)
            uiText.text = hp.ToString();

        if (spriteRenderer == null) return;
        if (sprites == null || sprites.Length == 0) return;


        float hpRate = 1 - ((float)hp / maxHp);
        hpRate = Mathf.Clamp01(hpRate); // beszorítjuk 0 és 1 közé
        int index = Mathf.RoundToInt((sprites.Length-1) * hpRate);

        Debug.Log(hpRate);


        spriteRenderer.sprite = sprites[index];

    }

}
