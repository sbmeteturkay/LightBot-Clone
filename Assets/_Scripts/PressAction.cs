//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

namespace MeteTurkay
{
    public class PressAction : ActionBase
    {
        public PressAction(PlayerUnit playerUnit) : base(playerUnit)
        {

        }
        public override void Execute()
        {
            _unit.PressAction();
        }
    }
}
