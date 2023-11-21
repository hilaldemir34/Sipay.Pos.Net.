using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using Core.Utilities.Results;
using Business.DTOs.ServiceResponseDtos;
using Microsoft.AspNetCore.Authorization;
using Entities.Concrete;

namespace Sipay.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class tokenController : ControllerBase {
        private IAuthService _authService;
        public tokenController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult> Token(UserForLoginDto userForLoginDto) {
            //https://provisioning.sipay.com.tr/ccpayment/api/token
            IDataResult<SipayTokenDto> successDataResult =
                await _authService.LoginAsync(userForLoginDto);
            HttpClient httpClient = new();
            string content = JsonSerializer.Serialize(userForLoginDto);
            using StringContent jsonContent = new(content, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(new Uri("https://provisioning.sipay.com.tr/ccpayment/api/token"), jsonContent);

            if(response.EnsureSuccessStatusCode().IsSuccessStatusCode is false) {
                return BadRequest();
            }

            //return Ok(response);

            return Ok(await response.Content.ReadFromJsonAsync<SipayToken>());
        }

        //[Authorize]
        //[HttpPost]
        //public async Task<ActionResult> Installments(Installment ınstallment)
        //{
        //    return BadRequest();
        //}


        public class SipayToken {
            [JsonPropertyName("status_code")]
            public int StatusCode { get; set; }
            [JsonPropertyName("status_description")]
            public String StatusDescription { get; set; }
            [JsonPropertyName("data")]
            public Data Data { get; set; }
        }

        public class Data {
            [JsonPropertyName("token")]
            public String Token { get; set; }
            [JsonPropertyName("is_3d")]
            public int Is3d { get; set; }
            [JsonPropertyName("expires_at")]
            public String ExpiresAt { get; set; }
        }

    
    }

}

