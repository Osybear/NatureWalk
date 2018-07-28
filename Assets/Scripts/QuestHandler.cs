using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestHandler : MonoBehaviour {

	public string m_QuestItem;
	public Text m_QuestItemText;
	public Image m_QuestItemImage;

	private void Awake() {
		m_QuestItemText.text = null;
	}

	public void SetQuestItem(string Name, Sprite Sprite){
		m_QuestItem = Name;
		m_QuestItemText.text = Name;
		m_QuestItemImage.sprite = Sprite;
	}

	public void ResetQuestItem(){
		m_QuestItem = null;
		m_QuestItemText.text = null;
		m_QuestItemImage.sprite = null;
	}
}
