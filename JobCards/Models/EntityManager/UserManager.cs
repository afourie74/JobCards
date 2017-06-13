using JobCards.Models.Database;
using JobCards.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobCards.Models.EntityManager
{
    public class UserManager
    {
        public void AddUserAccount(UserSignUpView user)
        {

            using (DigiFusionEntities db = new DigiFusionEntities())
            {

                SYSUser SU = new SYSUser();
                SU.LoginName = user.LoginName;
                SU.PasswordEncryptedText = user.Password;
                SU.CreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SU.ModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1; ;
                SU.CreatedDateTime = DateTime.Now;
                SU.ModifiedDateTime = DateTime.Now;

                db.SYSUsers.Add(SU);
                db.SaveChanges();

                SYSUserProfile SUP = new SYSUserProfile();
                SUP.SYSUserID = SU.SYSUserID;
                SUP.FirstName = user.FirstName;
                SUP.LastName = user.LastName;
                SUP.Gender = user.Gender;
                SUP.CreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SUP.ModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SUP.CreatedDateTime = DateTime.Now;
                SUP.ModifiedDateTime = DateTime.Now;

                db.SYSUserProfiles.Add(SUP);
                db.SaveChanges();

                Role userRole = db.Roles.FirstOrDefault(x => x.Name.ToUpper() == "USER");
                if (userRole != null)
                {
                    SYSUserRole SUR = new SYSUserRole();
                    SUR.RoleID = userRole.RoleID;
                    SUR.SYSUserID = SU.SYSUserID;
                    SUR.IsActive = true;
                    SUR.CreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                    SUR.ModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                    SUR.CreatedDateTime = DateTime.Now;
                    SUR.ModifiedDateTime = DateTime.Now;

                    db.SYSUserRoles.Add(SUR);
                    db.SaveChanges();
                }

                //if (user.RoleID > 0)
                //{
                //    SYSUserRole SUR = new SYSUserRole();
                //    SUR.RoleID = user.RoleID;
                //    SUR.SYSUserID = user.SYSUserID;
                //    SUR.IsActive = true;
                //    SUR.CreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                //    SUR.ModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                //    SUR.CreatedDateTime = DateTime.Now;
                //    SUR.ModifiedDateTime = DateTime.Now;

                //    db.SYSUserRoles.Add(SUR);
                //    db.SaveChanges();
                //}
            }
        }

        public bool IsLoginNameExist(string loginName)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                return db.SYSUsers.Where(o => o.LoginName.Equals(loginName)).Any();
            }
        }

        public string GetUserPassword(string loginName)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                var user = db.SYSUsers.Where(o => o.LoginName.ToLower().Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().PasswordEncryptedText;
                else
                    return string.Empty;
            }
        }

        public bool IsUserInRole(string loginName, string roleName)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                SYSUser SU = db.SYSUsers.Where(o => o.LoginName.ToLower().Equals(loginName))?.FirstOrDefault();
                if (SU != null)
                {
                    var roles = from q in db.SYSUserRoles
                                join r in db.Roles on q.RoleID equals r.RoleID
                                where r.Name.Equals(roleName) && q.SYSUserID.Equals(SU.SYSUserID)
                                select r.Name;

                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }

                return false;
            }
        }

        //public bool CreateJobCard(JobCardView jobCard)
        //{
        //    using (DigiFusionEntities db = new Database.DigiFusionEntities())
        //    {
        //        try
        //        {
        //            JobCard jc = new JobCard
        //            {
        //                CustomerID = (Guid)jobCard.CustomerID,
        //                DesignerID = (Guid)jobCard.DesignerID,
        //                JobDate = jobCard.JobDate,
        //                JobTypeID = jobCard.JobTypeID,
        //                MaterialID = jobCard.MaterialID,
        //                QuoteRef = jobCard.QuoteRef
        //            };

        //            db.JobCards.Add(jc);
        //            db.SaveChanges();


        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        public string[] GetAllRolesForUser(string userName)
        {
            using (DigiFusionEntities db = new Database.DigiFusionEntities())
            {
                var userID = db.SYSUsers.SingleOrDefault(x => x.LoginName == userName).SYSUserID;
                var roleIDs = db.SYSUserRoles.Where(x => x.SYSUserID == userID).Select(y => y.RoleID).ToList();
                var result = db.Roles.Where(x => roleIDs.Contains(x.RoleID)).Select(y => y.Name).ToArray();
                return result;
            }
        }
    }
}