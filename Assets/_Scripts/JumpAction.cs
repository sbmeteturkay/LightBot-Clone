//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

namespace MeteTurkay
{
    public class JumpAction : ActionBase
    {
        public JumpAction(PlayerUnit playerUnit) : base(playerUnit)
        {

        }
        public override void Execute()
        {
            _unit.Jump();
        }
    }
}
