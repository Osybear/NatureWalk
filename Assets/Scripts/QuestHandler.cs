using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestHandler : MonoBehaviour {

	public Text m_QuestItemText;
	public Image m_QuestItemImage;

	private void Awake() {
		m_QuestItemText.text = null;
	}

	public void SetQuestItem(string Name, Sprite Sprite){
		m_QuestItemText.text = Name;
		m_QuestItemImage.sprite = Sprite;
	}
}
