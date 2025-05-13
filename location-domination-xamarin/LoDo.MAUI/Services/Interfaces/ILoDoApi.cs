using LoDo.MAUI.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoDo.MAUI.Models.DTOs;
using LoginResponseDto = LoDo.MAUI.Models.LoginResponseDto;

namespace LoDo.MAUI.Services.Interfaces
{
    public interface ILoDoApi
    {
        #region Login
        [Headers("Content-Type: application/json")]
        [Put("/login/register")]
        Task<UserRegisteredDTO> Register([Body] RegistrationDTO data);


        [Get("/login/testUsername")]
        Task<LoginResponseDTO> FindByName(string name);
        
        [Headers("Content-Type: application/json")]
        [Put("/login")]
        Task<LoginResponseDTO> Login([Body] RegistrationDTO data);

        [Get("/players/findByPhoneNr")]
        Task<UserDTO?> FindByPhoneNr(string phoneNr);

        [Get("/players/{id}/authenticate")]
        Task<bool> AuthenticateAsync([AliasAs("id")] int playerId, [Query] string authCode);

        #endregion

        #region User
        [Get("/players/{id}")]
        Task<UserDTO?> GetPlayerById(int id);
        

        #endregion

        #region Location

        [Get("/loc")]
        Task<IEnumerable<LocationLightDTO>> GetLocations();

        #endregion

        //[Get("/players/{id}/authenticate{authCode}")]
        // Task<bool> Authenticate([AliasAs("id")] string userId, [AliasAs("authCode")] string code);
        // #endregion
        //
        // #region Map
        // [Get("/loc/{sportIds}{sort}{onlyopengames}")]
        // Task<IEnumerable<List<LocationLight>>> GetNearLocationsWithFilter([Query(CollectionFormat.Multi), AliasAs("sportIds")] List<int> sportIds, 
        //     double? radius,[AliasAs("sort")] string sortBy, 
        //     [AliasAs("onlyopengames")]bool openGames, double latitude = 47.391126, 
        //     double longitude = 8.040069);
        // #endregion
    }
}