using System;
using UnityEngine;

namespace BilliotGames
{
    public interface ISceneTransitor
    {
        public abstract void TransitionScene(string sceneID, SceneTransitionContextBase contextBase, Action callback = null);
    }

    public class SceneTransitionContextBase {

    }
}

