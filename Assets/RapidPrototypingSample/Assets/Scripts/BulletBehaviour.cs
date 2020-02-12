using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _damage = 1;
    
    // Update is called once per frame
    private void Update()
    {
        Debug.DrawLine(transform.position, (transform.up + transform.position) * 5);
        transform.Translate(0, _moveSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("test: " + other.gameObject.name);
        var player = other.gameObject.GetComponent<PlayerController>();
        var enemy = other.gameObject.GetComponent<DummyEnemy>();
        if (player == null && enemy == null) return;
        
        
        
        player?.TakeDamage(_damage);
        enemy?.TakeDamage(_damage);
        Destroy(gameObject);
    }
}
