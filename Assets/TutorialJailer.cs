using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialJailer : MonoBehaviour
{
    public GameObject playerInJail1;
    public GameObject jail1Management;
    public GameObject jail1Spawn;
    private JailManagement jail1ManagementComp;

    public GameObject playerInJail2;
    public GameObject jail2Management;
    public GameObject jail2Spawn;
    private JailManagement jail2ManagementComp;

    public GameObject playerInJail3;
    public GameObject jail3Management;
    public GameObject jail3Spawn;
    private JailManagement jail3ManagementComp;

    // Start is called before the first frame update
    void Start()
    {
        // Jail Players
        jail1ManagementComp = jail1Management.GetComponent<JailManagement>();
        jail2ManagementComp = jail2Management.GetComponent<JailManagement>();
        jail3ManagementComp = jail3Management.GetComponent<JailManagement>();

        playerInJail1.transform.position = jail1Spawn.transform.position;
        playerInJail2.transform.position = jail2Spawn.transform.position;
        playerInJail3.transform.position = jail3Spawn.transform.position;

        jail1ManagementComp.jailedAttackers.Enqueue(playerInJail1);
        jail2ManagementComp.jailedAttackers.Enqueue(playerInJail2);
        jail3ManagementComp.jailedAttackers.Enqueue(playerInJail3);
    }

}