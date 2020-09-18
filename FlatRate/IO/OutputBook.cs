using FlatRate.Model;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FlatRate
{
    class OutputBook
    {
        private readonly string filename;
        private DataManager dataManager = DataManager.GetInstance();
        private readonly PdfAuthorInfo MetaInfo;
        private Document doc;

        public OutputBook(string filename, PdfAuthorInfo info)
        {
            this.filename = filename;
            MetaInfo = info;
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

        public void writeBook()
        {
            //create document
            doc = new Document();
            doc.Info.Title = MetaInfo.Title;
            doc.Info.Subject = "Flat rate pricing for plumbing jobs.";
            doc.Info.Author = MetaInfo.Author;

            //define styles
            setStyle();

            //define contents
            defineCover();

            defineTableOfContents();

            defineContent();

            //render document
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false);
            pdfRenderer.Document = doc;

            pdfRenderer.RenderDocument();

            pdfRenderer.PdfDocument.Save(filename);

        }

        //set styles for headings, maybe text boxes and cells?
        public void setStyle()
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

            //subtitle style
            style = doc.Styles.AddStyle("Subtitle", "Normal");
            style.Font.Size = 20;
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            style.ParagraphFormat.SpaceBefore = 24;

            //table of contents style
            style = doc.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);

            //category heading style
            style = doc.Styles.AddStyle("Category", "Normal");
            style.Font.Size = 20;
            style.Font.Color = Colors.White;
            style.ParagraphFormat.Borders.Width = 2;
            style.ParagraphFormat.Shading.Color = Colors.Black;
            style.ParagraphFormat.LeftIndent = 0;

            //subcategory heading style
            style = doc.Styles.AddStyle("Subcategory", "Normal");
            style.Font.Size = 16;
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            style.ParagraphFormat.Borders.Bottom.Width = 2;

            //id style
            style = doc.Styles.AddStyle("id", "Normal");
            style.Font.Size = 8;

            //desc style
            style = doc.Styles.AddStyle("desc", "Normal");
            style.Font.Size = 8;

            //footer style for page numbers
            style = doc.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

        }

        public void defineCover()
        {

            Section coverSection = doc.AddSection();

            String logoFilename;

            if(MetaInfo.ImageFilePath == "")
            {
                byte[] logo = LoadImage("FlatRate.Resources.logo.jpg");

                logoFilename = MigraDocFilenameFromByteArray(logo);
            }
            else
            {
                logoFilename = MetaInfo.ImageFilePath;
            }

            Image logoImage = coverSection.AddImage(logoFilename);
            logoImage.Width = "15cm";
            logoImage.Left = ShapePosition.Center;

            Paragraph titleP = coverSection.AddParagraph(MetaInfo.Title);
            titleP.Style = "Title";

            Paragraph authorP = coverSection.AddParagraph(MetaInfo.Author);
            authorP.Style = "Subtitle";

        }

        public void defineTableOfContents()
        {
            Section tableOfContentsSection = doc.AddSection();

            Paragraph title = tableOfContentsSection.AddParagraph("Table of Contents");
            title.Format.Font.Size = 16;
            title.Format.Font.Bold = true;
            title.Format.SpaceAfter = 24;

            List<Category> categories = dataManager.GetCategories();
            foreach(Category category in categories)
            {
                Paragraph paragraph = tableOfContentsSection.AddParagraph();
                paragraph.Style = "TOC";
                //hyperlink takes a string which finds the matching Bookmark
                //use ID ToString since ID is the PK
                Hyperlink link = paragraph.AddHyperlink(category.Id.ToString());
                link.AddText(category.Title);
                link.AddTab();
                link.AddPageRefField(category.Id.ToString());
            }
        }

        public void defineContent()
        {
            //organized by category
            foreach(Category category in dataManager.GetCategories())
            {
                Section section = doc.AddSection();

                section.PageSetup = doc.DefaultPageSetup.Clone();

                Unit sectionWidth = section.PageSetup.PageWidth - section.PageSetup.LeftMargin - section.PageSetup.RightMargin;

                //page number footers --done here because it must be added to a section
                Paragraph footerP = new Paragraph();
                footerP.AddTab();
                footerP.AddPageField();
                section.Footers.Primary.Add(footerP);

                //category displayed
                Paragraph categoryParagraph = section.AddParagraph(category.Title);
                categoryParagraph.Style = "Category";

                //let table of contents link to category
                categoryParagraph.AddBookmark(category.Id.ToString());

                List<Subcategory> subcategories = dataManager.GetSubcategoriesByCategoryId(category.Id);

                foreach(Subcategory subcategory in dataManager.GetSubcategoriesByCategoryId(category.Id))
                {
                    Paragraph subcategoryParagraph = section.AddParagraph(subcategory.Title);
                    subcategoryParagraph.Style = "Subcategory";

                    //now create a table for the actual info
                    //also border/etc styling-- it appears that cannot be handled by named styles
                    Table table = new Table();
                    table.Borders.Width = 0.75;
                    table.Rows.LeftIndent = 0;

                    //define columns
                    Column idColumn = table.AddColumn(sectionWidth * 0.15);
                    Column nameDescColumn = table.AddColumn(sectionWidth * 0.55);
                    Column standRateColumn = table.AddColumn(sectionWidth * 0.15);
                    standRateColumn.Format.Alignment = ParagraphAlignment.Center;
                    Column premRateColumn = table.AddColumn(sectionWidth * 0.15);
                    premRateColumn.Format.Alignment = ParagraphAlignment.Center;

                    //first row is table header
                    Row tableHeader = table.AddRow();
                    tableHeader.Cells[0].AddParagraph("Task");
                    tableHeader.Cells[0].MergeRight = 1;
                    tableHeader.Cells[2].AddParagraph("Standard");
                    tableHeader.Cells[3].AddParagraph("Premium");

                    foreach (TaskSummary taskSummary in dataManager.GetTaskSummariesBySubcategoryId(subcategory.Id))
                    {
                        Row row = table.AddRow();
                        Paragraph idparagraph = row.Cells[0].AddParagraph(taskSummary.Id);
                        idparagraph.Style = "id";
                        idparagraph.Format.Alignment = ParagraphAlignment.Center;
                        row.Cells[0].VerticalAlignment = VerticalAlignment.Center;

                        Paragraph hoursParagraph = row.Cells[0].AddParagraph(taskSummary.Hours.ToString("F"));
                        hoursParagraph.Style = "id";
                        hoursParagraph.Format.Alignment = ParagraphAlignment.Center;

                        Paragraph titleParagraph = row.Cells[1].AddParagraph(taskSummary.Title);
                        
                        Paragraph descParagraph = row.Cells[1].AddParagraph(taskSummary.Description);
                        descParagraph.Style = "desc";
                        row.Cells[2].AddParagraph(taskSummary.StandardTotal.ToString("F"));
                        row.Cells[2].VerticalAlignment = VerticalAlignment.Center;

                        row.Cells[3].AddParagraph(taskSummary.PremiumTotal.ToString("F"));
                        row.Cells[3].VerticalAlignment = VerticalAlignment.Center;
                    }
                    section.Add(table);
                }
            }
        }
    }
}
