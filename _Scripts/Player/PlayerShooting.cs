using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : ObjShooting
{

    protected override bool IsShooting()
    {
        return this.isShooting;
    }
    protected override void Shooting()
    {
        
        this.shootTimer += Time.fixedDeltaTime;

        if (!this.isShooting) return;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletPlayer, spawnPos, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShotter(transform.parent);
        base.Shooting();
    }
}
