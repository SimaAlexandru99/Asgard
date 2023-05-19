// <copyright file="IUserRepository.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Models
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);

        void Add(UserModel userModel);

        void Edit(UserModel userModel);

        void Remove(int id);

        UserModel GetById(int id);

        UserModel GetByUsername(string username);

        IEnumerable<UserModel> GetByAll();

        Task AuthenticateUserAsync(NetworkCredential networkCredential);

        // ...
    }
}
