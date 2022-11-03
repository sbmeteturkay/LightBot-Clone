//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

namespace MeteTurkay
{
    public enum Direction
    {
        Left, Right, Foward, Back
    }
    public abstract class ActionBase
    {

        protected readonly PlayerUnit _unit;
        public ActionBase(PlayerUnit playerUnit)
        {
            _unit = playerUnit;
        }
        public abstract void Execute();
    }
}
