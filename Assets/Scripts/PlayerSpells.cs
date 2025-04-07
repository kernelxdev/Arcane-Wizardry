using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    public GameObject spellPrefab;
    [Space] [SerializeField] private SpellData selectedSpellData;
    [Space] [SerializeField] private List<SpellData> unlockedSpells = new List<SpellData>();
    [SerializeField] private Transform castPoint;
    
    private void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        if(Input.GetButtonDown("Fire1"))
            CastSpell();
    }

    void CastSpell()
    {
        if (spellPrefab == null) return;

        Transform origin = castPoint != null ? castPoint : transform;

        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0f;

        Vector2 direction = ((Vector2)mouseWorldPosition - (Vector2)origin.position).normalized;
 
        GameObject spell = Instantiate(spellPrefab, origin.position, Quaternion.identity);
        Rigidbody2D rb = spell.GetComponent<Spell>().rb;

        if (rb != null)
        {
            rb.linearVelocity = direction * selectedSpellData.speed;
        }
        else
        {
            Debug.LogError("Spell Prefab is missing a Rigidbody2D component.");
            Destroy(spell);
        }
    }
}