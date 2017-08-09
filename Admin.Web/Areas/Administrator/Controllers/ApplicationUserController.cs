using Admin.Data;
using Admin.Service;
using Admin.Web.App_Start;
using Admin.Web.Infrastructure.Core;
using Admin.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Web.Areas.Administrator.Controllers
{
    public class ApplicationUserController : Controller
    {
        private ApplicationUserManager _userManager;
        private IApplicationGroupService _appGroupService;
        private IApplicationRoleService _appRoleService;
        public ApplicationUserController(IApplicationGroupService appGroupService,
            IApplicationRoleService appRoleService,
            ApplicationUserManager userManager)
        {
            this._userManager = userManager;
            this._appGroupService = appGroupService;
            this._appRoleService = appRoleService;
        }
        public ActionResult Index(int page = 1, int pageSize = 20, string filter = null)
        {
            int totalRow = 0;
            var model = _userManager.Users;
            IEnumerable<ApplicationUserViewModel> modelVm = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserViewModel>>(model);

            PaginationSet<ApplicationUserViewModel> pagedSet = new PaginationSet<ApplicationUserViewModel>()
            {
                Page = page,
                TotalCount = totalRow,
                TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),
                Items = modelVm
            };
            return View();
        }
    }
}