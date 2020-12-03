using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//usually you use interfaces when you need to apply LSP (L in SOLID)
//right now I don't think there is practical benefit of these interfaces
public interface IDamageable
{
    void TakeDamage(int damage);
}
