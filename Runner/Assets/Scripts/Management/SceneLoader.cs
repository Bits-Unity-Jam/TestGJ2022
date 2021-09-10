using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mechanics.Managment
{
    public class SceneLoader : MonoBehaviour
    {
        static SceneLoader instance;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Replay(float delay)
        {
            Invoke("Replay", delay);
        }
    }

}
