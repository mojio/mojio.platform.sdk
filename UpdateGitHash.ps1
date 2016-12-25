
$content = [System.IO.File]::ReadAllText('src\Mojio.Platform.SDK\Entities\Environments\GitEnvironment.cs').split([Environment]::NewLine);
$newContent = "";
foreach ($line in $content) {
    $nl = $line;
    Write-Host $nl
   if($line.contains("GitHash")) {
        $nl = '     public string GitHash { get; } = "' + $args[0] + '";'
   }

   $newContent += $nl + [Environment]::NewLine;

 }

Write-Host $newContent

[System.IO.File]::WriteAllText('src\Mojio.Platform.SDK\Entities\Environments\GitEnvironment.cs', $newContent);