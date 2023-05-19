using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "ActorStats", menuName = "Stats/Actor", order = 0)]
    public class ActorStats : ScriptableObject
    {
        [SerializeField] private StatValues _statValues;

        public int MaxLife => _statValues.MaxLife;
        public float MovementSpeed => _statValues.MovementSpeed;
    }

    [System.Serializable]
    public struct StatValues
    {
        public int MaxLife;
        public float MovementSpeed;
    }
}
