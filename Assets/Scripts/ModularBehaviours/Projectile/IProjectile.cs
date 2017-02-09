using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile {
    void ApplyEffect(GameObject obj);
    int getDamageDealt();
}