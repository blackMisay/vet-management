using app.core.model;
using System;
using System.Collections.Generic;
using Core;
using System.Data;

namespace app.core.repository
{
    internal class UserRepository
    {
        public bool Save(User user)
        {
            string sql;
            Dictionary<string, string> parameters = null;

            bool saveState = user.Id > 0 ? true : false;

            if (saveState)
            {
                if (user.Password.Length > 0)
                {
                    sql = "UPDATE `user` SET user_id=@Id,`username`=@UserName,`password`=@Password,`key`=@Key,fname=@FirstName,mi=@MiddleName,lastname=@LastName,email=@Email,mobilenumber=@MobileNumber,user_type=@UserType,status=@Status WHERE user_id=@Id;";
                    
                    string key = SecureHash.GenerateSalt();
                    parameters = new Dictionary<string, string>()
                    {
                        {"@Id", Convert.ToString(user.Id)},
                        {"@UserName", user.Username },
                        {"@Password", SecureHash.HashPassword(user.Password, key) },
                        {"@Key", key },
                        {"@FirstName", user.FirstName },
                        {"@MiddleName", user.MiddleName },
                        {"@LastName", user.LastName },
                        {"@Email", user.Email },
                        {"@MobileNumber", user.MobilePhone },
                        {"@UserType", user.UserType },
                        {"@Status", user.Status}
                    };
                }
                else
                {
                    sql = "UPDATE user SET user_id=@Id,username=@UserName,fname=@FirstName,mi=@MiddleName,lastname=@LastName,email=@Email,mobilenumber=@MobileNumber,user_type=@UserType,status=@Status WHERE user_id=@Id;";

                    parameters = new Dictionary<string, string>()
                    {
                        {"@Id", Convert.ToString(user.Id)},
                        {"@UserName", user.Username },
                        {"@FirstName", user.FirstName },
                        {"@MiddleName", user.MiddleName },
                        {"@LastName", user.LastName },
                        {"@Email", user.Email },
                        {"@MobileNumber", user.MobilePhone },
                        {"@UserType", user.UserType },
                        {"@Status", user.Status}
                    };
                }
            }
            else
            {
                sql = "INSERT INTO user(username,`password`,`key`,fname,mi,lastname,email,mobilenumber,user_type) VALUES(@UserName,@Password,@Key,@FirstName,@MiddleName,@LastName,@Email,@MobileNumber,@UserType);";

                string key = SecureHash.GenerateSalt();
                parameters = new Dictionary<string, string>()
                    {
                        {"@UserName", user.Username },
                        {"@Password", SecureHash.HashPassword(user.Password, key)},
                        {"@Key", key },
                        {"@FirstName", user.FirstName },
                        {"@MiddleName", user.MiddleName },
                        {"@LastName", user.LastName },
                        {"@Email", user.Email },
                        {"@MobileNumber", user.MobilePhone },
                        {"@UserType", user.UserType }
                    };
            }

            UpgradeFile upgradeFile = new UpgradeFile();
            if (upgradeFile.ExecuteQuery(sql, parameters))
                return true;
            return false;
        }

        
        public DataTable LoadUserAccount()
        {
            return LoadUserAccount("");
        }
        
        public DataTable LoadUserAccount(string searchText)
        {
            DataTable table = new DataTable();

            UpgradeFile upgradeFile = new UpgradeFile();
            if (!(string.IsNullOrEmpty(searchText) || string.IsNullOrWhiteSpace(searchText)))
            {
                return upgradeFile.Load("SELECT user_id as `id`,CONCAT(`fname`,' ',`mi`,' ',`lastname`) as `fullname`,user_type as `userType`,email,mobilenumber,`status` FROM `user` WHERE `lastname` LIKE @searchText OR `fname` LIKE @searchText OR `username` LIKE @searchText", 
                                        new Dictionary<string, string> {{ "@searchText", "%" + searchText + "%" } });

            }
            else
            {
                return upgradeFile.Load("SELECT user_id as `id`,CONCAT(`fname`,' ',`mi`,' ',`lastname`) as `fullname`,user_type as `userType`,email,mobilenumber,`status` FROM `user`");
            }
        }

        public User LoadAccountDetails(int selectedAccountId)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            DataTable dt = new DataTable();
            dt = upgradeFile.Load("SELECT * FROM `user` WHERE user_id=@Id", new Dictionary<string, string> { {"@Id", selectedAccountId.ToString() } });

            if (dt.Rows.Count > 0)
            {
                return new User
                {
                    Id = Convert.ToInt32(dt.Rows[0][0]),
                    Username = dt.Rows[0][1].ToString(),
                    Password = dt.Rows[0][2].ToString(),
                    FirstName = dt.Rows[0][4].ToString(),
                    MiddleName = dt.Rows[0][5].ToString(),
                    LastName = dt.Rows[0][6].ToString(),
                    Email = dt.Rows[0][7].ToString(),
                    MobilePhone = dt.Rows[0][8].ToString(),
                    UserType = dt.Rows[0][9].ToString(),
                    Status = dt.Rows[0][10].ToString()
                };
            }

            return null;
        }


    }
}
