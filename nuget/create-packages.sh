#!/bin/bash

bash ../clean.sh

nuget restore ../

msbuild ../ImagePicker.sln /p:Configuration=Release /t:Clean \
  /t:"SDK\\Scanbot_ImagePicker_Droid" \
  /t:"SDK\\Scanbot_ImagePicker_iOS" \
  /t:"SDK_Forms\\Scanbot_ImagePicker_Forms" \
  /t:"SDK_Forms\\Scanbot_ImagePicker_Forms_Droid" \
  /t:"SDK_Forms\\Scanbot_ImagePicker_Forms_iOS"

NUGET_DIST_TARGET_DIR="dist"

mkdir -p $NUGET_DIST_TARGET_DIR

rm -rf $NUGET_DIST_TARGET_DIR/
nuget pack Scanbot.ImagePicker.nuspec -OutputDirectory $NUGET_DIST_TARGET_DIR
nuget pack Scanbot.ImagePicker.Forms.nuspec -OutputDirectory $NUGET_DIST_TARGET_DIR

echo "NuGet result packages:"
ls -lah $NUGET_DIST_TARGET_DIR/
