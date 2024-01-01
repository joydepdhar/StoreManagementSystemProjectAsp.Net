using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BusinessLogicLayer.Services
{
    public class UserService
    {
        public static UserDTO AddUser(UserDTO c)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(c);
            //var data2 = DataAccessFactory.UserData().Create(data);
            var data1 = DataAccessFactory.UserData().Create(data);
            return mapper.Map<UserDTO>(data1);
        }
        public static UserDTO UpdateUser(UserDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<User>(u);
            var ret = DataAccessFactory.UserData().Update(data);
            //if (ret != false)
            return mapper.Map<UserDTO>(ret);
            //return false;
        }
        //public static UserDTO DeleteUser(int id)
        //{
        //  var ex = DataAccessFactory.UserData().Read(id);
        //var data = DataAccessFactory.UserData().Delete(ex);
        //return true;

        //      }
        public static List<UserDTO> ViewUser()
        {
            var data = DataAccessFactory.UserData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;
        }
        public static UserDTO ViewUser(int id)
        {
            var data = DataAccessFactory.UserData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            //var RET = mapper.Map<User>(data);
            return mapper.Map<UserDTO>(data);
            //return RET;
        }
        public static bool Delete(int id)
        {
            var res = DataAccessFactory.UserData().Delete(id);
            return res;
        }


    }
}
