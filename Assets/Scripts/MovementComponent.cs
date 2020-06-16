using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
	[SerializeField] private float movementSpeed = 10f;
	private EMovingState movingState = EMovingState.Stopped;

	private Vector2 movingDir;
	private Rigidbody2D rb2d;

    private void Start() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		if (movingState == EMovingState.Moving) {
			Vector3 newPos = transform.position + (Vector3)movingDir * Time.fixedDeltaTime * movementSpeed;
			rb2d.MovePosition(newPos);
		}	
		else if (movingState == EMovingState.Deccelerating) {
			//TODO: manage decceleration
		}
	}

	public void StopMovement() {
		movingState = EMovingState.Stopped;
	}

	public void StopMovement(Vector3 atLocation) {
		movingState = EMovingState.Deccelerating;
	}

	public void AttemptBeginMovement(Vector2 direction) {
		//TODO cast in direction for StopperObject

		//If clear, move
		movingDir = direction;

		movingState = EMovingState.Moving;
	}
}

public enum EMovingState {
	Stopped,
	Moving,
	Deccelerating
}