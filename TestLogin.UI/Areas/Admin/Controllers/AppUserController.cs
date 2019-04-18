using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestLogin.DAL.ORM.Entity;
using TestLogin.UI.Areas.Admin.Models.LoginVM;
using TestLogin.UI.Utility;
using System.Security.Cryptography;

namespace TestLogin.UI.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {
        // GET: Admin/AppUser
        public ActionResult Add()
        {
            return View();
           
        }

        [HttpPost]
        public ActionResult Add(Class1 data)
        {

           

            if (ModelState.IsValid)
            {
              
                var user = service.AppUserService.FindByUserName(data.UserName);   //checking appuser data on db 

                if (user is null)                                            
                {
                    
                    AppUser appUser = new AppUser() ;                        //if is doesnt exist on db , add appuser
                    appUser.UserName = data.UserName;
                    data.Password = Md5Format.EncMD5(data.Password);         
                    string password1 = data.Password;
                    data.ConfirmPassword = Md5Format.EncMD5(data.ConfirmPassword);
                    string paswword2 = data.ConfirmPassword;
                    if (password1==paswword2)                                       //checking md5 format password and confirmpas.
                    {
                        appUser.Password = password1;
                        appUser.ConfirmPassword = paswword2;
                        appUser.Role = data.Role;
                        service.AppUserService.Add(appUser);
                        return Redirect("/Admin/Home/Index");
                    }
                    else
                    {
                        return View();
                    }
                     // if ekle
                    //appUser.Role = data.Role;
                    //service.AppUserService.Add(appUser);          
                    
                }
                else
                {
                    ViewData["error"] = "Username has already taken !";  //error message
                    return View();
                }
            }
            
            return View();   

                                  
        }
    }
}