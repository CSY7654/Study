using UnityEngine;


namespace Units 
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] protected float Speed = 0f;
        [SerializeField] internal float maxHp = 100f;
        [SerializeField] internal float currentHp;
        [SerializeField] internal float Damage = 5f;
        [SerializeField] internal float damageDelay = 3f;
        internal float damageDelayTime;
        [SerializeField] protected bool isDamage = false;

        virtual protected void Start()
        {
            currentHp = maxHp;
            damageDelayTime = damageDelay;
        }

        virtual protected void Update()
        {
            damaged();
        }

        protected  void damaged()
        {
            if (isDamage && damageDelay > 0)
            {
                damageDelay -= Time.deltaTime;
                if (damageDelay <= 0)
                {
                    isDamage = false;
                    damageDelay = damageDelayTime;
                }
            }
        }

    }
}
