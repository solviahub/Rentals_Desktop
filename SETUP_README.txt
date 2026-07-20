HOW TO SET THIS UP
===================

1. Open RMS.sln in Visual Studio 2012.

2. Create the database file:
   - In Solution Explorer, right-click the RMS project > Add > New Item
   - Choose "SQL Server Database", name it RMS.mdf
   - This creates RMS.mdf (and RMS_log.ldf) inside your project folder.

3. Build the tables:
   - In Server Explorer, find RMS.mdf > right-click > New Query
   - Open RMS_Database.sql (in this same folder) and paste/run its contents
     against that database. This creates all the tables and a default
     login (username: soluiahub, password: 1234).

4. Move the database to C:\RMS:
   - Close Visual Studio (or detach the database from Server Explorer first).
   - Create a folder C:\RMS
   - Copy RMS.mdf and RMS_log.ldf into C:\RMS

5. Connection string:
   - Open RMS/Database.cs
   - It already points to: C:\RMS\RMS.mdf
   - If you put the file somewhere else, just change that path.

6. Run the app (F5). Login with soluiahub / 1234.

NOTES
-----
- All the CRUD code uses plain ADO.NET (SqlConnection/SqlCommand),
  string-concatenated SQL, and simple Open()/Close() calls - no
  try/catch, no parameters, exactly as requested.
- Editing a record currently means: select the row in the list, click
  Edit, and the Add form opens blank - retype the identifying field
  (Roll No / Tax ID / etc.) and the values you want to change, then
  click Save (or Edit, where that button exists). Auto-filling the
  form from the selected row was left out to keep things simple.
- Heads up: because the SQL is built with string concatenation instead
  of parameters, someone typing a quote character or SQL keywords into
  a text box could break or manipulate a query (SQL injection). Fine
  for a private, single-user desktop app on your own PC - just don't
  expose this pattern on anything network-facing without switching to
  parameterized queries.
