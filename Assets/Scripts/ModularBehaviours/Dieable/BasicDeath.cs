﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDeath : MonoBehaviour, IDieable{

	public void Die()
    {
        Destroy(this.gameObject);
    }
}