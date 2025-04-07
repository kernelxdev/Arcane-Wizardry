using UnityEngine;

public class Spell : MonoBehaviour
{
    public SpellData spellData;
    
    public Rigidbody2D rb;
    
    private void Start()
    {
        if(spellSpriteRenderer != null)
            spellSpriteRenderer.sprite = spellData.spellSprite;
        else
        {
            spellSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (spellSpriteRenderer != null)
            {
                spellSpriteRenderer.sprite = spellData.spellSprite;
            }
            else
            {
                Debug.LogError("No SpriteRenderer component found on " + gameObject.name);
            }
        }
        rb = GetComponent<Rigidbody2D>();
    }
    
    [Header("Spell Sprite")] public SpriteRenderer spellSpriteRenderer;

    void OnHitNPC(GameObject target)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        
        if(enemy == null) return;
        
        switch (spellData.hitBehaviour)
        {
            case SpellData.OnHitBehaviours.None:
                enemy.health -= spellData.damage;
                break;
            
            case SpellData.OnHitBehaviours.Explode:
                Explode(spellData.damage, spellData.explosionRadius);
                break;
        }
    }

    void Explode(float damage, float explosionRadius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        Debug.Log("Explosion hit: " + hitColliders);
        
        foreach (Collider2D hit in hitColliders)
        {
            Enemy enemy = hit.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.health -= damage;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("NPC"))
            OnHitNPC(other.gameObject);
        
        Destroy(this.gameObject);
    }
}