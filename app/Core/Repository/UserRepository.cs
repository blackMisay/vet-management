using app.core.model;
using System;
using System.Collections.Generic;
using Core;

namespace app.core.repository
{
    internal class UserRepository
    {
        public bool Save(User user)
        {
            string sql;

            bool saveState = user.Id > 0 ? true : false;

            if (saveState)
            {
                sql = "UPDATE user SET user_id=@Id,username=@UserName,password=@Password WHERE user_id=@Id;";
            }
            else
            {
                sql = "INSERT INTO user(user_id,username,password) VALUES(@Id,@UserName,@Password);";
            }
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@Id", Convert.ToString(user.Id)},
                {"@UserName", user.UserName },
                {"@Password", user.Password },
            };

            UpgradeFile upgradeFile = new UpgradeFile();
            if (upgradeFile.ExecuteQuery(sql, parameters))
                return true;
            return false;
        }
    }
}
