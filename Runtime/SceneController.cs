using System;
using UnityEngine;

namespace BilliotGames
{
    public class SceneController : Singleton<SceneController>
    {
        public string CurrentSceneID => currentSceneID;

        private string currentSceneID;
        private ISceneTransitor sceneTransitorBase;

        public void SetSceneTransitor(ISceneTransitor transitor) {
            this.sceneTransitorBase = transitor;
        }

        public void TransitionScene(string sceneID, SceneTransitionContextBase contextBase=null, Action callback=null) {
            if (sceneTransitorBase != null) {
                sceneTransitorBase.TransitionScene(sceneID, contextBase, onTransitionSucess:() => {
                    currentSceneID = sceneID;
                    callback?.Invoke();
                });
            }
        }
    }
}