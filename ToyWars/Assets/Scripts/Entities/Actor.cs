using Flyweight;
using UnityEngine;

namespace Entities
{
    public class Actor : MonoBehaviour
    {
        public ActorStats Stats => _stats;
        [SerializeField] public ActorStats _stats;
    }

}