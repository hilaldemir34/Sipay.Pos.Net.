using Business.Abstract;
using Business.DTOs.ServiceResponseDtos;
using Business.Settings;
using Core.Utilities.Results;
using Entities.Dto;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Business.Concrete;
public class AuthManager : IAuthService {
    private readonly ServiceUrls serviceUrls;

    public AuthManager(IOptions<ServiceUrls> serviceUrls)   {
        this.serviceUrls = serviceUrls.Value;
    }

    public async Task<IDataResult<SipayTokenDto>> LoginAsync(UserForLoginDto userForLoginDto) {
        HttpClient httpClient = new();
        String content = JsonSerializer.Serialize(userForLoginDto);
        using StringContent jsonContent = new(content, Encoding.UTF8, "application/json");

        Uri sipayTokenServiceUri = new(this.serviceUrls.SipayTokenServiceUrl);
        HttpResponseMessage response = await httpClient.PostAsync(sipayTokenServiceUri, jsonContent);

        return response.EnsureSuccessStatusCode().IsSuccessStatusCode is false
            ? new ErrorDataResult<SipayTokenDto>("Failed")
            : new SuccessDataResult<SipayTokenDto>(
            await response.Content.ReadFromJsonAsync<SipayTokenDto>(),
            "Successfull");
    }
}
