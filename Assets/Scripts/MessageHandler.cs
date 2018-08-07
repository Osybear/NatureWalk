using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageHandler : MonoBehaviour {

	public Camera m_MainCamera;
	public Text m_MessageText;
	public Text m_TargetText;
	public Image m_MessageBackground;
	public Transform m_Target;
	public float m_AnimateMessageDelay;
	public float m_ClearMessageDelay;
	public Coroutine m_ShowMessage;

	private void Awake() {
		m_MessageBackground.rectTransform.sizeDelta = Vector2.zero;
		m_MessageText.text = null;
		m_TargetText.text = null;
	}

	private void Update() {
		if(m_Target != null){
			Vector3 ScreenPos = m_MainCamera.WorldToScreenPoint(m_Target.position);
			m_MessageText.rectTransform.position = new Vector2(ScreenPos.x, ScreenPos.y);
			m_MessageBackground.rectTransform.position = m_MessageText.rectTransform.position + new Vector3(0, m_TargetText.rectTransform.sizeDelta.y /2, 0);
			m_MessageBackground.rectTransform.sizeDelta = m_MessageText.rectTransform.sizeDelta + new Vector2(0, m_TargetText.rectTransform.sizeDelta.y);
		} 
	}

	public void ShowMessage(Transform Target, string TargetName, string Message){
		m_Target = Target;
		if(m_ShowMessage != null)
			StopCoroutine(m_ShowMessage);
		m_TargetText.text = TargetName;
		m_ShowMessage = StartCoroutine(AnimateMessage(Message));
	}

	public void ResetMessage(){
		m_Target = null;
		if(m_ShowMessage != null)
			StopCoroutine(m_ShowMessage);
		m_MessageBackground.rectTransform.sizeDelta = Vector2.zero;
		m_MessageText.rectTransform.sizeDelta = new Vector2(400,0);
		m_MessageText.text = null;
		m_TargetText.text = null;	
	}

	public IEnumerator AnimateMessage(string Message){
		char[] array = Message.ToCharArray();
		for(int i = 0; i < array.Length; i++){
			m_MessageText.text += array[i];
			yield return new WaitForSeconds(m_AnimateMessageDelay);
		}
		yield return new WaitForSeconds(m_ClearMessageDelay);
		ResetMessage();
	}
}
