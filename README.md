# UserDefaults

Implementation of user defaults similar to Swift. Data are stored as key-value in a file in the application execution path.

## Usage

You can create your own user default, but there is a standard user default that you can use as the default.

You can store data (string, integer and boolean) by using the **Store** method:
```csharp
UserDefault.standard.Store(key: "MyKey", value: 100);

```

By using methods : **GetObject**, **GetString**, **GetInteger** and **GetBoolean** you will get your stored vales:
```csharp
bool value = UserDefault.standard.GetBoolean(key: "MyKey0");
int value = UserDefault.standard.GetInteger(key: "MyKey1");
string value = UserDefault.standard.GetString(key: "MyKey2");
object value = UserDefault.standard.GetObject(key: "MyKey3");

```

**Warning**: Be careful that the keys used are unique, otherwise the data will be replaced.

### Caution
```diff
- Data is stored as a file without any security.
```