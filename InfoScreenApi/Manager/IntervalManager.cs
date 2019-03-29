using System;
using System.Linq;
using InfoScreenApi.Models;
using InfoScreenApi.ModelsDal;
using Microsoft.EntityFrameworkCore;

namespace InfoScreenApi.Manager
{
    public class IntervalManager
    {
        public IntervalDTO GetInterval()
        {
            using (var context = new InfoScreenSchoolContext())
            {
                Setting setting = context.Setting.FirstOrDefault();
                
                IntervalDTO interval = new IntervalDTO(setting.Interval);
                
                return interval;
            }
        }

        public int UpdateInterval(IntervalDTO intervalDto)
        {
            using (var context = new InfoScreenSchoolContext())
            {
                Setting setting = context.Setting.FirstOrDefault();
                if (setting != null)
                {
                    setting.Interval = intervalDto.Interval;

                    context.Entry(setting).State = EntityState.Modified;
                    return context.SaveChanges();
                }
                return 0;
            }
        }
    }
}