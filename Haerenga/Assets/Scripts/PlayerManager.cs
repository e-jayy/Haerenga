using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }


    [Header("Unlocked Abilities")]
    [SerializeField] private bool dashUnlocked;
    [SerializeField] private bool wallJumpUnlocked;
    [SerializeField] private bool doubleJumpUnlocked;
    [SerializeField] private bool hookUnlocked;
    [SerializeField] private bool starInfo1Unlocked;
    [SerializeField] private bool starInfo2Unlocked;
    [SerializeField] private bool starInfo3Unlocked;
    [SerializeField] private bool starInfo4Unlocked;

    public bool DashUnlocked => dashUnlocked;
    public bool WallJumpUnlocked => wallJumpUnlocked;
    public bool DoubleJumpUnlocked => doubleJumpUnlocked;
    public bool HookUnlocked => hookUnlocked;
    public bool StarInfo1Unlocked => starInfo1Unlocked;
    public bool StarInfo2Unlocked => starInfo2Unlocked;
    public bool StarInfo3Unlocked => starInfo3Unlocked;
    public bool StarInfo4Unlocked => starInfo4Unlocked;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #region Ability Unlock Methods
    
    public void UnlockDash()       => dashUnlocked = true;
    public void UnlockWallJump()   => wallJumpUnlocked = true;
    public void UnlockDoubleJump() => doubleJumpUnlocked = true;
    public void UnlockHook()       => hookUnlocked = true;
    public void UnlockStarInfo1()  => starInfo1Unlocked = true;
    public void UnlockStarInfo2()  => starInfo2Unlocked = true;
    public void UnlockStarInfo3()  => starInfo3Unlocked = true;
    public void UnlockStarInfo4()  => starInfo4Unlocked = true;

    

    public void ResetAbilities()
    {
        dashUnlocked = false;
        wallJumpUnlocked = false;
        doubleJumpUnlocked = false;
        hookUnlocked = false;
    }

    public void ResetStarInfo()
    {
        starInfo1Unlocked = false;
        starInfo2Unlocked = false;
        starInfo3Unlocked = false;
        starInfo4Unlocked = false;
    }

    #endregion

}