﻿using System;

namespace SimpleTrader.Domain.Models
{
    public class User : DomainObject
    {
        #region Properties

        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateJoined { get; set; }

        #endregion
    }
}
