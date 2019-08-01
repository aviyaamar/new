using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhoneNumberGateway : BaseGateway
    {
        private bool _isSuccess;

        public PhoneNumberGateway()
        {
            _isSuccess = false;
        }

        public List<PhoneNumber> GetAllPhoneNumber()
        {
            using (var db = dbContext())
            {
                //var aa= db.PhoneNumbers.Join()
                //var result = (from mPhone in db.PhoneNumbers
                //              join mUser in db.Users on mPhone.Id equals mUser.Id
                //              select new CommonTable
                //              {
                //                  Id = mUser.Id,
                //                  FirstName = mUser.FirstName,
                //                  Surname = mUser.Surname,
                //                  Country = mPhone.Country,
                //                  TelephoneNumber = mPhone.TelephoneNumber,
                //                  Owner = mPhone.Owner,
                //                  lastStatusChange = mPhone.lastStatusChange
                //              }).ToList();
                //return result.ToList();
                return db.PhoneNumbers.Include(w => w.Users).ToList();
            }
        }

        public bool Insert(PhoneNumber mPhoneNumber)
        {
            using (var db = dbContext())
            {
                try
                {
                    db.Entry(mPhoneNumber).State = EntityState.Added;
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

        public bool Edit(PhoneNumber mPhoneNumber)
        {
            using (var db = dbContext())
            {
                try
                {
                    PhoneNumber editPhoneNumber = (PhoneNumber)db.PhoneNumbers.Where(c => c.Id == mPhoneNumber.Id);
                    if (editPhoneNumber != null)
                    {
                        db.Entry(editPhoneNumber).CurrentValues.SetValues(mPhoneNumber);
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
        public PhoneNumber GetIdByPhoneNumber(int Id)
        {
            using (var db = dbContext())
            {
                return db.PhoneNumbers.SingleOrDefault(c => c.Id == Id);
            }
        }
        public bool Delete(int Id)
        {
            using (var db = dbContext())
            {
                try
                {
                    PhoneNumber deleteItem = db.PhoneNumbers.SingleOrDefault(c => c.Id == Id);
                    db.PhoneNumbers.Remove(deleteItem);
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
