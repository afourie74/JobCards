using JobCards.Models.EntityManager;
using JobCards.Models.ViewModel;
using System.Web.Mvc;
using System.Web.Security;

namespace JobCards.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserSignUpView USV)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                if (!UM.IsLoginNameExist(USV.LoginName))
                {
                    UM.AddUserAccount(USV);

                    UserManager manager = new UserManager();

                    FormsAuthentication.SetAuthCookie(USV.LoginName, false);

                    var roles = manager.GetAllRolesForUser(USV.LoginName);
                    foreach (var role in roles)
                    {
                        if (!Roles.RoleExists(role)) Roles.CreateRole(role);
                        if (!Roles.IsUserInRole(USV.LoginName, role)) Roles.AddUserToRole(USV.LoginName, role);
                    }

                    return RedirectToAction("Welcome", "Home");
                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginView ULV, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                string password = UM.GetUserPassword(ULV.LoginName);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else
                {
                    if (ULV.Password.Equals(password))
                    {
                        UserManager manager = new UserManager();
                        
                        FormsAuthentication.SetAuthCookie(ULV.LoginName, false);

                        var roles = manager.GetAllRolesForUser(ULV.LoginName);
                        foreach(var role in roles)
                        {
                            if (!Roles.RoleExists(role)) Roles.CreateRole(role);
                            if (!Roles.IsUserInRole(ULV.LoginName, role)) Roles.AddUserToRole(ULV.LoginName, role);
                        }

                        return RedirectToAction("Welcome", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(ULV);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}