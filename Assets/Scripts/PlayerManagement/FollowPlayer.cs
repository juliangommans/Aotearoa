using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform target;

	void LateUpdate () {
//		transform.position = new Vector3(target.position.x,
//			target.position.y,
//			transform.position.z);
		transform.position = new Vector3(5.5f,4f,transform.position.z);
	}
}
