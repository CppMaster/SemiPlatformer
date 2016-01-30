using UnityEngine;
using System.Collections;

public class ComboPuncher : Puncher {

    [HideInInspector]
    public bool isBlocking = false;

    [Header("Combos")]
    const int startNode = 1;
    public int edgeCount = 2;

    public ComboNode[] comboNodes;
    int currentNode = 1;
    float timeToNextMove = 0f;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (timeToNextMove > 0f)
        {
            timeToNextMove -= Time.deltaTime;
            if (timeToNextMove <= 0f)
            {
                punchTimeLeft = comboNodes[currentNode].punchCooldown;
                currentNode = 1;
            }
        }

        if (animator != null)
            animator.SetInteger("CurrentPunch", currentNode);
    }

    int GetNextNode(int node, int edge)
    {
        return node * edgeCount + edge;
    }

    public override float GetDamage()
    {
        return comboNodes[currentNode].damage;
    }

    protected override float GetPunchCooldown()
    {
        return comboNodes[currentNode].punchCooldown;
    }

    public override void PunchWithoutDetection()
    {

        int nextNode = GetNextNode(currentNode, punchIndex);
        if(nextNode >= comboNodes.Length)
        {
            punchTimeLeft = comboNodes[currentNode].punchCooldown;
            currentNode = 1;
            return;
        }

        timeToNextMove = comboNodes[currentNode].timeToNextMove;
        currentNode = nextNode;

        Debug.Log("Punch: " + currentNode);
        ExecutePunch();
        punchables.Clear();

    }

    public override void Damage(Puncher puncher)
    {
        if (isBlocking && IsFacingRight() != puncher.IsFacingRight()) return;
        base.Damage(puncher);
    }

}
