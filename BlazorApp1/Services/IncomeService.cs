// Services/IncomeService.cs
using BlazorApp1.Data.Models;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class IncomeService
    {
        private readonly ExpenseTrackerContext _context;

        public IncomeService(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Income>> GetAllIncomesAsync()
        {
            return await _context.Incomes.ToListAsync();
        }

        public async Task<Income> GetIncomeByIdAsync(int id)
        {
            return await _context.Incomes.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddIncomeAsync(Income income)
        {
            income.Date = DateTime.SpecifyKind(income.Date, DateTimeKind.Utc);
            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIncomeAsync(Income income)
        {
            _context.Entry(income).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIncomeAsync(int id)
        {
            var income = await _context.Incomes.FindAsync(id);
            if (income != null)
            {
                _context.Incomes.Remove(income);
                await _context.SaveChangesAsync();
            }
        }
    }
}
