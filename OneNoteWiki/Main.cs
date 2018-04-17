namespace OneNoteWiki
{
    using MimeKit;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class Main : Form
    {
        private List<string> m_pagesNames = new List<string>();
        private string m_sectionName;
        private string m_filenamePrefix;
        private Dictionary<string, string> m_imageNames = new Dictionary<string, string>();
        private List<HtmlPage> m_htmlPageList = new List<HtmlPage>();

        public Main()
        {
            InitializeComponent();
            TextBoxMhtmlFile.Text = Properties.Settings.Default.MhtmlFile;
            TextBoxExportDirectory.Text = Properties.Settings.Default.ExportDirectory;
            TextBoxRootName.Text = Properties.Settings.Default.RootName;
            TextBoxNotebookName.Text = Properties.Settings.Default.NotebookName;
            TextBoxDivider.Text = Properties.Settings.Default.Divider;
            if (TextBoxExportDirectory.Text.Length == 0)
            {
                TextBoxExportDirectory.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MhtmlFile = TextBoxMhtmlFile.Text;
            Properties.Settings.Default.ExportDirectory = TextBoxExportDirectory.Text;
            Properties.Settings.Default.RootName = TextBoxRootName.Text;
            Properties.Settings.Default.NotebookName = TextBoxNotebookName.Text;
            Properties.Settings.Default.Divider = TextBoxDivider.Text;
            Properties.Settings.Default.Save();
        }

        private void ButtonMhtmlBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (TextBoxMhtmlFile.Text.Length == 0)
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
            {
                openFileDialog.FileName = TextBoxMhtmlFile.Text;
            }
            openFileDialog.Filter = "mhtml files (*.mhtml;*.mht)|*.mhtml;*.mht|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
            {
                TextBoxMhtmlFile.Text = openFileDialog.FileName;
            }

        }

        private void ButtonExportBrowse_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = TextBoxExportDirectory.Text;

                if (folderDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    TextBoxExportDirectory.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            m_pagesNames.Clear();
            m_imageNames.Clear();
            m_htmlPageList.Clear();
            FileInfo sectionFileInfo = new FileInfo(this.TextBoxMhtmlFile.Text);
            m_sectionName = Path.GetFileNameWithoutExtension(sectionFileInfo.Name);
            m_filenamePrefix = TextBoxRootName.Text + TextBoxDivider.Text + TextBoxNotebookName.Text + TextBoxDivider.Text + m_sectionName + TextBoxDivider.Text;
            MimeMessage message = MimeKit.MimeMessage.Load(this.TextBoxMhtmlFile.Text);
            foreach (MimeEntity bodyPart in message.BodyParts)
            {
                if (bodyPart is MessagePart)
                {
                    if (bodyPart.ContentDisposition != null)
                    {
                        this.TextBoxLog.AppendText(String.Format("bodyPart.ContentDisposition.FileName = {0}\n", bodyPart.ContentDisposition.FileName));
                    }
                    else if (bodyPart.ContentType.Name != null)
                    {
                        this.TextBoxLog.AppendText(String.Format("attachment.ContentType.Name = {0}\n", bodyPart.ContentType.Name));
                    }
                    else
                    {
                        this.TextBoxLog.AppendText(String.Format("neither ContentDisposition.FileName nor ContentType.Name\n"));
                    }
                }
                else
                {
                    MimePart part = (MimePart)bodyPart;
                    FileInfo info = new FileInfo(part.ContentLocation.AbsolutePath);
                    this.TextBoxLog.AppendText(String.Format("part ContentType : {0}\n", part.ContentType));
                    this.TextBoxLog.AppendText(String.Format("part ContentTransferEncoding : {0}\n", part.ContentTransferEncoding));
                    if (part.ContentType.MediaType.ToLower() == "text")
                    {
                        if (part.ContentType.MediaSubtype.ToLower() == "html")
                        {
                            // Found html content, read it into a string
                            string htmlString = "";
                            using (MemoryStream stream = new MemoryStream())
                            {
                                part.Content.DecodeTo(stream);
                                stream.Position = 0;
                                htmlString = System.Text.Encoding.UTF8.GetString(stream.ToArray());
                            }

                            // Convert string containing html into an html node tree
                            HtmlNode htmlTree = ParseHtmlString(htmlString);

                            // Parse the html tree and pick out the pages
                            CreateHtmlPageList(htmlTree);

                            CleanupHtmlPages();
                            ExportHtmlPages();
                        }
                    }
                    else if (part.ContentType.MediaType.ToLower() == "image")
                    {
                        string fname = info.Name;
                        if (m_imageNames.Keys.Contains(fname))
                        {
                            fname = m_imageNames[fname];
                            string filename = Path.Combine(this.TextBoxExportDirectory.Text, fname);
                            this.TextBoxLog.AppendText(String.Format("part FileName : {0}\n", filename));
                            new FileInfo(filename).Directory.Create();
                            using (var stream = File.Create(filename))
                            {
                                part.Content.DecodeTo(stream);
                            }
                        }
                    }
                }
            }
        }

        private void ExportPage(HtmlNode pageNode, string pageName, string filename)
        {
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine("<!DOCTYPE html>");
            htmlBuilder.AppendLine("<html>");
            htmlBuilder.AppendLine(" <head>");
            htmlBuilder.AppendLine("  <meta charset=\"UTF-8\">");
            htmlBuilder.AppendLine(String.Format("  <title>{0}</title>", pageName));
            htmlBuilder.AppendLine(" </head>");
            htmlBuilder.AppendLine(" <body>");
            htmlBuilder.AppendLine("  <p>");
            htmlBuilder.AppendLine("   <a href=\"Main_Page\">Main Page</a>");
            htmlBuilder.AppendLine("  </p>");
            if (pageNode != null)
            {
                AddToHtmlBuilder(pageNode, htmlBuilder, 2);
            }
            htmlBuilder.AppendLine(" </body>");
            htmlBuilder.AppendLine("</html>");
            string filepath = Path.Combine(this.TextBoxExportDirectory.Text, filename);
            new FileInfo(filepath).Directory.Create();
            using (FileStream stream = File.Create(filepath))
            {
                byte[] fileContents = new UTF8Encoding(true).GetBytes(htmlBuilder.ToString());
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }

        private void ExportHtmlPages()
        {
            StringBuilder contentsPageBuilder = new StringBuilder();
            contentsPageBuilder.AppendLine("<!DOCTYPE html>");
            contentsPageBuilder.AppendLine("<html>");
            contentsPageBuilder.AppendLine(" <head>");
            contentsPageBuilder.AppendLine("  <meta charset=\"UTF-8\">");
            contentsPageBuilder.AppendLine(String.Format("  <title>{0}</title>", m_sectionName));
            contentsPageBuilder.AppendLine(" </head>");
            contentsPageBuilder.AppendLine(" <body>");
            contentsPageBuilder.AppendLine("  <p>");
            contentsPageBuilder.AppendLine("   <a href=\"Main_Page\">Main Page</a>");
            contentsPageBuilder.AppendLine("  </p>");
            contentsPageBuilder.AppendLine("  <p>");
            contentsPageBuilder.AppendLine(String.Format("   Contents of {0}", m_sectionName));
            contentsPageBuilder.AppendLine("  </p>");
            contentsPageBuilder.AppendLine("  <p>");
            contentsPageBuilder.AppendLine("   <ul>");

            foreach (HtmlPage page in m_htmlPageList)
            {
                string pageFilenamePrefix = m_filenamePrefix + page.PageFilename;
                string pageFilename = pageFilenamePrefix + ".html";
                ExportPage(page.PageContent, page.PageName, pageFilename);

                contentsPageBuilder.AppendLine("    <li>");
                contentsPageBuilder.AppendLine(String.Format("     <a href=\"{0}\">{1}</a>", pageFilename, page.PageName));

                if (page.SubPages.Count > 0)
                {
                    contentsPageBuilder.AppendLine("    <ul>");
                    foreach (HtmlPage subPage in page.SubPages)
                    {
                        string subPageFilename = pageFilenamePrefix + TextBoxDivider.Text + subPage.PageFilename + ".html";
                        ExportPage(subPage.PageContent, subPage.PageName, subPageFilename);
                        contentsPageBuilder.AppendLine("     <li>");
                        contentsPageBuilder.AppendLine(String.Format("      <a href=\"{0}\">{1}</a>", subPageFilename, subPage.PageName));
                        contentsPageBuilder.AppendLine("     </li>");
                    }
                    contentsPageBuilder.AppendLine("    </ul>");
                }
                contentsPageBuilder.AppendLine("    </li>");
            }

            contentsPageBuilder.AppendLine("   </ul>");
            contentsPageBuilder.AppendLine("  </p>");
            contentsPageBuilder.AppendLine(" </body>");
            contentsPageBuilder.AppendLine("</html>");
            string sectionFilename = TextBoxRootName.Text + TextBoxDivider.Text + TextBoxNotebookName.Text + TextBoxDivider.Text + m_sectionName + ".html";
            string filepath = Path.Combine(this.TextBoxExportDirectory.Text, sectionFilename);
            new FileInfo(filepath).Directory.Create();
            using (FileStream stream = File.Create(filepath))
            {
                byte[] fileContents = new UTF8Encoding(true).GetBytes(contentsPageBuilder.ToString());
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }

        private void CleanupHtmlPage(HtmlNode node)
        {
            foreach (HtmlNode nd in node.Children)
            {
                if (nd.Tag != null)
                {
                    if (nd.Tag == "p")
                    {
                        if (nd.Attributes != null)
                        {
                            if (nd.Attributes.Contains("'margin:0in;font-family:Calibri;font-size:16.0pt;color:#1E4E79'"))
                            {
                                nd.Tag = "h1";
                                nd.Attributes = null;
                            }
                            else if (nd.Attributes.Contains("'margin:0in;font-family:Calibri;font-size:14.0pt;color:#2E75B5'"))
                            {
                                nd.Tag = "h2";
                                nd.Attributes = null;
                            }
                            else if (nd.Attributes.Contains("'margin:0in;font-family:Calibri;font-size:12.0pt;color:#5B9BD5'"))
                            {
                                if (nd.Children.Count > 0 && nd.Children[0].Tag != null && nd.Children[0].Attributes != null && nd.Children[0].Tag == "span" && nd.Children[0].Attributes.Contains("'font-style:italic'"))
                                {
                                    nd.Tag = "h4";
                                    nd.Attributes = null;
                                    nd.Children.AddRange(nd.Children[0].Children);
                                    nd.Children.RemoveAt(0);
                                    foreach (HtmlNode e in nd.Children)
                                    {
                                        e.Parent = nd;
                                    }
                                }
                                else
                                {
                                    nd.Tag = "h3";
                                    nd.Attributes = null;
                                }
                            }
                            else if (nd.Attributes.Contains("'margin:0in;font-family:Calibri;font-size:11.0pt;color:#2E75B5'"))
                            {
                                if (nd.Children.Count > 0 && nd.Children[0].Tag != null && nd.Children[0].Attributes != null && nd.Children[0].Tag == "span" && nd.Children[0].Attributes.Contains("'font-style:italic'"))
                                {
                                    nd.Tag = "h6";
                                    nd.Attributes = null;
                                    nd.Children.AddRange(nd.Children[0].Children);
                                    nd.Children.RemoveAt(0);
                                    foreach (HtmlNode e in nd.Children)
                                    {
                                        e.Parent = nd;
                                    }
                                }
                                else
                                {
                                    nd.Tag = "h5";
                                    nd.Attributes = null;
                                }
                            }
                            else if (nd.Attributes.Contains("'margin:0in;font-family:Calibri;font-size:9.0pt;color:#595959'"))
                            {
                                nd.Tag = "cite";
                                nd.Attributes = null;
                            }
                            else if (nd.Attributes.Contains("'margin:0in;font-family:Calibri;font-size:11.0pt;color:#595959'"))
                            {
                                if (nd.Children.Count > 0 && nd.Children[0].Tag != null && nd.Children[0].Attributes != null && nd.Children[0].Tag == "span" && nd.Children[0].Attributes.Contains("'font-style:italic'"))
                                {
                                    nd.Tag = "q";
                                    nd.Attributes = null;
                                    nd.Children.AddRange(nd.Children[0].Children);
                                    nd.Children.RemoveAt(0);
                                    foreach (HtmlNode e in nd.Children)
                                    {
                                        e.Parent = nd;
                                    }
                                }
                            }
                            else if (nd.Attributes.Contains("'margin:0in;font-family:Consolas;font-size:11.0pt'"))
                            {
                                nd.Tag = "code";
                                nd.Attributes = null;
                            }
                        }
                    } // if (nd.Tag == "p")
                    else if (nd.Tag == "img")
                    {
                        if (nd.Attributes != null)
                        {
                            string[] partsArray = Regex.Split(nd.Attributes, "(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                            List<string> parts = new List<string>(partsArray);
                            // Remove empty attributes
                            for (int i = 0; i < parts.Count; i++)
                            {
                                while (i < parts.Count && parts[i].Length == 0)
                                {
                                    parts.RemoveAt(i);
                                }
                            }
                            for (int i = 0; i < parts.Count; i++)
                            {
                                if (parts[i].StartsWith("src="))
                                {
                                    int firstQuote = parts[i].IndexOf('"');
                                    if (firstQuote > 1)
                                    {
                                        int lastQuote = parts[i].IndexOf('"', firstQuote + 1);
                                        string imageFile = parts[i].Substring(firstQuote + 1, lastQuote - firstQuote - 1);
                                        FileInfo info = new FileInfo(imageFile);
                                        string originalFilename = info.Name;
                                        string newName = m_filenamePrefix + originalFilename;
                                        m_imageNames[originalFilename] = newName;
                                        parts[i] = String.Format("src=\"{0}\"", newName);
                                    }
                                    break;
                                }
                            }
                            nd.Attributes = String.Join(" ", parts);
                        }
                    } // if (nd.Tag == "img")
                    CleanupHtmlPage(nd);
                }
            }
        }

        private void CleanupHtmlPages()
        {
            foreach (HtmlPage page in m_htmlPageList)
            {
                if (page.PageContent != null)
                {
                    CleanupHtmlPage(page.PageContent);
                }
                foreach (HtmlPage subPage in page.SubPages)
                {
                    if (subPage.PageContent != null)
                    {
                        CleanupHtmlPage(subPage.PageContent);
                    }
                }
            }
        }

        private void CreateHtmlPageList(HtmlNode tree)
        {
            m_htmlPageList.Clear();
            if (tree.Children.Count > 1 && tree.Children[1].Tag != null && tree.Children[1].Tag == "body")
            {
                HtmlNode body = tree.Children[1];
                int nbspParagraphCount = 0;
                foreach (HtmlNode nd in body.Children)
                {
                    if (nd.Tag != null)
                    {
                        if (nd.Tag == "p")
                        {
                            if (nd.Children.Count > 0 && nd.Children[0].Content != null && nd.Children[0].Content == "&nbsp;")
                            {
                                nbspParagraphCount++;
                            }
                        }
                        else if (nd.Tag == "div")
                        {
                            if (nd.Children.Count > 0 && nd.Children[0].Tag != null && nd.Children[0].Tag == "div")
                            {
                                HtmlNode div1 = nd.Children[0];
                                if (div1.Children.Count > 0 && div1.Children[0].Tag != null && div1.Children[0].Tag == "div")
                                {
                                    HtmlNode div2 = div1.Children[0];
                                    if (div2.Children.Count > 0 && div2.Children[0].Tag != null && div2.Children[0].Tag == "p")
                                    {
                                        HtmlNode p = div2.Children[0];
                                        if (p.Children.Count > 0 && p.Children[0].Content != null)
                                        {
                                            // Get page name, removing any new lines
                                            string pageName = p.Children[0].Content.Replace(System.Environment.NewLine, " ");
                                            // Remove multiple spaces
                                            string newPageName = pageName.Trim().Replace("  ", " ");
                                            while (newPageName != pageName)
                                            {
                                                pageName = newPageName;
                                                newPageName = pageName.Replace("  ", " ");
                                            }
                                            // Make sure page name is not '&nbsp;'
                                            if (pageName == "&nbsp;")
                                            {
                                                pageName = "";
                                            }
                                            // Make sure page name is not empty
                                            if (pageName.Length == 0)
                                            {
                                                pageName = "PageWithNoName";
                                            }
                                            // Get filename
                                            string pageFilename = CleanupFilename(pageName, '_');
                                            // Make sure filename is not already used
                                            if (m_pagesNames.Contains(pageFilename))
                                            {
                                                string newPageFilename;
                                                int i = 1;
                                                do
                                                {
                                                    newPageFilename = String.Format("{0} ({1})", pageFilename, i);
                                                    newPageName = String.Format("{0} ({1})", pageName, i);
                                                    i++;
                                                } while (m_pagesNames.Contains(newPageFilename));
                                                pageFilename = newPageFilename;
                                                pageName = newPageName;
                                            }
                                            m_pagesNames.Add(pageFilename);
                                            HtmlPage newPage = new HtmlPage();
                                            newPage.PageName = pageName;
                                            newPage.PageFilename = pageFilename;
                                            if (div1.Children.Count > 2)
                                            {
                                                newPage.PageContent = div1.Children[2];
                                                newPage.PageContent.Tag = "page";
                                                newPage.PageContent.Attributes = null;
                                                if (div1.Children.Count > 3)
                                                {
                                                    for ( int i = 3; i < div1.Children.Count; i++)
                                                    {
                                                        newPage.PageContent.Children.AddRange(div1.Children[i].Children);
                                                    }
                                                }
                                            }
                                            if (nbspParagraphCount < 3 && m_htmlPageList.Count > 0)
                                            {
                                                m_htmlPageList.Last().SubPages.Add(newPage);
                                            }
                                            else
                                            {
                                                m_htmlPageList.Add(newPage);
                                            }
                                            nbspParagraphCount = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                this.TextBoxLog.AppendText("*** body node not found ***\n");
            }
        }

        private HtmlNode ParseHtmlString(string htmlString)
        {
            HtmlNode htmlTree = new HtmlNode();
            HtmlNode currentNode = htmlTree;

            int lastBracket = -1;
            int firstBracket = htmlString.IndexOf('<', 0);
            while (currentNode != null && firstBracket >= 0)
            {
                if (lastBracket > 0)
                {
                    int contentLength = firstBracket - lastBracket - 1;
                    if (contentLength > 0)
                    {
                        string content = htmlString.Substring(lastBracket + 1, contentLength).Trim();
                        if (content.Length > 0)
                        {
                            HtmlNode newNode = new HtmlNode();
                            newNode.Content = content;
                            newNode.Parent = currentNode;
                            currentNode.Children.Add(newNode);
                        }
                    }
                }
                lastBracket = htmlString.IndexOf('>', firstBracket);
                string withinBracket = htmlString.Substring(firstBracket + 1, lastBracket - firstBracket - 1).Trim();
                if (withinBracket[0] == '/')
                {
                    string tag = withinBracket.Substring(1).ToLower();
                    while (currentNode != null && tag != currentNode.Tag)
                    {
                        currentNode.Parent.Children.AddRange(currentNode.Children);
                        currentNode.Children.Clear();
                        currentNode = currentNode.Parent;
                    }
                    if (currentNode != null)
                    {
                        foreach (HtmlNode nd in currentNode.Children)
                        {
                            nd.Parent = currentNode;
                        }
                        currentNode = currentNode.Parent;
                    }
                }
                else
                {
                    HtmlNode newNode = new HtmlNode();
                    bool closedTag = withinBracket[withinBracket.Length - 1] == '/';
                    char[] chars = { ' ', '\r', '\n' };
                    int spaceLoc = withinBracket.IndexOfAny(chars);
                    if (spaceLoc < 0)
                    {
                        newNode.Tag = withinBracket.Substring(0, closedTag ? withinBracket.Length - 1 : withinBracket.Length).ToLower();
                    }
                    else
                    {
                        newNode.Tag = withinBracket.Substring(0, spaceLoc).ToLower();
                        newNode.Attributes = withinBracket.Substring(spaceLoc, closedTag ? withinBracket.Length - spaceLoc - 1 : withinBracket.Length - spaceLoc).Trim().Replace(System.Environment.NewLine, " ");
                    }
                    newNode.Parent = currentNode;
                    currentNode.Children.Add(newNode);
                    if (!closedTag)
                    {
                        currentNode = newNode;
                    }
                }
                firstBracket = htmlString.IndexOf('<', lastBracket);
            }
            if (htmlTree.Children.Count == 1)
            {
                return htmlTree.Children[0];
            }
            return htmlTree;
        }

        private void AddToHtmlBuilder(HtmlNode node, StringBuilder htmlBuilder, int indent)
        {
            if (node.Tag != null)
            {
                if (node.Tag == "page")
                {
                    foreach (HtmlNode nd in node.Children)
                    {
                        AddToHtmlBuilder(nd, htmlBuilder, indent);
                    }
                }
                else
                {
                    htmlBuilder.Append(new String(' ', indent));
                    htmlBuilder.Append('<');
                    htmlBuilder.Append(node.Tag);
                    if (node.Attributes != null)
                    {
                        htmlBuilder.Append(' ');
                        htmlBuilder.Append(node.Attributes);
                    }
                    if (node.Children.Count == 0)
                    {
                        htmlBuilder.Append('/');
                        htmlBuilder.Append('>');
                        htmlBuilder.AppendLine();
                    }
                    else
                    {
                        htmlBuilder.Append('>');
                        htmlBuilder.AppendLine();
                        foreach (HtmlNode nd in node.Children)
                        {
                            if (nd.Content != null)
                            {
                                htmlBuilder.Append(new String(' ', indent + 1));
                                htmlBuilder.Append(nd.Content);
                                htmlBuilder.AppendLine();
                            }
                            else
                            {
                                AddToHtmlBuilder(nd, htmlBuilder, indent + 1);
                            }
                        }
                        htmlBuilder.Append(new String(' ', indent));
                        htmlBuilder.Append('<');
                        htmlBuilder.Append('/');
                        htmlBuilder.Append(node.Tag);
                        htmlBuilder.Append('>');
                        htmlBuilder.AppendLine();
                    }
                }
            }
        }

        private string CleanupFilename(string filename, Char replacement)
        {
            string newFilename = filename;
            Char[] replaceChars = new Char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };
            foreach (char c in replaceChars)
            {
                newFilename = newFilename.Replace(c, replacement);
            }
            string[] replaceStrings = new string[] { "&gt;", "&lt;" };
            foreach (string s in replaceStrings)
            {
                newFilename = newFilename.Replace(s, replacement.ToString());
            }
            return newFilename;
        }
    }

    class HtmlNode
    {
        public HtmlNode()
        {
            Children = new List<HtmlNode>();
        }
        public string Tag { get; set; }
        public string Attributes { get; set; }
        public string Content { get; set; }
        public List<HtmlNode> Children { get; }
        public HtmlNode Parent { get; set; }
    }

    class HtmlPage
    {
        public HtmlPage()
        {
            SubPages = new List<HtmlPage>();
        }
        public string PageName { get; set; }
        public string PageFilename { get; set; }
        public HtmlNode PageContent { get; set; }
        public List<HtmlPage> SubPages { get; }
    }
}
