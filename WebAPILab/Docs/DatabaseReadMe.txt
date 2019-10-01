The following commands were run for migrations
----------------------------------------------
Enable-Migrations
Add-migration Initial
Update-Database

And to create an initial database script
----------------------------------------
Update-Database -Script -SourceMigration:0