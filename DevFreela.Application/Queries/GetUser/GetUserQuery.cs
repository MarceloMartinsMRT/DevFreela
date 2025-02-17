﻿using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<User>
    {
        public int Id { get; private set; }

        public GetUserQuery(int id) 
        {
            Id = id;
        }
    }
}
