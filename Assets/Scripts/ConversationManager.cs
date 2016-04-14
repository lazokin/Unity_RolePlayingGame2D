using UnityEngine;
using System.Collections;

public class ConversationManager : Singleton<ConversationManager> {

	bool talking = false;
	ConversationEntry currentConversationLine;
	int fontSpacing = 7;
	int conversationTextWidth;
	int dialogHeight = 70;

	public int displayTextureOffset = 70;
	Rect scaledTextureRect;

	protected ConversationManager() {}

	public void StartConversation(Conversation conversation) {
		if (!talking) {
			StartCoroutine (DisplayConversation (conversation));
		}
	}

	IEnumerator DisplayConversation(Conversation conversation) {
		talking = true;
		foreach (var conversationLine in conversation.ConversationLines) {
			currentConversationLine = conversationLine;
			conversationTextWidth = currentConversationLine.ConversationText.Length * fontSpacing;
			scaledTextureRect = new Rect (
				currentConversationLine.DisplayPic.textureRect.x /
				currentConversationLine.DisplayPic.texture.width,
				currentConversationLine.DisplayPic.textureRect.y /
				currentConversationLine.DisplayPic.texture.height,
				currentConversationLine.DisplayPic.textureRect.width /
				currentConversationLine.DisplayPic.texture.width,
				currentConversationLine.DisplayPic.textureRect.height /
				currentConversationLine.DisplayPic.texture.height
			);
			yield return new WaitForSeconds (3);
		}
		talking = false;
		yield return null;
	}

	void OnGUI() {
		if (talking) {
			
			// Start layout
			GUI.BeginGroup (new Rect (
				Screen.width / 2 - conversationTextWidth / 2,
				50,
				conversationTextWidth + displayTextureOffset + 10,
				dialogHeight
			));
			
			// Background box
			GUI.Box (new Rect(
				0,
				0,
				conversationTextWidth + displayTextureOffset + 10,
				dialogHeight
			), "");
			
			// Character name
			GUI.Label(new Rect(
				displayTextureOffset,
				10,
				conversationTextWidth + 30, 20
			), currentConversationLine.SpeakingCharacterName);

			// Conversation text
			GUI.Label(new Rect(
				displayTextureOffset,
				30,
				conversationTextWidth + 30,
				20
			), currentConversationLine.ConversationText);

			// Character image
			GUI.DrawTextureWithTexCoords (new Rect (
				10,
				10,
				50,
				50
			), currentConversationLine.DisplayPic.texture, scaledTextureRect);

			// End layout
			GUI.EndGroup ();
		}
	}

}
