using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform Player;
	public Transform Submarine;
	public Transform Level1End;
	public Transform Level2End;
	public Transform Level3End;
	public Transform Level4End;
	public Transform Level1Start;
	public Transform Help23;
	public Transform Help24;
	public float damping = 0.3f;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;
	public float MinYPosRestriction = -1;
	public float MaxYPosRestriction = 1;
	public float MinXPosRestriction = -1;
	public float MaxXPosRestriction = 1;
	public bool Menu = true;
	public bool PlayPressed = false;
	public bool Level1 = false;
	public bool Level2 = false;
	public bool Level3 = false;
	public bool Level4 = false;
	public bool endScene = false;
	public bool Help1 = false;
	public bool Help2 = false;
	public bool Help3 = false;
	public bool Help4 = false;
	public bool Dead = false;
	
	
	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;

	void Start () {
		if (Menu == true) {
			lastTargetPosition = Level1Start.position;
			offsetZ = (transform.position - Level1Start.position).z;
			transform.parent = null;
		} else if (Menu == false) {
			lastTargetPosition = Player.position;
			offsetZ = (transform.position - Player.position).z;
			transform.parent = null;
		}
	}

	void FixedUpdate () {
		//Is menu
		if (Menu == true && PlayPressed == true && Help1 == false && Help2 == false && Help3 == false && Help4 == false) {
			float xMoveDelta = (Submarine.position - lastTargetPosition).x;
			
			bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
			
			if (updateLookAheadTarget) {
				lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
			} else {
				lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
			}
			
			Vector3 aheadTargetPos = Submarine.position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
			
			newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
			
			transform.position = newPos;
			
			lastTargetPosition = Submarine.position;		
			
		}
		if (Menu == true && PlayPressed == false && Help1 == false && Help2 == false && Help3 == false && Help4 == false) {
			float xMoveDelta = (Level1Start.position - lastTargetPosition).x;
			
			bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
			
			if (updateLookAheadTarget) {
				lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
			} else {
				lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
			}
			
			Vector3 aheadTargetPos = Level1Start.position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
			
			newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
			
			transform.position = newPos;
			
			lastTargetPosition = Level1Start.position;	

				}
		//NoMenu
		if (Menu == false && endScene == false && Dead == false) {
			float xMoveDelta = (Player.position - lastTargetPosition).x;
			
			bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
			
			if (updateLookAheadTarget) {
				lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
			} else {
				lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
			}
			
			Vector3 aheadTargetPos = Player.position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
			
			newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
			
			transform.position = newPos;
			
			lastTargetPosition = Player.position;		
		}
		//Help1
		if (Menu == true && Help1 == true) {
			float xMoveDelta = (Submarine.position - lastTargetPosition).x;
			
			bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
			
			if (updateLookAheadTarget) {
				lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
			} else {
				lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
			}
			
			Vector3 aheadTargetPos = Submarine.position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
			
			newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
			
			transform.position = newPos;
			
			lastTargetPosition = Submarine.position;		
		}		
		//Help2
		if (Menu == true && Help2 == true) {
			float xMoveDelta = (Player.position - lastTargetPosition).x;
			
			bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
			
			if (updateLookAheadTarget) {
				lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
			} else {
				lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
			}
			
			Vector3 aheadTargetPos = Player.position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
			
			newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
			
			transform.position = newPos;
			
			lastTargetPosition = Player.position;		
		}
		//Help3
		if (Menu == true && Help3 == true) {
			float xMoveDelta = (Help23.position - lastTargetPosition).x;
			
			bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
			
			if (updateLookAheadTarget) {
				lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
			} else {
				lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
			}
			
			Vector3 aheadTargetPos = Help23.position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
			
			newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
			
			transform.position = newPos;
			
			lastTargetPosition = Help23.position;		
		}
		//Help4
		if (Menu == true && Help4 == true) {
			float xMoveDelta = (Help24.position - lastTargetPosition).x;
			
			bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
			
			if (updateLookAheadTarget) {
				lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
			} else {
				lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
			}
			
			Vector3 aheadTargetPos = Help24.position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
			
			newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
			
			transform.position = newPos;
			
			lastTargetPosition = Help24.position;		
		}
		//Dead
		if (Dead == true) {
			float xMoveDelta = (Submarine.position - lastTargetPosition).x;
			
			bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
			
			if (updateLookAheadTarget) {
				lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
			} else {
				lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
			}
			
			Vector3 aheadTargetPos = Submarine.position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
			
			newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
			
			transform.position = newPos;
			
			lastTargetPosition = Submarine.position;		
		}





		//End levels
		if (Level1 == true) {
			if(endScene == true){
				float xMoveDelta = (Level1End.position - lastTargetPosition).x;
				
				bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
				
				if (updateLookAheadTarget) {
					lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
				} else {
					lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
				}
				
				Vector3 aheadTargetPos = Level1End.position + lookAheadPos + Vector3.forward * offsetZ;
				Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
				
				newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
				
				transform.position = newPos;
				
				lastTargetPosition = Level1End.position;	
			}
		}


		//Level2
		if (Level2 == true) {
			if(endScene == true){
				float xMoveDelta = (Level2End.position - lastTargetPosition).x;
				
				bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
				
				if (updateLookAheadTarget) {
					lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
				} else {
					lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
				}
				
				Vector3 aheadTargetPos = Level2End.position + lookAheadPos + Vector3.forward * offsetZ;
				Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
				
				newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
				
				transform.position = newPos;
				
				lastTargetPosition = Level2End.position;	
			}
		}


		//Level3
		if (Level3 == true) {
			if(endScene == true){
				float xMoveDelta = (Level3End.position - lastTargetPosition).x;
				
				bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
				
				if (updateLookAheadTarget) {
					lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
				} else {
					lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
				}
				
				Vector3 aheadTargetPos = Level3End.position + lookAheadPos + Vector3.forward * offsetZ;
				Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
				
				newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
				
				transform.position = newPos;
				
				lastTargetPosition = Level3End.position;	
			}
		}


		//Level4
		if(Level4 == true){
			if(endScene){
				float xMoveDelta = (Level4End.position - lastTargetPosition).x;
				
				bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
				
				if (updateLookAheadTarget) {
					lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
				} else {
					lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
				}
				
				Vector3 aheadTargetPos = Level4End.position + lookAheadPos + Vector3.forward * offsetZ;
				Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
				
				newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
				
				transform.position = newPos;
				
				lastTargetPosition = Level4End.position;	
			}
		}
	}
}
