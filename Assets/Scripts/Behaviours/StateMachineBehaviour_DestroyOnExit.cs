using UnityEngine;

/// <summary>
/// State Machine Behaviour Destroy On Exit class. 
/// </summary>
public class StateMachineBehaviour_DestroyOnExit : StateMachineBehaviour
{
    /// <summary>
    /// Called when [state exit].
    /// </summary>
    /// <param name="animator">The animator.</param>
    /// <param name="stateInfo">The state information.</param>
    /// <param name="layerIndex">Index of the layer.</param>
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }
}
