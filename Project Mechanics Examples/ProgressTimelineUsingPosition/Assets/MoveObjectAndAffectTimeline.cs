using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class MoveObjectAndAffectTimeline : MonoBehaviour
{
    public PlayableDirector timeLine;

    void Update()
    {
        MoveObjectBetweenLimits();

        MoveTimelineRelativeToLocation();
    }

    // Fast dirty way to move a object between two points, not optimized
    void MoveObjectBetweenLimits()
    {
        Vector3 motionVector = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
            motionVector.x -= 1;

        if (Input.GetKey(KeyCode.RightArrow))
            motionVector.x += 1;

        transform.position += motionVector * 5 * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10, 10), -1, 0);
    }

    void MoveTimelineRelativeToLocation()
    {
        if (timeLine)
        {
            // 20 is max range basically You'd need to unhardcode this sorry :p
            // we add 10 so taht we're just in the positive range to get a correct normalized calculation
            float normalizedTimeByDistanceTravelled = (transform.position.x + 10) / (20);
            timeLine.time = normalizedTimeByDistanceTravelled;

            // Once we move the time lets evaluate
            timeLine.Evaluate();

            // Ensure the update mode is setup correctly so this doesnt start playing willy nilly
            timeLine.timeUpdateMode = DirectorUpdateMode.Manual;
        }
    }
}
