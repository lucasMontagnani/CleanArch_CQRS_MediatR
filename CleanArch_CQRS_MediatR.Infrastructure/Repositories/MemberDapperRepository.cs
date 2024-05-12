﻿using CleanArch_CQRS_MediatR.Domain.Abstractions;
using CleanArch_CQRS_MediatR.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.Infrastructure.Repositories
{
    public class MemberDapperRepository : IMemberDapperRepository
    {
        public readonly IDbConnection _dbConnection;
        public MemberDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<Member>> GetMembers()
        {
            string query = "SELECT * FROM Members";
            return await _dbConnection.QueryAsync<Member>(query);
        }

        public async Task<Member> GetMembersById(int id)
        {
            string query = "SELECT * FROM Members WHERE Id = @id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Member>(query, new { Id = id });
        }
    }
}
