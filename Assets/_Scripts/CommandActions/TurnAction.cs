//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

namespace MeteTurkay
{
    public class TurnAction : ActionBase
    {
        Direction side;
        public TurnAction(PlayerUnit playerUnit, Direction side) : base(playerUnit)
        {
            this.side = side;
        }
        public override void Execute()
        {
            _unit.TurnAction(side);
        }
    }
}
