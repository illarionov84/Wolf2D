using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MissionManager : MonoBehaviour, IGameManager {
	public ManagerStatus status {get; private set;}
	
	public int curLevel {get; private set;}
	public int maxLevel {get; private set;}
	
	public void Startup() {
		Debug.Log("Mission manager starting...");
		
		UpdateData(0, SceneManager.sceneCountInBuildSettings-1);
		
		status = ManagerStatus.Started;
	}

	public void UpdateData(int curLevel, int maxLevel) {
		this.curLevel = curLevel;
		this.maxLevel = maxLevel;
	}

	public void ReachObjective() {
		Messenger.Broadcast(GameEvent.LEVEL_COMPLETE);
	}

	public void GoToNext() {
		if (curLevel < maxLevel) {
			curLevel++;
			string name = "Level" + curLevel;
			Debug.Log("Loading " + name);
			SceneManager.LoadScene(name);
		} else {
			Debug.Log("Last level");
			Messenger.Broadcast(GameEvent.GAME_COMPLETE);
		}
	}

	public void RestartCurrent() {
		string name = "Level" + curLevel;
		Debug.Log("Loading " + name);
		SceneManager.LoadScene(name);
	}
}
