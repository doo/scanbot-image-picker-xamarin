## Scanbot Image Picker for Xamarin Native & Forms

A tool to simplify and unify image picking from from the gallery. No more discrepencies between platforms, no more `OnActivityResult`, `resultCode`, `FinishedPickingMedia`. No messing with permissions, no launching controllers or starting activities – **Pick & Go**. 

### Usage

##### Droid

```cs
Bitmap bitmap = await Scanbot.ImagePicker.Droid.ImagePicker.Instance.Pick();
```

##### iOS

```cs
UIImage image = await Scanbot.ImagePicker.iOS.ImagePicker.Instance.Pick();
```

##### Forms





