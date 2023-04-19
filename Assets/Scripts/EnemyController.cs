using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class EnemyController : MonoBehaviour

{
    public float moveSpeed;
    public float speedMod = 1f;

    private Path thePath;
    private int currentPoint;
    private bool reachedEnd;

    public float timeBetweenAttacks;
    public float damagePerAttack;
    private float attackCounter;
    private int selectedAttackPoint;

    private Castle theCastle;
    // Start is called before the first frame update

    void Start()
    {
        thePath = FindObjectOfType<Path>();
        attackCounter = timeBetweenAttacks;
        theCastle = FindObjectOfType<Castle>();
    }
    
    // Update is called once per frame

    void Update()
    {
        if(LevelManager.instance.levelActive)
        {
        if (reachedEnd == false)
        {
            transform.LookAt(thePath.points[currentPoint]);
            transform.position = Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position , moveSpeed * Time.deltaTime * speedMod);

            if(Vector3.Distance(transform.position, thePath.points[currentPoint].position) < .01f)
            currentPoint++;
                if (currentPoint>=thePath.points.Length)
                {
                    reachedEnd = true;
                    selectedAttackPoint = Random.Range(0,theCastle.attackPoints.Length);
                }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, theCastle.attackPoints[selectedAttackPoint].position, moveSpeed * Time.deltaTime * speedMod);
            attackCounter -= Time.deltaTime;
            if(attackCounter <=0 )
            {
                attackCounter = timeBetweenAttacks;
                theCastle.TakeDamage(damagePerAttack);
            }
        }
        }
    }
}