using Newtonsoft.Json.Linq;

namespace HideInPlainSight.Api.Models
{
    public class EncryptionRequest
    {
        public string Payload { get; set; }
        public string Key { get; set; }
    }
}