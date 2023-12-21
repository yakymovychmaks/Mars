﻿using DLL.DataAccess;
using DLL.Interface;
using DLL.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly ApplicationDbContext _dbContext;
        public CommentRepository (ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task Create(Comment entity)
        {
            await _dbContext.Comments.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Comment entity)
        {
            _dbContext.Comments.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetAll()
        {
            return _dbContext.Comments.ToList();
        }

        public async Task<Comment> GetById(int id)
        {

            var result = await _dbContext.Comments.FindAsync(id);
            return result;

        }

        public async Task<Comment> Update(Comment entity)
        {
            var result = await _dbContext.Comments.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
