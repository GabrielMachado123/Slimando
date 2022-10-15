using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyInfo", order = 1)]
public class EnemyInfo : ScriptableObject
{
       public float speed;
       public float health;
       public float damage;

       private Vector3 BucketPos = new Vector3(5000, 5000, 5000);

    public Vector3 GetBucketPosition()
    {
        return BucketPos;
    }
}
