## Scanbot Image Picker for Xamarin Native & Forms

A tool to simplify and unify image picking from from the gallery. No more discrepancies between platforms, no more `OnActivityResult`,  `resultCode`,  `FinishedPickingMedia`. No messing with permissions, no launching controllers or starting activities – **Pick & Go**. 

Available as nuget packages for [Xamarin](https://www.nuget.org/packages/Scanbot.Xamarin.ImagePicker/) and [Xamarin.Forms](https://www.nuget.org/packages/Scanbot.Xamarin.Forms.ImagePicker/)

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

**Quirk**: Depending on your target framework and Xamarin.Forms version, this may throw a `NullReferenceException`. That means native dependcendies weren't properly referenced. In that case, add the following to your `AppDelegate` and `MainActivity`, respectively:

```c#
Scanbot.ImagePicker.Forms.Droid.DependencyManager.Register();
```

```C#
Scanbot.ImagePicker.Forms.iOS.DependencyManager.Register();
```

### Contributing

Contributions in the form of **issues**, **pull requests** and **suggestions** are very welcome. 

### Disclaimer

This package is still in beta and should be used with that in mind. It is volatile. It has not been thorougly tested, all use cases are definitely not covered, breaking changes will happen without much notice.

### License

[MIT](LICENSE.md)

