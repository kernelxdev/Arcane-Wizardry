using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Spell")]
public class SpellData : ScriptableObject
{
    public Sprite spellSprite;
    
    [Header("Default Spell Data")]
    public float damage;
    public float speed;
    public float lifeTime;
    public float castCooldown;
    public float castTime;
    
    [Space]
    public OnHitBehaviours hitBehaviour;

    public enum OnHitBehaviours
    {
        None,
        Explode
    }

    [Header("Explosion Spell Data")]
    public float explosionRadius;
}
