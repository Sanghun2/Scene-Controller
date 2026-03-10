using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BilliotGames
{
    public class SceneTransitionContext : SceneTransitionContextBase {
        public LoadSceneMode LoadSceneMode => loadMode;

        private LoadSceneMode loadMode; 

        public SceneTransitionContext(LoadSceneMode loadMode) {
            this.loadMode = loadMode;
        }

    }


    public class SceneTransitor : ISceneTransitor
    {
        public void TransitionScene(string sceneID, SceneTransitionContextBase contextBase, Action callback) {
            if (contextBase is SceneTransitionContext context) {
                SceneManager.LoadScene(sceneID, context.LoadSceneMode);
            }
            else {
                Debug.LogError($"<color=red>context base is not tpye of ({typeof(SceneTransitionContext)})</color>");
            }
        }
    }
}
