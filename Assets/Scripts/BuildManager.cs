using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than 1 instance of buildmanager");
        }
        instance = this;
    }

    public GameObject standartTurretPrefab;
    public GameObject secondTurretPrefab;


    //void Start()
    //{
    //    turretToBuild = standartTurretPrefab;
    //}

    private GameObject turretToBuild;
    public GameObject GetTurretToBuild()
    {
      return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

}
