SETLOCAL EnableDelayedExpansion
SETLOCAL EnableExtensions

SET config_name=%~1
SET target_dir=%~2
SET solution_dir=%~3
SET iscc_path="C:\Program Files (x86)\Inno Setup 5\ISCC.exe"

SET release=0
SET portable=0

IF "!config_name!" == "Release" (
	SET release=1
)

IF "!config_name!" == "Release Portable" (
	SET release=1
	SET portable=1
)

SET return_exe=0
SET return_dll=0
SET return_license=0

IF !release! EQU 1 (

	:: Delete and recreate build directory
	RMDIR /s /q "!target_dir!build\"
	MKDIR "!target_dir!build\"

	ROBOCOPY "!target_dir! " "!target_dir!build\ " *.exe /njh /njs /ndl /np
	SET return_exe=!ERRORLEVEL!
	ROBOCOPY "!target_dir! " "!target_dir!build\ " *.dll /njh /njs /ndl /np
	SET return_dll=!ERRORLEVEL!
	ROBOCOPY "!target_dir! " "!target_dir!build\ " LICENSE.md /njh /njs /ndl /np
	SET return_license=!ERRORLEVEL!
	
	:: If not portable, try copying msi files
	IF !portable! EQU 0 (
		!iscc_path! /Q "!solution_dir!InstallerScript_x86.iss"
		IF !ERRORLEVEL! EQU 0 (
			echo.
			echo Created installer.
		)
	)

	IF !return_license! EQU 0 echo Copied License.
)

IF !release! EQU 0 (
	echo Debug Build: Skipping Post-Build Event.
	goto :eof
) 

IF !return_exe! EQU 1 (
	IF !return_dll! EQU 1 (
		EXIT /B 0
	)
)