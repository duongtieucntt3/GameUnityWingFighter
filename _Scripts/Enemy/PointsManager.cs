using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : DuongMonoBehaviour
{
    [SerializeField] protected List<ShipSpawnPos> spawnPoints = new List<ShipSpawnPos>();
    public List<ShipSpawnPos> SpawnPoints => spawnPoints;

    [SerializeField] protected List<ShipStandPos> standPoints = new List<ShipStandPos>();
    public List<ShipStandPos> StandPoints => standPoints;

    [SerializeField] protected List<ShipStandPos> standPoints_1 = new List<ShipStandPos>();
    public List<ShipStandPos> StandPoints_1 => standPoints_1;

    [SerializeField] protected List<ShipStandPos> standPoints_2 = new List<ShipStandPos>();
    public List<ShipStandPos> StandPoints_2 => standPoints_2;

    [SerializeField] protected List<ShipStandPos> standPoints_3 = new List<ShipStandPos>();
    public List<ShipStandPos> StandPoints_3 => standPoints_3;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
        this.LoadStandPoints();
        this.LoadStandPoints_1();
        this.LoadStandPoints_2();
        this.LoadStandPoints_3();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints.Count > 0) return;
        Transform points = transform.Find("SpawnPoints");
        foreach (Transform point in points)
        {
            ShipSpawnPos shipSpawnPos = point.GetComponent<ShipSpawnPos>();
            this.spawnPoints.Add(shipSpawnPos);
        }
        Debug.LogWarning(transform.name + ": LoadSpawnPoints", gameObject);
    }

    protected virtual void LoadStandPoints()
    {
        if (this.standPoints.Count > 0) return;
        Transform points = transform.Find("StandPoints");
        ShipStandPos shipStandPos;
        foreach (Transform point in points)
        {
            shipStandPos = point.GetComponent<ShipStandPos>();
            this.standPoints.Add(shipStandPos);
        }
        Debug.LogWarning(transform.name + ": LoadStandPoints", gameObject);
    }

    protected virtual void LoadStandPoints_1()
    {
        if (this.standPoints_1.Count > 0) return;
        Transform points = transform.Find("StandPoints_1");
        ShipStandPos shipStandPos;
        foreach (Transform point in points)
        {
            shipStandPos = point.GetComponent<ShipStandPos>();
            this.standPoints_1.Add(shipStandPos);
        }
        Debug.LogWarning(transform.name + ": LoadStandPoints_1", gameObject);
    }

    protected virtual void LoadStandPoints_2()
    {
        if (this.standPoints_2.Count > 0) return;
        Transform points = transform.Find("StandPoints_2");
        ShipStandPos shipStandPos;
        foreach (Transform point in points)
        {
            shipStandPos = point.GetComponent<ShipStandPos>();
            this.standPoints_2.Add(shipStandPos);
        }
        Debug.LogWarning(transform.name + ": LoadStandPoints_2", gameObject);
    }
    protected virtual void LoadStandPoints_3()
    {
        if (this.standPoints_3.Count > 0) return;
        Transform points = transform.Find("StandPoints_3");
        ShipStandPos shipStandPos;
        foreach (Transform point in points)
        {
            shipStandPos = point.GetComponent<ShipStandPos>();
            this.standPoints_3.Add(shipStandPos);
        }
        Debug.LogWarning(transform.name + ": LoadStandPoints_3", gameObject);
    }
}
