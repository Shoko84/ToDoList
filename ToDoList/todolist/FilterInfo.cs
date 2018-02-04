namespace todolist
{
    /// <summary>
    /// Define informations for the filtering
    /// </summary>
    public class FilterInfo
    {
        /// <summary>
        /// Constructor of the <see cref="FilterInfo"/> class
        /// </summary>
        /// <param name="showTodo">Showing or not tasks to be done</param>
        /// <param name="showDone">Showing or not tasks done</param>
        public FilterInfo(bool showTodo, bool showDone)
        {
            ShowTodo = showTodo;
            ShowDone = showDone;
        }

        /// <summary>
        /// Copy constructor of the <see cref="FilterInfo"/> class
        /// </summary>
        /// <param name="other">An other <see cref="FilterInfo"/> class</param>
        public FilterInfo(FilterInfo other)
        {
            ShowTodo = other.ShowTodo;
            ShowDone = other.ShowDone;
        }

        /// <summary>
        /// Show tasks to be done
        /// </summary>
        public bool ShowTodo { get; set; }

        /// <summary>
        /// Show tasks done
        /// </summary>
        public bool ShowDone { get; set; }
    }
}
