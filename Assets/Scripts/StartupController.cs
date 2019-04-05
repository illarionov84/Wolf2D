using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartupController : MonoBehaviour {
	[SerializeField] private float progressBar;

	void Awake() {
		Messenger<int, int>.AddListener(StartupEvent.MANAGERS_PROGRESS, OnManagersProgress);
		Messenger.AddListener(StartupEvent.MANAGERS_STARTED, OnManagersStarted);
	}
	void OnDestroy() {
		Messenger<int, int>.RemoveListener(StartupEvent.MANAGERS_PROGRESS, OnManagersProgress);
		Messenger.RemoveListener(StartupEvent.MANAGERS_STARTED, OnManagersStarted);
	}

	private void OnManagersProgress(int numReady, int numModules) {
		float progress = (float)numReady / numModules;
		progressBar = progress;
	}

	private void OnManagersStarted() {
        Debug.Log("Все менеджеры загружены");
    }
}
