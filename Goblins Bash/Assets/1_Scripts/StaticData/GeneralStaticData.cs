using UnityEngine;

namespace _1_Scripts.StaticData
{
    [CreateAssetMenu(fileName = "GeneralParameters", menuName = "Create General Parameters")]
    public class GeneralStaticData : ScriptableObject
    {
        [field:SerializeField] public int PlayerHealth { get; private set; }
        
        [field:SerializeField] public int PlayerStamina { get; private set; }
        [field:SerializeField] public float StaminaIncreaseRate { get; private set; }
        [field:SerializeField] public float StaminaReduceRate { get; private set; }
        
        [field:SerializeField] public float PlayerMoveTime { get; private set; }
        
        [field:SerializeField] public float PlayerDamageShakeStrength { get; private set; }
        [field:SerializeField] public float PlayerDamageShakeDuration { get; private set; }
        
    }
}