using System;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    private void Update()
    {
        
    }

    void PlayerInput()
    {
        if(Input.GetButtonDown("Fire1"))
            CastSpell();
    }

    void CastSpell()
    {
        
    }
}