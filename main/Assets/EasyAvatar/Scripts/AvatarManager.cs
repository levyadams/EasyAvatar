
using UnityEngine;
/// <summary>
/// Takes a skinned mesh renderer bone structure from one object and applies it directly to another.
/// Both Objects need to have the same Rig/Skeleton system, and should probably be the same file type
/// to avoid bad things in unity.
/// 
/// Written By Levy Adams (2/21/2018)
/// levyadams@aol.com for feedback/support
/// https://github.com/levyadams
/// </summary>
public class AvatarManager : MonoBehaviour
{
    //A reference to this singleton for easy access from any script that inherets monohaviour.
    public static AvatarManager instance;


    void Start()
    {
        //Make sure the singleton is in fact single
        if (instance == null)
        {

            instance = this;
        }
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// The only function you actually need to copy bones from one skinned mesh renderer to another. If it takes anything more than this, you've done something very wrong.
    /// </summary>
    /// <param name="ObjectToAdd"></param>
    /// <param name="avatar"></param>
    public void AddObjectToMesh(GameObject ObjectToAdd, GameObject avatar)
    {
        //Get the MR from the avatar(rigged base mesh)
        SkinnedMeshRenderer avatarMeshRenderer = avatar.GetComponentInChildren<SkinnedMeshRenderer>();

        //Get the MR from the object to be attached
        SkinnedMeshRenderer newMeshRenderer = ObjectToAdd.GetComponentInChildren<SkinnedMeshRenderer>();

        //if either of them are null, send a warning to the user and return. This could be more robust and tell the user which, I suppose.
        if (newMeshRenderer == null || avatarMeshRenderer == null)
        {
            Debug.LogWarning("No Skinned Mesh Renderer attached to one of the game objects! Make sure to export both objects with THE SAME rig attached to BOTH.");
            return;
        }

        //if the object is going to be literally attached to the base mesh, simply parent the object to the base mesh
        ObjectToAdd.transform.parent = avatar.transform;

        //Replace the bones from the object to the bones of the base mesh.
        newMeshRenderer.bones = avatarMeshRenderer.bones;
    }



}

