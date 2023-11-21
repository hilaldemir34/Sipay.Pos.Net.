using Business.DTOs.ServiceResponseDtos;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Abstract {
    public interface IAuthService 
    {
       Task<IDataResult<SipayTokenDto>> LoginAsync(UserForLoginDto userForLoginDto);

    }
}