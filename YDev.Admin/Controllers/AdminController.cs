using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YDev.Common.Models;

namespace YDev.Admin.Controllers
{
    public abstract class AdminController : Controller
    {
        public User UserInformation = new User();
    }
}