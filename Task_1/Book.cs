using System;

namespace HW_1
{
    [Serializable]
    public class Book
    {
        /// <summary>
        /// Автор
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Жанр
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Дата выхода
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int NumberOfPages { get; set; }

        public override string ToString()
        {
            return Author + " " + Title + " " + Genre + " " + PublicationDate.ToLongDateString() + " " + NumberOfPages;
        }
    }
}