using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Wolf2D
{

    public class LevelController : Singleton<LevelController>
    {
        public int CurLevel { get; private set; }
        public int MaxLevel { get; private set; }
        public UnityEvent hitEventLevelFailed = new UnityEvent();
        public UnityEvent hitEventLevelComplete = new UnityEvent();
        public UnityEvent hitEventGameComplete = new UnityEvent();

        private void Awake()
        {
            DontDestroyOnLoad(this);

            hitEventLevelFailed.AddListener(OnLevelFailed);
            hitEventLevelComplete.AddListener(OnLevelComplete);
            hitEventGameComplete.AddListener(OnGameComplete);

            UpdateData(0, SceneManager.sceneCountInBuildSettings - 1);
        }

        private void OnLevelFailed()
        {
            Debug.Log("Уровень перезагружен");
            RestartCurrent();
        }

        private void OnLevelComplete()
        {
            Debug.Log("Уровень пройден");
            GoToNext();
        }

        private void OnGameComplete()
        {
            Debug.Log("Игра пройдена");
        }

        public void UpdateData(int curLevel, int maxLevel)
        {
            this.CurLevel = curLevel;
            this.MaxLevel = maxLevel;
        }

        public void GoToNext()
        {
            if (CurLevel < MaxLevel)
            {
                CurLevel++;
                string name = "Level" + CurLevel;
                Debug.Log("Loading " + name);
                SceneManager.LoadScene(name);
            }
            else
            {
                Debug.Log("Last level");
                hitEventGameComplete.Invoke();
            }
        }

        public void RestartCurrent()
        {
            string name = "Level" + CurLevel;
            Debug.Log("Loading " + name);
            SceneManager.LoadScene(name);
        }
    }

}
