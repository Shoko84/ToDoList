using System;

namespace todolist
{
    /// <summary>
    /// Contains informations about a Task
    /// </summary>
    public class TaskInfo
    {
        /// <summary>
        /// Constructor of the <see cref="TaskInfo"/> class
        /// </summary>
        /// <param name="id">The <see cref="Task"/> identifier</param>
        /// <param name="title">The title of the <see cref="Task"/></param>
        /// <param name="content">The content of the <see cref="Task"/></param>
        /// <param name="due">The date planified to be done of the <see cref="Task"/></param>
        /// <param name="completed">Is the <see cref="Task"/> has been done</param>
        public TaskInfo(UInt32 id = 0, string title = "", string content = "", DateTime? due = null, bool completed = false)
        {
            Id = id;
            Title = title;
            Content = content;
            Due = due;
            Completed = completed;
        }

        /// <summary>
        /// Copy constructor of the <see cref="TaskInfo"/> class
        /// </summary>
        /// <param name="other">An other <see cref="TaskInfo"/> class</param>
        public TaskInfo(TaskInfo other)
        {
            Id = other.Id;
            Title = other.Title;
            Content = other.Content;
            Due = other.Due;
            Completed = other.Completed;
        }

        /// <summary>
        /// The <see cref="Task"/> identifier
        /// </summary>
        public UInt32 Id { get; set; }

        /// <summary>
        /// The title of the <see cref="Task"/>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The content of the <see cref="Task"/>
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The date planified to be done of the <see cref="Task"/>
        /// </summary>
        public DateTime? Due { get; set; }

        /// <summary>
        /// Is the <see cref="Task"/> has been done
        /// </summary>
        public bool Completed { get; set; }
    }
}
