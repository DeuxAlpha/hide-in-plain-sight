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
            try
            {
                var decrypted = SecretService.Decrypt(request.Payload, request.Key);
                return Ok(decrypted);
            }
            catch (Exception)
            {
                return BadRequest(request.Key);
            }
        }
    }
}