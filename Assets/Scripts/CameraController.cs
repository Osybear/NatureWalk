using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float m_RotateSpeed;

	void Update () {
		if(Input.GetKey(KeyCode.D))
			transform.Rotate(-Vector3.up * m_RotateSpeed * Time.deltaTime);
		if(Input.GetKey(KeyCode.A))
			transform.Rotate(Vector3.up * m_RotateSpeed * Time.deltaTime);
	}

}
