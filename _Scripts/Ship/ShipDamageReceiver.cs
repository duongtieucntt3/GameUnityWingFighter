using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageReceiver : DamageReceiver
{
    [SerializeField] protected AudioSource AudioShipDead;

    [SerializeField] protected AudioSource AudioThatBai;
    protected virtual void SetGameOver()
    {
        this.AudioThatBai.Play();
        UIInventory.Instance.Open();
        UIInventory.Instance.BtnTiepTuc.gameObject.SetActive(false);
        UIInventory.Instance.GameOver.gameObject.SetActive(true);
        UIInventory.Instance.BtnBtnInvClose.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
    protected override void OnDead()
    {
        this.OnDeadFX(); 
        this.AudioShipDead.Play();
        transform.parent.gameObject.SetActive(false);
        Invoke("SetGameOver", 2f);
    }
    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.Smoke1;
    }

}