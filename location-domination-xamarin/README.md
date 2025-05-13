# Location Domination mobile

# Build
Change URL in UserDataService. Put REST server IP, port and credentials.

## Firebase config
- register on Firebase site
- create project in Firebase
- on project site select Android icon an click. This creates Firebase-Android project.
- enter (from Visual Studio) from Android properties package name.
- after config is over download project json -> google-services.json and put this file under LoDo.Android.
- show google-services.json file properties and set build action to GoogleServicesJson

After this steps build app and send test messages from Firebase console
- In Firebase site choose Grow > Cloud messaging

   **Important**
   If exception is thrown on runtime in MainActivity.cs, in line with 
   ``` bash
   FirebaseMessaging.Instance.SubscribeToTopic("news")
   ```
   restart visual studio and project.
   

On sending test message phone will show notification with LoDo logo and with title and body text. Click on notification should open LoDo app.

## Google maps config

Add googleMaps credential key.
### Create key (if this is first one for google APIs)
https://docs.microsoft.com/hr-hr/xamarin/android/platform/maps-and-location/maps/obtaining-a-google-maps-api-key?tabs=windows#creating-an-api-project

### Add existing key (created for firebase)
Open same screens in Google API page,
- select existing Firebase project,
- open Credential Menu, select Firebase credential
- in xamarin project copy "api-key" > "current-key"  from google-service.json into AndroidManifest.xml fir "com.google.android.maps.v2.API_KEY"

Run app, app should show real map (not emtpy map in case of invalid key)






