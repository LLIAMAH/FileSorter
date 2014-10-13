FileSorter
==========

Welcome to the FileSorter!

This is the program which helps to filtrate and sort files, movies, books (actually the application has been developed for last ones)

How it works?
Steps

  In the Options you have to set the file filtration extensions which will be separate by special character (';' by default). Then you have to define aliases for folders - all these aliases will be shown in the context menu as "Move To" sub menu and allow you fast define destination for the file moving end point. Now you could use "Browse..." button to define disk or folder - all files (with extensions described in step 1) will be shown in the table. Using context menu you could assign operations on the each file in the visible list. Table contains:

    Check-box column, required for grouping;
    Current file name column
    Extension
    The list of operations which will applied to the item Context menu "Process" command - starts performing the operations.

Operations

    Open - just open file by the extension assigned application;
    Move To - moving file to the folder which described by alias;
    Add attachment - move file to the sub-folder (sub-folder name equals file name without description), the attached file moved too;
    Create group - creates sub-folder with predefined name and move all files (checked by check boxes) into it;
    Rename - rename file;
    Clear changes - clears all list of operations assigned on the file;
    Delete - deletes file;
    Process - starts operations perform;

