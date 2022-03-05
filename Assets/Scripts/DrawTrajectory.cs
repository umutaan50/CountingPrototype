using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    /*
     I want to learn about raycast, 
     */

    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] [Range(3, 30)] int lineSegmentCount;

    List<Vector3> linePoints = new List<Vector3>();

    #region Singleton
    public static DrawTrajectory Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidBody, Vector3 startingPoint)
    {
        Vector3 velocity = (forceVector / rigidBody.mass) * Time.fixedDeltaTime;

        float flightDuration = (2 * velocity.y) / Physics.gravity.y;

        float stepTime = flightDuration / lineSegmentCount;

        linePoints.Clear();

       
        for (int i = 0; i < lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i; // change in time

            Vector3 MovementVector = new Vector3(velocity.x * stepTimePassed, velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed, velocity.z * stepTimePassed);

            linePoints.Add(-MovementVector + startingPoint);
        }
        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());
    }
    public void HideLine()
    {
        lineRenderer.positionCount = 0;
    }
}
