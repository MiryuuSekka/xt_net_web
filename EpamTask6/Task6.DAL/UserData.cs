﻿using Entities;
using Task6.DAL.Interface;

namespace Task6.DAL
{
    public class UserData : AbstractData<User>
    {
        public UserData()
        {
            Manager = new Serializer<User>(PathData.User);
            Manager.OpenOrCreateFile();
        }
    }
}
