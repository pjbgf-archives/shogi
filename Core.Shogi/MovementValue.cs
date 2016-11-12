namespace Core.Shogi
{
    public enum MovementValue : byte
    {
        AtRiskOfBeingCaptured = 1,
        Exposed = 2,
        ExposedButCaptureWillTurnIntoOpponentExposure = 4,
        Protected = 8,
        AbleToCaptureOpponentsPiece = 16,
        Check = 32,
        CheckMate = 64
    }
}