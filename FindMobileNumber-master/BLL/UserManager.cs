using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserManager
    {
        private UserGateway _user;

        public UserManager()
        {
            _user = new UserGateway();
        }

        public List<User> GetAllUser()
        {
            return _user.GetAllUser();
        }

        public bool Insert(User mUser)
        {
            return _user.Insert(mUser);
        }

        public bool Edit(User mUser)
        {
            return _user.Edit(mUser);
        }

        public bool Delete(int Id)
        {
            return _user.Delete(Id);
        }
        public User GetIdByPhoneNumber(int Id)
        {
            return _user.GetIdByUser(Id);
        }
    }
}
