using ChatFlow.BusinessLogic.DBModel;
using ChatFlow.Domains.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow.BusinessLogic.Core {
     public class UserApi {
          public ULoginResp UserLoginAction(ULoginData data)
          {
               User result;
               var validate = new EmailAddressAttribute();
               if (validate.IsValid(data.Email))
               {
                    //var pass = LoginHelper.HashGen(data.Password);
                    using (var db = new UserContext())
                    {
                         using (var transaction = db.Database.BeginTransaction())
                         {
                              try
                              {
                                   result = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);

                                   if (result == null)
                                   {
                                        return new ULoginResp { Status = false, StatusMsg = "The Email or Password is Incorrect" };
                                   }

                                   return new ULoginResp { Status = true };
                              }
                              catch (Exception ex)
                              {
                                   transaction.Rollback();

                                   return new ULoginResp { Status = false, StatusMsg = "An error occurred while updating the password." };
                              }
                         }
                    }
               }
               else
                    return new ULoginResp { Status = false, StatusMsg = "Incorrect Email or Password" };
          }
     }
}
