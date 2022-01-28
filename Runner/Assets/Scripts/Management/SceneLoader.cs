using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mechanics.Management
{
    public class SceneLoader : MonoBehaviour
    {
        static SceneLoader instance;

        [SerializeField]
        GameObject panel;

        public static SceneLoader Instance { get => instance; }

        private void Awake()
        {
            if (instance)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        public void Replay()
        {
            //panel.SetActive(true);
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GameLoad()
        {
            SceneManager.LoadScene(1);
        }

        public void Replay(float delay)
        {
            Invoke("Replay", delay);
        }
    }

}
