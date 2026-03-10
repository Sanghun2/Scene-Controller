using System;
using UnityEngine;

namespace BilliotGames
{
    public class PanelTransitor : MonoBehaviour, ISceneTransitor
    {
        [SerializeField] PanelGroup[] panels;

        public void TransitionScene(string sceneID, SceneTransitionContextBase contextBase=null, Action callback = null) {
            for (int i = 0; i < panels.Length; i++) {
                var panel = panels[i];
                panel.SetPanelActive(panel.PanelID.Equals(sceneID));
            }
        }
    }

    [Serializable]
    public class PanelGroup
    {
        public string PanelID => panelID;

        [SerializeField] string panelID;
        [SerializeField] GameObject[] relatedPanels;

        public void SetPanelActive(bool active) {
            for (int i = 0; i < relatedPanels.Length; i++) {
                var panel = relatedPanels[i];
                panel.SetActive(active);
            }
        }
    }
}

