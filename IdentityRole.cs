﻿using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.AspNet.Identity
{
    public class IdentityRole : IdentityRole<string, IdentityUserRole>
    {
        public IdentityRole()
        {
            var newId = ObjectId.GenerateNewId();
            base.Id = newId.ToString();
        }

        public IdentityRole(string roleName)
            : this()
        {
            base.Name = roleName;
        }
    }


    public class IdentityRole<TKey, TUserRole> : IRole<TKey>
        where TUserRole : IdentityUserRole<TKey>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public TKey Id { get; set; }
        public string Name { get; set; }

        public ICollection<TUserRole> Users { get; set; }

        public virtual ICollection<TUserRole> GetUsers()
        {
            return Users;
        }

        public IdentityRole()
        {
            Users = new List<TUserRole>();
        }

    }
}