using DataAccessLayer;
using DVLD1_BusinessLayer;
using DVLD1_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUsersBusiness
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode mode = enMode.AddNew;
        
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
   

        public clsUsersBusiness()
        {
            
            this.UserID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            this.IsActive = true;

            mode = enMode.AddNew;
        }

        private clsUsersBusiness(int UserID, int personID, string Username, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = personID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            mode = enMode.Update;
        }

        public static clsUsersBusiness Find(int UserID)
        {
            int PersonID = -1; string Username = ""; string Password = ""; bool IsActive = true;

            bool IsFound = clsUsersDataAccess.GetUserDataByID (UserID, ref PersonID, ref Username, ref Password, ref IsActive);

            if (IsFound)
            {
                // with parameters إذا بيلاقيه بيرجع الكونستراكتر الكامل 
                return new clsUsersBusiness(UserID, PersonID, Username, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsPeopleBusiness Find(string NationalNo)
        {
            int PersonID = -1; string FirstName = ""; string SecondName = ""; string ThirdName = ""; string LastName = "";
            DateTime DateOfBirth = DateTime.Now; short Gender = 0; string Address = ""; string Phone = ""; string Email = "";
            int Nationality = -1; string ImagePath = "";

            bool IsFound = clsPeopleDataAccess.GetPersonDataByNationalNo
                            (
                                ref PersonID, NationalNo, ref FirstName, ref SecondName,
                                ref ThirdName, ref LastName, ref DateOfBirth, ref Gender,
                                ref Address, ref Phone, ref Email, ref Nationality, ref ImagePath
                            );

            if (IsFound)
            {
                // with parameters إذا بيلاقيه بيرجع الكونستراكتر الكامل 
                return new clsPeopleBusiness(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, Nationality, ImagePath);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewPerson()
        {
            //call DataAccessLayer 
            this.PersonID = clsPeopleDataAccess.AddNewPerson
                            (
                                this.NationalNo, this.FirstName, this.SecondName,
                                this.ThirdName, this.LastName, this.DateOfBirth,
                                this.Gender, this.Address, this.Phone, this.Email,
                                this.Nationality, this.ImagePath
                            );

            return (this.PersonID != -1);
        }

        private bool _UpdatePersonData()
        {
            //call DataAccessLayer
            return clsPeopleDataAccess.UpdatePersonData
                    (
                        this.PersonID, this.NationalNo, this.FirstName,
                        this.SecondName, this.ThirdName, this.LastName,
                        this.DateOfBirth, this.Gender, this.Address,
                        this.Phone, this.Email, this.Nationality, this.ImagePath
                    );
        }

        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewPerson())
                        {
                            mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    return _UpdatePersonData();
            }
            return false;
        }

        // أيضاً نستخدم للحذف دالة استاتيك على مستوى الكلاس وليس من خلال الاوبجكت
        // حيث من خلال الاوبجكت يتم حذف الأوبجكت ولكن تظل المعلومات في الميموري
        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleDataAccess.DeletePerson(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleDataAccess.GetAllPeople();
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPeopleDataAccess.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPeopleDataAccess.IsPersonExist(NationalNo);
        }
    }
}
