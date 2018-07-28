using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTree : MonoBehaviour {

	public GameObject m_CanoePaddle;
	public float m_InteractDistance;
	public MessageHandler m_MessageHandler;
	public void DropCannoePaddle(){
		m_MessageHandler.ShowMessage(transform, "Player", "You shake the tree!");
		Rigidbody rb = m_CanoePaddle.AddComponent<Rigidbody>();
		rb.AddForce(-transform.forward * 15, ForceMode.Impulse);
		Destroy(this);
	}
}
