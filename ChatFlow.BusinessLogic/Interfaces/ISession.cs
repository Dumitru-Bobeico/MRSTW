using ChatFlow.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow.BusinessLogic.Interfaces {
     public interface ISession {
          ULoginResp UserLogin(ULoginData data);
     }
}
