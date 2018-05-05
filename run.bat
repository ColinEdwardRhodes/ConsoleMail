bin\Debug\ConsoleMail.exe ^
-from donotreply@lollypop.org ^
-to alexc@lollypop.org ^
-host lpf-server1-new ^
-port 25 ^
-subject "Daily save rate" ^
-html C:\PetpointScripts\pictures\sample.html ^
-image -filePath C:\PetpointScripts\pictures\allRunningYearSaveRate.png -mimeType image/png -identifier allRunningYearSaveRate.png@lollypop.org ^
-image -filePath C:\PetpointScripts\pictures\dogsRunningYearSaveRate.png -mimeType image/png -identifier dogsRunningYearSaveRate.png@lollypop.org ^
-image -filePath C:\PetpointScripts\pictures\catsRunningYearSaveRate.png -mimeType image/png -identifier catsRunningYearSaveRate.png@lollypop.org ^
