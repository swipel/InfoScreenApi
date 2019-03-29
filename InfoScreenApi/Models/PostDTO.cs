using System;
using System.Collections;
using System.Net.Mime;
using InfoScreenApi.ModelsDal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace InfoScreenApi.Models
{
    public class PostDTO
    {
        
        public long PostId { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
        public string Picture { get; set; }
        public bool Featured { get; set; }
        public DateTime Created { get; set; }
        public PostTypeDTO PostType { get; set; }
        
        public PostDTO(){}
        
        public PostDTO(int postId, String headline,string text, string picture, bool featured, DateTime created, PostTypeDTO postType)
        {
            PostId = postId;
            PostType = postType;
            Headline = headline;
            Text = text;
            Picture = picture; 
            Featured = featured;
            Created = created;
        }
    }
}