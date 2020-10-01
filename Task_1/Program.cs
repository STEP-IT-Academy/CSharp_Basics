using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HW_1
{
    class Program
    {
        static void ValidationCallBack(object sender, ValidationEventArgs eventArgs)
        {
            if (eventArgs.Severity == XmlSeverityType.Warning)
                Console.WriteLine("\tОшибка: Выбранная схема не найдена.  Валидация не прошла." + eventArgs.Message);
            else
                Console.WriteLine("\tОшибка валидации: " + eventArgs.Message);
        }

        static void Main(string[] args)
        {
            try
            {
                // Проверка корректности данных в XML–файле в соответствии с XSD–схемой.
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add("http://tempuri.org/Books.xsd", "BooksScheme.xsd");

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = schemaSet;
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

                XmlReader xmlReader = XmlReader.Create("Books.xml", settings);
                while (xmlReader.Read()) { };

                // Формирование параметризованной коллекции объектов класса «Книга» из XML–файла, используя класс XmlReader
                Book book = null;
                List<Book> books = new List<Book>();

                using (XmlReader reader = XmlReader.Create("Books.xml"))
                {
                    while (reader.Read())
                    {
                        if (reader.GetAttribute("Genre") != null)
                        {
                            book = new Book();
                            book.Genre = reader.GetAttribute("Genre");
                        }

                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            switch (reader.Name)
                            {
                                case "Author": book.Author = reader.ReadElementContentAsString(); break;
                                case "Title": book.Title = reader.ReadElementContentAsString(); break;
                                case "PublicationDate": book.PublicationDate = DateTime.Parse(reader.ReadElementContentAsString()); break;
                                case "NumberOfPages": book.NumberOfPages = int.Parse(reader.ReadElementContentAsString()); books.Add(book); break;
                            }
                        }
                    }
                }

                // Вывод коллекции на экран
                books.ForEach(b => Console.WriteLine(b));

                // Сериализация отсортированной по авторам коллекции в XML-формате.
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Book>));
                using (FileStream fstream = new FileStream("Books_new.xml", FileMode.Create, FileAccess.Write))
                {
                    xmlSerializer.Serialize(fstream, books.OrderByDescending(b => b.Author).ToList());
                }

                // Запись информации о книгах заданного жанра в новый файл, используя класс XmlDocument
                XmlDocument xmlDoc = new XmlDocument();

                XmlNode rootNode = xmlDoc.CreateElement("Books");
                xmlDoc.AppendChild(rootNode);

                foreach (Book item in books)
                {
                    if (item.Genre == "Рассказ")
                    {
                        XmlNode bookNode = xmlDoc.CreateElement("Book");

                        XmlAttribute attribute = xmlDoc.CreateAttribute("Genre");
                        attribute.InnerText = item.Genre;
                        bookNode.Attributes.Append(attribute);

                        XmlNode authorNode = xmlDoc.CreateElement("Author");
                        authorNode.InnerText = item.Author;
                        bookNode.AppendChild(authorNode);

                        XmlNode titleNode = xmlDoc.CreateElement("Title");
                        titleNode.InnerText = item.Title;
                        bookNode.AppendChild(titleNode);

                        XmlNode publicationDateNode = xmlDoc.CreateElement("PublicationDate");
                        publicationDateNode.InnerText = item.PublicationDate.ToLongDateString().ToString();
                        bookNode.AppendChild(publicationDateNode);

                        XmlNode numberOfPagesNode = xmlDoc.CreateElement("NumberOfPages");
                        numberOfPagesNode.InnerText = item.NumberOfPages.ToString();
                        bookNode.AppendChild(numberOfPagesNode);

                        rootNode.AppendChild(bookNode);
                    }
                }
                xmlDoc.Save("BooksTest.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}