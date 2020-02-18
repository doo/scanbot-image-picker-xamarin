## Scanbot Image Picker for Xamarin Native & Forms

A tool to simplify and unify image picking from from the gallery. No more discrepencies between platforms, no more `OnActivityResult`,  `resultCode`,  `FinishedPickingMedia`. No messing with permissions, no launching controllers or starting activities – **Pick & Go**. 

### Usage

#### Droid

```cs
Bitmap bitmap = await Scanbot.ImagePicker.Droid.ImagePicker.Instance.Pick();
```

#### iOS

```cs
UIImage image = await Scanbot.ImagePicker.iOS.ImagePicker.Instance.Pick();
```

#### Forms

```c#
ImageSource source = await Scanbot.ImagePicker.Forms.ImagePicker.Instance.Pick();
```

**Quirk**: Depending on your target framework and Xamarin.Forms version, this may throw a `NullReferenceException`. That means native dependcendies weren't properly referenced. In that case, add the following to your `AppDelegate` and `MainActivity`:

```c#
DependencyManager.Register();
```

### Roadmap

* Format filter: **.jpg**, **.png**, **.pdf** etc.
* Different sources: **camera**, **external storage directory**, **custom path** etc.
* Various configuration options such as **min/max size**, **aspect ratio** etc.
* Improved errorhandling (not just returning `null` when something goes wrong, heh)

### Contributing

Contributions in the form of **issues**, **pull requests** and **suggestions** are very welcome. 

### Disclaimer

This package is still in beta and should be used with that in mind. It is volatile. It has not been thorougly tested, all use cases are definitely not covered, breaking changes will happen without much notice.

