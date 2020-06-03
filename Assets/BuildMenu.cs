
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    }
    public void PurchaseSecondTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    }
}
