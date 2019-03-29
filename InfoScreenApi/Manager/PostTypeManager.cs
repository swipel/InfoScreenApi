using System;
using System.Collections.Generic;
using System.Linq;
using InfoScreenApi.Models;
using InfoScreenApi.ModelsDal;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace InfoScreenApi.Manager
{
    public class PostTypeManager
    {
        public List<PostTypeDTO> GetAllPostType()
        {
            using (var context = new InfoScreenSchoolContext())
            {
                 List<PostTypeDTO> postTypes = (from p in context.PostType
                    where p.Active == true
                    select new PostTypeDTO()
                    {
                        Name = p.Name,
                        Created = p.Created
                    }).ToList();
                
                return postTypes;
            }
        }
    }
}