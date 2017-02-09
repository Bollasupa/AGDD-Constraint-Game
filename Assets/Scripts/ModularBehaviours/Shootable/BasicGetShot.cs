using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGetShot : MonoBehaviour, IShootable {

    public int health = 1;
    
    private IDieable iDieable;

    private void Start()
    {
        iDieable = this.gameObject.GetComponent(typeof(IDieable)) as IDieable;
    }

    public void GetShot(IProjectile projectile)
    {
        projectile.ApplyEffect(this.gameObject);

        health -= projectile.getDamageDealt();
    }

    public void Update()
    {
        if(health <= 0)
        {
            if(iDieable != null)
            {
                Debug.Log("Killed with IDieable interface");
                iDieable.Die();
            }else
            {
                Debug.Log("Killed with destroy");
                Destroy(this.gameObject);
            }
        }
    }
}
