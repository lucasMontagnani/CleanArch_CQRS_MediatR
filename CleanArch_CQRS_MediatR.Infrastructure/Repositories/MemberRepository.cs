using CleanArch_CQRS_MediatR.Domain.Abstractions;
using CleanArch_CQRS_MediatR.Domain.Entities;
using CleanArch_CQRS_MediatR.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        protected readonly AppDbContext db;
        public MemberRepository(AppDbContext _db)
        {
            this.db = _db;
        }

        public async Task<Member> GetMemberById(int memberId)
        {
            var member = await db.Members.FindAsync(memberId);
            if (member == null) throw new InvalidOperationException("Member not found");
            return member;
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            var memberList = await db.Members.ToListAsync();
            return memberList ?? Enumerable.Empty<Member>(); 
        }

        public async Task<Member> AddMember(Member member)
        {
            if (member == null) throw new ArgumentNullException(nameof(member));

            await db.Members.AddAsync(member);
            return member;
        }

        public void UpdateMember(Member member)
        {
            if( member == null) throw new ArgumentNullException(nameof(member));
            db.Members.Update(member);
        }

        public async Task<Member> DeleteMember(int memberId)
        {
            var member = await GetMemberById(memberId);
            if (member == null) throw new InvalidOperationException("Member Not Found");

            db.Members.Remove(member);
            return member;
        }
    }
}
