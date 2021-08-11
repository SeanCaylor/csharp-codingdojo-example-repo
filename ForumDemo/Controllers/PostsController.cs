using System;
using System.Collections.Generic;
using System.Linq;
using ForumDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumDemo.Controllers
{
    public class PostsController : Controller
    {
        private ForumDemoContext db;
        public PostsController(ForumDemoContext context)
        {
            db = context;
        }

        // 1. handles GET request to DISPLAY the form used to create a new Post
        [HttpGet("/posts/new")]
        public IActionResult New()
        {
            return View("New");
        }

        // 2. handles POST request form submission to CREATE a new Post model instance
        [HttpPost("/posts/create")]
        public IActionResult Create(Post newPost)
        {
            // Every time a form is submitted, check the validations.
            if (ModelState.IsValid == false)
            {
                // Go back to the form so error messages are displayed.
                return View("New");
            }

            // The above return did not happen so ModelState IS valid.
            db.Posts.Add(newPost);
            // db doesn't update until we run save changes
            // after SaveChanges, our newPost object now has it's PostId updated from db auto generated id
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpGet("/posts")]
        public IActionResult All()
        {
            List<Post> allPosts = db.Posts.ToList();
            return View("All", allPosts);
        }

        [HttpGet("/posts/{postId}")]
        public IActionResult Details(int postId)
        {
            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);

            if (post == null)
            {
                return RedirectToAction("All");
            }

            return View("Details", post);
        }

        [HttpPost("/posts/{postId}/delete")]
        public IActionResult Delete(int postId)
        {
            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);

            if (post == null)
            {
                return RedirectToAction("All");
            }

            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpGet("/posts/{postId}/edit")]
        public IActionResult Edit(int postId)
        {
            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);

            if (post == null)
            {
                return RedirectToAction("All");
            }

            return View("Edit", post);
        }

        [HttpPost("/posts/{postId}/update")]
        public IActionResult Update(int postId, Post editedPost)
        {
            if (ModelState.IsValid == false)
            {
                editedPost.PostId = postId;
                // Send back to the page with the current form edited data to
                // display errors.
                return View("Edit", editedPost);
            }

            Post dbPost = db.Posts.FirstOrDefault(p => p.PostId == postId);

            if (dbPost == null)
            {
                return RedirectToAction("All");
            }

            dbPost.Topic = editedPost.Topic;
            dbPost.Body = editedPost.Body;
            dbPost.ImgUrl = editedPost.ImgUrl;
            dbPost.UpdatedAt = DateTime.Now;

            db.Posts.Update(dbPost);
            db.SaveChanges();

            /* 
            When redirecting to action that has params, you need to pass in a
            dict with keys that match param names and the value of the keys are
            the values for the params.
            */
            return RedirectToAction("Details", new { postId = postId });
        }
    }
}