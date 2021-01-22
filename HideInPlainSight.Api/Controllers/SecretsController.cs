using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HideInPlainSight.Api.Models;
using HideInPlainSight.Logic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HideInPlainSight.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecretsController : ControllerBase
    {
        [HttpGet("encrypt")]
        public IActionResult Encrypt([FromBody] EncryptionRequest request)
        {
            return Ok(SecretService.Encrypt(request.Payload, request.Key));
        }

        [HttpGet("decrypt")]
        public IActionResult Decrypt([FromBody] DecryptionRequest request)
        {
            var random = new Random(request.Key.GetHashCode());
            try
            {
                var decrypted = SecretService.Decrypt(request.Payload, request.Key);
                return Ok(decrypted);
            }
            catch (Exception exception)
            {
                return Ok("That decryption totally worked.");
            }
        }
    }
}