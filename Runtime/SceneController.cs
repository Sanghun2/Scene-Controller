using System;
using UnityEngine;

namespace BilliotGames
{
    public class SceneController : Singleton<SceneController>
    {
        public enum State {
            Idle,
            Transitioning,
        }

        public string CurrentSceneID => currentSceneID;
        public State CurrentState => _currentState;

        private string currentSceneID;
        private State _currentState;
        private ISceneTransitor sceneTransitorBase;

        public void SetSceneTransitor(ISceneTransitor transitor) {
            this.sceneTransitorBase = transitor;
        }

        public void TransitionScene(string sceneID, SceneTransitionContextBase contextBase=null, Action callback=null) {
            if (sceneTransitorBase != null) {
                if (CurrentState == State.Transitioning) { Debug.Log($"<color=orange>이미 Scene 전환 중</color>"); return; }

                _currentState = State.Transitioning;
                sceneTransitorBase.TransitionScene(sceneID, contextBase, onTransitionSucess:() => {
                    currentSceneID = sceneID;
                    _currentState = State.Idle;
                    callback?.Invoke();
                });
            }
        }
    }
}