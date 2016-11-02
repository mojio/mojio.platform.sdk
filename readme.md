# C# SDK for Mojio Platform version 2

### Current Build Status (master):
![Build Status](https://mojio.visualstudio.com/_apis/public/build/definitions/1b4733a9-5dad-47aa-b18a-f4a981d9f0a6/3/badge)

----

> Total: 95
>
> Completed: 72
> 
> **Percent Complted: 80%**


----

## [OAuth 2.0 - RFC](https://tools.ietf.org/html/rfc6749)

### **OAUTH**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
OAuth | Resource Owner Password Credentials Grant  |  POST  | [Link](https://tools.ietf.org/html/rfc6749#section-4.3)  |  COMPLETE 
OAuth | Authorization Code Grant  |  POST  | [Link](https://tools.ietf.org/html/rfc6749#section-4.1)  |  COMPLETE 
OAuth | Refresh Token |  POST  | [Link](https://tools.ietf.org/html/rfc6749#section-1.5)  |  COMPLETE 


----

## [API - Swagger](https://api.moj.io/swagger/ui/index#/)


### **APPS**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
Apps | Delete an existing application.  |  DELETE  | [Link]( https://api.moj.io/swagger/ui/index#!/Apps/CRUD_DeleteApp)  |  COMPLETE 
Apps | Gets an individual application's details. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Apps/CRUD_GetApp) |  COMPLETE 
Apps | Update an existing application. Currently only Name, Description, and RedirectUris are editable. | PUT | [Link](https://api.moj.io/swagger/ui/index#!/Apps/CRUD_PutApp) |  COMPLETE 
Apps | Get all apps accessible to the current user. This will include applications the user owns and has purchased. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Apps/CRUD_GetAllApps) |  COMPLETE 
Apps | Create a new application. The current user will be made an administrator of the application. | POST | [Link](https://api.moj.io/swagger/ui/index#!/Apps/CRUD_PostApp) |  COMPLETE 
Apps | Revoke application's secret key. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/Apps/CRUD_RevokeSecret) |  COMPLETE 
Apps | Gets an individual application's secret key. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Apps/CRUD_GetSecret) |  COMPLETE  | 


### **GEOFENCES**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
Geofences | Delete an existing geofence. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/Geofences/CRUD_DeleteGeofence) |  **NOT STARTED** 
Geofences | Gets an individual geofence's details. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Geofences/CRUD_GetGeofence) |  **NOT STARTED** 
Geofences | Update an existing geofence. Currently only Name, Description, and Enabled are editable. | PUT | [Link](https://api.moj.io/swagger/ui/index#!/Geofences/CRUD_PutGeofence) |  **NOT STARTED** 
Geofences | Get all geofences accessible to the current user. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Geofences/CRUD_GetAllGeofences) |  **NOT STARTED** 
Geofences | Create a new geofence | POST | [Link](https://api.moj.io/swagger/ui/index#!/Geofences/CRUD_PostGeofence) |  **NOT STARTED**  | 

### **GROUPS**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
Groups | Delete an existing group. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/Groups/CRUD_DeleteGroup) |  COMPLETE 
Groups | Gets an individual group's details. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Groups/CRUD_GetGroup) |  COMPLETE 
Groups | Update an existing group. | PUT | [Link](https://api.moj.io/swagger/ui/index#!/Groups/CRUD_PutGroup) |  COMPLETE 
Groups | Get all groups accessible to the current user. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Groups/CRUD_GetAllGroups) |  COMPLETE 
Groups | Create a new group. The current user will be made an administrator of the group. | POST | [Link](https://api.moj.io/swagger/ui/index#!/Groups/CRUD_PostGroup) |  COMPLETE 
Groups | Delete a user from a group. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/Groups/CRUD_DeleteGroupUsers) |  COMPLETE 
Groups | Get a group's users. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Groups/CRUD_GetGroupUsers) |  COMPLETE 
Groups | Update a group to include a collection of users. | POST | [Link](https://api.moj.io/swagger/ui/index#!/Groups/CRUD_PostGroupUsers) |  COMPLETE 
Groups | Update a group to include a user. | PUT | [Link](https://api.moj.io/swagger/ui/index#!/Groups/CRUD_PutGroupUsers) |  COMPLETE  | 

### **HISTORY**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
History | Get the history of a trip. | GET | [Link](https://api.moj.io/swagger/ui/index#!/History/CRUD_GetTripHistory) |  COMPLETE 
History | Get the history of a trip. | GET | [Link](https://api.moj.io/swagger/ui/index#!/History/CRUD_GetTripLocation) |  COMPLETE 
History | Get the history of a vehicle. | GET | [Link](https://api.moj.io/swagger/ui/index#!/History/CRUD_GetVehicleHistory) |  COMPLETE 
History | Get the past locations of a vehicle. | GET | [Link](https://api.moj.io/swagger/ui/index#!/History/CRUD_GetVehicleLocation) |  COMPLETE  | 


### **IMAGES**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
Images | Delete an app's image. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/Images/Image_DeleteAppImage) |  COMPLETE 
Images | Get an app's image. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Images/Image_GetAppImage) |  COMPLETE 
Images | Create an app's image. | POST | [Link](https://api.moj.io/swagger/ui/index#!/Images/Image_PostAppImage) |  COMPLETE 
Images | Update an app's image. | PUT | [Link](https://api.moj.io/swagger/ui/index#!/Images/Image_PutAppImage) |  COMPLETE 
Images | Delete an user's image. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/Images/Image_DeleteUserImage) |  COMPLETE 
Images | Get a user's image. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Images/Image_GetUserImage) |  COMPLETE 
Images | Create an user's image. | POST | [Link](https://api.moj.io/swagger/ui/index#!/Images/Image_PostUserImage) |  COMPLETE 
Images | Update an user's image. | PUT | [Link](https://api.moj.io/swagger/ui/index#!/Images/Image_PutUserImage) |  COMPLETE 
Images | Delete a vehicle's image. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/Images/Image_DeleteVehicleImage) |  COMPLETE 
Images | Get a vehicle's image. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Images/Image_GetVehicleImage) |  COMPLETE 
Images | Create a vehicle's image. | POST | [Link](https://api.moj.io/swagger/ui/index#!/Images/Image_PostVehicleImage) |  COMPLETE 
Images | Update a vehicle's image. | PUT | [Link](https://api.moj.io/swagger/ui/index#!/Images/Image_PutVehicleImage) |  COMPLETE  | 


### **MOJIOS**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
Mojios | Delete an existing mojio. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/Mojios/CRUD_DeleteMojio) |  COMPLETE 
Mojios | GET | Gets an individual mojio's details. | [Link](https://api.moj.io/swagger/ui/index#!/Mojios/CRUD_GetMojio) |  COMPLETE 
Mojios | PUT | Update an existing Mojio. Currently only Name is editable. | [Link](https://api.moj.io/swagger/ui/index#!/Mojios/CRUD_PutMojio) |  COMPLETE 
Mojios | GET | Get all mojios accessible to the current user. | [Link](https://api.moj.io/swagger/ui/index#!/Mojios/CRUD_GetAllMojios) |  COMPLETE 
Mojios | POST | Claim a mojio. The current user will claim the mojio and be granted owner access. If permissions are supplied it will be a partial claim and the supplied permissions will be granted to either the group or the current user. | [Link](https://api.moj.io/swagger/ui/index#!/Mojios/CRUD_PostMojio) |  COMPLETE  | 


### **PERMISSIONS**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
Permissions | Gets the access rules for a resource. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Permissions/Permissions_GetMyPermissions) |  **NOT STARTED** 
Permissions | Removes a group's access to a resource. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/Permissions/Permissions_DeleteAccess) |  **NOT STARTED** 
Permissions | Gets the access rules for a resource. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Permissions/Permissions_GetAccess) |  **NOT STARTED** 
Permissions | Add an access rule for a resource. Overwrites any existing access rules. | POST | [Link](https://api.moj.io/swagger/ui/index#!/Permissions/Permissions_PostAccess) |  **NOT STARTED** 
Permissions | Update or add an access rule for a resource. Combines the new rule with any existing access rules. | PUT | [Link](https://api.moj.io/swagger/ui/index#!/Permissions/Permissions_PutAccess) |  **NOT STARTED**  | 


### **TAGS**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
Tag | Remove a tag from a resource. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/Tag/Tag_DeleteTag) |  COMPLETE 
Tag | Add a new tag to an app. | POST | [Link](https://api.moj.io/swagger/ui/index#!/Tag/Tag_PostTag) |  COMPLETE  | 


### **TRIPS**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
Trips | Delete an existing trip. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/Trips/CRUD_DeleteTrip) |  COMPLETE 
Trips | Gets an individual trip's details. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Trips/CRUD_GetTrip) |  COMPLETE 
Trips | Update an existing trip. Currently only Name is editable. | PUT | [Link](https://api.moj.io/swagger/ui/index#!/Trips/CRUD_PutTrip) |  COMPLETE 
Trips | Get all trips accessible to the current user. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Trips/CRUD_GetAllTrips) |  COMPLETE  | 


### **USERS**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
Users | Get the current user's details. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Users/CRUD_GetMe) |  COMPLETE 
Users | Gets an individual user's details. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Users/CRUD_GetUser) |  **NOT STARTED** 
Users | Update an existing user. Currently only UserName, Email, First Name, Last Name and Phone Numbers are editable. Note: existing phone numbers will be replaced by the new list. | PUT | [Link](https://api.moj.io/swagger/ui/index#!/Users/CRUD_PutUser) |  **NOT STARTED** 
Users | Get all users accessible to the current user. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Users/CRUD_GetAllUsers) |  **NOT STARTED** 
Users | Get all vehicles that the user is the owner of. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Users/CRUD_GetUserVehicles) |  **NOT STARTED** 
Users | Get all mojios that the user is the owner of. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Users/CRUD_GetUserMojios) |  **NOT STARTED** 
Users | Get all mojios that the user is the owner of. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Users/CRUD_GetUserTrips) |  **NOT STARTED** 
Users | Get all groups that the user is the owner of. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Users/CRUD_GetUserGroupsA) |  **NOT STARTED**  | 


### **VEHICLES**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
Vehicles | Delete an existing vehicle. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/Vehicles/CRUD_DeleteVehicle) |  **NOT STARTED** 
Vehicles | Gets an individual vehicle's details. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Vehicles/CRUD_GetVehicle) |  **NOT STARTED** 
Vehicles | Update an existing vehicle. Currently only Name, License Plate, VIN, and Override Odometer are editable. | PUT | [Link](https://api.moj.io/swagger/ui/index#!/Vehicles/CRUD_PutVehicle) |  **NOT STARTED** 
Vehicles | Get all vehicles accessible to the current user. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Vehicles/CRUD_GetAllVehicles) |  COMPLETE 
Vehicles | Create a new vehicle. | POST | [Link](https://api.moj.io/swagger/ui/index#!/Vehicles/CRUD_PostVehicle) |  **NOT STARTED** 
Vehicles | Get the current address of a vehicle. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Vehicles/CRUD_GetVehicleAddress) |  **NOT STARTED** 
Vehicles | Get all trips accessible to the current user for this vehicle. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Vehicles/CRUD_GetVehicleTrips) |  COMPLETE 
Vehicles | Get the vin details about the vehicle. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Vehicles/CRUD_GetVehicleVinDetails) |  COMPLETE 
Vehicles | Get the service schedule for the vehicle. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Vehicles/CRUD_GetVehicleServiceSchedule) |  **NOT STARTED** 
Vehicles | Get the next service schedule for the vehicle. | GET | [Link](https://api.moj.io/swagger/ui/index#!/Vehicles/CRUD_GetVehicleNextServiceSchedule) |  COMPLETE  | 


### **ActivityStreams**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
ActivityStreams  | Get an entities activity stream. | DELETE | [Link](https://api.moj.io/swagger/ui/index#!/ActivityStreams/ActivityStreams_GetResourceActivities) |  COMPLETE


----

## [PUSH - Swagger](https://push.moj.io/swagger/ui/index#/)


### **PUSH - MOJIOS**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
PUSH - MOJIOS | Gets an individual mojio oberver's details. | GET | [Link](https://push.moj.io/swagger/ui/index#!/Mojios/Observer_GetMojioObservers) |  COMPLETE  | 
PUSH - MOJIOS | Create a new observer. The current user will be made an administrator of the observer. | POST | [Link](https://push.moj.io/swagger/ui/index#!/Mojios/Observer_PostMojioObserver) |  COMPLETE  | 
PUSH - MOJIOS | Gets an individual mojio oberver's details. | GET | [Link](https://push.moj.io/swagger/ui/index#!/Mojios/Observer_GetMojioObserver) |  COMPLETE  | 
PUSH - MOJIOS | Update an existing observer. | PUT | [Link](https://push.moj.io/swagger/ui/index#!/Mojios/Observer_PutMojioObserver) |  COMPLETE  | 
PUSH - MOJIOS | Get all mojio observers accessible to the current user. | GET | [Link](https://push.moj.io/swagger/ui/index#!/Mojios/Observer_GetAllMojioObservers) |  COMPLETE  | 
PUSH - MOJIOS | Create a new observer. The current user will be made an administrator of the observer. | POST | [Link](https://push.moj.io/swagger/ui/index#!/Mojios/Observer_PostGroupMojioObserver) |  COMPLETE  | 
PUSH - MOJIOS | Create a new observer. The current user will be made an administrator of the observer. | PUT | [Link](https://push.moj.io/swagger/ui/index#!/Mojios/Observer_PutGroupMojioObserver) |  COMPLETE  | 


### **PUSH - USERS**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
PUSH - USERS | Gets an individual user oberver's details. | GET | [Link](https://push.moj.io/swagger/ui/index#!/Users/Observer_GetUserObservers) |  COMPLETE  | 
PUSH - USERS | Create a new observer. The current user will be made an administrator of the observer. | POST | [Link](https://push.moj.io/swagger/ui/index#!/Users/Observer_PostUserObserver) |  COMPLETE  | 
PUSH - USERS | Gets an individual user oberver's details. | GET | [Link](https://push.moj.io/swagger/ui/index#!/Users/Observer_GetUserObserver) |  COMPLETE  | 
PUSH - USERS | Update an existing observer. | PUT | [Link](https://push.moj.io/swagger/ui/index#!/Users/Observer_PutUserObserver) |  COMPLETE  | 
PUSH - USERS | Get all user observers accessible to the current user. | GET | [Link](https://push.moj.io/swagger/ui/index#!/Users/Observer_GetAllUserObservers) |  COMPLETE  | 
PUSH - USERS | Create a new observer. The current user will be made an administrator of the observer. | POST | [Link](https://push.moj.io/swagger/ui/index#!/Users/Observer_PostGroupUserObserver) |  COMPLETE  | 
PUSH - USERS | Create a new observer. The current user will be made an administrator of the observer. | PUT | [Link](https://push.moj.io/swagger/ui/index#!/Users/Observer_PutGroupUserObserver) |  COMPLETE  | 


### **PUSH - VEHICLES**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
PUSH - VEHICLES | Gets an individual vehicle oberver's details. | GET | [Link](https://push.moj.io/swagger/ui/index#!/Vehicles/Observer_GetVehicleObservers) |  COMPLETE  | 
PUSH - VEHICLES | Create a new observer. The current user will be made an administrator of the observer. | POST | [Link](https://push.moj.io/swagger/ui/index#!/Vehicles/Observer_PostVehicleObserver) |  COMPLETE  | 
PUSH - VEHICLES | Gets an individual vehicle oberver's details. | GET | [Link](https://push.moj.io/swagger/ui/index#!/Vehicles/Observer_GetVehicleObserver) |  COMPLETE  | 
PUSH - VEHICLES | Update an existing observer. | PUT | [Link](https://push.moj.io/swagger/ui/index#!/Vehicles/Observer_PutVehicleObserver) |  COMPLETE  | 
PUSH - VEHICLES | Get all vehicle observers accessible to the current user. | GET | [Link](https://push.moj.io/swagger/ui/index#!/Vehicles/Observer_GetAllVehicleObservers) |  COMPLETE  | 
PUSH - VEHICLES | Create a new observer. The current user will be made an administrator of the observer. | POST | [Link](https://push.moj.io/swagger/ui/index#!/Vehicles/Observer_PostGroupVehicleObserver) |  COMPLETE  | 
PUSH - VEHICLES | Create a new observer. The current user will be made an administrator of the observer. | PUT | [Link](https://push.moj.io/swagger/ui/index#!/Vehicles/Observer_PutGroupVehicleObserver) |  COMPLETE  | 


### **PUSH - WEBSOCKETS**

 Group  |  Purpose  |  VERB  |  Action  |  STATUS 
------- | --------- | -------- | -------- | --------
PUSH - VEHICLES | Establish a websocket connection for all vehicles or a single vehicle. |  |  |  COMPLETE  | 
PUSH - MOJIOS | Establish a websocket connection for all mojios or a single mojio. |  | |  COMPLETE  | 
PUSH - USERS | Establish a websocket connection for all users or a single user. |  | |  **NOT STARTED**  | 
PUSH - ACTIVITIES | Establish a websocket connection for all activities. |  | |  COMPLETE  | 

