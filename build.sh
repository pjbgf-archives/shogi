#!/usr/bin/env bash 

dotnet restore -v d --packages ./packages && dotnet build
