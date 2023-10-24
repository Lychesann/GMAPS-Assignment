using Unity.VisualScripting;
using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    private Vector3 start;
    private Vector3 end;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            CalculateGameDimensions();
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = 5;
        maxY = 5;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(-5, 5);
        endPt = new Vector2(-5, 5);
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        maxX = 5;
        maxY = 5;
        minX = -maxX;
        minY = -maxY;
        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));

            endPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));

            drawnLine = lineFactory.GetLine(startPt, 
                endPt, 0.02f, Color.black);
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 0),
            Color.red, 60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            start = new Vector3(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY),
                Random.Range(-maxY, maxY));

            end = new Vector3(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY),
                Random.Range(-maxY, maxY));

            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                end,
            Color.white,
                60f);
        }
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a + b;
        HVector2D cnew = a - b; // To get the modified vector C

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f); // To show the projection of 'a' from the origin
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f); // To show the projection of 'b' from the origin
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);// To show the projection of 'c' from the origin
        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.green, 60f); //To show the projection of 'b' from 'a'

        //modified code 
        //DebugExtension.DebugArrow(Vector3.zero, cnew.ToUnityVector3(), Color.white, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);

        Debug.Log("Magnitude of a = " + b.Magnitude().ToString("F2"));
        // Your code here
        
    }

    public void Question3b()
    {
        // Your code here
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(a.x /2, a.y /2);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(new Vector3(1,0,0), b.ToUnityVector3(), Color.green, 60f);

    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(3, 5);

        b.Normalize();
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(new Vector3(1, 0, 0), b.ToUnityVector3(), Color.green, 60f);
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;
        // Your code here

        HVector2D proj = new HVector2D(b.x/2, b.y/2);

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
