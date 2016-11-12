namespace Core.Shogi
{
    public enum MovementValue : byte
    {
        AtRiskOfBeingCaptured = 1,
        Exposed = 2,
        //ExposedButCaptureWillTurnIntoOpponentExposure
        Protected = 4,
        AbleToCaptureOpponentsPiece = 8,
        CheckMate = 16
    }
}