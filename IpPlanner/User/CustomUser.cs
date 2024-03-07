using System;
using System.ComponentModel.DataAnnotations;

public class CustomUser
{
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }

    public string LastName { get; set; } = "";

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    public string Phone { get; set; } = "";

    public string Gender { get; set; } = "";

    public string OrganizationName { get; set; } = "";

    public string AvatarUrl { get; set; } = "";

    [Required(ErrorMessage = "UID is required")]
    public string Uid { get; set; }

    public CustomUser(string uid, string firstName, string email, string lastName = "",  string phone = "", string organizationName = "", string gender = "", string avatarUrl = "")
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        OrganizationName = organizationName;
        Uid = uid;
        Gender = gender;
        AvatarUrl = avatarUrl;
    }

    public static CustomUser? CurrentUser { get; private set; }

    public static void ClearUser()
    {
        CurrentUser = null;
    }

    public static void SetUser(CustomUser? user)
    {
        CurrentUser = user;
    }

    public static void SetCurrentUser(string uid, string firstName, string lastName, string email, string phone = "", string organizationName = "", string gender = "", string avatarUrl = "")
    {
        CurrentUser = new CustomUser(firstName, lastName, email, phone, organizationName, uid, gender, avatarUrl);
    }

    public static CustomUser? GetCurrentUser () { return CurrentUser; }
}