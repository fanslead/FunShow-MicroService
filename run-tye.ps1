<# Check development certificates #>

if (! (  Test-Path ".\etc\dev-cert\localhost.pfx" -PathType Leaf ) ){
   Write-Information "Creating dev certificates..."
   cd ".\etc\dev-cert"
   .\create-certificate.ps1
   cd..
   cd ..  
}

<# Run all services #>

tye run --watch