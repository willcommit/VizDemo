using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairInteraction : MonoBehaviour
{
    [SerializeField]
    private Material[] LeatherMaterials;
    private Material[] CurrentMaterials;
    private Material CurrentMaterialArms;
    private Transform arms;
    private Renderer rend;
    private Renderer childRend;
    private bool armsRaised = false;

    // Start is called before the first frame update
    void Start()
    {
        arms = this.gameObject.transform.GetChild(0);
        rend = GetComponent<Renderer>();
        childRend = arms.GetComponent<Renderer>();
        CurrentMaterials = rend.materials;
        CurrentMaterialArms = childRend.material;
        CurrentMaterials[2] = LeatherMaterials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if(Physics.Raycast(ray, out hit, 5))
            {
                if(hit.transform.name == "ChairArms")
                {
                    MoveArms();
                }
            }           
        }
    }

    public void MoveArms()
    {
        if(!armsRaised)
        {
            arms.Rotate(90,0,0,Space.Self);
            armsRaised=true;
        } else if (armsRaised)
        {
            arms.Rotate(-90,0,0,Space.Self);
            armsRaised=false;
        }
    }

    public void ChangeColorRed()
    {
        CurrentMaterials[2] = LeatherMaterials[2];
        CurrentMaterialArms = LeatherMaterials[2];
        rend.materials = CurrentMaterials;
        childRend.material = CurrentMaterialArms;
    }

    public void ChangeColorBlue()
    {
        CurrentMaterials[2] = LeatherMaterials[1];
        CurrentMaterialArms = LeatherMaterials[1];
        rend.materials = CurrentMaterials;
        childRend.material = CurrentMaterialArms;
    }

    public void ChangeColorBlack()
    {
        CurrentMaterials[2] = LeatherMaterials[0];
        CurrentMaterialArms = LeatherMaterials[0];
        rend.materials = CurrentMaterials;
        childRend.material = CurrentMaterialArms;
    }

    

    
}
