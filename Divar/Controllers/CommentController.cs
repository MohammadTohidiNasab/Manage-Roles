﻿namespace Divar.Controllers
{
    public class CommentController : Controller
    {
        private readonly string _connectionString;

        public CommentController()
        {
            _connectionString = "Server=.; Initial Catalog=DivarDb; Integrated Security=True; encrypt=False";
        }

        // Create comment
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("sp_InsertComment", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Body", comment.Body);
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                    await command.ExecuteNonQueryAsync();
                }
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // Comment list
        public async Task<IActionResult> Index()
        {
            var comments = new List<Comment>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT Id, Body, CreatedDate FROM Comments", connection);
                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    comments.Add(new Comment
                    {
                        Id = reader.GetInt32(0),
                        Body = reader.GetString(1),
                        CreatedDate = reader.GetDateTime(2)
                    });
                }
            }

            return View(comments);
        }
    }
}

