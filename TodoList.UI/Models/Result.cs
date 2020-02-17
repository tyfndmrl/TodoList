using System.Collections.Generic;

namespace TodoList.UI.Models
{
    /// <summary>
    /// The result is the class to be used.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Error Model
        /// </summary>
        public ErrorModel Error { get; set; }
        /// <summary>
        /// The accuracy of the result
        /// </summary>
        public bool Success { get; set; }
    }

    /// <summary>
    /// The generic result is the class to be used.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : Result
    {
        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Success status
        /// </summary>
        private bool? success;
        public bool Success
        {
            get { return success ?? Error == null; }
            set { success = value; }
        }
    }

    public class ErrorModel
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// When there is an error with DataAnnotations
        /// </summary>
        public IEnumerable<FieldModel> Fields { get; set; }
    }

    public class FieldModel
    {
        /// <summary>
        /// Property Name
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// Property related messages
        /// </summary>
        public string[] Message { get; set; }
    }
}