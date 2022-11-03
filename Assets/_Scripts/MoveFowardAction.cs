//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

namespace MeteTurkay
{
    public class MoveFowardAction : ActionBase
    {
        Direction side;
        public MoveFowardAction(PlayerUnit playerUnit, Direction side) : base(playerUnit) { this.side = side; }
        public override void Execute()
        {
            _unit.MoveFoward(side);
        }
    }
}
