using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class ReturnHome : MonoBehaviour
    {
        public string hubSceneName;

        public void Init()
        {
            GameSceneManager gameSceneManager = GameManager.instance.gameObject.GetComponent<GameSceneManager>();

            if (SceneManager.GetActiveScene().name != hubSceneName)
            {
                gameSceneManager.InitSwitchScene(hubSceneName, new Vector3(0, 0, 0));
            }
        }
    }
}

