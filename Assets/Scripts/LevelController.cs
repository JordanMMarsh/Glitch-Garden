using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] int attackers;
    [SerializeField] GameObject winLabel;
    bool timerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
    }

    private void Update()
    {
        if (timerFinished && attackers <= 0)
        {
            winLabel.SetActive(true);
        }
    }

    public void AddAttacker()
    {
        attackers++;
    }

    public void KillAttacker()
    {
        attackers--;
    }

    public void TimerFinished()
    {
        timerFinished = true;
        var spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in spawners)
        {
            spawner.StopSpawner();
        }
    }
}
