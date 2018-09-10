namespace Braspag.Sdk.Contracts.Pagador
{
    /// <summary>
    /// Status das Transações no Pagador
    /// </summary>
    public enum TransactionStatus : byte
    {
        NotFinished = 0,
        Authorized = 1,
        PaymentConfirmed = 2,
        Denied = 3,
        Voided = 10,
        Refunded = 11,
        Pending = 12,
        Aborted = 13,
        Scheduled = 20
    }
}