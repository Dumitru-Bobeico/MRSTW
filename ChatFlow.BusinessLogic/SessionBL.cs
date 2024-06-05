using ChatFlow.BusinessLogic.Core;
using ChatFlow.BusinessLogic.Interfaces;
using ChatFlow.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatFlow.BusinessLogic {
     public class SessionBL : UserApi, ISession {
          public ULoginResp UserLogin(ULoginData data)
          {
               return new UserLoginAction(data);
          }
     }
}
