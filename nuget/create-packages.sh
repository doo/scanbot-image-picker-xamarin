#!/bin/bash

bash ../clean.sh

dotnet restore ../

dotnet build ../SDK/Scanbot.ImagePicker.Droid --configuration Release
dotnet build ../SDK/Scanbot.ImagePicker.iOS --configuration Release
dotnet build ../SDK.Forms/Scanbot.ImagePicker.Forms --configuration Release

NUGET_DIST_TARGET_DIR="dist"

mkdir -p $NUGET_DIST_TARGET_DIR

rm -rf $NUGET_DIST_TARGET_DIR/
nuget pack Scanbot.ImagePicker.nuspec -OutputDirectory $NUGET_DIST_TARGET_DIR
nuget pack Scanbot.ImagePicker.Forms.nuspec -OutputDirectory $NUGET_DIST_TARGET_DIR

echo "NuGet result packages:"
ls -lah $NUGET_DIST_TARGET_DIR/
