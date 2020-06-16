using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Wall : StopperObject
{
    
	private void OnTriggerEnter2D(Collider2D other) {
		MovementComponent moveable =  other.GetComponent<MovementComponent>();

		if (moveable)
			moveable.StopMovement();
	}
}
