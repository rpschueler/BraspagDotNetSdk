namespace Braspag.Sdk.Contracts.Pagador
{
    public class ExternalAuthenticationData
    {
        public string Cavv { get; set; }

        public string Xid { get; set; }

        public int Eci { get; set; }
    }
}