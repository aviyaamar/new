using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserGateway : BaseGateway
    {
        private bool _isSuccess;

        public UserGateway()
        {
            _isSuccess = false;
        }

        public List<User> GetAllUser()
        {
            using (var db = dbContext())
            {
                return db.Users.Include(i => i.PhoneNumber).ToList();
            }
        }

        public bool Insert(User mUser)
        {

            using (var db = dbContext())
            {
                try
                {
                    db.Entry(mUser).State = EntityState.Added;
                    db.SaveChanges();
                    _isSuccess = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _isSuccess;
        }

        public bool Edit(User mUser)
        {
            using (var db = dbContext())
            {
                try
                {

                    User editUser = (User)db.Users.Where(c => c.Id == mUser.Id);
                    if (editUser != null)
                    {
                        db.Entry(editUser).CurrentValues.SetValues(mUser);
                        db.SaveChanges();
                        _isSuccess = true;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _isSuccess;
        }

        public User GetIdByUser(int Id)
        {
            using (var db = dbContext())
            {
                return db.Users.SingleOrDefault(c => c.Id == Id);
            }
        }

        public bool Delete(int Id)
        {
            using (var db = dbContext())
            {
                try
                {
                    User deleteUser = db.Users.SingleOrDefault(c => c.Id == Id);
                    PhoneNumber deletePhoneNumber = db.PhoneNumbers.SingleOrDefault(c => c.Id == deleteUser.PhoneNumberTableId);

                    db.Users.Remove(deleteUser);
                    db.PhoneNumbers.Remove(deletePhoneNumber);
                    db.SaveChanges();
                    _isSuccess = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _isSuccess;
        }
    }
}
