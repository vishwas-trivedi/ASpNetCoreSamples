using System.ComponentModel.DataAnnotations;

namespace DefaultHttpClientFactory.Model
{
    /// <summary>
    /// Data model for HttpController
    /// </summary>
    public class HttpData
    {
        #region Properties
        /// <summary>
        /// Url of Http page we want to request
        /// </summary>
        [Required]
        public string Url { get; set; }
        #endregion
    }
}
