//// Uncomment this whole file.

//using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y); //to get the position of the sprite 
        Translate(1,1);
        Rotate(90);
    }


    void Translate(float x, float y) //to translate the sprite
    {
        transformMatrix.setIdentity(); //Set the default Identiity first 
        transformMatrix.setTranslationMatrix(x, y); //calls the setTranslation function to put the values in
        Transform(); //Transform the vertices accordingly

        pos = transformMatrix * pos;
    }

    void Rotate(float angle) //to rotate the sprite
    {
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();

        toOriginMatrix.setTranslationMatrix(-pos.x, -pos.y); //toOrigin is a - pos 
        fromOriginMatrix.setTranslationMatrix(pos.x, pos.y); //fromOrigin is a pos
        rotateMatrix.setRotationMatrix(angle); //get the angle of rotation which is the sin theta and cos theta


        transformMatrix.setIdentity();
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix; //transforms matrix that moves all the vertices

        Transform();
    }

    private void Transform() //to move the vertices 
    {
        vertices = meshManager.clonedMesh.vertices; //get the clonesmesh vertices

        for (int i = 0; i < vertices.Length; i++) //for loop to get the 4 vertices
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = transformMatrix * vert;
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;

        }

        meshManager.clonedMesh.vertices = vertices;
    }
}
