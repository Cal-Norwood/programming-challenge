using UnityEngine;

public abstract class WeaponBase : MonoBehaviour // weapon base class to initialize data with basic functions
{
    protected WeaponSO m_WeaponData;

    public virtual void Initialize(WeaponSO data)
    {
        m_WeaponData = data;
    }

    public abstract void Fire();
    public abstract void StopFire();
}
