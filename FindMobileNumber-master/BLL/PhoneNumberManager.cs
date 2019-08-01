using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhoneNumberManager
    {
        private PhoneNumberGateway _phoneNumber;

        public PhoneNumberManager()
        {
            _phoneNumber = new PhoneNumberGateway();
        }

        public List<PhoneNumber> GetAllPhoneNymber()
        {
            return _phoneNumber.GetAllPhoneNumber();
        }

        public bool Insert(PhoneNumber mCommonTable)
        {
            return _phoneNumber.Insert(mCommonTable);
        }

        public bool Edit(PhoneNumber mPhoneNumber)
        {
            return _phoneNumber.Edit(mPhoneNumber);
        }

        public bool Delete(int Id)
        {
            return _phoneNumber.Delete(Id);
        }
        public PhoneNumber GetIdByPhoneNumber(int Id)
        {
            return _phoneNumber.GetIdByPhoneNumber(Id);
        }

    }
}
