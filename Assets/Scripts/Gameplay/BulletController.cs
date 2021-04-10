using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target = null;
    private float speed = 10f;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        translateToTarget();
    }

    public void SetTarget(GameObject target){
        if(target == null){
            Debug.Log("set target");
        } else {
            this.target = target;
            Debug.Log("TAG " + this.target);
            this.gameObject.SetActive(true);
        }
    }

    void translateToTarget()
    {
        if(target!=null){
            Vector3 movement = 
                new Vector3(
                     target.transform.position.x - this.gameObject.transform.position.x ,
                     target.transform.position.y - this.gameObject.transform.position.y ,
                     target.transform.position.z - this.gameObject.transform.position.z  
                );
            this.gameObject.transform.Translate(Vector3.Normalize(movement) * Time.deltaTime * speed);
        }
    }

    private IEnumerator DestroyObject(){
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        // InvokeRepeating("LaunchProjectile", 0f, 1f);
        if(other.gameObject.tag == "Enemy"){
            StartCoroutine(DestroyObject());
        }

    }
}
