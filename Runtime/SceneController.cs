using System;
using UnityEngine;

namespace BilliotGames
{
    public class SceneController : Singleton<SceneController>
    {
        private ISceneTransitor sceneTransitorBase;

        public void SetSceneTransitor(ISceneTransitor transitor) {
            this.sceneTransitorBase = transitor;
        }

        public void TransitionScene(string sceneID, SceneTransitionContextBase contextBase=null, Action callback=null) {
            if (sceneTransitorBase != null) {
                sceneTransitorBase.TransitionScene(sceneID, contextBase, callback);
            }
        }
    }
}