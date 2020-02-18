#!/bin/bash

# Sample usage:
# NO_MSBUILD_CLEAN=1 NO_NUGET_CLEAR=1 ./create-nuget-packages.sh

# if [ -z "$NO_MSBUILD_CLEAN" ]; then
#   for folder in ScanbotSDK.*
#   do
#     # manual clean, because the regular clean doesn't remove
#     # the intermediate project files created by 'nuget restore'
#     rm -rf $folder/obj $folder/bin
#   done
#   msbuild ../ScanbotSDK.Xamarin.sln /p:Configuration=Release /t:Clean
#   rm -rf ScanbotSDK.iOS/framework
# fi

# if [ -z "$NO_NUGET_CLEAR" ]; then
#   nuget locals all -clear
#   rm -rf packages
# fi
# nuget restore

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
