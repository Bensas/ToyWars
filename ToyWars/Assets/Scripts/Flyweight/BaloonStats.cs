using UnityEngine;

public enum BaloonType {
    SPEED,
    HEALTH
}

namespace Flyweight
{

    [CreateAssetMenu(fileName = "BaloonStats", menuName = "Stats/Baloon", order = 0)]
    public class BaloonStats : ScriptableObject
    {
        [SerializeField] private StatValues _statValues;

        public int MaxLife => _statValues.MaxLife;
        public BaloonType BaloonType => _statValues.BaloonType;
        
        [System.Serializable]
        public struct StatValues
        {
            public int MaxLife;
            public BaloonType BaloonType;
        }
    }

    
}
