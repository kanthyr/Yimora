using UnityEngine;
using UnityEngine.Serialization;

public class FlipController : MonoBehaviour
{

    [FormerlySerializedAs("p1fr")] [SerializeField] bool p1Fr = true;
    [FormerlySerializedAs("p2fr")] [SerializeField] bool p2Fr;

    public GameObject player1;
    public GameObject player2;

    private SpriteRenderer _renderP1;
    private SpriteRenderer _renderP2;

    private Animator _animP1;
    private Animator _animP2;
    private static readonly int FacingR = Animator.StringToHash("FacingR");

    private void Start()
    {
        _renderP1 = player1.GetComponent<SpriteRenderer>();
        _animP1 = player1.GetComponent<Animator>();
        _renderP2 = player2.GetComponent<SpriteRenderer>();
        _animP2 = player2.GetComponent<Animator>();
    }

    public void Update()
    {
        FlipCheck();
        Flip(_renderP1, _animP1, p1Fr);
        Flip(_renderP2, _animP2, p2Fr);
    }

    private void FlipCheck()
    {
        if (player1.transform.position.x < player2.transform.position.x)
        {
            p1Fr = true;
            p2Fr = false;
        }
        else
        {
            p2Fr = true;
            p1Fr = false;
        }
    }

    private void Flip(SpriteRenderer render, Animator anim, bool facingrigth)
    {
        if (facingrigth)
        {
            render.flipX = true;
            anim.SetBool(FacingR, true);
        }
            
        else
        {
            render.flipX = false;
            anim.SetBool(FacingR, false);
        }
    }
    
}
