using UnityEngine;

public enum WeaponType { Pistol, Shotgun, Automatic, Melee }

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/Weapon Data")]
public class WeaponSO : ScriptableObject // allows for easy weapon creation
{
    public string weaponName;
    public WeaponType type;
    public float damage;
    public float fireRate;
    public GameObject weaponPrefab;
}
