using UnityEngine;

public interface IShooter
{
    public void Shoot();
}

public class Bullet: MonoBehaviour
{
  public Vector3 direction;
  public float bullet_speed = 100.0f;

}