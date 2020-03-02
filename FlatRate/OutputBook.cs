using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate
{
    class OutputBook
    {
        private string filename;

        public OutputBook(string filename)
        {
            this.filename = filename;
        }

        //helper function for loading resource images rather than from file path
        static string MigraDocFilenameFromByteArray(byte[] image)
        {
            return "base64:" + Convert.ToBase64String(image);
        }

        //helper function 2 for loading resource images rather than from file path
        static byte[] LoadImage(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
                if (stream == null)
                    throw new ArgumentException("No resource with name " + name);
                int count = (int)stream.Length;
                byte[] data = new byte[count];
                stream.Read(data, 0, count);
                return data;
            }
        }

        public void writeBook(Dictionary<string, Category> categories, List<Task> taskList)
        {
            //create document
            Document doc = new Document();
            doc.Info.Title = "Favinger Plumbing Price Guide";
            doc.Info.Subject = "Flat rate pricing for plumbing jobs.";
            doc.Info.Author = "CAZ Electric, LLC";

            //define styles
            setStyle(doc);

            //define contents
            defineCover(doc);

            defineTableOfContents(doc, categories);

            defineContent(doc, categories, taskList);



            //render document
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false);
            pdfRenderer.Document = doc;

            pdfRenderer.RenderDocument();

            //save document
            pdfRenderer.PdfDocument.Save(filename);
        }

        //set styles for headings, maybe text boxes and cells?
        public void setStyle(Document doc)
        {
            Style style = doc.Styles["Normal"];

            //heading 1 style
            style = doc.Styles["Heading1"];
            style.Font.Size = 16;

            //title style
            style = doc.Styles.AddStyle("Title", "Normal");
            style.Font.Size = 24;
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            style.ParagraphFormat.SpaceBefore = 16;

            //table of contents style
            style = doc.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);

            //category heading style
            style = doc.Styles.AddStyle("Category", "Normal");
            style.Font.Size = 20;
            style.Font.Color = Colors.White;
            style.ParagraphFormat.Borders.Width = 2;
            style.ParagraphFormat.Shading.Color = Colors.Black;
            

            //footer style for page numbers
            style = doc.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

        }

        public void defineCover(Document doc)
        {

            Section coverSection = doc.AddSection();

            byte[] logo = LoadImage("FlatRate.images.logo.jpg");

            string logoFilename = MigraDocFilenameFromByteArray(logo);

            Image logoImage = coverSection.AddImage(logoFilename);
            logoImage.Width = "15cm";
            logoImage.Left = ShapePosition.Center;

            Paragraph titleP = coverSection.AddParagraph("Favinger Plumbing \nFlat Rate Pricing");
            titleP.Style = "Title";

        }

        public void defineTableOfContents(Document doc, Dictionary<string, Category> categories)
        {
            Section tableOfContentsSection = doc.AddSection();

            Paragraph title = tableOfContentsSection.AddParagraph("Table of Contents");
            title.Format.Font.Size = 16;
            title.Format.Font.Bold = true;
            title.Format.SpaceAfter = 24;

            foreach(KeyValuePair<string, Category> kvp in categories)
            {
                Paragraph paragraph = tableOfContentsSection.AddParagraph();
                paragraph.Style = "TOC";
                //hyperlink takes a string which finds the matching Bookmark
                Hyperlink link = paragraph.AddHyperlink(kvp.Key);
                link.AddText(kvp.Key);
                link.AddTab();
                link.AddPageRefField(kvp.Key);
                
            }


        }

        public void defineContent(Document doc, Dictionary<string, Category> categories, List<Task> taskList)
        {
            foreach (KeyValuePair<string, Category> kvp in categories)
            {
                Section section = doc.AddSection();

                //page number footers
                Paragraph footerP = new Paragraph();
                footerP.AddTab();
                footerP.AddPageField();
                section.Footers.Primary.Add(footerP);

                //category displayed
                Paragraph categoryParagraph = section.AddParagraph(kvp.Key);
                categoryParagraph.Style = "Category";

                //let table of contents link to category
                categoryParagraph.AddBookmark(kvp.Key);

                //now create a table for the actual info
                Table table = new Table();
                //define columns
                Column idColumn = table.AddColumn();
                Column nameDescColumn = table.AddColumn();
                Column standRateColumn = table.AddColumn();
                Column premRateColumn = table.AddColumn();

                //first row is table header
                Row tableHeader = table.AddRow();
                tableHeader.Cells[0].AddParagraph("Task");
                tableHeader.Cells[0].MergeRight = 1;
                tableHeader.Cells[2].AddParagraph("Standard Rate");
                tableHeader.Cells[3].AddParagraph("Premium Rate");

                foreach(Task task in taskList)
                {
                    if(task.category.categoryName == kvp.Key)
                    {
                        Row row = table.AddRow();
                        row.Cells[0].AddParagraph(task.taskID);
                        row.Cells[1].AddParagraph(task.title + "\n" + task.description);
                        row.Cells[2].AddParagraph(task.standardTotal.ToString());
                        row.Cells[3].AddParagraph(task.premiumTotal.ToString());
                    }
                }

                section.Add(table);
            }
        }
    }
}
