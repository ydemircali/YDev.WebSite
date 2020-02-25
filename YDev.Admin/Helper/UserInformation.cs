using System;
using YDev.Common.Models;

public static class UserInformation 
{
    public static long Id { get; set; }
    public static string Name { get; set; }
    public static string SurName { get; set; }
    public static string UserName { get; set; }
    public static string Password { get; set; }
    public static string ImagePath { get; set; }
    public static string Phone { get; set; }
    public static string Address { get; set; }
    public static string Email { get; set; }
    public static byte Status { get; set; }
    public static long RoleId { get; set; }
    public static RoleTypes Role { get; set; }
    public static long TitleId { get; set; }
    public static Title Title { get; set; }

}