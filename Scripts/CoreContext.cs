using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "CoreContext", menuName = "Custom/CoreContext", order = 0)]
    public class CoreContext : SerializedScriptableObject
    {
        public IInteractable[] garbages;
        public LevelInfo[] levelsInfo;
    }
}