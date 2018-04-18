# OneNoteWiki

OneNoteWiki helps import OneNote content into a WikiMedia wiki.

## Introduction

The OneNoteWiki app reads a OneNote section export from an mht file, separates
each page into an html file and exports and reconciles images embeded in the pages.
These are added to a zip file and imported into WikiMedia using the Html2Wiki
Extension: https://www.mediawiki.org/wiki/Extension:Html2Wiki

## Usage

Export a section or a page from OneNote 2016 to an mht file.

In the OneNoteWiki application, select the exported mht file.

Select a location for the export from OneNoteWiki.

Select a root name applied to the imported page or pages in the wiki.
This name can include slashes '/' or other dividers, but must be valid
characters in a filename.

Include a wiki link. For a page to be importable, it must contain a link.
This is a Html2Wiki requirement. OneNoteWiki adds a link to the top of every page.

Include the name of a page that is to be ignored. All sub pages of that page
will also be ignored and will not be imported into the wiki. The first page
encountered by OneNoteWiki will always be imported, even if it has the ingore page name.
This can be left blank if no pages are to be ignored.

Select a divider. The slash '/' is recommended as it is used by MediaWiki to imply a hierarchy.

Press the wide 'Export' button to perform the export from OneNoteWiki.

The files will be found in the export directory.
For now, the exported files must manually be added to a zip file.

Got to the Html2Wiki import page on the wiki, eg. http://server/wiki/index.php/Special:Html2Wiki .
A link to this page can be found in the 'Special pages' section, eg. http://server/wiki/index.php/Special:SpecialPages .
Select the zip file and click on the 'Import' button. Only wiki administrators can do this.

### Examples

#### Section Import

If a root name of 'OneNote/NoteBook1' is used with a divider of '/'
and a section file named 'SectionB.mht' is imported,
the page 'Very Important Page' would find itself in the wiki
as 'OneNote/NoteBook1/SectionB/Very Important Page'.
The sub page to 'Very Important Page' called 'SubPage' would find
itself in the wiki as 'OneNote/NoteBook1/SectionB/Very Important Page/SubPage'.
The sub page to 'SubPage' named 'SubSubPage' would be placed at the same level as 'SubPage' and
find itself in the wiki as 'OneNote/NoteBook1/SectionB/Very Important Page/SubSubPage'.
A table of contents would find itself in 'OneNote/NoteBook1/SectionB'.

#### Page Import

If a root name of 'OneNote/Page' is used with a divider of '/' and a page named
'Very Important Page' is imported from a file named 'VeryImportantPage.mht',
the page would find itself in the wiki as 'OneNote/Page/Very Important Page'.
No table of contents would be generated.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
