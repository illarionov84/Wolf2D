using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	void Awake() {
		Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
		Messenger.AddListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
		Messenger.AddListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
		Messenger.AddListener(GameEvent.GAME_COMPLETE, OnGameComplete);
	}
	void OnDestroy() {
		Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
		Messenger.RemoveListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
		Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
		Messenger.RemoveListener(GameEvent.GAME_COMPLETE, OnGameComplete);
	}

	private void OnHealthUpdated() {
        Debug.Log("Попадание");
    }

	private void OnLevelFailed() {
        Debug.Log("Уровень перезагружен");
        Managers.Player.Respawn();
        Managers.Mission.RestartCurrent();
	}

	private void OnLevelComplete() {
        Debug.Log("Уровень пройден");
        Managers.Mission.GoToNext();
	}

	private void OnGameComplete() {
        Debug.Log("Игра пройдена");
    }
}
