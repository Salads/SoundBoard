param (
    [string]$solutiondir,
    [string]$targetdir,
    [string]$configname
)

function ClearFolder()
{
    param (
        [string]$FolderPath,
        [string]$ExcludeFilter
    )

    $childItems = Get-ChildItem $FolderPath -Exclude $ExcludeFilter
    foreach($item in $childItems)
    {
        if($item -is [System.IO.DirectoryInfo])
        {
            $item.Delete($true)
        }
        else
        {
            $item.Delete()
        }
    }
}

# Trim whitespace from ends of args
$solutiondir = $solutiondir.Trim()
$targetdir = $targetdir.Trim()
$configname = $configname.Trim()

$release = $false
$portable = $false

if ($configname -eq "Release")
{
    $release = $true
}

if($configname -eq "Release Portable")
{
    $release = $true
    $portable = $true
}

if($release -eq $false)
{
    Write-Host "Debug build, no action taken."
    exit
}

$bindir = $solutiondir + "bin\"
$toriReleaseBaseName = "Tori"

# Make sure the solution bin folder is there
if(!(Test-Path -Path $bindir))
{
    New-Item -Path $bindir -ItemType "directory"
}

# Remove old files, then get new ones
if($portable -eq $true) # Portable Version (.zip)
{
    # Delete everything except the exe
    ClearFolder -FolderPath $bindir -ExcludeFilter ($toriReleaseBaseName + "*.exe")

    # Create a zip file of all relevant files
    $version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo(($targetdir + "Tori.exe")).FileVersion
    $zipName = "Tori Portable x86 v" + $version

    Compress-Archive -Path ($targetdir + "*.dll"), ($targetdir + "Tori.exe"), ($solutiondir + "LICENSE.md") -CompressionLevel Optimal -DestinationPath ($bindir + $zipName + ".zip")
    
}
else # Installer version (.exe)
{
    # Delete everything except the .zip
    ClearFolder -FolderPath $bindir -ExcludeFilter ($toriReleaseBaseName + "*.zip")

    $isccpath = "C:\Program Files (x86)\Inno Setup 5\ISCC.exe"
    $iscc_switches = "/Q"
    $iscc_outdir_switch = "/O" + '"' + $bindir + '"'
    $iscc_scriptpath = '"' + $solutiondir + "InstallerScript_x86.iss" + '"'

    $iscc_return = Start-Process -Wait -FilePath $isccpath -NoNewWindow -ArgumentList $iscc_switches, $iscc_outdir_switch, $iscc_scriptpath
    if($iscc_return -eq 0)
    {
        Write-Host "Installer compile successful."
    }
    elseif ($iscc_return -eq 1)
    {
        Write-Host "Parameters Invalid or Internal Error"
    }
    elseif($iscc_return -eq 2)
    {
        Write-Host "Installer compile failed."
    }
}

