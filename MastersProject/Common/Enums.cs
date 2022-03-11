using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MastersProject.Common
{
    public class Enums
    {
          public enum RowStatus : int
            {
                Active = 1,
                Inactive = 2
            }
            public enum ApprovalStatus : int
            {
                Pending = 1,
                Approve = 2,
                Reject = 3
            }
            public enum HomeWorkStatus : int
            {
                Done = 1,
                Pending = 2
            }
            public enum BoardType : int
            {
                GujaratBoard = 1,
                CBSC = 2,
                Both = 3
            }
            public enum Gender : int
            {
                Male = 1,
                Female = 2,
                Transgender = 3
            }


            public enum ResultMessageLevel : int
            {
                Error = 1,
                Warning = 2,
                Info = 3
            }

            public enum UserType : int
            {
                SuperAdmin = 5,
                Admin = 1,
                Student = 2,
                Parent = 3,
                Staff = 4
            }

            public enum ClassID : int
            {
                BatchTime = 1,
                UserType = 2,
                RowStatus = 3
            }

            public enum TransactionType : int
            {
                Insert = 1,
                Update = 2,
                Delete = 3
            }

            public enum BatchType : int
            {
                Morning = 1,
                Afternoon = 2,
                Evening = 3
            }


            public enum Roles : int
            {
                Student = 1,
                Staff = 2,
                Standard = 3,
                School = 4,
                Subject = 5,
                Announcement = 6,
                Batch = 7,
                OnlinePayment = 8,
                AddUpiDetail = 9,
                Attendance = 10,
                TestSchedule = 11,
                TestMarks = 12,
                FeeStructure = 13,
                PracticePaper = 14,
                Homework = 15,
                Gallery = 16,
                Video = 17,
                LiveVideo = 18,
                UploadTestPaper = 19
            }
        }
    }
