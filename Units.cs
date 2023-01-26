using UnityEngine;


namespace Units 
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] protected float Speed = 0f; 
        [SerializeField] internal float maxHp = 100f;
        [SerializeField] internal float currentHp;
        [SerializeField] internal float Damage = 5f;

        virtual protected void Start()
        {
            currentHp = maxHp;
        }

    }
}
