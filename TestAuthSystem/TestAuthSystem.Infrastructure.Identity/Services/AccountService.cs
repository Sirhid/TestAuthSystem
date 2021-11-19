﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Cache;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestAuthSystem.Application.DTOs.Account;
using TestAuthSystem.Application.DTOs.Email;
using TestAuthSystem.Application.Enums;
using TestAuthSystem.Application.Exceptions;
using TestAuthSystem.Application.Interfaces;
using TestAuthSystem.Application.Wrappers;
using TestAuthSystem.Domain.Settings;
using TestAuthSystem.Infrastructure.Identity.Contexts;
using TestAuthSystem.Infrastructure.Identity.Helpers;
using TestAuthSystem.Infrastructure.Identity.Models;

namespace TestAuthSystem.Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {

        private readonly IdentityContext _context;

        public AccountService(IdentityContext identityContext)
        {
            _context = identityContext;
        }

        public async Task<List<MetricStatisticDTO>> GetStatictics(DateTime startDate, DateTime endDate, string metric, bool isSuccess)
        {
            var response = new List<MetricStatisticDTO>();

            switch (metric.ToLower())
            {
                case "hour":
                    response = await GetHourlyStats(startDate, endDate, isSuccess);
                    break;

                case "month":
                    response = await GetMonthlyStats(startDate, endDate, isSuccess);
                    break;

                case "year":
                    response = await GetYearlyStats(startDate, endDate, isSuccess);
                    break;

                default:
                    
                    break;
            }

            return response;
        }

        private async Task<List<MetricStatisticDTO>> GetHourlyStats(DateTime startDate, DateTime endDate, bool? isSuccess)
        {
            var stat = await _context.UserLoginAttempt
                       .Where(c => c.AttemptTime >= startDate && c.AttemptTime <= endDate && c.IsSuccess == isSuccess)
                       .GroupBy(c => c.AttemptTime.Hour)
                       .Select(c => new MetricStatisticDTO
                       {
                           Period = c.Key.ToString(),
                           Value = c.Count()
                       }).ToListAsync();

            return stat;
        }
        private async Task<List<MetricStatisticDTO>> GetMonthlyStats(DateTime startDate, DateTime endDate, bool? isSuccess)
        {
            var stat = await _context.UserLoginAttempt
                       .Where(c => c.AttemptTime >= startDate && c.AttemptTime <= endDate && c.IsSuccess == isSuccess)
                       .GroupBy(c => c.AttemptTime.Month)
                       .Select(c => new MetricStatisticDTO
                       {
                           Period = c.Key.ToString(),
                           Value = c.Count()
                       }).ToListAsync();

            return stat;
        }
        private async Task<List<MetricStatisticDTO>> GetYearlyStats(DateTime startDate, DateTime endDate, bool isSuccess)
        {
            var stat = await _context.UserLoginAttempt
                       .Where(c => c.AttemptTime >= startDate && c.AttemptTime <= endDate && c.IsSuccess == isSuccess)
                       .GroupBy(c => c.AttemptTime.Year)
                       .Select(c => new MetricStatisticDTO
                        {
                            Period = c.Key.ToString(),
                            Value = c.Count()
                        }).ToListAsync();

            return stat;
        }


        public async Task<List<UserLoginAttemptsDTO>> GetUserLoginAttemptsByEmail(string email)
        {
            var attempts = new List<UserLoginAttemptsDTO>();
            try
            {
                attempts = await _context.UserLoginAttempt
                         .Include(c => c.User)
                         .Where(c => c.User.Email == email)
                         .Select(c => new UserLoginAttemptsDTO
                         {
                             Id = c.Id,
                             AttemptTime = c.AttemptTime,
                             IsSuccess = c.IsSuccess
                         }).ToListAsync();

                return attempts;
            }
            catch (Exception ex)
            {

                //logs error
                return attempts;
            }


        }
    }
}

