Setup migrations
----------------
Enable-Migrations
Add-migration <migrationname>
Update-Database

And to create an initial database script
----------------------------------------
Update-Database -Script -SourceMigration:0

Make a new migration
--------------------
add-migration <migrationname>

List migrations
---------------
get-migrations

Delete bad migration
--------------------
Just delete the class file for the migration

Migrate class changes to database
---------------------------------
Update-Database

Rollback a migration (Run the Down method)
------------------------------------------
Update-Database -TargetMigration <migration to rollback to>