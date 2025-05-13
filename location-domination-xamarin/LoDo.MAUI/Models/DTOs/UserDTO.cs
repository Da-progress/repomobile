using LoDo.MAUI.Models.Enums;
using LoDo.MAUI.Models.Other;
using Newtonsoft.Json;

namespace LoDo.MAUI.Models.DTOs;

public class UserDTO
{
    [JsonProperty("accountNonExpired")] public bool AccountNonExpired { get; set; }

    [JsonProperty("accountNonLocked")] public bool AccountNonLocked { get; set; }

    [JsonProperty("address")] public AddressDTO Address { get; set; }

    [JsonProperty("authenticated")] public bool Authenticated { get; set; }

    [JsonProperty("authorities")] public List<GrantedAuthority> Authorities { get; set; }

    [JsonProperty("authorizationCode")] public string AuthorizationCode { get; set; }

    [JsonProperty("blocked")] public bool Blocked { get; set; }

    [JsonProperty("countLogin")] public int CountLogin { get; set; }

    [JsonProperty("countPasswordReset")] public int CountPasswordReset { get; set; }

    [JsonProperty("credentialsNonExpired")]
    public bool CredentialsNonExpired { get; set; }

    [JsonProperty("deleted")] public bool  Deleted { get; set; }

    [JsonProperty("displayImage")] public byte[] DisplayImage { get; set; }

    [JsonProperty("displayName")] public string DisplayName { get; set; }

    [JsonProperty("enabled")] public bool Enabled { get; set; }

    [JsonProperty("firebaseUserDeviceToken")]
    public string FirebaseUserDeviceToken { get; set; }

    [JsonProperty("firstName")] public string FirstName { get; set; }

    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("isAdmin")] public string IsAdmin { get; set; }

    [JsonProperty("isVerified")] public string IsVerified { get; set; }

    [JsonProperty("lastName")] public string LastName { get; set; }

    [JsonProperty("mobileNumber")] public string MobileNumber { get; set; }

    [JsonProperty("password")] public string Password { get; set; }

    [JsonProperty("passwordConfirm")] public string PasswordConfirm { get; set; }

    [JsonProperty("passwordHash")] public string PasswordHash { get; set; }

    [JsonProperty("receivePricePerPost")] public bool ReceivePricePerPost { get; set; }

    [JsonProperty("recordVersion")] public int RecordVersion { get; set; }

    [JsonProperty("registerDateTime")] public string RegisterDateTime { get; set; }

    [JsonProperty("userFullName")] public string UserFullName { get; set; }

    [JsonProperty("userType")] public string UserType { get; set; }

    [JsonProperty("username")] public string Username { get; set; }
}

