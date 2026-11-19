using Mentorsoft.Winform.Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortWellbeing
{
    public class BaseService : MTSService
    {
        // 개발
        public string _server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        public int _port = 3306; //DB 서버 포트

        // 운영
        //public string _server = "192.168.0.100"; //DB 서버 주소, 로컬일 경우 localhost
        //public int _port = 33066; //DB 서버 포트

        public string _database = "pam"; //DB 이름
        public string _id = "root"; //계정 아이디
        public string _pw = "seesoft#1004"; //계정 비밀번호
        public string _connectionAddress = "";

        public BaseService() 
        {
            connectionDb();
        }
                
        private void connectionDb()
        { 
            //MySQL 연결을 위한 주소 형식
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);        
        }
        
    }
}
