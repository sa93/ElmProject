set elmTestFolder=.
wt -w 0 nt -d "%elmTestFolder%\API" --title APIs --suppressApplicationTitle --tabColor #00afbb cmd /k dotnet run --no-build
wt -w 0 nt -d "%elmTestFolder%\Ng" --title Ng --suppressApplicationTitle --tabColor #000000 cmd /k npm run watch