using Admin.Data.Identity;
using Admin.Service;
using Admin.Web.Infrastructure.Extensions;
using Admin.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Web.Areas.Administrator.Controllers
{
    public class ApplicationRoleController : Controller
    {
        private IApplicationGroupService _appGroupService;
        private IApplicationRoleService _appRoleService;
        public ApplicationRoleController(IApplicationGroupService appGroupService,
            IApplicationRoleService appRoleService
           )
        {

            this._appGroupService = appGroupService;
            this._appRoleService = appRoleService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationRoleViewModel applicationRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var newApplicationRole = new ApplicationRole();
                newApplicationRole.UpdateApplicationRole(applicationRoleViewModel);
                _appRoleService.Add(newApplicationRole);
                _appRoleService.Save();

              
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}